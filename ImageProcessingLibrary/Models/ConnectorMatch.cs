namespace ImageProcessingLibrary.Models
{
    public class ConnectorMatch
    {
        public string Name { get; set; }
        public float ResnetScore { get; set; }
        public float Dinov2Score { get; set; }
    }
}
