using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;
using System.Diagnostics;

namespace simple_ids_cam_view.Presenters
{
    /// <summary> Presenter for Sample Details form - contains all business logic </summary>
    public class SampleDetailsPresenter
    {
        private readonly ISampleDetailsView _view;
        private readonly ReferenciasRepository _referenciasRepo;
        private readonly CordConRepository _cordConRepo;
        private readonly MetadataRepository _metadataRepo;

        // Cache lists (same as original static lists)
        private List<KeyValue> _tipoList;
        private List<KeyValue> _corsList;
        private List<KeyValue> _viasList;
        private List<string> _fabricanteList;

        public SampleDetail SampleDetails { get; private set; }

        public SampleDetailsPresenter(
            ISampleDetailsView view,
            ReferenciasRepository referenciasRepo,
            CordConRepository cordConRepo,
            MetadataRepository metadataRepo)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _referenciasRepo = referenciasRepo ?? throw new ArgumentNullException(nameof(referenciasRepo));
            _cordConRepo = cordConRepo ?? throw new ArgumentNullException(nameof(cordConRepo));
            _metadataRepo = metadataRepo ?? throw new ArgumentNullException(nameof(metadataRepo));

            SubscribeToViewEvents();
        }

        #region Event Subscription

        private void SubscribeToViewEvents()
        {
            _view.ViewLoaded += OnViewLoaded;
            _view.SaveRequested += OnSaveRequested;
            _view.TipoChanged += OnTipoChanged;
        }

        public void UnsubscribeFromViewEvents()
        {
            _view.ViewLoaded -= OnViewLoaded;
            _view.SaveRequested -= OnSaveRequested;
            _view.TipoChanged -= OnTipoChanged;
        }

        #endregion

        #region Event Handlers

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            // Initialize autocomplete for PosId
            await ConfigureAutoCompleteForPosIdAsync();

            // Configure all comboboxes
            await ConfigureTipoCorsViasAsync();

