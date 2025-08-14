using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public struct ConfigSettings
    {
        public DbConfigSettings DbConfigSettings { get; set; }
        public ModbusConfigSettings ModbusConfigSettings { get; set; }
        public string DefaultFolderPath { get; set; }
    }

    public class DbConfigSettings
    {
        [Required(ErrorMessage = "Server name is required")]
        public string Server { get; set; } = string.Empty;

        [Required(ErrorMessage = "Database name is required")]
        public string Database { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IntegratedSecurity { get; set; } = true;


        // Generates a connection string based on authentication type
        public override string ToString()
        {
            return IntegratedSecurity
           ? $"Server={Server};Database={Database};Integrated Security=True;"
           : $"Server={Server};Database={Database};User Id={UserId};Password={Password};Integrated Security=False;";
        }
    }

    public class ModbusConfigSettings
    {
        [Required(ErrorMessage = "Ip Address is required")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Please enter valid ip address")]
        public string ModbusIpAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Port number is required")]
        [Range(1, 65535, ErrorMessage = "Please enter valid port number")]
        public int ModbusPort { get; set; } = 0;
    }
}
