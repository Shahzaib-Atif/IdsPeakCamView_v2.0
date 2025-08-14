using EasyModbus;
using ImageProcessingLibrary.Helpers;
using static ImageProcessingLibrary.ProjectSettings;

namespace ImageProcessingLibrary.Services
{
    public class ModbusDeviceController
    {
        public bool Connected { get; private set; } // modbus connection
        public bool LightsOn { get; private set; }
        public bool SystemError { get; private set; }
        public bool HomePosition { get; private set; }
        public bool DoorClosed { get; private set; }
        public int MotorPosition { get; set; }
        private ModbusClient? client;

        public ModbusDeviceController()
        {
            // set default values
            LightsOn = false;
            MotorPosition = 0;

            // initialize ModbusClient
            if (ConnectClient(showWarningMsg: false))
                ReadModbusValues();
        }

        private bool ConnectClient(bool showWarningMsg = true)
        {
            try
            {
                client = new ModbusClient(ModbusIpAddress, ModbusPort);
                client.Connect();
                Connected = true;
                return true;
            }
            catch (Exception ex)
            {
                if (showWarningMsg)
                    ExceptionHelper.ShowWarningMessage($"Modbus Error: {ex.Message}");
                DisconnectClient();
                return false;
            }
        }

        public bool ReadModbusValues()
        {
            try
            {
                if (!CheckModbusConnection())
                    return false;

                LightsOn = ReadLightsStatusFromDevice();
                MotorPosition = ReadMotorPositionFromDevice();

                SystemError = ReadBit(D7000Bits.SystemError);
                DoorClosed = ReadBit(D7000Bits.DoorStatus);
                HomePosition = ReadBit(D7000Bits.HomePosition);

                Connected = true;
                return true;
            }
            catch
            {
                ExceptionHelper.DisplayErrorMessage("Error: Cannot read Modbus values");
                Connected = false;
                return false;
            }
        }

        public bool ChangeLightsStatus(bool lightsOn)
        {
            if (!CheckModbusConnection())
                return false;

            try
            {
                WriteBit(D7002Bits.Lights, lightsOn);

                // update the public field
                this.LightsOn = lightsOn;

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return false;
            }
        }

        public bool ChangeMotorPosition(int motorPosition)
        {
            // change motor position if it is between 1 and 16
            if (motorPosition >= 1 && motorPosition <= 16)
            {
                return WriteToDevice(motorPosition);
            }
            else
            {
                ExceptionHelper.ShowWarningMessage($"Unknown position value specified: {motorPosition}");
                return false;
            }
        }

        // go to home position
        public void ResetSystem_GoToHomePosition()
        {
            if (!CheckModbusConnection(showWarning: false))
                return;

            WriteBit(D7001Bits.ResetSystem, true);
        }

        public void ReconnectClient()
        {
            DisconnectClient();
            ConnectClient();

            if (this.Connected)
            {
                ReadModbusValues();
                ExceptionHelper.ShowSuccessMessage("Modbus connected!");
            }
            else
                ExceptionHelper.ShowWarningMessage("Modbus connection failed!");
        }

        public void DisconnectClient()
        {
            if (client is not null && client.Connected)
                client.Disconnect();

            Connected = false;
        }

        // Communicate MOTORS data
        private bool WriteToDevice(int motorPos)
        {
            if (!CheckModbusConnection())
                return false;

            try
            {
                int[] vals = { motorPos };

                client!.WriteMultipleRegisters(1, vals);

                // update the public field
                this.MotorPosition = motorPos;

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// read Lights status from the device
        /// </summary>
        private bool ReadLightsStatusFromDevice()
        {
            if (!CheckModbusConnection())
                return false;

            int[] regs = client!.ReadHoldingRegisters(2, 1);

            // return true if value is greater than 0
            return regs[0] > 0;
        }

        /// <summary> read feedback position from the device. </summary>
        private short ReadMotorPositionFromDevice()
        {
            if (!CheckModbusConnection())
                return 100; // return out of range value

            int[] regs = client!.ReadHoldingRegisters(0, 1);
            //return (short)regs[0];
            return (short)(regs[0] & 0b00011111); // Masking the first 5 bits (0-4)
        }

        /// <summary> Returns true if Modbus is connected. </summary>
        private bool CheckModbusConnection(bool showWarning = true)
        {
            if (client is null || !client.Connected)
            {
                if (showWarning)
                    ExceptionHelper.ShowWarningMessage("Modbus not connected!");
                Connected = false;
                return false;
            }
            else
            {
                Connected = true;
                return true;
            }
        }


        #region -- BITWISE OPERATIONS

        // Read a specific bit. Return true if it is 1.
        private bool ReadBit(D7000Bits bit)
        {
            if (client is null) return false;

            int[] regs = client.ReadHoldingRegisters(0, 1); // Read D7000
            int value = regs[0];

            return (value & (1 << (int)bit)) != 0; // Check if the bit is set
        }

        /// <summary> Write to a specific bit true or false. </summary>
        private void WriteBit(D7001Bits bit, bool state)
        {
            if (client is null) return;

            int[] regs = client.ReadHoldingRegisters(1, 1); // Read D7001
            int value = regs[0];

            if (state)
                value |= (1 << (int)bit);  // Set bit (turn ON)
            else
                value &= ~(1 << (int)bit); // Clear bit (turn OFF)

            int[] values = { value };
            client.WriteMultipleRegisters(1, values); // Write back to D7001
        }

        /// <summary> Write to a specific bit true or false. </summary>
        private void WriteBit(D7002Bits bit, bool state)
        {
            if (client is null) return;

            int[] regs = client.ReadHoldingRegisters(2, 1); // Read D7002
            int value = regs[0];

            if (state)
                value |= (1 << (int)bit);  // Set bit (turn ON)
            else
                value &= ~(1 << (int)bit); // Clear bit (turn OFF)

            int[] values = { value };
            client.WriteMultipleRegisters(2, values); // Write back to D7002
        }
        #endregion

        #region -- ENUMS
        // Read Bits
        public enum D7000Bits
        {
            SystemError = 5,    // Bit 5
            DoorStatus = 6,   // Bit 6
            HomePosition = 7 // Bit 7
        }

        // Write Bits
        public enum D7001Bits
        {
            MotorPos1 = 0,    // Bit 0
            MotorPos2 = 2,   // Bit 2
            MotorPos3 = 4,   // Bit 4
            ResetSystem = 6 // Bit 6
        }

        // Write Bits
        public enum D7002Bits
        {
            Lights = 0,   // Bit 0
        }
        #endregion

    }
}
