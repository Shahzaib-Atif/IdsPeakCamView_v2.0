using ImageProcessingLibrary.Services;

namespace TriCamPylonView.UI
{
    public partial class ImageQualityForm : Form
    {
        public ImageQualityForm()
        {
            InitializeComponent();

            // update value in UI
            this.QualityIndex.Value = ImageProcessor.QualityIndex;

            // Select the numeric value
            this.QualityIndex.Focus();
            this.QualityIndex.Select(0, QualityIndex.Value.ToString().Length);
        }

        private void BtnSave_Click(object sender, EventArgs e) => SaveAndCloseForm();

        private void QualityIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveAndCloseForm();
        }

        private void SaveAndCloseForm()
        {
            // update static value in ImageProcessing 
            ImageProcessor.QualityIndex = (long)this.QualityIndex.Value;
            this.Close();
        }
    }
}
