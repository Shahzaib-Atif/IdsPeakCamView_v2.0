using Emgu.CV;
using Emgu.CV.Util;

namespace ImageProcessingLibrary.Models
{
    // Struct to hold feature data and the associated detector type
    public struct DetectorFeatures : IDisposable
    {
        public VectorOfKeyPoint KeyPoints { get; set; }
        public UMat Descriptors { get; set; }
        //public DetectorType Detector { get; set; }  // Use enum to represent the detector type

        public DetectorFeatures(VectorOfKeyPoint keyPoints, UMat descriptors) : this()
        {
            this.KeyPoints = keyPoints;
            this.Descriptors = descriptors;
        }

        public readonly void Dispose()
        {
            KeyPoints?.Dispose();
            Descriptors?.Dispose();
        }
    }
}
