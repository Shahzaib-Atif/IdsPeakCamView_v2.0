


using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Interfaces
{
    public interface IAddAccessoryView
    {
        string ConnectorName { get; }
        string ConnectorType { get; }
        string Reference { get; }
        string RefDV { get; }
        bool ColorAssociated { get; }
        string ClipColor { get; }
        string CapotAngle { get; }
        int Quantity { get; }

        event EventHandler ViewLoaded;
        event EventHandler ColorAssociatedChanged;
        event EventHandler SaveRequested;
        event EventHandler TipoChanged;

        void CloseFormWithSuccess();
        void PopulateClipColorComboBox(IEnumerable<KeyValue> items);
        void PopulateCapotAngleComboBox(IEnumerable<string> items);
        void PopulateTipoComboBox(IEnumerable<string> items);
        void SetAutoCompleteForConnNames(AutoCompleteStringCollection codivmacCollection);
        void SwitchAutoCompleteSource(AutoCompleteStringCollection autoCompleteStringCollection);
        void ToggleCapotAngleVisibility(bool showCapotAngle);
        void ToggleClipColorVisibility(bool showClipColor);
    }
}
