

namespace ImageProcessingLibrary.Interfaces
{
    public interface ISimplePictureBox
    {
        event MouseEventHandler MouseDown;
        event MouseEventHandler MouseMove;
        event MouseEventHandler MouseUp;
        bool IsSelecting { get; set; }
        Image Image { get; set; }
        Rectangle CroppingRectangle { get; set; }
        Rectangle ClientRectangle { get; }
        PictureBox MyPanel { get; }
        void Invalidate();
    }
}
