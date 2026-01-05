using static ImageProcessingLibrary.ProjectSettings;

namespace ImageProcessingLibrary.Helpers
{
    public class FileHelper
    {
        private static int MaxFileSize { get; } = 1000; // 1000kb

        #region Public Methods

        // ask the user for storage location and image type
        public static void SaveImage(Bitmap image)
        {
            if (image != null)
            {
                using SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "image";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file name and create a stream to write to it.
                    using System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    // Save the image in the appropriate format based on the file extension.
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case 2:
                            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 3:
                            image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                }
                image?.Dispose();
            }
            else
            {
                ExceptionHelper.ShowWarningMessage("No image available to save.");
            }
        }

        // return a file path
        public static string SelectImageFilePath(string title = "Select the Source Image")
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = title,
                Filter = "Image Files|*.png;*.jpeg;"
            };

            // Set the default folder if provided
            if (!string.IsNullOrEmpty(DefaultFolder) && Directory.Exists(DefaultFolder))
                openFileDialog.InitialDirectory = DefaultFolder;

            var result = openFileDialog.ShowDialog() == DialogResult.OK ?
                openFileDialog.FileName :
                string.Empty;

            openFileDialog.Dispose();
            openFileDialog = null;
            return result;
        }

        // delete a file
        public static void DeleteImageFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        // opens a dialog to select folder
        public static string SelectFolder()
        {
            // Create and configure the FolderBrowserDialog
            using var folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.Description = "Select a folder which contains all reference images";

            // Get the selected folder path
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                return folderBrowserDialog.SelectedPath;

            return "";
        }

        // Get files and filter based on size and type
        public static string[]? GetFilteredImagePaths(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
                return null;

            const long MaxFileSize = 1000 * 1024; // value in KB (1000 kb)
            var files = Directory.EnumerateFiles(folderPath)
                                         .Where(file => (file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                         file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                         file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)) &&
                                                        new FileInfo(file).Length <= MaxFileSize) // Check file size
                                         .ToArray();
            return files;
        }

        // return true if filesize is greater than defined maxLength
        public static bool IsFileTooLarge(string originalFilename)
        {
            var fileLength = (new FileInfo(originalFilename).Length) / 1000; // file size in kb
            if (fileLength > MaxFileSize)     // if greater than 1000kb
            {
                ExceptionHelper.ShowWarningMessage($"Source image size is greater than {MaxFileSize} KB. Unable to process request.");
                return true;
            }
            return false;
        }

        // Prompt user to update the default folder if it doesn't exist 
        public static bool IsDefaultFolderUpdateRequired()
        {
            var defaultFolder = ProjectSettings.DefaultFolder;

            // check if directory already exists
            if (Directory.Exists(defaultFolder))
                return false;

            // show confirmation dialog
            string text = $"The current directory is set to: [ {defaultFolder} ]. " +
                "\n Would you like to update the default folder location?";
            string caption = "Update Default Folder";
            DialogResult result = DialogHelper.ShowYesNoDialog(text, caption);

            return result == DialogResult.Yes;
        }

        // Open the selected image in the default system image viewer
        public static void OpenImageInDefaultViewer(string imagePath)
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = imagePath,
                    UseShellExecute = true // Important for .NET Core/5/6+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        // open the selected image in file explorer
        public static void OpenImageInFileExplorer(string imagePath)
        {
            try
            {
                // Open File Explorer and highlight the image file
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{imagePath}\"");
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Error opening image in explorer: {ex.Message}");
            }
        }

        public static string SelectSaveImageFilePath(string v)
        {
            // get image path from user
            using var saveFileDialog = new SaveFileDialog()
            {
                Title = v,
                Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp",
                FileName = "image"
            };

            return saveFileDialog.ShowDialog() == DialogResult.OK ?
                saveFileDialog.FileName :
                string.Empty;
        }
        #endregion
    }
}
