using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using ImageProcessingLibrary.Services.Database;
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

        public ImageStorageService(SimplePictureBox customPictureBox, GroupBox gbxShowLoading, Label labelConnectorName)
        {
            // initialize UI components references
            this.customPictureBox = customPictureBox;
            this.GbxShowLoading = gbxShowLoading;
            this.LabelConnectorName = labelConnectorName;

            // initialize services
            _imageProcessor = new ImageProcessorService();
        }

        /// <summary> store connector in local folder and database </summary>
        public async Task<bool> SaveConnectorToDB()
        {
            // check image availability and default folder
            PerformInitalChecks();

            // Get connector details from the user.
            //var connectorName = GetConnectorDetails(); //TODO
            SampleDetail newSample = new()
            {
                BasicDetails = new BasicSampleDetails
                {
                    PosId = "A000",
                    Cor = "B",
                    Vias = "R",
                    Codivmac = "A000BR",
                    Tipo = "Conector"
                },
                Dimensions = new SampleDimensions
                {
                    InternalDiameter = 1,
                    ExternalDiameter = 2,
                    Thickness = 5
                }
            };
            string connectorName = newSample.BasicDetails.Codivmac;
            //if (string.IsNullOrEmpty(connectorName)) return false;

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

            // ask user if he wants to open the image
            PromptUserForOpeningImage(filePath);

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

            using var f = new AddAccessoryForm();
            //f.TopMost = true;
            if (f.ShowDialog() != DialogResult.OK)
                return;

            var accessoryDetails = f.AccessoryDetails;

            // check if \_Accessories folder path is correct 
            string accessoriesFolderPath = ProjectSettings.DefaultFolder + @"\_Accessories";
            if (!Directory.Exists(accessoriesFolderPath))
                throw new Exception("_Accessories folder not found!");

            // show loading status
            this.GbxShowLoading.Visible = true;

            // Generate file path using connector name.
            string filePath = Path.Combine(accessoriesFolderPath, $"{f.AccessoryDetails.FullName}.jpeg");

            // Cancel the process if file already exists
            if (File.Exists(filePath))
                throw new Exception($"File '{filePath}' already exists! Process cancelled.");

            // Add the image in the Accessory folder
            await Task.Run(() =>
            {
                Image _image = customPictureBox.GetProcessedImage();
                _imageProcessor.SaveCompressedImage(_image, filePath);
            });

            // add the image in the database
            await DatabaseManager.SaveAccessoryDetails(filePath, f.AccessoryDetails);

            // ask user if he wants to open the image
            PromptUserForOpeningImage(filePath);
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
            _ = DatabaseManager.DeleteFromMainTableAsync(fileName);

            ExceptionHelper.ShowInformationMessage($"{fileName} deleted successfully!");
        }

        // Saves the processed image with a pre-defined name, and returns a filepath
        public string SaveTempImage(string name)
        {
            // get default save location
            string filePath = Path.Combine(ProjectSettings.DefaultFolder, name);

            // get image
            using var _image = new Bitmap(customPictureBox.Image);
            if (_image is null) return null;

            // save image after processing
            _imageProcessor.SaveCompressedImage(_image, filePath);

            return filePath;
        }

        /// <summary> Open SampleDetailsForm to get connector details from user. </summary>
        private static SampleDetail GetConnectorDetails()
        {
            using var f = new SampleDetailsForm();
            return f.ShowDialog() == DialogResult.OK ? f.SampleDetails : null;
        }

        private void PerformInitalChecks()
        {
            // check if image is available
            if (customPictureBox.Image is null)
                throw new Exception("No image available from the camera!");

            // Validate default folder or prompt user to update it.
            if (!EnsureDefaultFolderIsValid())
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

        private static bool EnsureDefaultFolderIsValid()
        {
            if (FileHelper.IsDefaultFolderUpdateRequired())
            {
                using var f = new DefaultFolderForm();    //f.TopMost = true;            
                f.ShowDialog();
            }

            if (!Directory.Exists(ProjectSettings.DefaultFolder))
            {
                ExceptionHelper.ShowDefaultFolderNotFoundWarning();
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
                    await DatabaseManager.SaveFeatures(fileName, resnet, dino).ConfigureAwait(false);

                    // save in referencias table
                    await InsertHandler.InsertReferenceDataAsync(filePath, newSample).ConfigureAwait(false);
                    //return await DatabaseManager.StoreImageFeatures(filePath, SampleDetails).ConfigureAwait(false);
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
                    throw new Exception($"An entry with the same key {newSample.BasicDetails.Codivmac} already exists in the database! Process cancelled.");
                else
                    throw; // re-throw the original error
            }
        }

        private (float[], float[]) ExtractFeatures(string filePath)
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


        // Ask the user if they want to open the image in File Explorer
        private void PromptUserForOpeningImage(string savePath)
        {
            // hide the loading status
            this.GbxShowLoading.Visible = false;

            try
            {
                DialogResult result = MessageBox.Show("Image saved successfully! Do you want to open it in File Explorer?",
                                                      "Open Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks 'Yes', open the folder and highlight the image
                if (result == DialogResult.Yes)
                {
                    string argument = "/select, \"" + Path.GetFullPath(savePath) + "\"";
                    Process.Start("explorer.exe", argument);
                }
            }
            catch
            {
                ExceptionHelper.DisplayErrorMessage($"Error occured while trying to open file location:\n{savePath}");
            }
        }
    }
}
