using ImageProcessingLibrary.Models;
using static ImageProcessingLibrary.Models.SimilarityThresholds;

namespace TriCamPylonView.UI.Forms
{
    public partial class ThresholdControlPanel : Form
    {
        private SimilarityThresholds InitialValues { get; set; } = new();

        public ThresholdControlPanel()
        {
            InitializeComponent();
        }


        // --------------------- //
        #region Event Handlers

        // Loads the trackbar values from constants when the form is loaded.
        private void ThresholdControlPanel_Load(object s, EventArgs e)
        {
            UpdateInitialValues();
            UpdateTrackbars();
        }

        private void UpdateInitialValues()
        {
            InitialValues.Hist = Thresholds.Hist;
            InitialValues.Akaze = Thresholds.Akaze;
            InitialValues.Orb = Thresholds.Orb;
            InitialValues.Gftt = Thresholds.Gftt;
            InitialValues.FastFeature = Thresholds.FastFeature;
            InitialValues.ImageHash = Thresholds.ImageHash;
        }


        // Saves the current trackbar values into constants (configuration settings).
        private void BtnSave_Click(object s, EventArgs e)
        {
            UpdateThresholdConstants();

            this.DialogResult = DialogResult.OK;
        }


        // Updates the group box text with the current value of the trackbar.
        private void SimilarityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var trackBar = (TrackBar)sender;

            if (trackBar.Parent is GroupBox groupBox && trackBar.Tag != null)
                groupBox.Text = $"{trackBar.Tag} --- [{trackBar.Value}]";
        }

        private void RestoreDefaultBtn_Click(object s, EventArgs e)
        {
            SimilarityThresholds.RestoreDefaults();
            UpdateTrackbars();
        }

        private void ResetToZeroBtn_Click(object sender, EventArgs e)
        {
            SimilarityThresholds.ResetToZero();
            UpdateTrackbars();
        }

        private void ThresholdControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                Thresholds = InitialValues; // discard all changes
        }

        #endregion



        // Update the trackbar values
        private void UpdateTrackbars()
        {
            histSimilarityTrackBar.Value = Thresholds.Hist;
            akazeSimilarityTrackBar.Value = Thresholds.Akaze;
            orbSimilarityTrackBar.Value = Thresholds.Orb;
            gfttSimilarityTrackBar.Value = Thresholds.Gftt;
            fastFeatureSimilarityTrackBar.Value = Thresholds.FastFeature;
            imageHashSimilarityTrackBar.Value = Thresholds.ImageHash;
        }


        // Save current trackbar values into constants or configuration
        private void UpdateThresholdConstants()
        {
            Thresholds.Hist = histSimilarityTrackBar.Value;
            Thresholds.Akaze = akazeSimilarityTrackBar.Value;
            Thresholds.Orb = orbSimilarityTrackBar.Value;
            Thresholds.Gftt = gfttSimilarityTrackBar.Value;
            Thresholds.FastFeature = fastFeatureSimilarityTrackBar.Value;
            Thresholds.ImageHash = imageHashSimilarityTrackBar.Value;
        }


    }
}
