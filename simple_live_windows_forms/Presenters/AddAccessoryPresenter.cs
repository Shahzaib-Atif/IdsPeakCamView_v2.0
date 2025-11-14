using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Interfaces;
using ImageProcessingLibrary.Models;
using ImageProcessingLibrary.Services.Database;

namespace simple_ids_cam_view.Presenters
{
    public class AddAccessoryPresenter
    {
        private readonly IAddAccessoryView _view;
        private readonly AccessoryRepository _accessoryRepo;
        private readonly ReferenciasRepository _referenciasRepo;
        private AutoCompleteStringCollection codivmacCollection;
        private AutoCompleteStringCollection posIdCollection;
        public AccessoryDetails AccessoryDetails { get; set; }


        public AddAccessoryPresenter(IAddAccessoryView view, AccessoryRepository accessoryRepo, ReferenciasRepository referenciasRepo)
        {
            _view = view;
            _accessoryRepo = accessoryRepo;
            _referenciasRepo = referenciasRepo;

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _view.ViewLoaded += OnViewLoaded;
            _view.ColorAssociatedChanged += OnColorAssociatedChanged;
            _view.SaveRequested += OnSaveRequested;
        }

        public void UnsubscribeFromViewEvents()
        {
            _view.ViewLoaded -= OnViewLoaded;
            _view.ColorAssociatedChanged -= OnColorAssociatedChanged;
            _view.SaveRequested -= OnSaveRequested;
        }


        #region -- Event Handlers

        private void OnSaveRequested(object sender, EventArgs e)
        {
            // create a new basicDetails object
            var details = new AccessoryDetails
            {
                ConnectorName = _view.ConnectorName.ToUpper(),
                Tipo = _view.ConnectorType,
                Reference = _view.Reference,
            };

            // Update FullName property
            details.FullName = $"{details.ConnectorName}_{details.Reference}";

            // check basic model validation
            if (!ModelDataValidation.Validate(details)) return;

            // if the Connector does not exist, then we cannot proceed
            if (_view.ColorAssociated)
            {
                if (posIdCollection is null || !posIdCollection.Contains(details.ConnectorName))
                {
                    ExceptionHelper.ShowWarningMessage("Cannot find this connector name in the existing data!");
                    return;
                }
            }
            else
            {
                if (codivmacCollection is null || !codivmacCollection.Contains(details.ConnectorName))
                {
                    ExceptionHelper.ShowWarningMessage("Cannot find this connector name in the existing data!");
                    return;
                }
            }

            // configure sample details & close the form
            this.AccessoryDetails = details;
            _view.CloseFormWithSuccess();
        }

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            ConfigureAutoCompleteForConnectorNames();
            ConfigureTipo();

            _view.SetAutoCompleteForConnNames(codivmacCollection);
        }

        private void OnColorAssociatedChanged(object sender, EventArgs e)
        {
            _view.SwitchAutoCompleteSource(_view.ColorAssociated ? posIdCollection : codivmacCollection);
        }

        #endregion


        #region -- Configuration Methods
        private async void ConfigureAutoCompleteForConnectorNames()
        {
            await Task.WhenAll(
                InitializeCodivmacCollection(), InitializePosIdCollection()
            );
        }

        private async Task InitializeCodivmacCollection()
        {
            try
            {
                codivmacCollection ??= new(); // initialize only first time
                codivmacCollection.Clear(); // clear the list

                var items = await _referenciasRepo.ReadAvailableCodivmac(); // fetch data from db
                codivmacCollection.AddRange(items.ToArray()); // add to collection
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        private async Task InitializePosIdCollection()
        {
            try
            {
                posIdCollection ??= new(); // initialize only first time
                posIdCollection.Clear();

                var items = await _referenciasRepo.ReadAvailablePosId(); // fetch data from db
                posIdCollection.AddRange(items.ToArray()); // add to collection
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }

        private async void ConfigureTipo()
        {
            try
            {
                var items = (await _accessoryRepo.ReadAvailableAccessoryTypes()).ToList();
                items.Insert(0, ""); // add empty option

                _view.PopulateTipoComboBox(items);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }
        #endregion
    }
}
