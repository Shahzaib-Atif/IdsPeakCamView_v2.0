namespace ImageProcessingLibrary.Models
{
    public class ImageFeaturesStruct
    {
        public string FileName { get; set; }
        public byte[]? Histogram { get; set; }
        public byte[]? Hash { get; set; }
        public byte[]? ORBKeyPoints { get; set; }
        public byte[]? ORBDescriptors { get; set; }
        public byte[]? AkazeKeyPoints { get; set; }
        public byte[]? AkazeDescriptors { get; set; }
        public byte[]? FastKeyPoints { get; set; }
        public byte[]? FastDescriptors { get; set; }
        public byte[]? GFTTKeyPoints { get; set; }
        public byte[]? GFTTDescriptors { get; set; }
    }
}
