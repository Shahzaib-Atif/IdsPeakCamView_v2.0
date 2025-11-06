using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;
using ImageProcessingLibrary.Services.Database;
using simple_ids_cam_view.Presenters;
using simple_ids_cam_view.UI.Controls;
using simple_ids_cam_view.UI.Forms;
using System.ComponentModel;
using System.Diagnostics;
using TriCamPylonView.UI.Forms;

namespace simple_ids_cam_view.Services
{
    internal class BackgroundWorkerService
    {
        #region -- variables --
        private BackgroundWorker BgWorker { get; } = new BackgroundWorker();
        // Use Stopwatch to measure the time taken
        private Stopwatch Stopwatch { get; } = new Stopwatch();
        private SimplePictureBox CustomPictureBox { get; set; }
        private ProgressBar ProgressBar { get; set; }
        private GroupBox GbxProgress { get; set; }
        private string SourceImageFilepath { get; set; }
        private SampleDetail SampleDetails { get; set; }
        private List<ConnectorMatch> TopMatches { get; set; }

        // use these two fields for uploading images from some folder to the DB
        private bool _AddImagesToDbFromFolder = false;
        private string selectedFolderForUploadingImages;
        private readonly string _cancellationMessage = "The operation was canceled.";
        #endregion

        public BackgroundWorkerService(SimplePictureBox customPictureBox, ProgressBar progressBar, GroupBox gbxProgress)
        {
            // set the params
            this.CustomPictureBox = customPictureBox;
            this.ProgressBar = progressBar;
            this.GbxProgress = gbxProgress;

            // assign event handlers
            BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            BgWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            BgWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            BgWorker.WorkerReportsProgress = true;
            BgWorker.WorkerSupportsCancellation = true;
        }

        /// <summary> find similar images from database based on their features </summary>
        public void FindSimilarImages(bool IsUsingCurrentImage)
        {
            // Validate default folder or prompt user to update it.
            if (FileHelper.IsDefaultFolderUpdateRequired())
            {
                using var f1 = new DefaultFolderForm();
                f1.ShowDialog();
            }

            // return if the directory still does not exist for the default folder
            if (!Directory.Exists(ProjectSettings.DefaultFolder))
            {
                ExceptionHelper.ShowDefaultFolderNotFoundWarning();
                return;
            }

            // choose filePath
            string filePath = SelectFilePath(IsUsingCurrentImage);
            if (!string.IsNullOrEmpty(filePath))
            {
                // get otpional connector details for a filtered search
                using var f = new SampleDetailsForm(isSaveMode: false);
                if (f.ShowDialog() != DialogResult.OK) return; // return if user has cancelled the process

                // start the process
                this.Start(filePath, f.SampleDetails);
            }
        }


        // Starts the background worker process if not already running
        public void Start(string sourceFilepath, SampleDetail sampleDetails, bool AddImagesToDbFromFolder = false)
        {
            //DatabaseManager.SaveFeatures(sourceFilepath, vector);

            if (string.IsNullOrEmpty(sourceFilepath) || BgWorker is null)
                return;

            Debug.WriteLine($"--- [BackgroundWorkerService] Source filePath: {sourceFilepath}");

            //assign params
            this.SourceImageFilepath = sourceFilepath;
            this.SampleDetails = sampleDetails;

            // Update UI for progress
            SetupInitialProgressUI();

            if (AddImagesToDbFromFolder)
            {
                if (!TrySelectFolderForImageUpload())
                {
                    GbxProgress.Visible = false;
                    return;
                }

                ConfigureProgressBarForImagesUpload();
            }
            else
            {
                ConfigureProgressBarForSearch();
            }

            // Start background processing
            if (!BgWorker.IsBusy)
                BgWorker.RunWorkerAsync();
        }

        // Saves the processed image with a pre-defined name, and returns a filepath
        private string SaveTempImage(string name)
        {
            // get default save location
            string filePath = Path.Combine(ProjectSettings.DefaultFolder, name);

            // get image
            using var _image = new Bitmap(this.CustomPictureBox.Image);
            if (_image is null) return null;

            // save image after processing
            ImageProcessor.SaveCompressedImage(_image, filePath);

            return filePath;
        }


        #region -- BackgroundWorker Events --
        // BackgroundWorker DoWork method, handles the main comparison process
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // start the stopwatch
            Stopwatch.Start();

