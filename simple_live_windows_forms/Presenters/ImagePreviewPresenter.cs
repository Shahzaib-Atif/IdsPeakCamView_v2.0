using Emgu.CV;
using Emgu.CV.Structure;
using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;

namespace simple_ids_cam_view.Presenters
{
    internal class ImagePreviewPresenter : IDisposable
    {
        #region -- Variables --
        private readonly IImagePreviewForm View;
        private readonly string _ImagesDirectory = ProjectSettings.DefaultFolder;
        private string CurrentSorting { get; set; } = ImageRecognitionModelType.Resnet50;
        #endregion


        public ImagePreviewPresenter(IImagePreviewForm view)
        {
            this.View = view;

            SubscribeToViewEvents();
        }

        public void Initialize()
        {
            OnViewLoaded(null, EventArgs.Empty);
        }

        public void ShowDialog()
        {
            this.View.ShowDialog();
        }

        private void SubscribeToViewEvents()
        {
            this.View.ViewLoaded += OnViewLoaded;
            this.View.ImageSelected += OnImageSelected;
            this.View.OpenFileRequested += OnOpenFileRequested;
            this.View.ViewInExplorerRequested += OnViewInExplorerRequested;
            this.View.CopyFilepathRequested += OnCopyFilepathRequested;
            this.View.SortingChanged += OnSortingChanged;
        }

        private void UnsubscribeFromViewEvents()
        {
            this.View.ViewLoaded -= OnViewLoaded;
            this.View.ImageSelected -= OnImageSelected;
            this.View.OpenFileRequested -= OnOpenFileRequested;
            this.View.ViewInExplorerRequested -= OnViewInExplorerRequested;
            this.View.CopyFilepathRequested -= OnCopyFilepathRequested;
            this.View.SortingChanged -= OnSortingChanged;
        }

        private void OnOpenFileRequested(object sender, EventArgs e)
        {
            string selectedImagePath = this.View.GetSelectedImagePath();
            FileHelper.OpenImageInDefaultViewer(selectedImagePath + 's');
        }

        private void OnViewInExplorerRequested(object sender, EventArgs e)
        {
            string selectedImagePath = this.View.GetSelectedImagePath();
            FileHelper.OpenImageInFileExplorer(selectedImagePath);
        }

        private void OnCopyFilepathRequested(object sender, EventArgs e)
        {
            string selectedImagePath = this.View.GetSelectedImagePath();
            Clipboard.SetText(selectedImagePath);
        }

        private void OnSortingChanged(object sender, EventArgs e)
        {
            // return if there is no change
            string selectedSortingModel = (e as SortingTypeEventArgs)?.SortingModelType;
            if (selectedSortingModel is null) return;
            if (selectedSortingModel == CurrentSorting) return;

            try
            {
                ApplySorting(selectedSortingModel);

                // update current sorting order
                this.CurrentSorting = selectedSortingModel;

                // clear selected image in the right-hand side panel
                this.View.ClearSelectedImage();

                // reload view
                OnViewLoaded(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        // change sorting order
        private static void ApplySorting(string selectedSortingModel)
        {
            switch (selectedSortingModel)
            {
                case ImageRecognitionModelType.Resnet50:
                    ImageCompareService.OrderByResnetScoreDescending();
                    break;
                case ImageRecognitionModelType.Dinov2:
                    ImageCompareService.OrderByDinov2ScoreDescending();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            // Clear old images
            this.View.ClearImages();

            // add images to the view
            foreach (var item in ImageCompareService.SimilarImages)
                LoadNewImage(item.Name, item.ResnetScore, item.Dinov2Score);
        }

        private void LoadNewImage(string imageName, float ResnetScore, float Dinov2Score)
        {
            // format score string
            string score =
                $"DinoV2 Model: {Dinov2Score * 100:F2}%\n" +
                $"Resnet Model: {ResnetScore * 100:F2}%";

            // get image path
            string imagePath = ResolveImagePath(imageName);
            if (imagePath == null) return;

            // load a new image
            using var image = Image.FromFile(imagePath);
            using var bmp = new Bitmap(image);
            var img = (Image)bmp.Clone();

            // add image item to _View
            this.View.AddImageItem(imageName, img, score, imagePath);
        }

        private void OnImageSelected(object sender, EventArgs e)
        {
            // Get the selected image file name
            string selectedImagePath = this.View.GetSelectedImagePath();
            if (selectedImagePath == null) return;

            if (File.Exists(selectedImagePath))
            {
                // Load new image
                var img = new Image<Bgr, byte>(selectedImagePath);
                this.View.DisplayImage(img);

                // update description text
                this.View.UpdateDescriptionLabel();
            }
            else
            {
                this.View.DisplayImage(null);
                this.View.HideDescriptionLabel();
            }
        }


        #region -- Helper Methods --
        private string ResolveImagePath(string imageName)
        {
            var supportedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

            return Directory
                .GetFiles(_ImagesDirectory, $"{imageName}.*")
                .FirstOrDefault(file =>
                    supportedExtensions.Any(ext =>
                        file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)));
        }

        public void Dispose()
        {
            UnsubscribeFromViewEvents();
        }
        #endregion


    }
}
