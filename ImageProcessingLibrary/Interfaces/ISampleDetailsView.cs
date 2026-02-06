
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
        event EventHandler ViasChanged;

        #endregion

        #region Properties (Presenter reads from View)

        string PosId { get; }
        string CorValue { get; }
        string ViasValue { get; }
        string Tipo { get; }

        decimal InternalDiameter { get; }
        decimal ExternalDiameter { get; }
        decimal Thickness { get; }

        string Fabricante { get; }
        string Refabricante { get; }
        string Designação { get; }
        string OBS { get; }
        string ClipColor { get; }
        string CapotAngle { get; }
        int Quantity { get; }
        int Family { get; }
        int ActualViaCount { get; }


        bool Clip { get; }
        bool Spacer { get; }
        bool Tampa { get; }
        bool Vedante { get; }
        bool Mola { get; }
        bool Moldagem { get; }
        bool Travão { get; }
        bool Abracadeira { get; }
        bool Linguetes { get; }
        bool Outros { get; }
        bool Amostra { get; }
        bool Olhal { get; }

        #endregion

        #region Methods (Presenter calls View)

        // AutoComplete configuration
        void SetPosIdAutoComplete(IEnumerable<string> posIds);

        // ComboBox population
        void PopulateTipoComboBox(List<KeyValue> items);
        void PopulateCorComboBox(List<KeyValue> items);
        void PopulateClipColorComboBox(List<KeyValue> items);
        void PopulateCapotAngleComboBox(List<string> items);
        void PopulateViasComboBox(List<KeyValue> items);
        void PopulateFabricanteComboBox(List<string> items);

        // UI State
        void ShowDiameterSection(bool status = true);
        void ShowClipColorSection(bool status = true);
        void ShowCapotAngleSection(bool status = true);
        void ShowActualViasSection(bool status = true);
        void ShowWaitCursor();
        void ShowDefaultCursor();

        // Dialog operations
        DialogResult ShowYesNoDialog(string message, string title);
        DialogResult ShowNewPositionForm(string posId);
        void CloseFormWithSuccess(SampleDetail sampleDetails);

        #endregion
    }
}
