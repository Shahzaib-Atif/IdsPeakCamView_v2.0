using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class AddAccessoryForm : Form
    {
        public AccessoryDetails AccessoryDetails { get; set; }
        private static AutoCompleteStringCollection myCollection;
        private readonly AccessoryRepository _accessoryRepo;

        public AddAccessoryForm()
        {
            InitializeComponent();

            // initialize repository
            _accessoryRepo = new AccessoryRepository();

            // initial setup
            ConfigureAutoCompleteForConnectorNames();
            ConfigureTipo();
        }


        // fetch accessory types from the DB and add in the combobox
        private async void ConfigureTipo()
        {
            try
            {
                comboBoxTipo.Items.Clear();
                var items = await _accessoryRepo.ReadAvailableAccessoryTypes();
                comboBoxTipo.Items.AddRange(items.ToArray());
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        #region -- AUTO COMPLETE CONNECTOR NAMES
        private void ConfigureAutoCompleteForConnectorNames()
        {
            InitializeMyCollection();

            textBoxName.AutoCompleteCustomSource = myCollection;
            textBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private static async void InitializeMyCollection()
        {
            try
            {
                myCollection ??= new(); // initialize only first time
                myCollection.Clear(); // clear the list

                var items = await DatabaseManager.ReadAvailableCodivmac(); // fetch data from db
                myCollection.AddRange(items.ToArray()); // add to collection
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }
        #endregion

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // create a new basicDetails object
            var details = new AccessoryDetails
            {
                ConnectorName = textBoxName.Text.ToUpper(),
                Tipo = comboBoxTipo.Text,
                Reference = textBoxReference.Text?.ToString() ?? "",
            };

            // Update FullName property
            details.FullName = $"{details.ConnectorName}_{details.Reference}";

            // check basic model validation
            if (!ModelDataValidation.Validate(details)) return;

            // if the Connector does not exist, then we cannot proceed
            if (myCollection is null || !myCollection.Contains(details.ConnectorName))
            {
                ExceptionHelper.ShowWarningMessage("Cannot find this connector name in the existing data!");
                return;
            }

            // configure sample details & close the form
            this.AccessoryDetails = details;
            this.DialogResult = DialogResult.OK;
        }
    }
}
