using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.Presenters
{
    public class SampleDetailsPresenter
    {
        private readonly ISampleDetailsView _view;
        private readonly ReferenciasRepository _refRepo;
        private readonly CordConRepository _cordRepo;
        private readonly MetadataRepository _metaRepo;

        public SampleDetailsPresenter(ISampleDetailsView view)
        {
            _view = view;
            _refRepo = new ReferenciasRepository();
            _cordRepo = new CordConRepository();
            _metaRepo = new MetadataRepository();

            _view.SaveClicked += OnSaveClicked;
            _view.TipoChanged += OnTipoChanged;
            _view.SuggestNextPosId += OnSuggestNextPosId;

            Init();
        }

        private async void Init()
        {
            _view.SetTipoList(await _metaRepo.ReadAvailableTipo());
            _view.SetCorsList(await _metaRepo.ReadAvailableCors());
            _view.SetViasList(await _metaRepo.ReadAvailableVias());
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Build model, validate, handle DB calls
            // then call _view.CloseWithResult(detail)
        }

        private void OnTipoChanged(object sender, EventArgs e)
        {
            // Update UI flags (handled via view interface)
        }

        private async void OnSuggestNextPosId(object sender, EventArgs e)
        {
            // Fetch last CON and suggest next ID
        }
    }
}
