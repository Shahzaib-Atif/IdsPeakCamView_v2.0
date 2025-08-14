using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Services;
using System.Diagnostics;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class DefaultFolderForm : Form
    {
        public DefaultFolderForm()
        {
            InitializeComponent();

            // load the default folder from project settings
            textBoxFolderPath.Text = ProjectSettings.DefaultFolder;

            // disable the save button initially
            SaveBtn.Enabled = false;
        }

        private void UpdateFolderBtn_Click(object sender, EventArgs e)
        {
            string folder = FileHelper.SelectFolder();
            if (!string.IsNullOrEmpty(folder))
            {
                textBoxFolderPath.Text = folder;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveAndCloseForm();
        }


        private void TextBoxFolderPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent default beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
                e.SuppressKeyPress = false;
        }


        private void SaveAndCloseForm()
        {
            string updatedPath = textBoxFolderPath.Text;

            if (Directory.Exists(updatedPath))
            {
                // update project settings
                ProjectSettings.SetDefaultFolderPath(updatedPath);

                // prompt user if he wants to write changes to the settings file
                SettingsManager.PromptToUpdateSettings();

                Debug.WriteLine("--- [DefaultFolder] Folder path updated");
                DialogResult = DialogResult.OK;
            }
            else
            {
                ExceptionHelper.DisplayErrorMessage($"The specified folder does not exist: {updatedPath}");
            }
        }

        private void TextBoxFolderPath_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = true;
        }
    }
}
