using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.Services
{
    internal class OnnxService
    {
        private const int MAX_RESULT_LENGTH = 50;
        private readonly FeatureRepository _featureRepo;

        public OnnxService()
        {
            _featureRepo = new FeatureRepository();
        }

        // Find matching images based on extracted features
        internal List<ConnectorMatch> FindMatchingImages(string sourceFilepath)
        {
            try
            {
                // resnet
                using var resnetExtractor = new FeatureExtractorResnet50();
                float[] resnetVector = resnetExtractor.ExtractFeatures(sourceFilepath);

                // dinov2
                using var dinov2Extractor = new FeatureExtractorDINOv2();
                float[] dinov2Vector = dinov2Extractor.ExtractFeatures(sourceFilepath);

                var storedVectors = _featureRepo.LoadAllVectors(); // load values from database
                var topMatches = FindTopScores(resnetVector, dinov2Vector, storedVectors);

                return topMatches;
            }
            catch (Exception e)
            {
                ExceptionHelper.DisplayErrorMessage(e.Message);
                return new List<ConnectorMatch>();
            }
        }

        // Find top matching scores based on cosine similarity
        private static List<ConnectorMatch> FindTopScores(float[] resnetVector, float[] dinov2Vector, List<ConnectorFeature> storedVectors)
        {
            return storedVectors.Select(v => new ConnectorMatch
            {
                Name = v.Name,
                ResnetScore = CosineSimilarity(resnetVector, v.ResnetVector),
                Dinov2Score = CosineSimilarity(dinov2Vector, v.Dinov2Vector)
            })
            .OrderByDescending(x => x.Dinov2Score)
            .Take(MAX_RESULT_LENGTH)
            .ToList();
        }

        private static float CosineSimilarity(float[] v1, float[] v2)
        {
            if (v1.Length != v2.Length)
                throw new ArgumentException("Vectors must be the same length");

            float dot = 0f;
            float normA = 0f;
            float normB = 0f;

            for (int i = 0; i < v1.Length; i++)
            {
                dot += v1[i] * v2[i];
                normA += v1[i] * v1[i];
                normB += v2[i] * v2[i];
            }

            return dot / (float)(Math.Sqrt(normA) * Math.Sqrt(normB));
        }


    }
}
