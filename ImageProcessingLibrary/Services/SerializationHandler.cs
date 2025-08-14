using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImageProcessingLibrary.Services
{
    internal class SerializationHandler
    {
        // ORB and Akaze
        private static (byte[]?, byte[]?) GetSerializedFeatures_1(string filename, Feature2D detector)
        {
            try
            {
                using var image = new Image<Gray, byte>(filename);
                var keyPoints = new VectorOfKeyPoint();
                var descriptors = new UMat();
                detector.DetectAndCompute(image, null, keyPoints, descriptors, false);

                byte[]? keyPointsBytes = SerializeKeyPoints(keyPoints);
                byte[]? descriptorBytes = SerializeDescriptors(descriptors);

                return (keyPointsBytes, descriptorBytes);
            }
            catch
            {
                ExceptionHelper.DisplayErrorMessage($"Error occurred in GetSerializedFeatures_1: {filename}");
                return (null, null);
            }
        }

        // fast feature and GFTT
        private static (byte[]?, byte[]?) GetSerializedFeatures_2(string filename, Feature2D detector)
        {
            try
            {
                using var image = new Image<Gray, byte>(filename);
                using var orb = new ORB(); // ORB for descriptor extraction
                                           // Detect keypoints using the provided detector
                var keyPoints = new VectorOfKeyPoint();
                detector.DetectRaw(image, keyPoints);

                // Compute descriptors using ORB for both images
                var descriptors = new UMat();
                orb.Compute(image, keyPoints, descriptors);

                byte[]? keyPointsBytes = SerializeKeyPoints(keyPoints);
                byte[]? descriptorBytes = SerializeDescriptors(descriptors);

                return (keyPointsBytes, descriptorBytes);
            }
            catch
            {
                ExceptionHelper.DisplayErrorMessage($"Error occurred in GetSerializedFeatures_2: {filename}");
                return (null, null);
            }
        }

        internal static (byte[]?, byte[]?) GetSerializedORBFeatures(string imagePath)
        {
            using var detector = new ORB();
            return GetSerializedFeatures_1(imagePath, detector);
        }

        internal static (byte[]?, byte[]?) GetSerializedAkazeFeatures(string imagePath)
        {
            using var detector = new AKAZE();
            return GetSerializedFeatures_1(imagePath, detector);
        }

        internal static (byte[]?, byte[]?) GetSerializedFastFeatures(string imagePath)
        {
            using var detector = new FastFeatureDetector();
            return GetSerializedFeatures_2(imagePath, detector);
        }

        internal static (byte[]?, byte[]?) GetSerializedGFTTFeatures(string imagePath)
        {
            using var detector = new GFTTDetector();
            return GetSerializedFeatures_2(imagePath, detector);
        }

        internal static DetectorFeatures GetDeserializedDetectorFeatures(byte[] keyPointsBytes, byte[] descriptorBytes, int descriptorCols = 32)
        {
            VectorOfKeyPoint keyPoints = DeserializeKeyPoints(keyPointsBytes);
            UMat descriptors = DeserializeDescriptors(descriptorBytes, descriptorCols);

            return new DetectorFeatures(keyPoints, descriptors);
        }

        internal static byte[]? SerializeObject(object obj)
        {
            if (obj == null) return null;

            using var ms = new MemoryStream();
            BinaryFormatter formatter = new();
            formatter.Serialize(ms, obj);
            ms.Flush();
            return ms.ToArray();
        }

        internal static T? DeserializeObject<T>(byte[] bytes)
        {
            if (bytes == null) return default;

            using var ms = new MemoryStream(bytes);
            BinaryFormatter formatter = new();
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }

        // Serialize keypoints (as VectorOfKeyPoint)
        private static byte[]? SerializeKeyPoints(VectorOfKeyPoint keyPoints)
        {
            return SerializeObject(keyPoints.ToArray());
        }

        // Serialize descriptors (as UMat)
        private static byte[]? SerializeDescriptors(UMat descriptors)
        {
            // Directly copy the raw data from the Mat
            Mat mat = new();
            descriptors.CopyTo(mat);

            // Get the total number of bytes in the Mat
            int dataSize = mat.Rows * mat.Cols * mat.ElementSize;

            if (dataSize > 0)
            {
                byte[] descriptorBytes = new byte[dataSize];

                // Copy the raw data from the Mat into the byte array
                System.Runtime.InteropServices.Marshal.Copy(mat.DataPointer, descriptorBytes, 0, dataSize);

                return descriptorBytes;
            }
            else
                return null;
        }

        // Deserialization
        private static VectorOfKeyPoint DeserializeKeyPoints(byte[] keyPointsBytes)
        {
            return new VectorOfKeyPoint(DeserializeObject<MKeyPoint[]>(keyPointsBytes));
        }

        // Convert descriptor bytes back into UMat format
        private static UMat DeserializeDescriptors(byte[] descriptorBytes, int descriptorCols)
        {
            Mat mat = new(new Size(descriptorCols, descriptorBytes.Length / descriptorCols), Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            mat.SetTo(descriptorBytes);
            UMat uMat = new();
            mat.CopyTo(uMat);
            mat.Dispose();
            return uMat;
        }
    }
}
