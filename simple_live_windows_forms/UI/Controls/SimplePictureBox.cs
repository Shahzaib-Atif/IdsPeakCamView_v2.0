using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services;

namespace simple_ids_cam_view.UI.Controls
{
    public class SimplePictureBox : PictureBox, ISimplePictureBox
    {
        public Rectangle ActualImageRectangle { get; private set; }
        public Rectangle CroppingRectangle { get; set; }
        public bool IsSelecting { get; set; } = false;
        private readonly Mutex mutex = new();
        private readonly Label EditTextLabel;
        public PictureBox MyPanel { get; }
        private readonly EditTextService editTextService;
        private bool ShowCrosshair { get; set; } = false;
        private int centerX = 0;
        private int centerY = 0;

        public SimplePictureBox()
        {
            // Initialize and configure EditTextLabel
            EditTextLabel = new()
            {
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Visible = false,
            };
            Controls.Add(EditTextLabel);

            // Initialize and configure MyPanel
            MyPanel = new()
            {
                // Set Panel properties
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Zoom,
                Visible = false,
            };
            this.Controls.Add(MyPanel);
            MyPanel.Paint += MyPanel_Paint;

            // Set properties for the PictureBox
            base.SizeMode = PictureBoxSizeMode.Normal;
            base.DoubleBuffered = true;
            this.DoubleBuffered = true;

            // initialize services
            editTextService = new(EditTextLabel);
        }

        public new Image Image
        {
            get { return base.Image; }
            set { SetImage(value); }
        }

        // Use a mutex to ensure thread safety when setting the image
        private void SetImage(Image image)
        {
            mutex.WaitOne();  // Block until available
            try
            {
                var old = base.Image;
                base.Image = image;
                old?.Dispose();  // Dispose after successful assignment
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (IsSelecting)
                    return;

                mutex.WaitOne();
                UpdateDrawingArea();
                base.OnPaint(e);
                DrawCrossHair(e);
                mutex.ReleaseMutex();
            }
            finally
            {
            }
        }

        private void DrawCrossHair(PaintEventArgs e)
        {
            // first check if crosshair mode is on
            if (!ShowCrosshair) return;

            // Define PictureBox dimensions (first time only)
            if (centerX == 0 && centerY == 0)
            {
                centerX = base.Width / 2;
                centerY = base.Height / 2;
            }

            // Create a pen for drawing
            using Pen pen = new(Color.White, 1);
            // Draw horizontal line
            e.Graphics.DrawLine(pen, 0, centerY, base.Width, centerY);
            // Draw vertical line
            e.Graphics.DrawLine(pen, centerX, 0, centerX, base.Height);
        }

        private void MyPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawCroppingRect(e);
        }


        internal void ChangePanelVisibility(bool isVisible) => MyPanel.Visible = isVisible;

        internal bool ToggleCrosshair(bool forcedOff)
        {
            if (forcedOff) ShowCrosshair = false; // turn off
            else ShowCrosshair = !ShowCrosshair; // toggle

            return ShowCrosshair;
        }

        internal TextAppearanceStruct GetDescriptionDetails()
        {
            return editTextService.GetDescriptionDetails();
        }

        internal void UpdateDescription(TextAppearanceStruct textAppearanceStruct)
        {
            editTextService.UpdateDescription(textAppearanceStruct);
        }

        internal void MakeEditTextVisible(bool visible)
        {
            EditTextLabel.Visible = visible;
        }

        /// <summary> returns a processed image with the embedded text </summary>
        internal Bitmap GetProcessedImage()
        {
            if (Image == null)
                return null;

            var bmp = new Bitmap(Image);
            editTextService.EmbedTextOntoImage(bmp);
            return bmp; // caller MUST dispose
        }

        // returns a clone of the current image
        internal Bitmap GetClonedImage()
        {
            if (Image == null)
                return null;
            return new Bitmap(Image); // caller MUST dispose
        }

        private void UpdateDrawingArea()
        {
            if (Image is null)
                return;

            // Calculate the drawing area for the image
            Rectangle drawingArea = CalculateDrawingArea();

            // Calculate & update the scale factor and actualimagerectangle
            editTextService.ScaleFactor = (float)drawingArea.Width / (float)Image.Width;
            editTextService.ActualImageRectangle = drawingArea;

            // Update the actual rectangle
            ActualImageRectangle = drawingArea;
        }

        private Rectangle CalculateDrawingArea()
        {
            double aspectRatioImage = (double)Image.Width / Image.Height;
            int availableDisplayWidth = this.Width;
            int availableDisplayHeight = this.Height;

            int drawingAreaWidth, drawingAreaHeight;

            // Determine the drawing area while maintaining the aspect ratio
            if (availableDisplayWidth / (double)availableDisplayHeight > aspectRatioImage)
            {
                // The control is wider than the image's aspect ratio
                drawingAreaHeight = availableDisplayHeight;
                drawingAreaWidth = (int)(drawingAreaHeight * aspectRatioImage);
            }
            else
            {
                // The control is taller than the image's aspect ratio
                drawingAreaWidth = availableDisplayWidth;
                drawingAreaHeight = (int)(drawingAreaWidth / aspectRatioImage);
            }

            // Center the drawing area within the control
            int offsetX = (availableDisplayWidth - drawingAreaWidth) / 2;
            int offsetY = (availableDisplayHeight - drawingAreaHeight) / 2;

            return new Rectangle(offsetX, offsetY, drawingAreaWidth, drawingAreaHeight);
        }


        private void DrawCroppingRect(PaintEventArgs e)
        {
            if (IsSelecting && !CroppingRectangle.IsEmpty)
            {
                // use a Darker semi-transparent brush to draw the rectangle .. and Light blue pen for borders
                using Brush semiTransparentBrush = new SolidBrush(Color.FromArgb(100, Color.FromArgb(50, 50, 50)));
                using Pen borderPen = new(Color.FromArgb(180, 173, 216, 230), 2);
                e.Graphics.FillRectangle(semiTransparentBrush, CroppingRectangle);
                e.Graphics.DrawRectangle(borderPen, CroppingRectangle);
            }
        }
    }
}
