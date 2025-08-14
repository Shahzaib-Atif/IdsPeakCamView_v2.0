namespace ImageProcessingLibrary.Services
{
    using Microsoft.ML.OnnxRuntime;
    using Microsoft.ML.OnnxRuntime.Tensors;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;

    public class FeatureExtractorResnet50 : IDisposable
    {
        private readonly string _modelPath = "D:/Downloads/resnet50model.onnx";
        private readonly InferenceSession _session;

        public FeatureExtractorResnet50()
        {
            _session = new InferenceSession(_modelPath);
        }

        public float[] ExtractFeatures(string imagePath)
        {
            using var image = Image.Load<Rgb24>(imagePath);
            image.Mutate(x => x.Resize(224, 224));

            var input = new DenseTensor<float>(new[] { 1, 3, 224, 224 });

            for (int y = 0; y < 224; y++)
            {
                for (int x = 0; x < 224; x++)
                {
                    Rgb24 pixel = image[x, y];

                    // Normalize to [0,1] and then apply mean/std
                    input[0, 0, y, x] = (pixel.R / 255f - 0.485f) / 0.229f; // R
                    input[0, 1, y, x] = (pixel.G / 255f - 0.456f) / 0.224f; // G
                    input[0, 2, y, x] = (pixel.B / 255f - 0.406f) / 0.225f; // B
                }
            }

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("pixel_values", input) // "data" is the typical input name for resnet50-v2
            };

            using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _session.Run(inputs);

            var output = results.First(r => r.Name == "491").AsTensor<float>().ToArray();

            return output; // This is required 2048-dim vector
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }

}
