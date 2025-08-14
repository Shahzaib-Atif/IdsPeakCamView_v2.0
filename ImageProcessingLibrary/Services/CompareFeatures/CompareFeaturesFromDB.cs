using Emgu.CV.Features2D;
using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services.CompareFeatures
{
    public partial class CompareFeaturesClass
    {
        // ORBDetector: Detects and describes keypoints in images using a combination of
        // FAST keypoint detector and BRIEF descriptors, suitable for matching and object recognition.
        internal static double CompareWithORB(DetectorFeatures? detectorFeatures)
        {
            if (detectorFeatures == null) return 0.0;

            using var orb = new ORB();
            var keyPoints1 = OrbSourceFeatures.KeyPoints;
            var descriptors1 = OrbSourceFeatures.Descriptors;

            var keyPoints2 = detectorFeatures?.KeyPoints;
            var descriptors2 = detectorFeatures?.Descriptors;


            if (descriptors2 is null || keyPoints2 is null)
                return 0.0;

            double val = CompareDescriptors(descriptors1, descriptors2, keyPoints1, keyPoints2);
            return (val * 100);
        }


        // AKAZE: Detects and describes keypoints using nonlinear diffusion filters to handle changes
        // in scale and rotation, often used for robust feature matching.
        internal static double CompareWithAKAZE(DetectorFeatures? detectorFeatures)
        {
            using var akaze = new AKAZE();
            var keyPoints1 = AkazeSourceFeatures.KeyPoints;
            var descriptors1 = AkazeSourceFeatures.Descriptors;

            var keyPoints2 = detectorFeatures?.KeyPoints;
            var descriptors2 = detectorFeatures?.Descriptors;

            if (descriptors2 is null || keyPoints2 is null)
                return 0.0;

            double val = CompareDescriptors(descriptors1, descriptors2, keyPoints1, keyPoints2);
            return (val * 100);
        }


        // FastFeatureDetector: Identifies keypoints quickly using the
        // FAST (Features from Accelerated Segment Test) algorithm, which is effective for high-speed feature detection.
        internal static double CompareWithFastFeature(DetectorFeatures? detectorFeatures)
        {
            var keyPoints1 = FastSourceFeatures.KeyPoints;
            var descriptors1 = FastSourceFeatures.Descriptors;

            var keyPoints2 = detectorFeatures?.KeyPoints;
            var descriptors2 = detectorFeatures?.Descriptors;

            // If no descriptors or keypoints are found, return 0 similarity
            if (keyPoints2 is null || descriptors2 is null) return 0.0;
            if (descriptors1.IsEmpty || descriptors2.IsEmpty || keyPoints1.Size == 0 || keyPoints2.Size == 0) return 0.0;

            // Use BFMatcher to compare the descriptors
            double val = CompareDescriptorsUsingBFMatcher(descriptors1, descriptors2, keyPoints1.Size, keyPoints2.Size);
            return (val * 100);
        }


        // GFTTDetector: Detects corners in images using the Harris corner detection method,
        // useful for finding distinctive points in an image.
        internal static double CompareWithGFTT(DetectorFeatures? detectorFeatures)
        {
            var keyPoints1 = GfttSourceFeatures.KeyPoints;
            var descriptors1 = GfttSourceFeatures.Descriptors;

            // extract keyPoints2 and descriptors2 from the provided DetectorFeatures object
            var keyPoints2 = detectorFeatures?.KeyPoints;
            var descriptors2 = detectorFeatures?.Descriptors;

            // If no descriptors or keypoints are found, return 0 similarity
            if (keyPoints2 is null || descriptors2 is null) return 0.0;
            if (descriptors1.IsEmpty || descriptors2.IsEmpty || keyPoints1.Size == 0 || keyPoints2.Size == 0) return 0.0;

            // Use BFMatcher to compare the descriptors
            double val = CompareDescriptorsUsingBFMatcher(descriptors1, descriptors2, keyPoints1.Size, keyPoints2.Size);
            return (val * 100);
        }

        // Compares two image hashes and returns the count of matching pixels.
        internal static double CompareWithImageHash(List<bool> iHash)
        {
            // Determine the number of equal pixels (x out of 256)
            int hash = IHashSource.Zip(iHash, (i, j) => i == j).Count(eq => eq);

            // convert to double and return
            double similarity = (double)hash / 256;
            if (similarity < 1)
            {
                var temp = Math.Round(similarity, 2);
            }
            return Math.Round(similarity * 100, 2); // Round to 2 decimal places
        }

    }
}
