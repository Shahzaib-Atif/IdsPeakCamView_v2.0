using ImageProcessingLibrary;
using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view.UI.Controls
{
    /// <summary>
    /// FOCUS, EXPOSURE, GAIN use a predefined user control
    /// only white balance is implemented here
    /// </summary>
    public partial class AdjustSettings : UserControl
    {
        private BackEnd backEnd;

        public AdjustSettings()
        {
            InitializeComponent();
            this.Hide(); // initially hide the panel
            this.DoubleBuffered = true;

            GbxWhiteBalance.Click += (object s, EventArgs e) => this.labelAuto.Focus();
        }

        /// <summary> Set backend and attach event handlers </summary>
        internal void Initialize(BackEnd backEnd)
        {
            this.backEnd = backEnd;
            AttachCameraSettingsListeners();

            //backEnd.SetGainMode(AutoMode.Off);
            //backEnd.SetGainValue(ProjectSettings.GainValue);
            // initialize gain UI
            synchronizedGain.InitializeAutomodeUI(AutoMode.Off);

            //backEnd.SetExposureMode(AutoMode.Off);
            //backEnd.SetExposureValue(ProjectSettings.ExposureValue);
            // initialize exposure UI
            synchronizedExposure.InitializeAutomodeUI(AutoMode.Off);
        }

        private void AttachCameraSettingsListeners()
        {
            synchronizedExposure.ValueChanged += ExposureValueChanged;
            synchronizedExposure.AutoModeChanged += ExposureAutoModeChanged;
            synchronizedGain.ValueChanged += GainValueChanged;
            synchronizedGain.AutoModeChanged += GainAutoModeChanged;
            synchronizedFocus.ValueChanged += FocusValueChanged;
            synchronizedFocus.AutoModeChanged += FocusAutoModeChanged;
        }

        #region -- EXPOSURE
        private void ExposureValueChanged(int val) => backEnd.SetExposureValue(val);
        private void ExposureAutoModeChanged(string val)
        {
            this.Cursor = Cursors.WaitCursor;

            backEnd.SetExposureMode(val);
            if (val == AutoMode.Off) // update exposure value
            {
                double exposureTime = backEnd.GetExposureValue();
                synchronizedExposure.SetValue(exposureTime);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region -- GAIN
        private void GainValueChanged(int val) => backEnd.SetGainValue(val);
        private void GainAutoModeChanged(string val)
        {
            this.Cursor = Cursors.WaitCursor;

            backEnd.SetGainMode(val);
            if (val == AutoMode.Off)
            {
                // update gain value
                double gain = backEnd.GetGainValue();
                synchronizedGain.SetValue(gain);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region -- FOCUS
        private void FocusValueChanged(int val) => backEnd.SetFocusValue(val);
        private void FocusAutoModeChanged(string val)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                backEnd.SetFocusMode(val);
                if (val == AutoMode.Off)
                {
                    // update focus value
                    double focus = backEnd.GetFocusValue();
                    synchronizedFocus.SetValue(focus);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void BtnClose_Click(object sender, EventArgs e) => this.Hide();


        #region -- WHITE BALANCE
        private void WhiteBalanceAutoModeChanged(string mode)
        {
            if (backEnd is null) return;

            this.Cursor = Cursors.WaitCursor;
            backEnd.SetWhiteBalanceMode(mode);
            this.Cursor = Cursors.Default;
        }

        private void WhiteBalanceOffBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (WhiteBalanceOffBtn.Checked)
            {
                WhiteBalanceOnBtn.Checked = false;
                WhiteBalanceAutoModeChanged("Off");
            }
        }

        private void WhiteBalanceOnBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (WhiteBalanceOnBtn.Checked)
            {
                WhiteBalanceOffBtn.Checked = false;
                WhiteBalanceAutoModeChanged("Continuous");
            }
        }
        #endregion

        internal void UpdateCameraSettingsValues()
        {
            if (backEnd is null) return;

            // update exposure
            double exposureTime = backEnd.GetExposureValue();
            synchronizedExposure.SetValue(exposureTime);

            // update gain
            double gain = backEnd.GetGainValue();
            synchronizedGain.SetValue(gain);

            // update gain
            double focus = backEnd.GetFocusValue();
            synchronizedFocus.SetValue(focus);
        }

        internal void SaveGainAndExposureValues()
        {
            if (backEnd is null) return;

            // save gain values
            ProjectSettings.GainValue = synchronizedGain.Value;
            ProjectSettings.GainAutoMode = backEnd.GetGainMode();

            ProjectSettings.ExposureValue = synchronizedExposure.Value;
            ProjectSettings.ExposureAutoMode = backEnd.GetExposureMode();
        }
    }
}
