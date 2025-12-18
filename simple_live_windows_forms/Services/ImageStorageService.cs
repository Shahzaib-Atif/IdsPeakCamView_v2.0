using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using ImageProcessingLibrary.Services.Database;
using simple_ids_cam_view.Presenters;
using simple_ids_cam_view.UI.Controls;
using simple_ids_cam_view.UI.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace simple_ids_cam_view.Services
{
    internal class ImageStorageService
    {
        private readonly SimplePictureBox customPictureBox;
        private readonly GroupBox GbxShowLoading;
        private readonly Label LabelConnectorName;
        private readonly ImageProcessorService _imageProcessor;
        private readonly FileService _fileService;
        private readonly PromptService _promptService;
        private readonly FeatureRepository _featureRepo;
        private readonly AccessoryRepository _accessoryRepo;
        private readonly ReferenciasRepository _referenciasRepo;


        public ImageStorageService(SimplePictureBox customPictureBox, GroupBox gbxShowLoading, Label labelConnectorName)
        {
            // initialize UI components references
            this.customPictureBox = customPictureBox;
            this.GbxShowLoading = gbxShowLoading;
            this.LabelConnectorName = labelConnectorName;

            // initialize services
            _imageProcessor = new ImageProcessorService();
            _fileService = new FileService();
            _promptService = new PromptService();
            _featureRepo = new FeatureRepository();
            _accessoryRepo = new AccessoryRepository();
            _referenciasRepo = new ReferenciasRepository();
        }

        /// <summary> store connector in local folder and database </summary>
        public async Task<bool> SaveConnectorToDB()
        {
            // check image availability and default folder
            PerformInitalChecks();

            // Get connector details
            var newSample = GetConnectorDetails();
            string connectorName = newSample?.BasicDetails.Codivmac;

            if (string.IsNullOrEmpty(connectorName)) return false;

            // show loading status
            this.GbxShowLoading.Visible = true;

            // Generate file path using connector name.
            string filePath = GetDefaultConnectorPath(connectorName);

            // Save image in local folder and database
            if (!await SaveImage(filePath, newSample)) return false;

            // Overwrite original image in local folder with the processed image containing text.
            await Task.Run(() =>
            {
                Image _image = customPictureBox.GetProcessedImage();
                _imageProcessor.SaveCompressedImage(_image, filePath);
            });

            // hide the loading status
            this.GbxShowLoading.Visible = false;

            // ask user if he wants to open the image
            _promptService.PromptUserForOpeningImage(filePath);

            // update Label which shows ConnectorName
            LabelConnectorName.Text = connectorName;

            // if everything went well then save connector name
            ProjectSettings.SetConnectorName(connectorName);

            return true;
        }


        /// <summary> store accessory image to local folder and database </summary>
        public async Task SaveAccessoryToDB()
        {
            if (!IsImageAvailable()) return; // Exit if Image is NOT available.

            var accessoryDetails = GetAccessoryDetails();
            if (accessoryDetails is null) return;

            // check if \_Accessories folder path is correct 
            string accessoriesFolderPath = ProjectSettings.DefaultFolder + @"\_Accessories";
            if (!Directory.Exists(accessoriesFolderPath))
                throw new Exception("_Accessories folder not found!");

            // show loading status
            this.GbxShowLoading.Visible = true;

            // Generate file path using connector name.
            string filePath = Path.Combine(accessoriesFolderPath, $"{accessoryDetails?.FullName}.jpeg");

            // Cancel the process if file already exists
            //if (File.Exists(filePath))
            //throw new Exception($"File '{filePath}' already exists! Process cancelled.");

            // Add the image in the Accessory folder
            await Task.Run(() =>
            {
                Image _image = customPictureBox.GetProcessedImage();
                _imageProcessor.SaveCompressedImage(_image, filePath);
            });

            // validate the file path
            if (!_fileService.IsValidPath(filePath))
            {
                this.GbxShowLoading.Visible = false;
                throw new Exception("The image file path is not valid! Process cancelled.");
            }

            // add the image in the database
            if (accessoryDetails is AccessoryDetails details)
            {
                bool recordExists = await _accessoryRepo.FindExistingRecord(details);
                if (recordExists)
                {
                    var dialogResult = DialogHelper.ShowYesNoDialog(
                         $"An accessory with the name '{details.FullName}' already exists in the system.\n" +
                         "Do you want to add to the existing record?",
                         "Confirm Overwrite"
                     );

                    if (dialogResult == DialogResult.No) return;
                    await _accessoryRepo.UpdateAccessory(details);
                }
                else
                    await _accessoryRepo.SaveNewAccessory(filePath, details);

                _promptService.PromptUserForOpeningImage(filePath);
            }
        }

        public void DeleteImage()
        {
            string filePath = FileHelper.SelectImageFilePath("Select the image you want to delete");
            if (string.IsNullOrEmpty(filePath))
                return;

            // delete from local folder
            FileHelper.DeleteImageFile(filePath);

            // delete from db
            string fileName = Path.GetFileName(filePath);
            _ = _referenciasRepo.DeleteDataAsync(fileName);

            ExceptionHelper.ShowInformationMessage($"{fileName} deleted successfully!");
        }

        // Saves the processed image with a pre-defined name, and returns a filepath
        public string SaveTempImage(string name)
        {
            using var _image = new Bitmap(customPictureBox.Image);
            string filePath = _fileService.GetFilePath(name);
            _imageProcessor.SaveCompressedImage(_image, filePath);

            return filePath;
        }

        private static AccessoryDetails? GetAccessoryDetails()
        {
            using var view = new AddAccessoryView();

            // Create repositories
            var referenciasRepo = new ReferenciasRepository();
            var accessoryRepo = new AccessoryRepository();
            var metadataRepo = new MetadataRepository();

            // Create presenter (connects view and repositories)
            var presenter = new AddAccessoryPresenter(
                view,
                accessoryRepo,
                referenciasRepo,
                metadataRepo
            );

            // Show the view
            if (view.ShowDialog() == DialogResult.OK)
            {
                presenter.UnsubscribeFromViewEvents();
                return presenter.AccessoryDetails;
            }
            else
            {
                presenter.UnsubscribeFromViewEvents();
                return null;
            }
        }

        /// <summary> Open SampleDetailsForm to get connector details from user. </summary>
        private static SampleDetail GetConnectorDetails()
        {
            using var view = new SampleDetailsView();

            // Create repositories
            var referenciasRepo = new ReferenciasRepository();
            var cordConRepo = new CordConRepository();
            var metadataRepo = new MetadataRepository();

            // Create presenter (connects view and repositories)
            var presenter = new SampleDetailsPresenter(
                view,
                referenciasRepo,
                cordConRepo,
                metadataRepo
            );

            // Show the view
            if (view.ShowDialog() == DialogResult.OK)
            {
                var sampleDetails = presenter.SampleDetails;
            }

            // Clean up
            presenter.UnsubscribeFromViewEvents();
            return presenter.SampleDetails;
        }

        private void PerformInitalChecks()
        {
            // check if image is available
            if (customPictureBox.Image is null)
                throw new Exception("No image available from the camera!");

            // Validate default folder or prompt user to update it.
            if (!_fileService.EnsureDefaultFolderIsValid())
                throw new Exception("The default local folder does not exist! \n Process cancelled!");
        }

        /// <summary> returns true if an image is available in the customPictureBox </summary>
        private bool IsImageAvailable()
        {
            if (customPictureBox.Image is null)
            {
                ExceptionHelper.ShowWarningMessage("No Image Found!");
                return false;
            }
            return true;
        }

        private static string GetDefaultConnectorPath(string connectorName)
        {
            string filePath = Path.Combine(ProjectSettings.DefaultFolder, $"{connectorName}.jpeg");

            // Cancel the process if file already exists
            if (File.Exists(filePath))
                throw new Exception($"File '{filePath}' already exists! Process cancelled.");

            return filePath;
        }

        /// <summary> Save image in local folder and database. </summary>
        private async Task<bool> SaveImage(string filePath, SampleDetail newSample)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    // first save in local folder
                    using var _temImage = new Bitmap(customPictureBox.Image);
                    _imageProcessor.SaveCompressedImage(_temImage, filePath);

                    // then save features in database
                    var (resnet, dino) = ExtractFeatures(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    await _featureRepo.SaveFeatures(fileName, resnet, dino).ConfigureAwait(false);

                    // save in referencias table
                    //await _referenciasRepo.InsertDataAsync(filePath, newSample).ConfigureAwait(false);
                    await _referenciasRepo.InsertNewConnector(filePath, newSample).ConfigureAwait(false);
                    return true;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // in case of error, delete the file from the local folder
                if (File.Exists(filePath))
                    File.Delete(filePath);

                // Handle UNIQUE KEY violation (duplicate entry)
                if (ex is SqlException sqlx && (sqlx.Number == 2627 || sqlx.Number == 2601))
                    throw new Exception($"{newSample.BasicDetails.Codivmac} already exists in the database! Process cancelled.");
                else
                    throw; // re-throw the original error
            }
        }

        private static (float[], float[]) ExtractFeatures(string filePath)
        {
            using var resnetExtractor = new FeatureExtractorResnet50();
            using var dinov2Extractor = new FeatureExtractorDINOv2();

            try
            {
                float[] resnetVector = resnetExtractor.ExtractFeatures(filePath);
                float[] dinov2Vector = dinov2Extractor.ExtractFeatures(filePath);
                return (resnetVector, dinov2Vector);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while adding {filePath}: {ex.Message}");
                return (Array.Empty<float>(), Array.Empty<float>());
            }
        }


    }
}
