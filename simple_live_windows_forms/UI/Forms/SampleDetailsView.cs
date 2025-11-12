using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class SampleDetailsView : Form, ISampleDetailsView
    {
        #region Events (View -> Presenter)

        public event EventHandler ViewLoaded;
        public event EventHandler SaveRequested;
        public event EventHandler TipoChanged;
        public event EventHandler PosIdTextChanged;

        #endregion

        #region Properties (Presenter reads from View)

        public string PosId => textBoxPosId.Text;
        public string Tipo => comboBoxTipo.Text;
        public string CorValue => comboBoxCor.SelectedValue?.ToString();
        public string ViasValue => comboBoxVias.SelectedValue?.ToString();
        public decimal InternalDiameter => numericIntDia.Value;
        public decimal ExternalDiameter => numericExtDia.Value;
        public decimal Thickness => numericThickness.Value;

        #endregion

        public SampleDetailsView()
        {
            InitializeComponent();
            InitializeView();
        }
        private void InitializeView()
        {
            // Hook up form events
            this.Load += SampleDetailsView_Load;
        }

        #region ISampleDetailsView Implementation (Presenter -> View)

        public void SetPosIdAutoComplete(IEnumerable<string> posIds)
        {
            var myCollection = new AutoCompleteStringCollection();
            myCollection.AddRange(posIds.ToArray());

            textBoxPosId.AutoCompleteCustomSource = myCollection;
            textBoxPosId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxPosId.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        public void PopulateTipoComboBox(List<KeyValue> items)
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.DisplayMember = "Key";
            comboBoxTipo.ValueMember = "Value";
            comboBoxTipo.DataSource = items;
        }

        public void PopulateCorComboBox(List<KeyValue> items)
        {
            comboBoxCor.Items.Clear();
            comboBoxCor.DisplayMember = "Key";
            comboBoxCor.ValueMember = "Value";
            comboBoxCor.DataSource = items;
        }

        public void PopulateViasComboBox(List<KeyValue> items)
        {
            comboBoxVias.Items.Clear();
            comboBoxVias.DisplayMember = "Key";
            comboBoxVias.ValueMember = "Value";
            comboBoxVias.DataSource = items;
        }

        public void ShowDiameterSection()
        {
            gbxDiameter.Visible = true;
        }

        public void HideDiameterSection()
        {
            gbxDiameter.Visible = false;
        }

        public void SetPosIdBackColorNormal()
        {
            textBoxPosId.BackColor = SystemColors.Window;
        }

        public void SetTipoBackColorNormal()
        {
            comboBoxTipo.BackColor = SystemColors.Window;
        }

        public void ShowWaitCursor()
        {
            this.Cursor = Cursors.WaitCursor;
        }

        public void ShowDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }

        public DialogResult ShowYesNoDialog(string message, string title)
        {
            return DialogHelper.ShowYesNoDialog(message, title);
        }

        public DialogResult ShowNewPositionForm(string posId)
        {
            using var saveForm = new NewPositionForm(posId);
            return saveForm.ShowDialog();
        }

        public void CloseFormWithSuccess(SampleDetail sampleDetails)
        {
            // Store the result (needed for caller to access)
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion


        #region UI Event Handlers (View -> Presenter)

        private void SampleDetailsView_Load(object sender, EventArgs e)
        {
            // Notify presenter that view is loaded
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Just raise event - presenter handles logic
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Just raise event - presenter handles logic
            TipoChanged?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxPosId_Leave(object sender, EventArgs e)
        {
            // Just raise event - presenter handles logic
            PosIdTextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxPosId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent default beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                e.SuppressKeyPress = false;
            }
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

        #endregion
    }
}
