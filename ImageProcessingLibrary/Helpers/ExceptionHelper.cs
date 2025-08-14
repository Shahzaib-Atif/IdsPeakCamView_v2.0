using System.Diagnostics;

namespace ImageProcessingLibrary.Helpers
{
    public static class ExceptionHelper
    {
        #region Public Methods
        public static void ThrowDetailedException(string message = "An error has occurred!")
        {
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                var stackTrace = new StackTrace();
                var frame = stackTrace.GetFrame(1); // Get the calling frame (not this method)

                string errorMessage = $"Error in {frame.GetFileName()} at line {frame.GetFileLineNumber()}, method {frame.GetMethod().Name}: {ex.Message}";
                throw new Exception(errorMessage, ex);
            }
        }

        public static void ShowDetailedErrorWithoutCrashing(string message = "An error has occurred!")
        {
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                var stackTrace = new StackTrace();
                var frame = stackTrace.GetFrame(1); // Get the calling frame (not this method)

                string errorMessage = $"Error in {frame.GetFileName()} at line {frame.GetFileLineNumber()}, method {frame.GetMethod().Name}: {ex.Message}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDefaultFolderNotFoundWarning()
        {
            ShowWarningMessage("The default local folder does not exist! \n Process cancelled!");
        }

        public static void DeleteImageAndThrowException(string filePath)
        {
            // delete the file from the local folder
            if (File.Exists(filePath))
                File.Delete(filePath);

            throw new Exception("Failed to save the image. Process is cancelled!");
        }
        #endregion

    }

}
