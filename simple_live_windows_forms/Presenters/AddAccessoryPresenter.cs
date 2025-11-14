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
        private readonly MetadataRepository _metadataRepo;
        private AutoCompleteStringCollection codivmacCollection;
        private AutoCompleteStringCollection posIdCollection;
        private bool showCapotAngle;
        private bool showClipColor;

        public AccessoryDetails AccessoryDetails { get; set; }


        public AddAccessoryPresenter(IAddAccessoryView view, AccessoryRepository accessoryRepo,
            ReferenciasRepository referenciasRepo, MetadataRepository metadataRepository)
        {
            _view = view;
            _accessoryRepo = accessoryRepo;
            _referenciasRepo = referenciasRepo;
            _metadataRepo = metadataRepository;

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _view.ViewLoaded += OnViewLoaded;
            _view.ColorAssociatedChanged += OnColorAssociatedChanged;
            _view.SaveRequested += OnSaveRequested;
            _view.TipoChanged += OnTipoChanged;
        }

        public void UnsubscribeFromViewEvents()
        {
            _view.ViewLoaded -= OnViewLoaded;
            _view.ColorAssociatedChanged -= OnColorAssociatedChanged;
            _view.SaveRequested -= OnSaveRequested;
            _view.TipoChanged -= OnTipoChanged;
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
                Quantity = _view.Quantity,
                ColorAssociated = _view.ColorAssociated
            };

            // conditionally fields
            if (!string.IsNullOrEmpty(_view.RefDV)) details.RefDV = _view.RefDV;
            if (showCapotAngle) details.CapotAngle = _view.CapotAngle;
            if (showClipColor) details.ClipColor = _view.ClipColor;

            // Update FullName property
            details.FullName = $"{details.ConnectorName}_{details.Reference}";
            if (!string.IsNullOrEmpty(details.RefDV))
                details.FullName += $"_{details.RefDV}";

            // check basic model validation
            if (!ModelDataValidation.Validate(details)) return;

            // if the Connector does not exist, then we cannot proceed
            if (!_view.ColorAssociated && !posIdCollection.Contains(details.ConnectorName))
            {
                ExceptionHelper.ShowWarningMessage("This entry does not match with any existing [Pos ID]!");
                return;
            }
            else if (_view.ColorAssociated && !codivmacCollection.Contains(details.ConnectorName))
            {
                ExceptionHelper.ShowWarningMessage("This entry does not match with any existing [CODIVMAC]!");
                return;
            }

            // configure sample details & close the form
            this.AccessoryDetails = details;
            _view.CloseFormWithSuccess();
        }

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            await Task.WhenAll(
                InitializeCodivmacCollectionAsync(),
                InitializePosIdCollectionAsync(),
                ConfigureTipoAsync(),
                ConfigureCorsAsync(),
                ConfigureCapotAnglesAsync()
                );

            _view.SetAutoCompleteForConnNames(posIdCollection); // initialize with PosId collection
        }

        private void OnColorAssociatedChanged(object sender, EventArgs e)
        {
            _view.SwitchAutoCompleteSource(_view.ColorAssociated ? codivmacCollection : posIdCollection);
        }


        private void OnTipoChanged(object sender, EventArgs e)
        {
            showCapotAngle = _view.ConnectorType.Equals("CAPOT", StringComparison.OrdinalIgnoreCase);
            showClipColor = _view.ConnectorType.Equals("CLIPS", StringComparison.OrdinalIgnoreCase);

            _view.ToggleCapotAngleVisibility(showCapotAngle);
            _view.ToggleClipColorVisibility(showClipColor);
        }
        #endregion


        #region -- Configuration Methods

        private async Task InitializeCodivmacCollectionAsync()
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

        private async Task InitializePosIdCollectionAsync()
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

        private async Task ConfigureTipoAsync()
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

        private async Task ConfigureCorsAsync()
        {
            var items = (await _metadataRepo.ReadAvailableCors()).ToList();

            // Let the user see color and its equivalent code
            foreach (var item in items)
                item.Key = item.Key + $" ({item.Value})";

            items.Insert(0, new KeyValue { Key = "", Value = "" }); // Insert empty option at the start

            _view.PopulateClipColorComboBox(items);
        }

        private async Task ConfigureCapotAnglesAsync()
        {
            try
            {
                var items = (await _metadataRepo.ReadAvailableCapotAngles()).ToList();
                items.Insert(0, ""); // add empty option
                _view.PopulateCapotAngleComboBox(items);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowWarningMessage(ex.Message);
            }
        }
        #endregion

    }
}
