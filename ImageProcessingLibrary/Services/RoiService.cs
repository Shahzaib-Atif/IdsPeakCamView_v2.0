using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;
using static ImageProcessingLibrary.Models.ImageRoiStruct;

namespace ImageProcessingLibrary.Services
{
    public class RoiService
    {
        #region Variables
        private readonly ISimplePictureBox _pictureBox;
        private Point _startPoint;
        private Rectangle _roiRect;
        private bool _isSelecting = false;
        private bool IsSelectionEnabled { get; set; } = true; // true at the beginning
        public bool IsServiceValid { get; set; } = true; // false if service no longer in use
        public event EventHandler? MouseSelectionEnded; // an event to denote that user has stopped cropping
        #endregion

        public RoiService(ISimplePictureBox pictureBox)
        {
            this._pictureBox = pictureBox;

            // Attach event handlers
            _pictureBox.MyPanel.MouseDown += PictureWindow_MouseDown;
            _pictureBox.MyPanel.MouseMove += PictureWindow_MouseMove;
            _pictureBox.MyPanel.MouseUp += PictureWindow_MouseUp;
        }

        #region -- Event Handlers
        private void PictureWindow_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!IsSelectionEnabled || !IsServiceValid) return;

            _isSelecting = true;
            _startPoint = e.Location;
            _roiRect = new Rectangle(e.X, e.Y, 0, 0);
        }

        private void PictureWindow_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isSelecting && IsSelectionEnabled && IsServiceValid)
            {
                // Handle negative width/height
                _roiRect = new Rectangle(
                    Math.Min(_startPoint.X, e.X),
                    Math.Min(_startPoint.Y, e.Y),
                    Math.Abs(e.X - _startPoint.X),
                    Math.Abs(e.Y - _startPoint.Y)
                );

                // Pass the ROI rectangle to PictureWindow for visual feedback
                _pictureBox.CroppingRectangle = _roiRect;
                _pictureBox.IsSelecting = true;

                _pictureBox.MyPanel.Refresh();  // Trigger a repaint for visual feedback
            }
        }

        private void PictureWindow_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!IsSelectionEnabled || !IsServiceValid) return;

            _isSelecting = false;
            _pictureBox.IsSelecting = false;
            _pictureBox.Invalidate();  // Refresh the PictureWindow

            UpdateRoiValues();

            // disable selection when mouse is up
            IsSelectionEnabled = false;

            // invoke this event so that subscribers (mainform) can know that cropping has ended
            MouseSelectionEnded?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private void UpdateRoiValues()
        {
            int w = UpdateWidth(_roiRect.Width);
            int h = UpdateHeight(_roiRect.Height);

            // normal case without mirroring
            //int x = UpdateOffsetX(_roiRect.X, w);
            //int y = UpdateOffsetY(_roiRect.Y, h);

            // this is valid if x and y are mirrored from camera image
            int x = UpdateOffsetX_mirrored(_roiRect.X, w);
            int y = UpdateOffsetY_mirrored(_roiRect.Y, h);

            ImageRoiStruct.UpdateRoiValues(w, h, x, y);
        }


        #region -- X-Direction Helper Functions
        // this is for the normal cases without mirroring
        private int UpdateOffsetX(int offset_X, int newImageWidth)
        {
            int val = GetScaledVal_X(offset_X);

            if (val + newImageWidth > Max_Width_Sensor)
                val = Max_Width_Sensor - newImageWidth;

            return val;
        }

        // this is valid if camera image is mirrored
        private int UpdateOffsetX_mirrored(int offset_X, int newImageWidth)
        {
            int val = GetScaledVal_X(offset_X);
            val = Max_Width_Sensor - (val + newImageWidth); // Flip X-axis

            if (val < 0) val = 0; // Prevent negative offsets

            return val;
        }

        private int UpdateWidth(int width)
        {
            int val = GetScaledVal_X(width);
            if (val > Max_Width_Sensor) val = Max_Width_Sensor;
            if (val < Min_Width_Sensor) val = Min_Width_Sensor;

            return val;
        }

        private int GetScaledVal_X(int val)
        {
            Rectangle windowRect = _pictureBox.ClientRectangle;
            float imageRatio1 = (float)(ImageROI.Width) / windowRect.Width;
            float imageRatio2 = 1;

            int scaled_val = (int)(val * imageRatio1 * imageRatio2);
            scaled_val -= scaled_val % x_inc;
            return scaled_val;
        }
        #endregion


        #region -- Y-direction Helper Functions

        // this is for the normal cases without mirroring
        private int UpdateOffsetY(int offset_Y, int newImageHeight)
        {
            int val = GetScaledVal_Y(offset_Y);

            if (val + newImageHeight > Max_Height_Sensor)
                val = Max_Height_Sensor - newImageHeight;

            return val;
        }

        // this is valid if camera image is mirrored
        private int UpdateOffsetY_mirrored(int offset_Y, int newImageHeight)
        {
            int val = GetScaledVal_Y(offset_Y);
            val = Max_Height_Sensor - (val + newImageHeight); // Flip Y-axis

            if (val < 0) val = 0; // Prevent negative offsets

            return val;
        }

        private int UpdateHeight(int height)
        {
            int val = GetScaledVal_Y(height);
            if (val > Max_Height_Sensor) val = Max_Height_Sensor;
            if (val < Min_Height_Sensor) val = Min_Height_Sensor;

            return val;
        }

        private int GetScaledVal_Y(int val)
        {
            Rectangle windowRect = _pictureBox.ClientRectangle;
            float imageRatio1 = (float)(ImageROI.Height) / windowRect.Height;
            float imageRatio2 = 1;

            int scaled_val = (int)(val * imageRatio1 * imageRatio2);
            scaled_val -= scaled_val % y_inc;
            return scaled_val;
        }
        #endregion
    }
}
