using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Services;
using simple_ids_cam_view.Services;
using simple_ids_cam_view.UI.Forms;
using System.Diagnostics;
using TriCamPylonView.UI;
using TriCamPylonView.UI.Forms;

namespace simple_ids_cam_view
{
    public partial class MainForm : Form
    {
        private readonly BackEnd backEnd; // for handling camera related functionality
        private readonly BackgroundWorkerService backgroundWorkerService; // related to image comparison
        private readonly ImageStorageService imageStorageService; // related to image storage
        private readonly ImageProcessorService imageProcessorService;
        private readonly ControlPanelManager controlPanelManager; // for toggling camera and modbus controls

        private bool IsRoiModified { get; set; } = false;
        private bool IsUsingCurrentImage { get; set; } = true;
        private RoiService previousImageCropService; // Keep a reference to the previous service

        public MainForm()
        {
            // stay at the top, initially
            this.TopMost = true;

            Debug.WriteLine("--- [MainForm] Init");
            InitializeComponent();
            DoubleBuffered = true;

            backgroundWorkerService = new(customPictureBox, progressBar, gbxProgress);
            imageStorageService = new(customPictureBox, GbxShowLoading, LabelConnectorName);
            imageProcessorService = new ImageProcessorService();
            controlPanelManager = new(CameraSettingsPanel, ModbusControlsPanel);
            backEnd = new();
            SettingsManager.LoadInitialSettings();

            FormClosing += FormWindow_FormClosing;

            backEnd.ImageReceived += BackEnd_ImageReceived;
            backEnd.CounterChanged += BackEnd_CounterChanged;
            backEnd.MessageBoxTrigger += BackEnd_MessageBoxTrigger;

            // no need of staying at the top later on
            this.TopMost = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // initialize Modbus controls
                ModbusControlsPanel.Initialize();

                // initialize Camera controls
                if (backEnd.Start())
                    CameraSettingsPanel.Initialize(this.backEnd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("--- [FormWindow] Exception: " + ex.Message);
                BackEnd_MessageBoxTrigger(this, "Exception", ex.Message);
            }
        }

        #region -- Event Handlers
        private void BackEnd_ImageReceived(object sender, Bitmap image)
        {
            try
            {
                customPictureBox.Image = image;
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [FormWindow] Exception: " + e.Message);
                BackEnd_MessageBoxTrigger(this, "Exception", e.Message);
            }
        }

        private void BackEnd_CounterChanged(object sender, uint frameCounter, uint errorCounter)
        {
            if (counterLabel.InvokeRequired)
                counterLabel.BeginInvoke((MethodInvoker)delegate { counterLabel.Text = "Frames acquired: " + frameCounter + ", errors: " + errorCounter; });
        }

        private void BackEnd_MessageBoxTrigger(object sender, string messageTitle, string messageText)
        {
            MessageBox.Show(messageText, messageTitle);
        }

        private void FormWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("--- [FormWindow] Closing");

            // stop backend
            try
            {
                if (backEnd.acquisitionWorker.IsRunning)
                    backEnd.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // disconnect modbus & turn off lights
            ModbusControlsPanel.TurnOffLights();
            ModbusControlsPanel.DisconnectClient();
        }

        private void StartAcquisitionBtn_Click(object s, EventArgs e) => StartAcquisition();

        private void StopAcquisitionBtn_Click(object s, EventArgs e) => StopAcquisition();

        private void SingleAcquisitionBtn_Click(object s, EventArgs e) => SingleAcquisition();

        private void UpdateRoiBtn_Click(object s, EventArgs e)
        {
            try
            {
                if (!IsRoiModified)
                    EnterCropMode();
                else
                    EnterResetMode();
            }
            catch
            {
                ExceptionHelper.DisplayErrorMessage("Something went wrong while changing ROI!");
            }
        }

        private void EditTextBtn_Click(object s, EventArgs e) => HandleEditText();

        private void SaveFinalImageBtn_Click(object s, EventArgs e)
        {
            //SaveFinalImage();
        }