            // Hide diameter section initially
            _view.HideDiameterSection();
        }

        private async void OnSaveRequested(object sender, EventArgs e)
        {
            // Create BasicSampleDetails object (same logic as original)
            var basicDetails = new BasicSampleDetails
            {
                PosId = _view.PosId.ToUpper(),
                Tipo = _view.Tipo,
                Cor = _view.CorValue ?? "",
                Vias = _view.ViasValue ?? "",
            };

            // Validate basic model
            if (!ModelDataValidation.Validate(basicDetails))
                return;

            // Handle PosId (check if exists or save new one)
            _view.ShowWaitCursor();
            bool isSuccess = await HandlePosIdAsync(basicDetails.PosId);
            _view.ShowDefaultCursor();

            if (!isSuccess) return;

            // Create SampleDimensions object (convert 0 to null)
            var dimensions = new SampleDimensions
            {
                InternalDiameter = _view.InternalDiameter == 0 ? null : _view.InternalDiameter,
                ExternalDiameter = _view.ExternalDiameter == 0 ? null : _view.ExternalDiameter,
                Thickness = _view.Thickness == 0 ? null : _view.Thickness
            };

            var additionalDetails = new AdditionalDetails
            {
                Fabricante = _view.Fabricante,
                Refabricante = _view.Refabricante,
                Designação = _view.Designação,
                OBS = _view.OBS
            };

            var componentDetails = new ComponentsDetails
            {
                Clip = _view.Clip,
                Spacer = _view.Spacer,
                Tampa = _view.Tampa,
                Vedante = _view.Vedante,
                Mola = _view.Mola,
                Moldagem = _view.Moldagem,
                Travão = _view.Travão,
                Abracadeira = _view.Abracadeira,
                Linguetes = _view.Linguetes,
                Outros = _view.Outros,
                Amostra = _view.Amostra,
                Olhal = _view.Olhal,
            };

            // Join PosId, Tipo & Cor to make CODIVMAC
            basicDetails.Codivmac = $"{basicDetails.PosId}{basicDetails.Cor}{basicDetails.Vias}";

            // Configure sample details & close the form
            this.SampleDetails = new SampleDetail(basicDetails, dimensions, additionalDetails, componentDetails);
            _view.CloseFormWithSuccess(this.SampleDetails);
        }

        private void OnTipoChanged(object sender, EventArgs e)
        {
            var tipo = _view.Tipo;

            // Show diameters & thickness if "Olhal" is selected
            if (tipo.ToLower() == "olhal")
                _view.ShowDiameterSection();
            else
                _view.HideDiameterSection();
        }

        #endregion

        #region Configuration Methods (same logic as original)

        private async Task ConfigureAutoCompleteForPosIdAsync()
        {
            try
            {
                var items = await _referenciasRepo.ReadAvailablePosId();
                _view.SetPosIdAutoComplete(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while trying to read available posId. {ex.Message}");
            }
        }

        private async Task ConfigureTipoCorsViasAsync()
        {
            // Run three tasks in parallel (same as original)
            await Task.WhenAll(
                ConfigureTipoAsync(),
                ConfigureCorsAsync(),
                ConfigureViasAsync(),
                ConfigureFabricanteAsync()
            );
        }

        private async Task ConfigureTipoAsync()
        {
            // Only execute first time if list is null
            if (_tipoList == null)
                await PopulateTipoListAsync();

            _view.PopulateTipoComboBox(_tipoList);
        }

        private async Task ConfigureCorsAsync()
        {
            // Only execute first time if list is null
            if (_corsList == null)
                await PopulateCorsListAsync();

            _view.PopulateCorComboBox(_corsList);
        }

        private async Task ConfigureViasAsync()
        {
            // Only execute first time if list is null
            if (_viasList == null)
                await PopulateViasListAsync();

            _view.PopulateViasComboBox(_viasList);
        }

        private async Task ConfigureFabricanteAsync()
        {
            // Only execute first time if list is null
            if (_fabricanteList == null)
                await PopulateFabricanteListAsync();

            _view.PopulateFabricanteComboBox(_fabricanteList);
        }

        private async Task PopulateTipoListAsync()
        {
            try
            {
                _tipoList = (await _metadataRepo.ReadAvailableTipo()).ToList();
                _tipoList.Insert(0, new KeyValue { Key = "", Value = "" }); // Insert empty option at the start
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Database Error: {ex.Message}");
                _tipoList = new List<KeyValue>();
            }
        }

        private async Task PopulateCorsListAsync()
        {
            _corsList = (await _metadataRepo.ReadAvailableCors()).ToList();

            // Let the user see color and its equivalent code
            foreach (var item in _corsList)
                item.Key = item.Key + $"  ({item.Value})";

            _corsList.Insert(0, new KeyValue { Key = "", Value = "" }); // Insert empty option at the start
        }

        private async Task PopulateViasListAsync()
        {
            _viasList = (await _metadataRepo.ReadAvailableVias()).ToList();

            // Let the user see vias number and its equivalent code (for numbers greater than 9)
            foreach (var item in _viasList)
            {
                if (int.Parse(item.Key) > 9)
                    item.Key = item.Key + $"  ({item.Value})";
            }

            _viasList.Insert(0, new KeyValue { Key = "", Value = "" }); // Insert empty option at the start
        }

        private async Task PopulateFabricanteListAsync()
        {
            try
            {
                _fabricanteList = (await _metadataRepo.ReadAvailableFabricante()).ToList();
                _fabricanteList.Insert(0, ""); // Insert empty option at the start
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"Database Error: {ex.Message}");
                _fabricanteList = new List<string>();
            }
        }
        #endregion

        #region Helper Methods (same logic as original)

        /// <summary> Returns true if posId exists or is successfully saved, otherwise false. </summary>
        private async Task<bool> HandlePosIdAsync(string posId)
        {
            try
            {
                // Check if the PosId already exists in the database
                if (await _cordConRepo.CheckIfPosIdExists(posId))
                {
                    return true; // No action needed if PosId exists
                }
                else
                {
                    // Prompt the user to save new coordinates for the new PosId
                    string message = "A new position has been entered.\n" +
                                     "Do you want to save new coordinates for this position?";

                    var dialogResult = _view.ShowYesNoDialog(message, "");

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Show the form to save the new coordinates
                        return (_view.ShowNewPositionForm(posId) == DialogResult.OK);
                    }
                    else
                    {
                        return false; // Return false if user cancels
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
