using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public class SampleDetail
    {
        public BasicSampleDetails BasicDetails { get; set; }
        public SampleDimensions Dimensions { get; set; }

        public SampleDetail(BasicSampleDetails basicDetails, SampleDimensions dimensions)
        {
            BasicDetails = basicDetails;
            Dimensions = dimensions;
        }

        public SampleDetail()
        {
        }

        public static SampleDetail Default()
        {
            return new()
            {
                BasicDetails = new BasicSampleDetails
                {
                    PosId = "A000",
                    Cor = "B",
                    Vias = "R",
                    Codivmac = "A000BR",
                    Tipo = "Conector"
                },
                Dimensions = new SampleDimensions
                {
                    InternalDiameter = 1,
                    ExternalDiameter = 2,
                    Thickness = 5
                }
            };
        }
    }

    public struct BasicSampleDetails
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "{0} should consist of {1} chars")]
        public string PosId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 1, MinimumLength = 1, ErrorMessage = "{0} should consist of only {1} char")]
        public string Vias { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 1, MinimumLength = 1, ErrorMessage = "{0} should consist of only {1} char")]
        public string Cor { get; set; }

        public string Codivmac { get; set; }
    }

    public struct SampleDimensions
    {
        public decimal? InternalDiameter { get; set; }
        public decimal? ExternalDiameter { get; set; }
        public decimal? Thickness { get; set; }

        public SampleDimensions(decimal? internalDiameter, decimal? externalDiameter, decimal? thickness)
        {
            InternalDiameter = internalDiameter;
            ExternalDiameter = externalDiameter;
            Thickness = thickness;
        }
    }

}
