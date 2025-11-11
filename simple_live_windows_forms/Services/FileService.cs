using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using simple_ids_cam_view.UI.Forms;

namespace simple_ids_cam_view.Services
{
    internal class FileService
    {
        /// <summary> Ensures the default folder is valid; prompts user to update if necessary. </summary>
        public bool EnsureDefaultFolderIsValid()
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

        public string GetFilePath(string name)
        {
            return Path.Combine(ProjectSettings.DefaultFolder, name);
        }

        public bool IsValidPath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                ExceptionHelper.ShowWarningMessage("ExtractImageFeatures: Invalid image path!");
                return false;
            }
            return true;
        }
    }
}
