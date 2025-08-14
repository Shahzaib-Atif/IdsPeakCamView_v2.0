namespace ImageProcessingLibrary.Helpers
{
    public class DialogHelper
    {
        public static DialogResult ShowYesNoDialog(string text, string caption)
        {
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }
    }
}
