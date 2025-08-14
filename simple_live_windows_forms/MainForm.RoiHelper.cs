using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using simple_ids_cam_view.UI.Forms;

namespace simple_ids_cam_view
{
    partial class MainForm
    {
        private void EnterCropMode()
        {
            string filepath = SaveBackgroundImage("background.jpeg");
            if (string.IsNullOrEmpty(filepath)) return;

            SetCropModeUI(filepath);
            InitializeRoiService();
        }

        private void SetCropModeUI(string filepath)
        {
            customPictureBox.ChangePanelVisibility(isVisible: true);
            customPictureBox.MyPanel.BackgroundImage = Image.FromFile(filepath);

            CropBtn.BackColor = SystemColors.GradientActiveCaption;
            CropBtn.Enabled = false;
            this.Cursor = Cursors.Cross;
        }

        private void InitializeRoiService()
        {
            var roiService = new RoiService(this.customPictureBox);
            roiService.MouseSelectionEnded += MouseSelectionEnded_Handler;
            previousImageCropService = roiService;
        }

        private void EnterResetMode()
        {
            this.Cursor = Cursors.WaitCursor;
            ImageRoiStruct.ResetValues();
            IsRoiModified = false;

            SetCropBtnProperties("Update ROI", true, SystemColors.ControlLight);
            StartAcquisition();
            Reset_Cursor();
        }

        private void LeaveCropMode()
        {
            IsRoiModified = false;
            Reset_Cursor();
            SetCropBtnProperties("Update ROI", true, SystemColors.ControlLight);

            // Disconnect the previous service
            if (previousImageCropService is not null)
            {
                previousImageCropService.IsServiceValid = false;
                previousImageCropService.MouseSelectionEnded -= MouseSelectionEnded_Handler;
            }
        }

        private void MouseSelectionEnded_Handler(object s, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SetCropBtnProperties("Reset Original", true, SystemColors.ControlLight);
            IsRoiModified = true;

            StartAcquisition();
            Reset_Cursor();
        }

        private void SetCropBtnProperties(string text, bool enabled, Color backColor)
        {
            CropBtn.Text = text;
            CropBtn.Enabled = enabled;
            CropBtn.BackColor = backColor;
        }

        private void Reset_Cursor() => this.Cursor = Cursors.Default;

        // it saves a background image with low quality to be used later in cropping
        private string SaveBackgroundImage(string name)
        {
            if (!IsImageAvailable())
                return null;

            // check if the directory is correct
            if (FileHelper.IsDefaultFolderUpdateRequired())
            {
                using var f = new DefaultFolderForm();
                //f.TopMost = true;
                f.ShowDialog();
            }

            // return if the directory still does not exist for the default folder
            if (!Directory.Exists(ProjectSettings.DefaultFolder))
            {
                ExceptionHelper.ShowDefaultFolderNotFoundWarning();
                return null;
            }

            // get default save location
            string filePath = Path.Combine(ProjectSettings.DefaultFolder, name);

            // get image
            if (customPictureBox.Image is null) return null;
            using var _image = new Bitmap(customPictureBox.Image);

            // save image after processing
            ImageProcessor.SaveBackgroundImage(_image, filePath);

            return filePath;
        }

    }
}
