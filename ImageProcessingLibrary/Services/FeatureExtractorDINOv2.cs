namespace ImageProcessingLibrary.Services
{
    using Microsoft.ML.OnnxRuntime;
    using Microsoft.ML.OnnxRuntime.Tensors;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;
    using System.Collections.Generic;
    using System.Linq;
    using static ImageProcessingLibrary.ProjectSettings;

    public class FeatureExtractorDINOv2 : IDisposable
    {
        private readonly InferenceSession _session;

        public FeatureExtractorDINOv2()
        {
            _session = new InferenceSession(Dinov2ModelPath);
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
                    var pixel = image[x, y];

                    float r = pixel.R / 255f;
                    float g = pixel.G / 255f;
                    float b = pixel.B / 255f;

                    // DINOv2 expects mean/std normalized input (ImageNet)
                    input[0, 0, y, x] = (r - 0.485f) / 0.229f;
                    input[0, 1, y, x] = (g - 0.456f) / 0.224f;
                    input[0, 2, y, x] = (b - 0.406f) / 0.225f;
                }
            }


            var inputs = new List<NamedOnnxValue>
            {
               NamedOnnxValue.CreateFromTensor("input", input) // "input" is the input name for DINOv2
            };

            using var results = _session.Run(inputs);
            var output = results[0].AsTensor<float>().ToArray(); // Output array length is 384

            return output;
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }

}
