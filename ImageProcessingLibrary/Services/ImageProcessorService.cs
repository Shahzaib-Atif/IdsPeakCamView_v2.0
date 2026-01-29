using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using static ImageProcessingLibrary.ProjectSettings;

namespace ImageProcessingLibrary.Services
{
    public class ImageProcessorService
    {
        public ImageProcessorService() { }

        // Save image after compressing and prompt user to open in File Explorer.
        public void SaveCompressedImage(Image image, string savePath)
        {
            // Set up the parameters for JPEG compression
            ImageCodecInfo? jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            if (jpgEncoder == null)
            {
                Debug.WriteLine("--- [ImageProcessor] JPEG encoder not found!");
                return;
            }

            Encoder qualityEncoder = Encoder.Quality;
            using EncoderParameters encoderParameters = new(1);

            // Set the image quality (between 0 and 100)
            EncoderParameter qualityParam = new(qualityEncoder, QualityIndex);
            encoderParameters.Param[0] = qualityParam;

            // Save the image with the compression settings
            using var resized = ResizeImage(image, (int)(image.Width * ResizeFactor), (int)(image.Height * ResizeFactor));
            resized.Save(savePath, jpgEncoder, encoderParameters);

            Debug.WriteLine("--- [ImageProcessor] image saved after compressing");
        }


        // it saves a background image with low quality to be used later in cropping
        public void SaveBackgroundImage(Image originalImage, string savePath)
        {
            double resize_factor = 0.2; long quality_index = 50;

            // Set up the parameters for JPEG compression
            ImageCodecInfo? jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            if (jpgEncoder == null)
            {
                Debug.WriteLine("--- [ImageProcessor] JPEG encoder not found!");
                return;
            }

            Encoder qualityEncoder = Encoder.Quality;
            using EncoderParameters encoderParameters = new(1);

            // Set the image quality (between 0 and 100)
            using EncoderParameter qualityParam = new(qualityEncoder, quality_index);
            encoderParameters.Param[0] = qualityParam;

            int newWidth = (int)(originalImage.Width * resize_factor);
            int newHeight = (int)(originalImage.Height * resize_factor);

            try
            {
                // Avoid too much downsizing
                if (originalImage.Width > 500 && originalImage.Height > 500)
                {
                    using Image resizedImage = ResizeImage(originalImage, newWidth, newHeight);
                    resizedImage.Save(savePath, jpgEncoder, encoderParameters);
                }
                else
                {
                    originalImage.Save(savePath, jpgEncoder, encoderParameters);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            Debug.WriteLine("--- [ImageProcessor] image saved after compressing");
        }


        // --------------------- //
        #region Private functions
        // Get the JPEG encoder
        private static ImageCodecInfo? GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        // resize images
        private static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            // Calculate the new dimensions while preserving aspect ratio
            int newWidth, newHeight;
            double aspectRatio = (double)image.Width / image.Height;

            if (aspectRatio > 1)  // Landscape orientation
            {
                newWidth = Math.Min(maxWidth, image.Width);
                newHeight = (int)(newWidth / aspectRatio);
            }
            else  // Portrait orientation
            {
                newHeight = Math.Min(maxHeight, image.Height);
                newWidth = (int)(newHeight * aspectRatio);
            }

            // Adjust if dimensions exceed max values
            if (newWidth > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)(newWidth / aspectRatio);
            }

            if (newHeight > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)(newHeight * aspectRatio);
            }

            // generate a new image
            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Dispose of the original image as it's no longer needed.
            image.Dispose();

            return resizedImage;
        }
        #endregion

    }

}
