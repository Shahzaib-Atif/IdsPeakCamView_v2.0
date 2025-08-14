namespace ImageProcessingLibrary.Models
{
    public class ImageSimilarityMetrics
    {
        public string Filename { get; set; } = "";
        public double HistSimilarity { get; set; } = 0.0;
        public double OrbSimilarity { get; set; } = 0.0;
        public double AkazeSimilarity { get; set; } = 0.0;
        public double FastFeatureSimilarity { get; set; } = 0.0;
        public double GfttSimilarity { get; set; } = 0.0;
        public double ImageHashSimilarity { get; set; } = 0.0;

        public override string ToString()
        {
            return //$"Filename: {Filename}\n" +
                   $"Histogram Similarity: {HistSimilarity:F2}\n" +
                   $"ORB Similarity: {OrbSimilarity:F2}\n" +
                   $"AKAZE Similarity: {AkazeSimilarity:F2}\n" +
                   $"FAST Feature Similarity: {FastFeatureSimilarity:F2}\n" +
                   $"GFTT Similarity: {GfttSimilarity:F2}\n" +
                   $"Image Hash Similarity: {ImageHashSimilarity}\n";
        }
    }
}
