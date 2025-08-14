using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class UserCredentialsForm : Form
    {
        public UserCredentialsForm()
        {
            InitializeComponent();
            InitializeUiFields();

            // Enable or disable user ID and password fields based on Windows authentication
            gboxUserId.Enabled = !checkBoxWindowsAuth.Checked;
            gboxPassword.Enabled = !checkBoxWindowsAuth.Checked;

            // disable the save button initially
            SaveBtn.Enabled = false;
        }

        private void InitializeUiFields()
        {
            textboxServerName.Text = ProjectSettings.DbConfigSettings.Server;
            textBoxDatabaseName.Text = ProjectSettings.DbConfigSettings.Database;
            checkBoxWindowsAuth.Checked = ProjectSettings.DbConfigSettings.IntegratedSecurity;
            textBoxUserId.Text = ProjectSettings.DbConfigSettings.UserId;
            textBoxPassword.Text = ProjectSettings.DbConfigSettings.Password;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var newSettings = new DbConfigSettings
            {
                Server = textboxServerName.Text,
                Database = textBoxDatabaseName.Text,
                IntegratedSecurity = checkBoxWindowsAuth.Checked,
                UserId = textBoxUserId.Text,
                Password = textBoxPassword.Text,
            };

            // first validate the data
            if (ModelDataValidation.Validate(newSettings))
            {
                // update project settings
                ProjectSettings.SetDbConfigSettings(newSettings);
                ProjectSettings.SetDbConnectionString(newSettings.ToString());

                // prompt user if he wants to write changes to the settings file
                SettingsManager.PromptToUpdateSettings();

                DialogResult = DialogResult.OK;
            }
        }

        private void CheckBoxWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable user ID and password fields based on Windows authentication
            gboxUserId.Enabled = !checkBoxWindowsAuth.Checked;
            gboxPassword.Enabled = !checkBoxWindowsAuth.Checked;

            // enable the save button
            SaveBtn.Enabled = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for Enter key
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent default beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
                e.SuppressKeyPress = false;
        }

        private void TextBoxDatabaseFields_TextChanged(object sender, EventArgs e)
        {
            // enable the save button
            SaveBtn.Enabled = true;
        }
    }
}
