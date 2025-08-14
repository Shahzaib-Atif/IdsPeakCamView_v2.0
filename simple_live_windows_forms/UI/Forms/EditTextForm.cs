using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view
{
    public partial class EditTextForm : Form
    {
        public TextAppearanceStruct TextAppearanceStruct { get; set; }

        public EditTextForm(TextAppearanceStruct textAppearance)
        {
            InitializeComponent();

            // update UI properties
            textBox.Text = textAppearance.TextDescription;
            UpdateColors(textAppearance.TextColor);
            UpdateFonts(textAppearance.TextFont);
        }


        // --------------------- //
        #region Event Handlers
        private void SelectColorBtn_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                UpdateColors(colorDialog.Color);
        }

        private void SelectFontBtn_Click(object sender, EventArgs e)
        {
            using FontDialog fontDialog = new();
            if (fontDialog.ShowDialog() == DialogResult.OK)
                UpdateFonts(fontDialog.Font);
        }

        // close the form when escape key is pressed
        private void ImageDescriptionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //TextDescription = textBox.Text; // other properties like font & color are updated in their event handlers
            this.TextAppearanceStruct = new TextAppearanceStruct(
                textBox.Text, lblSampleText.Font, showColorPanel.BackColor);
            this.DialogResult = DialogResult.OK;
        }
        #endregion


        // update colors wherever required
        private void UpdateColors(Color color)
        {
            showColorPanel.BackColor = color;
            textBox.ForeColor = color;
            lblSampleText.ForeColor = color;
            //TextColor = color;
        }

        // update fonts wherever required
        private void UpdateFonts(Font font)
        {
            lblSampleText.Font = font;
            textBox.Font = font;
            //TextFont = font;
        }
    }
}
