using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageProcessingLibrary.Services.CompareFeatures
{
    public partial class CompareFeaturesClass
    {
        // ORBDetector: Detects and describes keypoints in images using a combination of
        // FAST keypoint detector and BRIEF descriptors, suitable for matching and object recognition.
        internal static double CompareWithORB(Image<Gray, byte> fileImage)
        {
            using var orb = new ORB();
            var keyPoints1 = OrbSourceFeatures.KeyPoints;
            var descriptors1 = OrbSourceFeatures.Descriptors;

            var keyPoints2 = new VectorOfKeyPoint();
            var descriptors2 = new UMat();
            orb.DetectAndCompute(fileImage, null, keyPoints2, descriptors2, false);

            double val = CompareDescriptors(descriptors1, descriptors2, keyPoints1, keyPoints2);
            return (val * 100);
        }

        // AKAZE: Detects and describes keypoints using nonlinear diffusion filters to handle changes
        // in scale and rotation, often used for robust feature matching.
        internal static double CompareWithAKAZE(Image<Gray, byte> fileImage)
        {
            using var akaze = new AKAZE();
            var keyPoints1 = AkazeSourceFeatures.KeyPoints;
            var descriptors1 = AkazeSourceFeatures.Descriptors;

            var keyPoints2 = new VectorOfKeyPoint();
            var descriptors2 = new UMat();
            akaze.DetectAndCompute(fileImage, null, keyPoints2, descriptors2, false);

            double val = CompareDescriptors(descriptors1, descriptors2, keyPoints1, keyPoints2);
            return (val * 100);
        }

        // FastFeatureDetector: Identifies keypoints quickly using the
        // FAST (Features from Accelerated Segment Test) algorithm, which is effective for high-speed feature detection.
        internal static double CompareWithFastFeature(Image<Gray, byte> fileImage)
        {
            using var fastDetector = new FastFeatureDetector();
            using var orb = new ORB(); // ORB for descriptor extraction
            var keyPoints1 = FastSourceFeatures.KeyPoints;
            var descriptors1 = FastSourceFeatures.Descriptors;

            var keyPoints2 = new VectorOfKeyPoint();
            fastDetector.DetectRaw(fileImage, keyPoints2);

            var descriptors2 = new UMat();
            orb.Compute(fileImage, keyPoints2, descriptors2);

            // If no descriptors or keypoints are found, return 0 similarity
            if (descriptors1.IsEmpty || descriptors2.IsEmpty || keyPoints1.Size == 0 || keyPoints2.Size == 0)
                return 0.0;

            // Use BFMatcher to compare the descriptors
            double val = CompareDescriptorsUsingBFMatcher(descriptors1, descriptors2, keyPoints1.Size, keyPoints2.Size);
            return (val * 100);
        }

        // GFTTDetector: Detects corners in images using the Harris corner detection method,
        // useful for finding distinctive points in an image.
        internal static double CompareWithGFTT(Image<Gray, byte> fileImage)
        {
            using var gfttDetector = new GFTTDetector();
            using var orb = new ORB(); // ORB for descriptor extraction
            var keyPoints1 = GfttSourceFeatures.KeyPoints;
            var descriptors1 = GfttSourceFeatures.Descriptors;

            var keyPoints2 = new VectorOfKeyPoint();
            gfttDetector.DetectRaw(fileImage, keyPoints2);

            var descriptors2 = new UMat();
            orb.Compute(fileImage, keyPoints2, descriptors2);

            // If no descriptors or keypoints are found, return 0 similarity
            if (descriptors1.IsEmpty || descriptors2.IsEmpty || keyPoints1.Size == 0 || keyPoints2.Size == 0)
                return 0.0;

            // Use BFMatcher to compare the descriptors
            double val = CompareDescriptorsUsingBFMatcher(descriptors1, descriptors2, keyPoints1.Size, keyPoints2.Size);
            return (val * 100);
        }

        // Compares two image hashes and returns the count of matching pixels.
        internal static double CompareWithImageHash(string filename)
        {
            List<bool> iHash2 = GetHash(filename);

            // Determine the number of equal pixels (x out of 256)
            int hash = IHashSource.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

            // convert to double and return
            double similarity = (double)hash / 256;
            return Math.Round(similarity * 100, 2); // Round to 2 decimal places
        }
    }
}
