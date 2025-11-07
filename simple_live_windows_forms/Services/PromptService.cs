using ImageProcessingLibrary.Helpers;
using System.Diagnostics;

namespace simple_ids_cam_view.Services
{
    internal class PromptService
    {
        // Ask the user if they want to open the image in File Explorer
        internal void PromptUserForOpeningImage(string savePath)
        {
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
