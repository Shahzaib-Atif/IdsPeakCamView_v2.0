using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class AddAccessoryForm : Form
    {
        public AccessoryDetails AccessoryDetails { get; set; }
        private static AutoCompleteStringCollection codivmacCollection;
        private static AutoCompleteStringCollection posIdCollection;
        private readonly AccessoryRepository _accessoryRepo;
        private readonly ReferenciasRepository _referenciasRepo;
        public bool ColorAssociated => checkBoxColorAssociated.Checked;


        public AddAccessoryForm()
        {
            InitializeComponent();

            // initialize repository
            _accessoryRepo = new AccessoryRepository();
            _referenciasRepo = new ReferenciasRepository();

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
            InitializeCodivmacCollection();
            InitializePosIdCollection();

            textBoxName.AutoCompleteCustomSource = codivmacCollection;
            textBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private async void InitializeCodivmacCollection()
        {
            try
            {
                codivmacCollection ??= new(); // initialize only first time
                codivmacCollection.Clear(); // clear the list

                var items = await _referenciasRepo.ReadAvailableCodivmac(); // fetch data from db
                codivmacCollection.AddRange(items.ToArray()); // add to collection
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        private async void InitializePosIdCollection()
        {
            try
            {
                posIdCollection ??= new(); // initialize only first time
                posIdCollection.Clear();

                var items = await _referenciasRepo.ReadAvailablePosId(); // fetch data from db
                posIdCollection.AddRange(items.ToArray()); // add to collection
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
            if (ColorAssociated)
            {
                if (posIdCollection is null || !posIdCollection.Contains(details.ConnectorName))
                {
                    ExceptionHelper.ShowWarningMessage("Cannot find this connector name in the existing data!");
                    return;
                }
            }
            else
            {
                if (codivmacCollection is null || !codivmacCollection.Contains(details.ConnectorName))
                {
                    ExceptionHelper.ShowWarningMessage("Cannot find this connector name in the existing data!");
                    return;
                }
            }

            // configure sample details & close the form
            this.AccessoryDetails = details;
            this.DialogResult = DialogResult.OK;
        }

        private void checkBoxColorAssociated_CheckedChanged(object sender, EventArgs e)
        {
            textBoxName.AutoCompleteCustomSource = ColorAssociated ? posIdCollection : codivmacCollection;
        }
    }
}
