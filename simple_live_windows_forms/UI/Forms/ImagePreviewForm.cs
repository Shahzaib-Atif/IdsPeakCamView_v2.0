using Emgu.CV;
using Emgu.CV.Structure;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Services;

namespace TriCamPylonView.UI.Forms
{
    public partial class ImagePreviewForm : Form, IImagePreviewForm
    {
        #region -- Variables --
        private List<Image> ManagedImages { get; } = new(); // to manage lifespan of loaded images

        public event EventHandler ViewLoaded;
        public event EventHandler ImageSelected;
        public event EventHandler OpenFileRequested;
        public event EventHandler ViewInExplorerRequested;
        public event EventHandler CopyFilepathRequested;
        public event EventHandler SortingChanged;
        public event EventHandler ViewClosed;
        #endregion

        // ctor
        public ImagePreviewForm()
        {
            InitializeComponent();
            comboBoxSortingType.SelectedIndex = 1;

            this.FormClosed += ImagePreviewForm_FormClosed;
        }


        #region -- Public Methods --


        public void AddImageItem(string imageName, Image image, string score, string imagePath)
        {
            try
            {
                ManagedImages.Add(image); // Store the loaded image
                imageList.Images.Add(imageName, image); // Add image to ImageList

                // create new litsviewitem
                var newListViewItem = new ListViewItem(imageName, imageList.Images.IndexOfKey(imageName));

                // add subitems
                newListViewItem.SubItems.Add(score); // subitems[1]
                newListViewItem.SubItems.Add(imagePath); // subitem[2]

                // add new item to the list
                listView.Items.Add(newListViewItem);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Error loading image: {ex.Message}");
            }
        }

        // loads and displays the selected image and its description
        public void DisplayImage(Image<Bgr, byte> img)
        {
            try
            {
                // Dispose previous image first
                imageBox.Image?.Dispose();
                imageBox.Image = null;

                // Set image to ImageBox
                imageBox.Image = img;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying image: {ex.Message}");
            }
        }

        public void UpdateDescriptionLabel()
        {
            if (listView.SelectedItems.Count > 0)
            {
                ShowDescriptionLabel();

                // update description text
                labelDescription.Text = listView.SelectedItems[0].SubItems[1].Text;
            }
        }

        public string GetSelectedImagePath()
        {
            if (listView.SelectedItems.Count > 0)
                return listView.SelectedItems[0].SubItems[2].Text;
            else
                return null;
        }

        public string GetSelectedFileName()
        {
            if (listView.SelectedItems.Count > 0)
                return listView.SelectedItems[0].Text;
            else
                return null;
        }

        /// <summary> show the label if it is hidden (the label is hidden initially) </summary>
        public void ShowDescriptionLabel()
        {
            if (!labelDescription.Visible)
                labelDescription.Visible = true;
        }

        /// <summary> hide the label if it is shown </summary>
        public void HideDescriptionLabel()
        {
            if (labelDescription.Visible)
                labelDescription.Visible = false;
        }
        #endregion


        #region ------- UI Events -------
        // show the selected image and its description
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure an item is selected
            if (listView.SelectedItems.Count > 0)
                ImageSelected?.Invoke(this, EventArgs.Empty);
        }

        // open the selected image in default image viewer
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
                OpenFileRequested?.Invoke(sender, EventArgs.Empty);
        }

        // _View the selected image in file explorer
        private void BtnViewInExplorer_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
                ViewInExplorerRequested?.Invoke(sender, EventArgs.Empty);
        }

        // copy the file path of selected image
        private void BtnCopyFilePath_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
                CopyFilepathRequested?.Invoke(sender, EventArgs.Empty);
        }

        private void BtnShowDetails_Click(object sender, EventArgs e)
        {
            //using var f = new ShowDetailsForm();
            //f.ShowDialog();
        }

        // close the form if Esc is pressed
        private void ImagePreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        // change the image comparison model type
        private void SortingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSortingType.SelectedItem is string selectedSortingModel)
            {
                var eventArgs = new SortingTypeEventArgs(selectedSortingModel);
                SortingChanged?.Invoke(sender, eventArgs);
            }
        }

        private void ImagePreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ClearImages();

            // clear manage images
            foreach (Image img in ManagedImages) { img?.Dispose(); }
            ManagedImages.Clear();

            // Clear the list of similar images
            ImageCompareService.ClearSimilarImages();
        }

        /// <summary> Clear Imagelist and listview, and cleanup images </summary>
        public void ClearImages()
        {
            imageList.Images.Clear();
            listView.Items.Clear();

            imageBox.Image?.Dispose();
            imageBox.Image = null;

            foreach (Image img in ManagedImages)
            {
                img?.Dispose();
            }

            ManagedImages.Clear();
        }

        public void ClearSelectedImage()
        {
            this.labelDescription.Text = "";

            imageBox.Image?.Dispose();
            imageBox.Image = null;
        }
        #endregion


        void IImagePreviewForm.ShowDialog()
        {
            this.ShowDialog();
        }

        private static ImagePreviewForm instance;
        public static ImagePreviewForm GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ImagePreviewForm
                {
                    //MdiParent = parentContainer,
                    //Dock = DockStyle.Fill,
                    //FormBorderStyle = FormBorderStyle.None,
                    //DoubleBuffered = true
                };
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

    }
}
