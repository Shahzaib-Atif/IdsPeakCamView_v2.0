using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class NewPositionForm : Form
    {
        private readonly CordConRepository _cordConRepo;
        private readonly MetadataRepository _metadataRepo;

        public NewPositionForm(string posId)
        {
            InitializeComponent();
            textBoxPosId.Text = posId;

            // initialize repository
            _cordConRepo = new CordConRepository();
            _metadataRepo = new MetadataRepository();

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
                var items = await _metadataRepo.ReadAvailableSampleSection();
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

            // select the correct columns based on the country
            var (vertColumn, horizColumn) = SelectCountry(coordinates);
            if (vertColumn is null || horizColumn is null) return;

            if (!ModelDataValidation.Validate(coordinates)) return;

            try
            {
                bool isInsertSuccessful = await _cordConRepo.InsertNewPosID(coordinates, vertColumn, horizColumn);
                if (!isInsertSuccessful) return;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
                return;
            }

            // if all good then close the form
            this.DialogResult = DialogResult.OK;
        }

        // select (CV,CH) OR (CV_Ma,CH_Ma) based on the country
        private static (string, string) SelectCountry(NewPositionCoordinates newPosition)
        {
            switch (newPosition.Country)
            {
                case "Portugal":
                    return ("[CV]", "[CH]");
                case "Morocco":
                    return ("[CV_Ma]", "[CH_Ma]");
                default:
                    ExceptionHelper.ShowWarningMessage("Error: Unknown country selected!");
                    return (null, null);
            }
        }

        private void FLP_Main_Click(object sender, EventArgs e)
        {
            this.FLP_Main.Focus();
        }
    }
}
