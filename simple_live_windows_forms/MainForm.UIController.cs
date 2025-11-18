using ImageProcessingLibrary.Models;

namespace simple_ids_cam_view
{
    partial class MainForm
    {
        // enable or disable the start, stop, etc., buttons
        private void EnableButtons(bool enable)
        {
            StopAcquisitionBtn.Enabled = !enable;
            CameraSettingsMenuItem.Enabled = !enable;
            CrosshairBtn.Enabled = !enable;

            hardwareSettingsMenuItem.Enabled = enable;
            StartAcquisitionBtn.Enabled = enable;
            SingleAcquisitionBtn.Enabled = enable;
            CropBtn.Enabled = enable;
            EditTextBtn.Enabled = enable;
            customPictureBox?.MakeEditTextVisible(enable);
            SaveFinalImageBtn.Enabled = enable;
            FindSimilarImgsBtn.Enabled = enable;
            SaveToDbBtn.Enabled = enable;
            UseCurrentImageCheckbox.Enabled = enable;
            AddAccessoryBtn.Enabled = enable;
        }

        // manage text editing
        private void HandleEditText()
        {
            if (!IsImageAvailable())
                return;

            TextAppearanceStruct textAppearance = customPictureBox.GetDescriptionDetails();
            using var f = new EditTextForm(textAppearance);
            //f.TopMost = true;
            if (f.ShowDialog() == DialogResult.OK)
                customPictureBox.UpdateDescription(f.TextAppearanceStruct);
        }

        // toggle crosshair on or off
        private void ToggleCrosshair(bool forcedOff = false)
        {
            // toggle crosshair
            bool isCrosshairDisplayed = this.customPictureBox.ToggleCrosshair(forcedOff);

            // change backcolor of button depending on the state of crosshair
            CrosshairBtn.BackColor = isCrosshairDisplayed ? SystemColors.ButtonHighlight : SystemColors.ControlLight;
        }
    }
}
