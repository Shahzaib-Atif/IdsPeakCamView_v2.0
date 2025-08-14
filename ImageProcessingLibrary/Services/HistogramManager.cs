using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageProcessingLibrary.Services
{
    public class HistogramManager
    {
        // ----------------- //
        #region Public Methods
        // Compare two histograms for similarity
        internal static double Compare(string sourceFile, string otherFile)
        {
            // GET GRAY HISTOGRAM
            using var hist1 = GetHistogramFromImage(sourceFile);
            using var hist2 = GetHistogramFromImage(otherFile);
            // Normalize histograms to the same scale
            Emgu.CV.CvInvoke.Normalize(hist1, hist1, 0, 1, NormType.MinMax, (DepthType)(-1), new Mat());
            CvInvoke.Normalize(hist2, hist2, 0, 1, NormType.MinMax, (DepthType)(-1), new Mat());

            double similarity = CvInvoke.CompareHist(hist1, hist2, HistogramCompMethod.Correl); // Correlation method
            return Math.Max(0.0, similarity * 100);
        }

        // Compare two histograms for similarity
        internal static double Compare(string sourceFile, Mat hist2)
        {
            // GET GRAY HISTOGRAM
            using var hist1 = GetHistogramFromImage(sourceFile);
            // Normalize histograms to the same scale
            CvInvoke.Normalize(hist1, hist1, 0, 1, NormType.MinMax, (DepthType)(-1), new Mat());
            CvInvoke.Normalize(hist2, hist2, 0, 1, NormType.MinMax, (DepthType)(-1), new Mat());

            double similarity = CvInvoke.CompareHist(hist1, hist2, HistogramCompMethod.Correl); // Correlation method
            return Math.Max(0.0, similarity * 100);
        }


        // Get histogram from an image file path
        public static Mat GetHistogramFromImage(string imagePath)
        {
            using var image = new Image<Gray, byte>(imagePath); // Load directly as grayscale
            return CalculateHist(image);
        }
        #endregion


        // Calculate histogram for a grayscale image
        private static Mat CalculateHist(Image<Gray, byte> grayImage)
        {
            using var grayMat = grayImage.Mat;
            using var vectorOfMat = new VectorOfMat(grayMat);
            // Create an empty histogram
            Mat hist = new();

            // Calculate histogram
            CvInvoke.CalcHist(
                vectorOfMat,                          // Input image
                new int[] { 0 },                      // Channels (for grayscale, it's channel 0)
                null,                                 // No mask
                hist,                                 // Output histogram
                new int[] { 256 },                    // Histogram size (number of bins)
                new float[] { 0, 256 },               // Range (0 to 256)
                false                                 // Uniform flag
            );

            return hist;
        }
    }

}
