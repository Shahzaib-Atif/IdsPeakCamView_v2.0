using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public struct AccessoryDetails
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 6, MinimumLength = 6, ErrorMessage = "{0} should consist of {1} chars")]
        public string ConnectorName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        public string Reference { get; set; }

        public string FullName { get; set; }
    }
}
