using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public struct AccessoryDetails
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 6, MinimumLength = 4, ErrorMessage = "{0} should consist of {2} or {1} chars")]
        public string ConnectorName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        public string Reference { get; set; }
        public string RefDV { get; set; }
        public string CapotAngle { get; set; }
        public string ClipColor { get; set; }
        public int Quantity { get; set; }
        public bool ColorAssociated { get; set; }
        public string FullName { get; set; }
    }
}
