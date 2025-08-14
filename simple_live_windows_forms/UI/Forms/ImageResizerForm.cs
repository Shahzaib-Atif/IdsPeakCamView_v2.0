using ImageProcessingLibrary.Services;

namespace TriCamPylonView.UI.Forms
{
    public partial class ImageResizerForm : Form
    {
        public ImageResizerForm()
        {
            InitializeComponent();

            // update value in UI
            this.ResizeFactor.Value = (decimal)ImageProcessor.ResizeFactor;
        }

        private void BtnSave_Click(object sender, EventArgs e) => SaveAndCloseForm();

        private void ResizeFactor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveAndCloseForm();
        }

        private void SaveAndCloseForm()
        {
            // update static value in ImageProcessing 
            ImageProcessor.ResizeFactor = (double)this.ResizeFactor.Value;
            this.Close();
        }
    }
}
