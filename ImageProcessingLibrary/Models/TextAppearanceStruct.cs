namespace ImageProcessingLibrary.Models
{
    public readonly struct TextAppearanceStruct
    {
        public readonly string TextDescription;
        public readonly Font TextFont;
        public readonly Color TextColor;

        public TextAppearanceStruct(string text, Font font, Color foreColor)
        {
            this.TextDescription = text;
            this.TextFont = font;
            this.TextColor = foreColor;
        }
    }
}
