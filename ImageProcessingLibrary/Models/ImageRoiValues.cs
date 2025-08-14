namespace ImageProcessingLibrary.Models
{
    public class ImageRoiStruct
    {
        // Fields to hold the current threshold values
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Offset_X { get; private set; }
        public int Offset_Y { get; private set; }
        public static ImageRoiStruct ImageROI { get; private set; } = new(4200, 3120, 0, 0);

        public ImageRoiStruct(int w, int h, int x, int y)
        {
            Width = w;
            Height = h;
            Offset_X = x;
            Offset_Y = y;

            // make sure the values are always a multiple of 12 and 2
            Width -= Width % 12;
            Height -= Height % 2;
        }

        public static void ResetValues()
        {
            ImageROI = new(4200, 3120, 0, 0);
        }

        public static void UpdateRoiValues(int w, int h, int x, int y)
        {
            ImageROI = new(w, h, x, y);
        }


        public static int Max_Width_Sensor { get; private set; } = 4200;
        public static int Max_Height_Sensor { get; private set; } = 3120;
        public static int Min_Width_Sensor { get; private set; } = 204;
        public static int Min_Height_Sensor { get; private set; } = 102;

        public static readonly int x_inc = 12; // values in X should be its multiple
        public static readonly int y_inc = 2; // values in Y should be its multiple
    }
}
