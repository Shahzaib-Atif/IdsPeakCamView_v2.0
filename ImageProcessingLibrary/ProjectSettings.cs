using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary
{
    public class ProjectSettings
    {
        public static string DefaultFolder { get; private set; } = string.Empty;
        public static void SetDefaultFolderPath(string folder) => DefaultFolder = folder;

        public static string ModbusIpAddress { get; private set; } = "10.0.0.1";
        public static void SetModbusIpAddress(string newVal) => ModbusIpAddress = newVal;

        public static int ModbusPort { get; private set; } = 502;
        public static void SetModbusPort(int newVal) => ModbusPort = newVal;

        public static string DbConnectionString { get; private set; } = string.Empty;
        public static void SetDbConnectionString(string str) => DbConnectionString = str;

        public static DbConfigSettings DbConfigSettings { get; private set; } = new();
        public static void SetDbConfigSettings(DbConfigSettings newSettings) => DbConfigSettings = newSettings;

        public static string SettingsFilePath { get; private set; } = "settings.ipcv";

        public static string ConnectorName { get; private set; } = string.Empty;
        public static void SetConnectorName(string str) => ConnectorName = str;

        public static int GainValue { get; set; } = 1;
        public static string GainAutoMode { get; set; } = AutoMode.Off;
        public static int ExposureValue { get; set; } = 1200;
        public static string ExposureAutoMode { get; set; } = AutoMode.Off;

    }
}
