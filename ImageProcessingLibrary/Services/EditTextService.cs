using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Services
{
    public class EditTextService
    {
        #region Variables
        private Label DraggableLabel { get; set; }
        private bool IsDragging { get; set; } = false; // flag used for dragging label
        private Point DragStartPoint { get; set; } = new Point(); // used for storing Start Point of dragging label
        public float ScaleFactor { private get; set; } = 1.0f; // Default scale factor (no scaling)
        public Rectangle ActualImageRectangle { private get; set; }
        #endregion

        public EditTextService(Label label)
        {
            DraggableLabel = label;

            // Enable label dragging
            DraggableLabel.MouseDown += DraggableLabel_MouseDown;
            DraggableLabel.MouseMove += DraggableLabel_MouseMove;
            DraggableLabel.MouseUp += DraggableLabel_MouseUp;
        }


        // --------------------- //
        #region Public functions
        // update text description
        public void UpdateDescription(TextAppearanceStruct textAppearance)
        {
            DraggableLabel.Text = textAppearance.TextDescription;
            DraggableLabel.Font = textAppearance.TextFont;
            DraggableLabel.ForeColor = textAppearance.TextColor;
        }

        // retrieve text description
        public TextAppearanceStruct GetDescriptionDetails()
        {
            return new TextAppearanceStruct(DraggableLabel.Text, DraggableLabel.Font, DraggableLabel.ForeColor);
        }

        // embed text on the Image
        public void EmbedTextOntoImage(Bitmap processedImage)
        {
            if (DraggableLabel is null) return;
            using Graphics g = Graphics.FromImage(processedImage);

            // Get text related properties from draggableLabel
            string text = DraggableLabel.Text;
            Font font = DraggableLabel.Font;
            Color foreColor = DraggableLabel.ForeColor;

            // calculate updated location w.r.t scaleFactor
            Point labelLocation = new(DraggableLabel.Location.X, DraggableLabel.Location.Y);
            labelLocation.X = (int)((labelLocation.X - ActualImageRectangle.X) / ScaleFactor);
            labelLocation.Y = (int)((labelLocation.Y - ActualImageRectangle.Y) / ScaleFactor);

            // Scale the font size to match the image scaling
            using Font scaledFont = new(font.FontFamily, font.Size / ScaleFactor, font.Style);
            using Brush textBrush = new SolidBrush(foreColor);
            g.DrawString(text, scaledFont, textBrush, labelLocation);
        }
        #endregion



        // --------------------- //
        #region Private functions
        // Start dragging when the mouse button is pressed
        private void DraggableLabel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = true;
                DragStartPoint = e.Location; // Store the initial mouse position
                DraggableLabel.Cursor = Cursors.SizeAll;
            }
        }

        // Update the label's position based on the mouse movement
        private void DraggableLabel_MouseMove(object? sender, MouseEventArgs e)
        {
            if (IsDragging && sender is Label label)
            {
                label.Left += e.X - DragStartPoint.X;
                label.Top += e.Y - DragStartPoint.Y;
            }
        }

        // Stop dragging when the mouse button is released
        private void DraggableLabel_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = false;
                DraggableLabel.Cursor = Cursors.Default;
            }
        }
        #endregion
    }

}
