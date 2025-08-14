using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.CompareFeatures
{
    public partial class CompareFeaturesClass
    {
        #region -- Variables --
        private static DetectorFeatures OrbSourceFeatures { get; set; }
        private static DetectorFeatures AkazeSourceFeatures { get; set; }
        private static DetectorFeatures FastSourceFeatures { get; set; }
        private static DetectorFeatures GfttSourceFeatures { get; set; }
        private static List<bool> IHashSource { get; set; }
        private static Mat SourceImg { get; set; }
        #endregion

        // Pre-Compute features for source image
        public static void InitializeSourceFeatures(string originalFilename)
        {
            using var sourceImage = new Image<Gray, byte>(originalFilename);
            // orb
            using (var orb = new ORB())
            {
                var keyPoints1 = new VectorOfKeyPoint();
                var descriptors1 = new UMat();
                orb.DetectAndCompute(sourceImage, null, keyPoints1, descriptors1, false);
                OrbSourceFeatures = new DetectorFeatures(keyPoints1, descriptors1);
            }

            // akaze
            using (var akaze = new AKAZE())
            {
                var keyPoints1 = new VectorOfKeyPoint();
                var descriptors1 = new UMat();
                akaze.DetectAndCompute(sourceImage, null, keyPoints1, descriptors1, false);
                AkazeSourceFeatures = new DetectorFeatures(keyPoints1, descriptors1);
            }

            // fast
            using (var fastDetector = new FastFeatureDetector())
            using (var orb = new ORB()) // ORB for descriptor extraction
            {
                var keyPoints1 = new VectorOfKeyPoint();
                fastDetector.DetectRaw(sourceImage, keyPoints1);
                var descriptors1 = new UMat();
                orb.Compute(sourceImage, keyPoints1, descriptors1);
                FastSourceFeatures = new DetectorFeatures(keyPoints1, descriptors1);
            }

            // gftt
            using (var gfttDetector = new GFTTDetector())
            using (var orb = new ORB()) // ORB for descriptor extraction
            {
                var keyPoints1 = new VectorOfKeyPoint();
                gfttDetector.DetectRaw(sourceImage, keyPoints1);
                var descriptors1 = new UMat();
                orb.Compute(sourceImage, keyPoints1, descriptors1);
                GfttSourceFeatures = new DetectorFeatures(keyPoints1, descriptors1);
            }

            // hash
            IHashSource = GetHash(originalFilename);

            // Abs Diff
            SourceImg = CvInvoke.Imread(originalFilename, ImreadModes.Color);
        }

        public static List<bool> GetHash(string filePath)
        {
            using var bmpSource = new Bitmap(filePath);
            List<bool> lResult = new();

            //create new image with 16x16 pixel
            using Bitmap bmpMin = new(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
                for (int i = 0; i < bmpMin.Width; i++)
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f); //reduce colors to true / false

            return lResult;
        }

        // Function to compare descriptors and calculate similarity
        private static double CompareDescriptors(UMat descriptors1, UMat descriptors2, VectorOfKeyPoint keyPoints1, VectorOfKeyPoint keyPoints2)
        {
            if (keyPoints2 is null || descriptors2 is null) return 0.0;
            if (descriptors1.IsEmpty || descriptors2.IsEmpty) return 0.0;
            if (keyPoints1.Size == 0 || keyPoints2.Size == 0) return 0.0;

            int keyPointsSize1 = keyPoints1.Size;
            int keyPointsSize2 = keyPoints2.Size;

            DistanceType distanceType = DistanceType.Hamming;

            using var matcher = new BFMatcher(distanceType);
            using var matches = new VectorOfDMatch();
            matcher.Match(descriptors1, descriptors2, matches);

            if (matches.Size == 0) return 0.0;

            var distances = matches.ToArray().Select(m => m.Distance).ToArray();
            double maxDistance = distances.Max();
            double minDistance = distances.Min();

            double goodMatchThreshold = 0.6; // Adjust as needed
            double threshold = goodMatchThreshold * (maxDistance - minDistance) + minDistance;

            int goodMatches = distances.Count(d => d <= threshold);
            double similarity = (double)goodMatches / Math.Max(keyPointsSize1, keyPointsSize2);
            return Math.Max(0.0, similarity); // make sure value is not less than 0
        }

        // Function to compare descriptors using BFMatcher and calculate similarity
        private static double CompareDescriptorsUsingBFMatcher(UMat descriptors1, UMat descriptors2, int keyPointsSize1, int keyPointsSize2)
        {
            using var bfMatcher = new BFMatcher(DistanceType.Hamming, crossCheck: true);  // Hamming distance for binary descriptors like ORB
            using var matches = new VectorOfDMatch();
            bfMatcher.Match(descriptors1, descriptors2, matches);

            // Check if matches were found
            if (matches.Size == 0)
            {
                return 0.0;
            }

            // Calculate the distances from the matches
            var distances = matches.ToArray().Select(m => m.Distance).ToArray();
            double maxDistance = distances.Max();
            double minDistance = distances.Min();

            // Set a reasonable good match threshold
            double goodMatchThreshold = 0.7;  // Adjust threshold based on testing
            double threshold = goodMatchThreshold * (maxDistance - minDistance) + minDistance;

            // Filter matches to find good matches
            int goodMatches = distances.Count(d => d <= threshold);

            // Calculate similarity based on the number of good matches
            double similarity = (double)goodMatches / Math.Max(keyPointsSize1, keyPointsSize2);
            return Math.Max(0.0, similarity); // make sure value is not less than 0
        }
    }
}
