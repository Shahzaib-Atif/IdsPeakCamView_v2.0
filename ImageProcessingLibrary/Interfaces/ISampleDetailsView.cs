using Emgu.CV;
using Emgu.CV.Structure;
using ImageProcessingLibrary.Helpers;

namespace ImageProcessingLibrary.Interfaces
{
    public interface IImagePreviewView
    {
        #region Events (View -> Presenter)
        event EventHandler ViewLoaded;
        event EventHandler ImageSelected;
        event EventHandler OpenFileRequested;
        event EventHandler ViewInExplorerRequested;
        event EventHandler CopyFilepathRequested;
        event EventHandler<SortingTypeEventArgs> SortingChanged;
        event EventHandler ViewClosed;
        #endregion

        #region Methods (Presenter -> View)

        /// <summary>
        /// Add an image item to the list view
        /// </summary>
        //void AddImageToList(ImageItem item);

        /// <summary>
        /// Display the full-size image in the image box
        /// </summary>
        void DisplayImage(Image<Bgr, byte> image);

        /// <summary>
        /// Update the description label text
        /// </summary>
        void UpdateDescription(string description);

        /// <summary>
        /// Show the description label
        /// </summary>
        void ShowDescriptionLabel();

        /// <summary>
        /// Hide the description label
        /// </summary>
        void HideDescriptionLabel();

        /// <summary>
        /// Clear all images from the view
        /// </summary>
        void ClearAllImages();

        /// <summary>
        /// Clear the currently selected/displayed image
        /// </summary>
        void ClearSelectedImage();

        /// <summary>
        /// Get the file path of the currently selected image
        /// </summary>
        string GetSelectedImagePath();

        /// <summary>
        /// Get the file name of the currently selected image
        /// </summary>
        string GetSelectedFileName();

        /// <summary>
        /// Show the form as a dialog
        /// </summary>
        void ShowDialog();

        /// <summary>
        /// Close the form
        /// </summary>
        void Close();

        #endregion
    }
}
