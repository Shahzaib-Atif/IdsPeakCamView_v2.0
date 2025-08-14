using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class ModbusConfigForm : Form
    {
        // a flag to indicate if there has been any change in the settings
        public bool SettingsChanged { get; private set; } = false;

        public ModbusConfigForm()
        {
            InitializeComponent();

            // initialize textboxes
            textBoxIpAddr.Text = ProjectSettings.ModbusIpAddress;
            textBoxPort.Text = ProjectSettings.ModbusPort.ToString();

            // disable the save btn initially
            SaveBtn.Enabled = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // convert port number to Int
            _ = int.TryParse(textBoxPort.Text, out int port);

            // create a new modbus settings object
            var newSettings = new ModbusConfigSettings
            {
                ModbusIpAddress = textBoxIpAddr.Text,
                ModbusPort = port,
            };

            // first validate the data
            if (ModelDataValidation.Validate(newSettings))
            {
                // update project settings
                ProjectSettings.SetModbusIpAddress(newSettings.ModbusIpAddress);
                ProjectSettings.SetModbusPort(newSettings.ModbusPort);

                // prompt user if he wants to write changes to settings JSON file
                SettingsManager.PromptToUpdateSettings();

                this.SettingsChanged = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void TextBoxModbus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent default beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
                e.SuppressKeyPress = false;
        }

        private void TextBoxFields_TextChanged(object sender, EventArgs e)
        {
            // enable the save button
            SaveBtn.Enabled = true;
        }
    }
}
