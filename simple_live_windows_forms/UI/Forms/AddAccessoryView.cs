using ImageProcessingLibrary.Interfaces;

namespace simple_ids_cam_view.UI.Forms
{
    public partial class AddAccessoryView : Form, IAddAccessoryView
    {
        #region Properties
        public string ConnectorName => textBoxName.Text;
        public string ConnectorType => comboBoxTipo.Text;
        public string Reference => textBoxReference.Text;
        public bool ColorAssociated => checkBoxColorAssociated.Checked;
        #endregion

        #region UI Events
        public event EventHandler ViewLoaded;
        public event EventHandler ColorAssociatedChanged;
        public event EventHandler SaveRequested;
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

        public void SetAutoCompleteForConnNames(AutoCompleteStringCollection codivmacCollection)
        {
            textBoxName.AutoCompleteCustomSource = codivmacCollection;
            textBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void SwitchAutoCompleteSource(AutoCompleteStringCollection collection)
        {
            textBoxName.AutoCompleteCustomSource = collection;
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

        #endregion

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        public void CloseFormWithSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
