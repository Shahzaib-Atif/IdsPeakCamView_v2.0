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
        private readonly ImageProcessorService _imageProcessor;
        private readonly FileService _fileService;
        private readonly PromptService _promptService;
        private readonly FeatureRepository _featureRepo;
        private readonly AccessoryRepository _accessoryRepo;
        private readonly ReferenciasRepository _referenciasRepo;


        public ImageStorageService(SimplePictureBox customPictureBox, GroupBox gbxShowLoading)
        {
            // initialize UI components references
            this.customPictureBox = customPictureBox;
            this.GbxShowLoading = gbxShowLoading;

            // initialize services
            _imageProcessor = new ImageProcessorService();
            _fileService = new FileService();
            _promptService = new PromptService();
            _featureRepo = new FeatureRepository();
            _accessoryRepo = new AccessoryRepository();
            _referenciasRepo = new ReferenciasRepository();
        }

        public async Task<bool> SaveExtraImage()
        {
            // get image path from user
            string filePath = FileHelper.SelectSaveImageFilePath("Select the location to save the image");

            return await SaveCompressedImageAsync(filePath);
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

            // show error if same file already exists and exit
            if (File.Exists(filePath))
                throw new Exception($"A connector with the name '{connectorName}' already exists!");

            // Save image in local folder and database
            if (!await SaveImage(filePath, newSample)) return false;

            // Save compressed image with text overlays
            if (!await SaveCompressedImageAsync(filePath)) return false;

            // hide the loading status
            this.GbxShowLoading.Visible = false;

            // if everything went well then save connector name
            ProjectSettings.SetConnectorName(connectorName);

            return true;
        }


        /// <summary> store accessory image to local folder and database </summary>
        public async Task<bool> SaveAccessoryToDB()
        {
            if (!IsImageAvailable()) return false; // Exit if Image is NOT available.

            var accessoryDetails = GetAccessoryDetails();
            if (accessoryDetails is null) return false;

            // check if \_Accessories folder path is correct 
            string accessoriesFolderPath = ProjectSettings.DefaultFolder + @"\_Accessories";
            if (!Directory.Exists(accessoriesFolderPath))
                throw new Exception("_Accessories folder not found!");

            // show loading status
            this.GbxShowLoading.Visible = true;

            // Generate file path using connector name.
            string filePath = Path.Combine(accessoriesFolderPath, $"{accessoryDetails?.FullName}.jpeg");

            // show error if same file already exists and exit
            if (File.Exists(filePath))
                throw new Exception($"An accessory with the name '{accessoryDetails?.FullName}' already exists!");

            // Save compressed image with text overlays
            if (!await SaveCompressedImageAsync(filePath)) return false;

            // validate the file path (check if image was saved correctly)
            if (!_fileService.IsValidPath(filePath)) return false;

            // insert or update accessory record
            if (accessoryDetails is AccessoryDetails details)
            {
                await UpsertAccessoryAsync(details, filePath);
                return true;
            }

            throw new Exception("Something went wrong while saving accessory!");
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
        public async Task<string> SaveTempImage(string name)
        {
            string filePath = _fileService.GetFilePath(name);
            using var imageCopy = customPictureBox.GetProcessedImage();

            await Task.Run(() =>
            {
                using (imageCopy)
                {
                    _imageProcessor.SaveCompressedImage(imageCopy, filePath);
                }
            });

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

        /// <summary> Saves the processed image with text overlays. </summary>
        private async Task<bool> SaveCompressedImageAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;

            // get image on UI thread, process in background
            Bitmap imageCopy = customPictureBox.GetProcessedImage();
            if (imageCopy == null) return false;

            // write original image in local folder with the processed image containing text.
            await Task.Run(() =>
            {
                using (imageCopy)
                {
                    _imageProcessor.SaveCompressedImage(imageCopy, filePath);
                }
            });

            // ask user if he wants to open the image
            //_promptService.PromptUserForOpeningImage(filePath);

            return true;
        }

        /// <summary> Insert or update accessory record in the database </summary>
        private async Task<bool> UpsertAccessoryAsync(AccessoryDetails details, string filePath)
        {
            bool recordExists = await _accessoryRepo.FindExistingRecord(details);
            if (recordExists)
            {
                var dialogResult = DialogHelper.ShowYesNoDialog(
                     $"An accessory with the name '{details.FullName}' already exists in the system.\n" +
                     "Do you want to add to the existing record?",
                     "Confirm Overwrite"
                 );

                if (dialogResult == DialogResult.No) return false;
                await _accessoryRepo.UpdateAccessory(details);
            }
            else
                await _accessoryRepo.SaveNewAccessory(filePath, details);

            return true;
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
            Bitmap imageCopy = null;

            try
            {
                imageCopy = customPictureBox.GetClonedImage();
                if (imageCopy == null) return false;

                // Save image on background thread
                await Task.Run(() => _imageProcessor.SaveCompressedImage(imageCopy, filePath));

                // Extract features
                var (resnet, dino) = await Task.Run(() => ExtractFeatures(filePath));
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                // Save features to DB (async naturally)
                await _featureRepo.SaveFeatures(fileName, resnet, dino);
                await _referenciasRepo.InsertNewConnector(filePath, newSample);

                return true;
            }
            catch (Exception ex)
            {
                // in case of error, delete the file from the local folder
                if (File.Exists(filePath)) File.Delete(filePath);

                // Handle UNIQUE KEY violation (duplicate entry)
                if (ex is SqlException sqlx && (sqlx.Number == 2627 || sqlx.Number == 2601))
                    throw new Exception($"{newSample.BasicDetails.Codivmac} already exists in the database! Process cancelled.");
                else
                    throw; // re-throw the original error
            }
            finally
            {
                imageCopy?.Dispose();
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
