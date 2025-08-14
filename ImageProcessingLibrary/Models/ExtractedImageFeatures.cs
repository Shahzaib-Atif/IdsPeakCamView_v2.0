using Emgu.CV;

namespace ImageProcessingLibrary.Models
{
    public class ExtractedImageFeatures
    {
        public string? CodivmacRef { get; set; }
        public Mat? Histogram { get; set; }
        public List<bool>? Hash { get; set; }
        public DetectorFeatures? OrbDetectorFeatures { get; set; }
        public DetectorFeatures? AkazeDetectorFeatures { get; set; }
        public DetectorFeatures? FastDetectorFeatures { get; set; }
        public DetectorFeatures? GfttDetectorFeatures { get; set; }
    }
}
