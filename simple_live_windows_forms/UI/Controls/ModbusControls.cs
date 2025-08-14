using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;

namespace simple_ids_cam_view.UI.Controls
{
    public partial class ModbusControls : UserControl
    {
        private ModbusDeviceController modbusController;

        public ModbusControls()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            modbusController = new();
            RefreshUI();
        }


        #region -- REFRESH UI --

        public void RefreshUI()
        {
            if (modbusController is null) return;

            // MODBUS LIGHTS
            UpdateLightsUI();

            // MOTOR
            ShowCurrentMotorPosition();

            // Update status indicators based on Modbus system states
            UpdateModbusStatusIndicators();
        }

        // Update status indicators based on Modbus system states
        private void UpdateModbusStatusIndicators()
        {
            StatusSystemError.BackColor = modbusController.SystemError ? Color.Maroon : Color.Green;
            StatusConnected.BackColor = modbusController.Connected ? Color.Green : Color.Maroon;
            StatusDoorClosed.BackColor = modbusController.DoorClosed ? Color.Green : Color.Maroon;
            StatusHomePosition.BackColor = modbusController.HomePosition ? Color.Green : Color.Maroon;
        }

        private void PictureBoxRefreshInfo_Click(object s, EventArgs e)
        {
            bool isSuccess = modbusController.ReadModbusValues();
            if (isSuccess)
            {
                this.RefreshUI();
                ExceptionHelper.ShowSuccessMessage("You are now viewing updated info!");
            }
        }

        #endregion


        #region -- MOTOR --

        // show current motor position
        private void ShowCurrentMotorPosition()
        {
            // first check if motor is at home position
            if (modbusController.HomePosition)
                textBoxCurrentPos.Text = "Home Position";

            // otherwise find & display the actual motor position
            else
            {
                int motorPosition = modbusController.MotorPosition;
                textBoxCurrentPos.Text = motorPosition switch
                {
                    1 => "Position 1",
                    4 => "Position 2",
                    16 => "Position 3",
                    _ => "Unkown",
                };
            }
        }

        private void ComboBoxMotorPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSuccess = ChangeMotorPosition(comboBoxMotorPos.SelectedItem.ToString());
            if (isSuccess) RefreshUI();
        }

        public bool ChangeMotorPosition(string position)
        {
            if (modbusController is null) return false;

            switch (position)
            {
                case CameraPositions.Position_1:
                    return modbusController.ChangeMotorPosition(1);
                case CameraPositions.Position_2:
                    return modbusController.ChangeMotorPosition(4);
                case CameraPositions.Position_3:
                    return modbusController.ChangeMotorPosition(16);
                default:
                    ExceptionHelper.ShowWarningMessage($"Unknown camera position selected: {position}");
                    return false;
            }
        }

        private void BtnResetSystem_Click(object sender, EventArgs e)
        {
            // confirm from user
            string message = "Are you sure you want to reset the system (go to home position)?";
            var result = DialogHelper.ShowYesNoDialog(message, "");

            if (result == DialogResult.Yes)
            {
                modbusController.ResetSystem_GoToHomePosition();

                // read values again and refresh UI
                bool isSuccess = modbusController.ReadModbusValues();
                if (isSuccess)
                    this.RefreshUI();
            }
        }

        #endregion


        #region -- LIGHTS --

        public void TurnOffLights()
        {
            if (modbusController.Connected)
                modbusController.ChangeLightsStatus(false);
        }

        /// <summary> Toggle lights on/off. Return true if lights are now on. </summary>
        public bool ToggleLights()
        {
            if (modbusController.LightsOn)
            {
                bool isSuccess = LightsOffClickHandler();
                if (isSuccess) return false; // lights successfully turned off
            }
            else
            {
                bool isSuccess = LightsOnClickHandler();
                if (isSuccess) return true; // lights successfully turned ON
            }

            return false;
        }

        private void UpdateLightsUI()
        {
            if (modbusController.LightsOn)
            {
                // disable lights On button
                BtnLightsOn.Enabled = false;
                BtnLightsOff.Enabled = true;
            }
            else
            {
                // disable lights Off button
                BtnLightsOn.Enabled = true;
                BtnLightsOff.Enabled = false;
            }
        }

        private void BtnLightsOn_Click(object sender, EventArgs e) => LightsOnClickHandler();

        private bool LightsOnClickHandler()
        {
            bool isSuccess = modbusController.ChangeLightsStatus(true);
            if (isSuccess) RefreshUI();

            return isSuccess;
        }

        private void BtnLightsOff_Click(object sender, EventArgs e) => LightsOffClickHandler();

        private bool LightsOffClickHandler()
        {
            bool isSuccess = modbusController.ChangeLightsStatus(false);
            if (isSuccess) RefreshUI();

            return isSuccess;
        }
        #endregion


        #region -- TIMER --

        public void StartTimer()
        {
            if (modbusController.Connected)
                timer1.Start();
        }

        public void StopTimer() => timer1.Stop();
        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool isSuccess = modbusController.ReadModbusValues();
            if (isSuccess)
                this.RefreshUI();
            else
            {
                ExceptionHelper.ShowWarningMessage("Auto update timer has stopped!");
                timer1.Stop();
            }
        }
        #endregion


        private void BtnClose_Click(object sender, EventArgs e) => this.Hide();
        public void DisconnectClient() => modbusController.DisconnectClient();
        public void ReconnectClient() => modbusController.ReconnectClient();
    }
}
