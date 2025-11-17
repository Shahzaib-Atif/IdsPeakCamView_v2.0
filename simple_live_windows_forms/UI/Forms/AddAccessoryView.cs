using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class AddAccessoryView : Form, IAddAccessoryView
    {
        #region Properties
        public string ConnectorName => textBoxName.Text;
        public string ConnectorType => comboBoxTipo.Text;
        public string Reference => textBoxReference.Text;
        public string RefDV => textBoxRefDV.Text;
        public bool ColorAssociated => checkBoxColorAssociated.Checked;
        public string CapotAngle => comboBoxCapotAngle.Text;
        public string ClipColor => comboBoxClipColor.SelectedValue?.ToString();
        public int Quantity => (int)numUpDownQty.Value;
        #endregion

        #region UI Events
        public event EventHandler ViewLoaded;
        public event EventHandler ColorAssociatedChanged;
        public event EventHandler SaveRequested;
        public event EventHandler TipoChanged;
        #endregion

        public AddAccessoryView()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            // Hook up form events
            this.Load += AddAccessoryView_Load;
        }

        #region -- View Implementation
        public void PopulateTipoComboBox(IEnumerable<string> items)
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.DataSource = items;
        }

        public void SetAutoCompleteForConnNames(AutoCompleteStringCollection collection)
        {
            textBoxName.AutoCompleteCustomSource = collection;
            textBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void PopulateClipColorComboBox(IEnumerable<KeyValue> items)
        {
            comboBoxClipColor.Items.Clear();
            comboBoxClipColor.DisplayMember = "Key";
            comboBoxClipColor.ValueMember = "Value";
            comboBoxClipColor.DataSource = items;
        }

        public void PopulateCapotAngleComboBox(IEnumerable<string> items)
        {
            comboBoxCapotAngle.Items.Clear();
            comboBoxCapotAngle.DataSource = items;
        }

        public void SwitchAutoCompleteSource(AutoCompleteStringCollection collection)
        {
            textBoxName.AutoCompleteCustomSource = collection;
        }

        public void ToggleCapotAngleVisibility(bool show)
        {
            gbxCapotAngle.Visible = show;
        }

        public void ToggleClipColorVisibility(bool show)
        {
            gbxClipColor.Visible = show;
        }

        public void CloseFormWithSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region -- UI Events Handlers   
        private void AddAccessoryView_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void checkBoxColorAssociated_CheckedChanged(object sender, EventArgs e)
        {
            ColorAssociatedChanged?.Invoke(this, EventArgs.Empty);
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
