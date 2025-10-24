using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;
using System.Diagnostics;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class SampleDetailsForm : Form
    {
        #region -- VARIABLES
        private static AutoCompleteStringCollection myCollection;
        private static List<KeyValue> TipoList;
        private static List<KeyValue> CorsList;
        private static List<KeyValue> ViasList;
        public SampleDetail SampleDetails { get; private set; }
        // Disable validation for search; enable for adding a new sample
        private bool IsSaveMode { get; set; }
        #endregion

        public SampleDetailsForm(bool isSaveMode = true)
        {
            InitializeComponent();

            // initialize form
            this.IsSaveMode = isSaveMode;

            // hide the diameters and thickness initially
            gbxDiameter.Visible = false;

            // hide the suggestLabel in case of search mode
            if (!isSaveMode) LabelSuggest.Visible = false;

            // assign titles to groupboxes
            AssignTitlesToGroupBoxes();

            ConfigureAutoCompleteForPosId();

            // configure all combobox
            _ = ConfigureTipoCorsVias();
        }

        // add '*' if this is in 'Save' mode
        private void AssignTitlesToGroupBoxes()
        {
            gbxName.Text = IsSaveMode ? "Pos Id *" : "Pos Id";
            gbxType.Text = IsSaveMode ? "Tipo *" : "Tipo";
            gbxCor.Text = IsSaveMode ? "Cor *" : "Cor";
            gbxVias.Text = IsSaveMode ? "Vias *" : "Vias";

            //gbxType.Text = "Tipo";
        }


        #region -- CONFIGURE AUTOCOMPLETE FOR POS ID
        private void ConfigureAutoCompleteForPosId()
        {
            InitializeMyCollection();

            textBoxPosId.AutoCompleteCustomSource = myCollection;
            textBoxPosId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxPosId.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private static async void InitializeMyCollection()
        {
            try
            {
                myCollection ??= new(); // initialize only first time
                myCollection.Clear(); // clear the list

                var items = await DatabaseManager.ReadAvailablePosId(); // fetch data from db
                myCollection.AddRange(items.ToArray()); // add to collection
            }
            catch (Exception ex)
            {
                //ExceptionHelper.ShowWarningMessage($"Error while trying to read available posId. {ex.Message}");
                Debug.WriteLine($"Error while trying to read available posId. {ex.Message}");
            }
        }

        /*
        private static void AddFilenamesToMyCollection(string folderPath)
        {
            try
            {
                // Get all file names without extensions (truncated to 4 chars)
                var fileNamesWithoutExtension = Directory.GetFiles(folderPath)
                                                         .Select(file => Path.GetFileNameWithoutExtension(file))
                                                         .Select(name => name.Length > 4 ? name.Substring(0, 4) : name)
                                                         .ToArray();
                // add to collection
                myCollection.AddRange(fileNamesWithoutExtension);
            }
            catch (Exception ex) { Debug.WriteLine($"An error occurred: {ex.Message}"); }
        }*/

        #endregion


        #region -- CONFIGURE TIPO, CORS, AND VIAS
        private async Task ConfigureTipoCorsVias()
        {
            // run three tasks in parallel
            await Task.WhenAll(ConfigureTipo(), ConfigureCors(), ConfigureVias());
        }

        // fetch colors from the DB and add in the combobox
        private async Task ConfigureTipo()
        {
            // only execute first time if list is null
            if (TipoList is null) await PopulateTipoList();

            // add data to combobox
            comboBoxTipo.Items.Clear();
            comboBoxTipo.DisplayMember = "Key";    // --> What the user sees
            comboBoxTipo.ValueMember = "Value";    // --> The actual identifier 
            comboBoxTipo.DataSource = TipoList;
        }

        // fetch colors from the DB and add in the combobox
        private async Task ConfigureCors()
        {
            // only execute first time if list is null
            if (CorsList is null) await PopulateCorsList();

            // add data to combobox
            comboBoxCor.Items.Clear();
            comboBoxCor.DisplayMember = "Key";    // --> What the user sees
            comboBoxCor.ValueMember = "Value";    // --> The actual identifier 
            comboBoxCor.DataSource = CorsList;
        }

        // fetch vias from the DB and add in the combobox
        private async Task ConfigureVias()
        {
            // only execute first time if list is null
            if (ViasList is null) await PopulateViasList();

            // add data to combobox
            comboBoxVias.Items.Clear();
            comboBoxVias.DisplayMember = "Key";  // --> What the user sees
            comboBoxVias.ValueMember = "Value";  // --> The actual identifier 
            comboBoxVias.DataSource = ViasList;
        }

        private static async Task PopulateTipoList()
        {
            TipoList = (await DatabaseManager.ReadAvailableTipo()).ToList();

            // Insert an empty option at the start
            TipoList.Insert(0, new KeyValue { Key = "", Value = "" });
        }

        private static async Task PopulateCorsList()
        {
            // get the values from database (in the form of KEY,VALUE pairs)
            CorsList = (await DatabaseManager.ReadAvailableCors()).ToList(); // fetch from db

            // let the user see color and its equivalent code
            foreach (var item in CorsList)
                item.Key = item.Key + $"  ({item.Value})";

            // Insert an empty option at the start
            CorsList.Insert(0, new KeyValue { Key = "", Value = "" });
        }

        private static async Task PopulateViasList()
        {
            // get the values from database (in the form of KEY,VALUE pairs)
            ViasList = (await DatabaseManager.ReadAvailableVias()).ToList();

            // let the user see vias number and its equivalent code (for numbers greater than 9)
            foreach (var item in ViasList)
            {
                if (int.Parse(item.Key) > 9)
                    item.Key = item.Key + $"  ({item.Value})";
            }

            // Insert an empty option at the start
            ViasList.Insert(0, new KeyValue { Key = "", Value = "" });
        }

        #endregion


        #region -- EVENT HANDLERS
        private async void BtnSave_ClickAsync(object sender, EventArgs e)
        {
            // create a new basicDetails object
            var basicDetails = new BasicSampleDetails
            {
                PosId = textBoxPosId.Text.ToUpper(),
                Tipo = comboBoxTipo.Text,
                Cor = comboBoxCor.SelectedValue?.ToString() ?? "",
                Vias = comboBoxVias.SelectedValue?.ToString() ?? "",
            };

            // This code block only executes when user is in the Save Mode
            if (IsSaveMode)
            {
                // check basic model validation
                if (!ModelDataValidation.Validate(basicDetails)) return;

                // if this [Pos Id] does not exist, then we need to save in DB along with CV, CH
                this.Cursor = Cursors.WaitCursor;
                bool isSuccess = await HandlePosIdAsync(basicDetails.PosId);
                this.Cursor = Cursors.Default;
                if (!isSuccess) return;
            }

            // create SampleDimensions object (convert value of 0 to null)
            var dimensions = new SampleDimensions
            {
                InternalDiameter = numericIntDia.Value == 0 ? null : numericIntDia.Value,
                ExternalDiameter = numericExtDia.Value == 0 ? null : numericExtDia.Value,
                Thickness = numericThickness.Value == 0 ? null : numericThickness.Value
            };

            // Join PosId, Tipo & Cor to make CODIVMAC
            basicDetails.Codivmac = ($"{basicDetails.PosId}{basicDetails.Cor}{basicDetails.Vias}");

            // configure sample details & close the form
            this.SampleDetails = new SampleDetail(basicDetails, dimensions);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary> Returns true if posId exists or is successfully saved, otherwise false. </summary>
        private static async Task<bool> HandlePosIdAsync(string posId)
        {
            try
            {
                // Check if the PosId already exists in the database
                if (await DatabaseManager.CheckIfPosIdExists(posId))
                {
                    return true; // No action needed if PosId exists
                }
                else
                {
                    // Prompt the user to save new coordinates for the new PosId
                    string message = "A new position has been entered.\n" +
                                     "Do you want to save new coordinates for this position?";
                    var dialogResult = DialogHelper.ShowYesNoDialog(message, "");

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Show the form to save the new coordinates
                        using var saveForm = new NewPositionForm(posId);
                        //saveForm.TopMost = true;

                        // return true if user saves new position successfully
                        return (saveForm.ShowDialog() == DialogResult.OK);
                    }
                    else
                        return false; // Return false if user cancels or insertion fails
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return false;
            }
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipo = comboBoxTipo.Text;

            // make the ComboBoxTipo color normal again
            if (!string.IsNullOrWhiteSpace(tipo))
                comboBoxTipo.BackColor = SystemColors.Window;

            // only show suggest label once the tipo is selected
            LabelSuggest.Enabled = !string.IsNullOrWhiteSpace(tipo);

            // show diameters & thickness in case Olhal is selected
            gbxDiameter.Visible = (tipo.ToLower() == "olhal");
        }

        private async void LabelSuggest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine Section from TipoList
            string section = comboBoxTipo.SelectedValue?.ToString() ?? "";

            // Retrieve the last position ID with the least highest number
            string lastPosId = await DatabaseManager.GetLeastHighestConAsync(section);

            // show warning if the retrieval was successful
            if (string.IsNullOrWhiteSpace(lastPosId))
                ExceptionHelper.ShowWarningMessage("Sorry, something went wrong!");
            else
                // Update the text box with the next position ID
                textBoxPosId.Text = ReturnNextPosId(lastPosId);
        }

        private void NumericDimensionBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to the next control
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true; // Mark the event as handled
            }
        }

        private void TextBoxPosId_Leave(object sender, EventArgs e)
        {
            // make the TextBoxName color normal again
            if (!string.IsNullOrWhiteSpace(textBoxPosId.Text))
                textBoxPosId.BackColor = SystemColors.Window;
        }

        private void TextBoxPosId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent default beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
                e.SuppressKeyPress = false;
        }

        #endregion


        #region -- SUGGEST NEXT AVAILABLE POS ID

        // Return next available name based on input string
        private static string ReturnNextPosId(string lastCellValue)
        {
            if (string.IsNullOrWhiteSpace(lastCellValue))
                return string.Empty;
            else
            {
                // Extract the alphabetic prefix and numeric suffix.
                string prefix = new(lastCellValue.TakeWhile(char.IsLetter).ToArray());
                string numberPart = new(lastCellValue.SkipWhile(char.IsLetter).ToArray());

                if (int.TryParse(numberPart, out int num))
                {
                    // Increment the numeric part and format it with leading zeros.
                    string nextNumber = (num + 1).ToString($"D{numberPart.Length}");
                    return $"{prefix}{nextNumber}";
                }

                return string.Empty;
            }
        }
        #endregion

    }
}
