


namespace ImageProcessingLibrary.Interfaces
{
    public interface IAddAccessoryView
    {
        string ConnectorName { get; }
        string ConnectorType { get; }
        string Reference { get; }
        bool ColorAssociated { get; }

        event EventHandler ViewLoaded;
        event EventHandler ColorAssociatedChanged;
        event EventHandler SaveRequested;

        void CloseFormWithSuccess();
        void PopulateTipoComboBox(IEnumerable<string> items);
        void SetAutoCompleteForConnNames(AutoCompleteStringCollection codivmacCollection);
        void SwitchAutoCompleteSource(AutoCompleteStringCollection autoCompleteStringCollection);
    }
}
