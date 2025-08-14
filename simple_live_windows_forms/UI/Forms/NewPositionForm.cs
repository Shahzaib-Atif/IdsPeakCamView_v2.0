using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class NewPositionForm : Form
    {
        public NewPositionForm(string posId)
        {
            InitializeComponent();
            textBoxPosId.Text = posId;

            // select the first option as a default
            comboBoxCountry.SelectedIndex = 0;

            // configure Sample Section
            ConfigureSampleSection();
        }

        // fetch Section from the DB and add in the combobox
        private async void ConfigureSampleSection()
        {
            try
            {
                comboBoxSampleSection.Items.Clear();
                var items = await DatabaseManager.ReadAvailableSampleSection();
                comboBoxSampleSection.Items.AddRange(items.ToArray());
                comboBoxSampleSection.Text = "CONECTORES";
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        private async void BtnSave_ClickAsync(object sender, EventArgs e)
        {
            var coordinates = new NewPositionCoordinates
            {
                PosId = textBoxPosId.Text.ToUpper(),
                CV = textBoxCV.Text.ToUpper(),
                CH = textBoxCH.Text.ToUpper(),
                Country = comboBoxCountry.Text,
                SampleSection = comboBoxSampleSection.Text,
            };

            bool isDataValid = ModelDataValidation.Validate(coordinates);
            if (!isDataValid) return;

            bool isInsertSuccessful = await DatabaseManager.InsertNewPosID(coordinates);
            if (!isInsertSuccessful) return;

            // if all good then close the form
            this.DialogResult = DialogResult.OK;
        }

        private void FLP_Main_Click(object sender, EventArgs e)
        {
            this.FLP_Main.Focus();
        }
    }
}
