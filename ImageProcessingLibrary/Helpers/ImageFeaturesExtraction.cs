using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using static ImageProcessingLibrary.Services.SerializationHandler;
using FeatureComparison = ImageProcessingLibrary.Services.CompareFeatures.CompareFeaturesClass;

namespace ImageProcessingLibrary.Helpers
{
    internal static class ImageFeaturesExtraction
    {
        // Extract image features and serialize them
        internal static ImageFeaturesStruct? ExtractImageFeatures(string imagePath)
        {
            try
            {
                using var histogram = HistogramManager.GetHistogramFromImage(imagePath);
                List<bool> hash = FeatureComparison.GetHash(imagePath);
                var (orbKeyPointsBytes, orbDescriptorBytes) = GetSerializedORBFeatures(imagePath);
                var (akazeKeyPointsBytes, akazeDescriptorBytes) = GetSerializedAkazeFeatures(imagePath);
                var (fastKeyPointsBytes, fastDescriptorBytes) = GetSerializedFastFeatures(imagePath);
                var (gfttKeyPointsBytes, gfttDescriptorBytes) = GetSerializedGFTTFeatures(imagePath);

                // Check if any features are missing
                if (orbKeyPointsBytes == null || orbDescriptorBytes == null ||
                    akazeKeyPointsBytes == null || akazeDescriptorBytes == null ||
                    fastKeyPointsBytes == null || fastDescriptorBytes == null ||
                    gfttKeyPointsBytes == null || gfttDescriptorBytes == null)
                    return null;

                // Flatten histogram to 1D array and serialize
                float[] histogramData = new float[histogram.Rows * histogram.Cols];
                histogram.CopyTo(histogramData);
                return new ImageFeaturesStruct
                {
                    FileName = Path.GetFileName(imagePath),
                    Histogram = SerializeObject(histogramData),
                    Hash = SerializeObject(hash),
                    ORBKeyPoints = orbKeyPointsBytes,
                    ORBDescriptors = orbDescriptorBytes,
                    AkazeKeyPoints = akazeKeyPointsBytes,
                    AkazeDescriptors = akazeDescriptorBytes,
                    FastKeyPoints = fastKeyPointsBytes,
                    FastDescriptors = fastDescriptorBytes,
                    GFTTKeyPoints = gfttKeyPointsBytes,
                    GFTTDescriptors = gfttDescriptorBytes
                };
            }
            catch
            {
                ExceptionHelper.ShowWarningMessage($"Failed to extract features from: {imagePath}");
                return null;
            }
        }

    }
}