            if (_AddImagesToDbFromFolder)
            {
                UploadImageFeaturesFromFolder(e).GetAwaiter().GetResult();
            }
            else
            {
                var topMatches = OnnxService.FindMatchingImages(this.SourceImageFilepath);
                ImageCompareService.AssignListOfSimilarImages(topMatches);
            }

            // Stop the stopwatch after the process is done
            Stopwatch.Stop();
        }

        // Updates progress on the progress bar
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        // Handles the process when the worker completes its task
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ProgressBar.MarqueeAnimationSpeed = 0; // stop the marquee animation (for marquee mode)

            // reset stopwatch and note the time
            TimeSpan timeTaken = Stopwatch.Elapsed;
            Stopwatch.Reset();

            // show appropriate message
            if (e.Cancelled)
                ExceptionHelper.ShowWarningMessage(_cancellationMessage);
            else
                ExceptionHelper.ShowSuccessMessage($"Process was completed in {timeTaken.Seconds} seconds.");

            // hide progress bar
            GbxProgress.Visible = false;

            if (!_AddImagesToDbFromFolder) // this flag is by default always false
                ShowSimilarImages();

            // clear the flag again after the process is done
            _AddImagesToDbFromFolder = false;

            this.GbxProgress.Cursor = Cursors.Default;
        }
        #endregion

        /// <summary> Show similar images if available, sorted and limited to 15, in a preview form. </summary>
        private static void ShowSimilarImages()
        {
            // show similar images if available
            if (ImageCompareService.SimilarImages.Count >= 1)
            {
                var _view = ImagePreviewForm.GetInstance();
                var presenter = new ImagePreviewPresenter(_view);
                presenter.Initialize();
                presenter.ShowDialog();
                presenter.Dispose();
            }
        }


        // Add images to DB from the specified folder
        private async Task UploadImageFeaturesFromFolder(DoWorkEventArgs e)
        {
            int processedFiles = 0;

            // get all the files from selected folder (there is a size limit in this function)
            var files = FileHelper.GetFilteredImagePaths(this.selectedFolderForUploadingImages);
            if (files is null) return;

            int totalFiles = files.Length;
            using var resnetExtractor = new FeatureExtractorResnet50();
            using var dinov2Extractor = new FeatureExtractorDINOv2();

            // process each filePath
            foreach (var filePath in files)
            {
                if (BgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    float[] resnetVector = resnetExtractor.ExtractFeatures(filePath);
                    float[] dinov2Vector = dinov2Extractor.ExtractFeatures(filePath);
                    await DatabaseManager.SaveFeatures(fileName, resnetVector, dinov2Vector);
                    //await DatabaseManager.UpdateFeatures(fileName, resnetVector, dinov2Vector); // use this line if you are updating
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error while adding {filePath}: {ex.Message}");
                }

                // Thread-safe update of processed files count and reporting progress
                Interlocked.Increment(ref processedFiles);
                BgWorker.ReportProgress(processedFiles * 100 / totalFiles);
            }
        }


        #region -- Helper Methods --
        // returns false if user does not select a folder
        private bool TrySelectFolderForImageUpload()
        {
            // update flag
            _AddImagesToDbFromFolder = true;

            // select a folder
            using FolderBrowserDialog folderBrowserDialog = new();
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return false;
            // else
            this.selectedFolderForUploadingImages = folderBrowserDialog.SelectedPath;
            return true;
        }

        // select filePath path based on the flag IsUsingCurrentImage
        private string SelectFilePath(bool IsUsingCurrentImage)
        {
            string filePath =
                IsUsingCurrentImage ?
                SaveTempImage("temp.jpeg") :
                FileHelper.SelectImageFilePath();

            if (string.IsNullOrEmpty(filePath))
                ExceptionHelper.ShowWarningMessage("No image selected or the filePath path is empty. Process cancelled!");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return filePath;
        }
        #endregion


        #region -- Progress Bar Configuration Methods --
        private void SetupInitialProgressUI()
        {
            this.GbxProgress.Cursor = Cursors.WaitCursor;
            this.GbxProgress.Visible = true;
            this.ProgressBar.Value = 0;
        }

        private void ConfigureProgressBarForImagesUpload()
        {
            GbxProgress.Text = "Uploading images from folder to DB ...";
            ProgressBar.Style = ProgressBarStyle.Blocks;
        }

        private void ConfigureProgressBarForSearch()
        {
            GbxProgress.Text = "Searching for similar images ...";
            ProgressBar.Style = ProgressBarStyle.Marquee;
            ProgressBar.MarqueeAnimationSpeed = 30;
        }
        #endregion
    }

}
