namespace ImageProcessingLibrary.Models
{
    public class ConnectorFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float[] ResnetVector { get; set; }
        public float[] Dinov2Vector { get; set; }

    }
}
