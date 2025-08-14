using simple_ids_cam_view.UI.Controls;

namespace simple_ids_cam_view.Services
{
    // CLASS OBJECTIVE: TOGGLE B/W CAMERA SETTINGS AND MODBUS SETTINGS PANEL
    internal class ControlPanelManager
    {
        private readonly AdjustSettings CameraSettingsPanel;
        private readonly ModbusControls ModbusControlsPanel;

        public ControlPanelManager(AdjustSettings CameraSettingsPanel, ModbusControls ModbusControlsPanel)
        {
            this.CameraSettingsPanel = CameraSettingsPanel;
            this.ModbusControlsPanel = ModbusControlsPanel;
        }

        public void ToggleCameraControlsPanel()
        {
            // this.Cursor = Cursors.WaitCursor;

            if (CameraSettingsPanel.Visible)
                ShowCameraSettingsPanel(false); // hide camera panel
            else
            {
                ShowCameraSettingsPanel(true); // show camera panel
                ShowModbusControlsPanel(false); // hide modbus panel
            }
            // this.Cursor = Cursors.Default;
        }

        public void ToggleModbusControlsPanel()
        {
            // this.Cursor = Cursors.WaitCursor;

            if (ModbusControlsPanel.Visible)
                ShowModbusControlsPanel(false); // hide modbus panel
            else
            {
                ShowModbusControlsPanel(true); // show modbus panel
                ShowCameraSettingsPanel(false); // hide camera panel
            }
            // this.Cursor = Cursors.Default;
        }

        private void ShowCameraSettingsPanel(bool state)
        {
            if (state is true)
            {
                CameraSettingsPanel.UpdateCameraSettingsValues();
                CameraSettingsPanel.Show();
            }
            else
            {
                CameraSettingsPanel.Hide();
            }
        }

        private void ShowModbusControlsPanel(bool state)
        {
            if (state is true)
            {
                ModbusControlsPanel.RefreshUI();
                ModbusControlsPanel.Show();
                ModbusControlsPanel.StartTimer();
            }
            else
            {
                ModbusControlsPanel.Hide();
                ModbusControlsPanel.StopTimer();
            }
        }
    }
}
