using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services
{
    public class ImageCompareService
    {
        private static List<ConnectorMatch> ListOfSimilarImages { get; set; } = new();
        public static IReadOnlyList<ConnectorMatch> SimilarImages => ListOfSimilarImages.AsReadOnly(); // Public read-only property

        #region -- List related methods
        public static void AssignListOfSimilarImages(List<ConnectorMatch> list)
        {
            ListOfSimilarImages = list ?? new List<ConnectorMatch>();
        }

        public static void ClearSimilarImages()
        {
            ListOfSimilarImages.Clear();
        }

        public static void OrderByResnetScoreDescending()
        {
            ListOfSimilarImages.Sort((x, y) => y.ResnetScore.CompareTo(x.ResnetScore));
        }

        public static void OrderByDinov2ScoreDescending()
        {
            ListOfSimilarImages.Sort((x, y) => y.Dinov2Score.CompareTo(x.Dinov2Score));
        }
        #endregion
    }
}
