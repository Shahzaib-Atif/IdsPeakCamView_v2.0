
using ImageProcessingLibrary.Models;

/// <summary>
/// View interface for Sample Details form
/// Defines contract between View and Presenter
/// </summary>
namespace ImageProcessingLibrary.Interfaces
{
    public interface ISampleDetailsView
    {
        #region Events (View -> Presenter)

        event EventHandler ViewLoaded;
        event EventHandler SaveRequested;
        event EventHandler TipoChanged;
        event EventHandler PosIdTextChanged;

        #endregion

        #region Properties (Presenter reads from View)

        string PosId { get; }
        string Tipo { get; }
        string CorValue { get; }
        string ViasValue { get; }
        decimal InternalDiameter { get; }
        decimal ExternalDiameter { get; }
        decimal Thickness { get; }

        #endregion

        #region Methods (Presenter calls View)

        // AutoComplete configuration
        void SetPosIdAutoComplete(IEnumerable<string> posIds);

        // ComboBox population
        void PopulateTipoComboBox(List<KeyValue> items);
        void PopulateCorComboBox(List<KeyValue> items);
        void PopulateViasComboBox(List<KeyValue> items);

        // UI State
        void ShowDiameterSection();
        void HideDiameterSection();
        void SetPosIdBackColorNormal();
        void SetTipoBackColorNormal();
        void ShowWaitCursor();
        void ShowDefaultCursor();

        // Dialog operations
        DialogResult ShowYesNoDialog(string message, string title);
        DialogResult ShowNewPositionForm(string posId);
        void CloseFormWithSuccess(SampleDetail sampleDetails);

        #endregion
    }
}