        private async void SaveOriginalImageMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // No camera image -→ skip
                if (!IsImageAvailable()) return;
                await imageStorageService.SaveExtraImage();
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        private async void SaveToDbBtn_ClickAsync(object s, EventArgs e)
        {
            try
            {
                bool isSuccess = await imageStorageService.SaveConnectorToDB();
                this.GbxShowLoading.Visible = false;
            }
            catch (Exception ex)
            {
                this.GbxShowLoading.Visible = false;
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        private async void AddAccessoryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //await SaveAccessoryToDB();
                await imageStorageService.SaveAccessoryToDB();
                this.GbxShowLoading.Visible = false;
            }
            catch (Exception ex)
            {
                this.GbxShowLoading.Visible = false;
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }


        private void FindImagesBtn_Click(object s, EventArgs e)
        {
            try
            {
                if (IsUsingCurrentImage && !IsImageAvailable()) return; // if camera mode for searching selected + No camera image -→ skip
                else this.backgroundWorkerService.FindSimilarImages(this.IsUsingCurrentImage); // else proceed with the search
            }
            catch (Exception ex)
            {
                this.GbxShowLoading.Visible = false;
                this.Cursor = Cursors.Default; // reset cursor
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        private void ImageQualityMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new ImageQualityForm(); //f.TopMost = true;
            f.ShowDialog();
        }

        private void ImageSizeMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new ImageResizerForm();
            //f.TopMost = true;
            f.ShowDialog();
        }

        private void ImageSimilarityMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new ThresholdControlPanel();            //f.TopMost = true;
            f.ShowDialog();
        }

        private void DefaultFolderMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new DefaultFolderForm();            //f.TopMost = true;
            f.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                LeaveCropMode();
        }

        private void UseCurrentImage_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkbox)
                IsUsingCurrentImage = checkbox.Checked;
        }

        private void AddImagesToDBMenuItem_Click(object s, EventArgs e)
        {
            backgroundWorkerService.Start("UploadImageFeaturesToDB", null, AddImagesToDbFromFolder: true);
        }

        private void AdjustSettingsBtn_Click(object sender, EventArgs e)
        {
            this.controlPanelManager.ToggleCameraControlsPanel();
        }

        private void DeleteImageMenuItem_Click(object s, EventArgs e) => this.imageStorageService.DeleteImage();

        private void ModbusConfigMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new ModbusConfigForm();
            //f.TopMost = true;
            if (f.ShowDialog() == DialogResult.OK && f.SettingsChanged)
                ModbusControlsPanel.ReconnectClient();
        }

        private void ChangeDatabaseSettingsMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new UserCredentialsForm();
            f.ShowDialog();
        }

        private void ModbusControlsBtn_Click(object sender, EventArgs e)
        {
            this.controlPanelManager.ToggleModbusControlsPanel();
        }

        private void CrosshairBtn_Click(object sender, EventArgs e)
        {
            ToggleCrosshair();
        }


        private void LightsBtn_Click(object sender, EventArgs e)
        {
            // toggle lights state
            bool isLightsOn = ModbusControlsPanel.ToggleLights();

            // change the back color
            LightsBtn.BackColor = isLightsOn ? Color.LightGoldenrodYellow : SystemColors.ControlLight;
        }

        private void MotorPositionBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string newPosition = e.ClickedItem.Text;
            bool isSuccess = ModbusControlsPanel.ChangeMotorPosition(newPosition);

            if (isSuccess)
                ModbusControlsPanel.RefreshUI();
        }

        // Remove the Close button while keeping the title bar
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        const int CS_NOCLOSE = 0x200;
        //        cp.ClassStyle |= CS_NOCLOSE;
        //        return cp;
        //    }
        //}

        /// <summary> Return true if image exists; otherwise show warning </summary>
        private bool IsImageAvailable()
        {
            if (customPictureBox.Image is null)
            {
                ExceptionHelper.ShowWarningMessage("No Image Found!");
                return false;
            }
            return true;
        }
        #endregion
    }
}
