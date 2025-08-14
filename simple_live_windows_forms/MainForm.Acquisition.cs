namespace simple_ids_cam_view
{
    partial class MainForm
    {
        // start Acquisition
        private void StartAcquisition()
        {
            if (backEnd is not null)
            {
                // start backend
                backEnd.InitializeBackend();
                backEnd.Start();

                // update UI options
                EnableButtons(false);

                customPictureBox.ChangePanelVisibility(isVisible: false);
                customPictureBox.MyPanel.BackgroundImage?.Dispose();
                customPictureBox.MyPanel.BackgroundImage = null;
            }
        }

        // stop Acquisition
        private void StopAcquisition()
        {
            if (backEnd is null) return;
            this.Cursor = Cursors.WaitCursor;

            // turn off the crosshair
            ToggleCrosshair(forcedOff: true);

            // save the gain and exposure values for next iteration
            CameraSettingsPanel.SaveGainAndExposureValues();

            // stop the backend and adjust UI
            backEnd.Stop();
            EnableButtons(true); // toggle certain button visibilites
            CameraSettingsPanel.Hide(); // hide the camera settings

            this.Cursor = Cursors.Default;
        }

        // single Acquisition
        private void SingleAcquisition()
        {
            this.Cursor = Cursors.WaitCursor;
            backEnd.InitializeBackend();
            backEnd.acquisitionWorker.isSingleAcquisition = true;
            backEnd.Start();

            // Wait for the thread to finish
            backEnd.acquisitionThread.Join();

            backEnd.Stop();
            this.Cursor = Cursors.Default;
        }

    }
}
