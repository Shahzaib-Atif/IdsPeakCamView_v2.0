using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageProcessingLibrary.Interfaces
{
    public interface IImagePreviewForm
    {
        event EventHandler ViewLoaded;
        event EventHandler ImageSelected;
        event EventHandler OpenFileRequested;
        event EventHandler ViewInExplorerRequested;
        event EventHandler CopyFilepathRequested;
        event EventHandler SortingChanged;

        void ClearImages();
        void AddImageItem(string imageName, Image image, string score, string imagePath);
        void ShowDialog();
        void ShowDescriptionLabel();
        string GetSelectedImagePath();
        void DisplayImage(Image<Bgr, byte>? img);
        void UpdateDescriptionLabel();
        void HideDescriptionLabel();
        string GetSelectedFileName();
        void ClearSelectedImage();
    }
}
