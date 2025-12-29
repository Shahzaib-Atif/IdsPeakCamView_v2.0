namespace ImageProcessingLibrary.Helpers
{
    /// <summary>
    /// Modern color palette for the application UI
    /// All colors are carefully selected for a professional, modern appearance
    /// </summary>
    public static class UIColors
    {
        // Primary Colors
        public static readonly Color Primary = ColorTranslator.FromHtml("#2C3E50");
        public static readonly Color Secondary = ColorTranslator.FromHtml("#34495E");
        public static readonly Color Accent = ColorTranslator.FromHtml("#3498DB");

        // Semantic Colors
        public static readonly Color Success = ColorTranslator.FromHtml("#27AE60");
        public static readonly Color Warning = ColorTranslator.FromHtml("#E67E22");
        public static readonly Color Danger = ColorTranslator.FromHtml("#E74C3C");
        public static readonly Color Info = ColorTranslator.FromHtml("#3498DB");

        // Background & Surface
        public static readonly Color Background = ColorTranslator.FromHtml("#ECF0F1");
        public static readonly Color Surface = Color.White;
        public static readonly Color SurfaceSecondary = ColorTranslator.FromHtml("#F8F9FA");

        // Text Colors
        public static readonly Color TextPrimary = ColorTranslator.FromHtml("#2C3E50");
        public static readonly Color TextSecondary = ColorTranslator.FromHtml("#7F8C8D");
        public static readonly Color TextLight = Color.White;

        // Border & Divider
        public static readonly Color Border = ColorTranslator.FromHtml("#BDC3C7");
        public static readonly Color BorderLight = ColorTranslator.FromHtml("#E0E0E0");

        // Button specific
        public static readonly Color ButtonPrimary = Accent;
        public static readonly Color ButtonSuccess = Success;
        public static readonly Color ButtonDanger = Danger;
        public static readonly Color ButtonSecondary = ColorTranslator.FromHtml("#95A5A6");
        public static readonly Color ButtonCancel = ColorTranslator.FromHtml("#BDC3C7");

        // Hover states (slightly darker versions)
        public static readonly Color SuccessHover = ColorTranslator.FromHtml("#229954");
        public static readonly Color DangerHover = ColorTranslator.FromHtml("#C0392B");
        public static readonly Color AccentHover = ColorTranslator.FromHtml("#2980B9");
        public static readonly Color CancelHover = ColorTranslator.FromHtml("#95A5A6");
    }
}
