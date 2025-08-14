namespace ImageProcessingLibrary.Helpers
{
    public class SortingTypeEventArgs : EventArgs
    {
        public string SortingModelType { get; set; }

        public SortingTypeEventArgs(string sortingType)
        {
            SortingModelType = sortingType;
        }
    }
}
