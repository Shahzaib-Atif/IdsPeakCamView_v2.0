using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Services;
using ImageProcessingLibrary.Services.Database;
using simple_ids_cam_view.UI.Controls;
using simple_ids_cam_view.UI.Forms;
using System.Diagnostics;
using static ImageProcessingLibrary.Helpers.ExceptionHelper;

namespace simple_ids_cam_view.Services
{
    internal class ImageStorageService
    {
        private readonly SimplePictureBox customPictureBox;
        private readonly GroupBox GbxShowLoading;
        private readonly Label LabelConnectorName;

        public ImageStorageService(SimplePictureBox customPictureBox, GroupBox gbxShowLoading, Label labelConnectorName)
        {
            this.customPictureBox = customPictureBox;
            this.GbxShowLoading = gbxShowLoading;
            this.LabelConnectorName = labelConnectorName;
        }

        /// <summary> store connector in local folder and database </summary>
        public async Task<bool> SaveConnectorToDB()
        {
            // check image availability and default folder
            PerformInitalChecks();

            // Get connector details from the user.
            //string connectorName = GetConnectorDetails(); //TODO
            string connectorName = "A000BR";
            if (string.IsNullOrEmpty(connectorName)) return false;

            // show loading status
            this.GbxShowLoading.Visible = true;

            // Generate file path using connector name.
            string filePath = GetDefaultConnectorPath(connectorName);

            bool isSaveSuccessful = await SaveOriginalImage(filePath);
            if (!isSaveSuccessful)
                DeleteImageAndThrowException(filePath);

            // Overwrite original image in local folder with the processed image containing text.
            await Task.Run(() =>
            {
                Image _image = customPictureBox.GetProcessedImage();
                ImageProcessor.SaveCompressedImage(_image, filePath);
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
                ImageProcessor.SaveCompressedImage(_image, filePath);
            });

            // add the image in the database
            await DatabaseManager.SaveAccessoryDetails(filePath, f.AccessoryDetails);

            // ask user if he wants to open the image
            PromptUserForOpeningImage(filePath);
        }

        public static void DeleteImage()
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



        /// <summary> Open SampleDetailsForm to get connector details from user. </summary>
        private static string GetConnectorDetails()
        {
            using var f = new SampleDetailsForm(); //f.TopMost = true;

            if (f.ShowDialog() == DialogResult.OK)
            {
                //this.SampleDetails = f.SampleDetails;
                return (f.SampleDetails.BasicDetails.Codivmac);
            }
            else
                return string.Empty;
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

        private async Task<bool> SaveOriginalImage(string filePath)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    // first save in local folder
                    using var _temImage = new Bitmap(customPictureBox.Image);
                    ImageProcessor.SaveCompressedImage(_temImage, filePath);

                    //return await DatabaseManager.StoreImageFeatures(filePath, SampleDetails).ConfigureAwait(false);
                    var (resnet, dino) = ExtractFeatures(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    await DatabaseManager.SaveFeatures(fileName, resnet, dino).ConfigureAwait(false);
                    return true;
                }).ConfigureAwait(false);
            }
            catch
            {
                // in case of error, delete the file from the local folder
                if (File.Exists(filePath))
                    File.Delete(filePath);

                // re-throw the original error
                throw;
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
