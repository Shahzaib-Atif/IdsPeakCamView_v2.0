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

        #endregion

        #region Properties (Presenter reads from View)

        // Sample Details Properties
        public string PosId => textBoxPosId.Text;
        public string Tipo => comboBoxTipo.Text;
        public string CorValue => comboBoxCor.SelectedValue?.ToString();
        public string ViasValue => comboBoxVias.SelectedValue?.ToString();
        public int Quantity => (int)numUpDownQty.Value;
        public int Family => (int)numUpDownFamily.Value;
        public decimal InternalDiameter => numericIntDia.Value;
        public decimal ExternalDiameter => numericExtDia.Value;
        public decimal Thickness => numericThickness.Value;

        // Additional Properties
        public string Fabricante => comboBoxManufact.SelectedValue?.ToString();
        public string Refabricante => textBoxRefManufact.Text;
        public string Designação => textBoxDesignation.Text;
        public string OBS => textBoxOBS.Text;
        public string ClipColor => comboBoxClipColor.SelectedValue?.ToString();
        public string CapotAngle => comboBoxCapotAngles.Text;

        // Component Checkboxes
        public bool Clip => checkBoxClip.Checked;
        public bool Spacer => checkBoxSpacer.Checked;
        public bool Tampa => checkBoxCapot.Checked;
        public bool Vedante => checkBoxVedante.Checked;
        public bool Mola => checkBoxMola.Checked;
        public bool Moldagem => checkBoxMoldagem.Checked;
        public bool Travão => checkBoxTravao.Checked;
        public bool Abracadeira => checkBoxAbracadeira.Checked;
        public bool Linguetes => checkBoxLinguetes.Checked;
        public bool Outros => checkBoxOutros.Checked;
        public bool Amostra => checkBoxSamplePanel.Checked;
        public bool Olhal => checkBoxOlhal.Checked;

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

        public void PopulateClipColorComboBox(List<KeyValue> items)
        {
            comboBoxClipColor.Items.Clear();
            comboBoxClipColor.DisplayMember = "Key";
            comboBoxClipColor.ValueMember = "Value";
            // clone the list to avoid data source issues
            comboBoxClipColor.DataSource = new List<KeyValue>(items);
        }

        public void PopulateCapotAngleComboBox(List<string> items)
        {
            comboBoxCapotAngles.Items.Clear();
            comboBoxCapotAngles.DisplayMember = "Key";
            comboBoxCapotAngles.ValueMember = "Value";
            comboBoxCapotAngles.DataSource = items;
        }

        public void PopulateFabricanteComboBox(List<string> items)
        {
            comboBoxManufact.Items.Clear();
            comboBoxManufact.DisplayMember = "Key";
            comboBoxManufact.ValueMember = "Value";
            comboBoxManufact.DataSource = items;
        }

        public void ShowDiameterSection(bool state = true)
        {
            gbxDiameter.Visible = state;
        }

        public void ShowClipColorSection(bool state = true)
        {
            gbxClipColor.Visible = state;
        }

        public void ShowCapotAngleSection(bool state = true)
        {
            gbxCapotAngle.Visible = state;
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
