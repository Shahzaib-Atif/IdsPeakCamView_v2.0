namespace ImageProcessingLibrary.Models
{
    public class SimilarityThresholds
    {
        // Fields to hold the current threshold values
        public int Hist { get; set; } = 34;
        public int Akaze { get; set; } = 30;
        public int Orb { get; set; } = 30;
        public int Gftt { get; set; } = 5;
        public int FastFeature { get; set; } = 4;
        public int ImageHash { get; set; } = 75;

        public static SimilarityThresholds Thresholds { get; set; } = new();

        public static void RestoreDefaults()
        {
            Thresholds.Hist = 34;
            Thresholds.Akaze = 30;
            Thresholds.Orb = 30;
            Thresholds.Gftt = 5;
            Thresholds.FastFeature = 4;
            Thresholds.ImageHash = 75;
        }

        public static void ResetToZero()
        {
            Thresholds.Hist = 0;
            Thresholds.Akaze = 0;
            Thresholds.Orb = 0;
            Thresholds.Gftt = 0;
            Thresholds.FastFeature = 0;
            Thresholds.ImageHash = 0;
        }
    }
}
