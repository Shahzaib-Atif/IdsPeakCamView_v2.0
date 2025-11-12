using ImageProcessingLibrary.Models;

namespace ImageProcessingLibrary.Interfaces
{
    public interface ISampleDetailsView
    {
        string PosId { get; set; }
        string Tipo { get; set; }
        string Cor { get; set; }
        string Vias { get; set; }

        event EventHandler SaveClicked;
        event EventHandler TipoChanged;
        event EventHandler SuggestNextPosId;

        void SetTipoList(IEnumerable<KeyValue> tipos);
        void SetCorsList(IEnumerable<KeyValue> cores);
        void SetViasList(IEnumerable<KeyValue> vias);
        void ShowMessage(string message);
        //void CloseWithResult(SampleDetail detail);
    }
}
