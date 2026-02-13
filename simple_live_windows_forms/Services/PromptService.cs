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

        internal string PromptForPassword()
        {
            using Form prompt = new();
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = "Enter Password";
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;

            TextBox textBox = new()
            {
                Left = 50,
                Top = 20,
                Width = 200,
                UseSystemPasswordChar = true
            };

            Button confirmation = new()
            {
                Text = "OK",
                Left = 100,
                Width = 100,
                Top = 50,
                DialogResult = DialogResult.OK
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK
                ? textBox.Text
                : null;
        }


    }
}
