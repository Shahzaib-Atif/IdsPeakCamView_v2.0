using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Models
{
    public class SampleDetail
    {
        public BasicSampleDetails BasicDetails { get; set; }
        public SampleDimensions Dimensions { get; set; }
        public AdditionalDetails? AdditionalDetails { get; set; }
        public ComponentsDetails? ComponentsDetails { get; set; }

        public SampleDetail(BasicSampleDetails basicDetails, SampleDimensions dimensions,
            AdditionalDetails? additionalDetails, ComponentsDetails? componentDetails)
        {
            BasicDetails = basicDetails;
            Dimensions = dimensions;
            AdditionalDetails = additionalDetails;
            ComponentsDetails = componentDetails;
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
        public int Qty { get; set; }
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

    public struct AdditionalDetails
    {
        public string Designação { get; set; }
        public string Fabricante { get; set; }
        public string Refabricante { get; set; }
        public string OBS { get; set; }
        public string ClipColor { get; set; }
        public string CapotAngle { get; set; }
        public int Family { get; set; }
        public int ActualViaCount { get; set; }
    }

    public struct ComponentsDetails
    {
        public bool Clip { get; set; }
        public bool Spacer { get; set; }
        public bool Tampa { get; set; }
        public bool Vedante { get; set; }
        public bool Mola { get; set; }
        public bool Moldagem { get; set; }
        public bool Travão { get; set; }
        public bool Abracadeira { get; set; }
        public bool Linguetes { get; set; }
        public bool Outros { get; set; }
        public bool Amostra { get; set; }
        public bool Olhal { get; set; }
        public bool CPA { get; set; }
    }



}
