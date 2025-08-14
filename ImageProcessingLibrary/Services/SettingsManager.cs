using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using System.Text.Json;
using static ImageProcessingLibrary.ProjectSettings;

namespace ImageProcessingLibrary.Services
{
    public class SettingsManager
    {
        #region -- READ SETTINGS FILE
        public static void LoadInitialSettings()
        {
            try
            {
                // LOAD SETTINGS FILE
                ConfigSettings? settings = LoadSettingsFile();
                if (settings is null) return;

                // -- Database
                var dbSettings = settings?.DbConfigSettings;
                if (dbSettings is not null)
                {
                    // decrypt server access info
                    DecryptServerAccessInfo(dbSettings);

                    // update in ProjectSettings
                    ProjectSettings.SetDbConfigSettings(dbSettings);
                    ProjectSettings.SetDbConnectionString(dbSettings.ToString());
                }

                // -- MODBUS
                var modbusSettings = settings?.ModbusConfigSettings;
                if (modbusSettings is not null)
                {
                    // update parameters in ProjectSettings
                    ProjectSettings.SetModbusIpAddress(modbusSettings.ModbusIpAddress);
                    ProjectSettings.SetModbusPort(modbusSettings.ModbusPort);
                }

                // -- DEFAULT FOLDER
                ProjectSettings.SetDefaultFolderPath(settings?.DefaultFolderPath ?? "");
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
            }
        }

        private static void DecryptServerAccessInfo(DbConfigSettings dbSettings)
        {
            dbSettings.Server = DataProtector.Decrypt(dbSettings.Server, nameof(dbSettings.Server));
            dbSettings.Database = DataProtector.Decrypt(dbSettings.Database, nameof(dbSettings.Database));
            dbSettings.Password = DataProtector.Decrypt(dbSettings.Password, nameof(dbSettings.Password));
            dbSettings.UserId = DataProtector.Decrypt(dbSettings.UserId, nameof(dbSettings.UserId));
        }

        // Load settings from the .ipcv file
        private static ConfigSettings? LoadSettingsFile()
        {
            if (File.Exists(SettingsFilePath))
            {
                string json = File.ReadAllText(SettingsFilePath);
                return JsonSerializer.Deserialize<ConfigSettings>(json);
            }
            else
            {
                ExceptionHelper.ShowWarningMessage($"{SettingsFilePath} not found!");
                return null;
            }
        }
        #endregion


        #region -- WRITE TO SETTINGS FILE
        public static void PromptToUpdateSettings()
        {
            string text = "Would you like to write these changes to your settings.ipcv file?";
            string caption = "Update settings file";
            if (DialogHelper.ShowYesNoDialog(text, caption) == DialogResult.Yes)
            {
                WriteToSettingsFile();
            }
        }

        private static void WriteToSettingsFile()
        {
            // database settings object
            var dbSettings = new DbConfigSettings
            {
                Server = ProjectSettings.DbConfigSettings.Server,
                Database = ProjectSettings.DbConfigSettings.Database,
                IntegratedSecurity = ProjectSettings.DbConfigSettings.IntegratedSecurity,
                UserId = ProjectSettings.DbConfigSettings.UserId,
                Password = ProjectSettings.DbConfigSettings.Password
            };

            // encrypt data related to db credentials
            EncryptServerAccessInfo(dbSettings);

            // modbus settings object
            var modbusSettings = new ModbusConfigSettings
            {
                ModbusIpAddress = ProjectSettings.ModbusIpAddress,
                ModbusPort = ProjectSettings.ModbusPort,
            };

            // final settings object
            var settings = new ConfigSettings
            {
                DbConfigSettings = dbSettings,
                ModbusConfigSettings = modbusSettings,
                DefaultFolderPath = ProjectSettings.DefaultFolder
            };

            // serialize and write the json file
            string jsonString = JsonSerializer.Serialize<ConfigSettings>
                (settings, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(SettingsFilePath, jsonString);

            ExceptionHelper.ShowSuccessMessage("Settings file updated successfully!");
        }

        private static void EncryptServerAccessInfo(DbConfigSettings dbSettings)
        {
            dbSettings.Server = DataProtector.Encrypt(dbSettings.Server);
            dbSettings.Database = DataProtector.Encrypt(dbSettings.Database);
            dbSettings.UserId = DataProtector.Encrypt(dbSettings.UserId);
            dbSettings.Password = DataProtector.Encrypt(dbSettings.Password);
        }

        #endregion
    }
}
