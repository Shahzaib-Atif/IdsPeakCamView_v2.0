using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public struct NewPositionCoordinates
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "{0} should consist of {1} chars")]
        public string PosId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 2, MinimumLength = 1, ErrorMessage = "{0} should consist of only {1} char")]
        public string CV { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 3, MinimumLength = 1, ErrorMessage = "{0} should consist of only {1} char")]
        public string CH { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string SampleSection { get; set; }
    }

}
