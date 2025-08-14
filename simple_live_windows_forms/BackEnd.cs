using simple_ids_cam_view.Services;
using System.Diagnostics;
using deviceHandler = simple_ids_cam_view.Services.DeviceManagerHandler;

namespace simple_ids_cam_view
{
    class BackEnd
    {
        // Event which is raised if a new image was received
        public delegate void ImageReceivedEventHandler(object sender, Bitmap image);
        public event ImageReceivedEventHandler ImageReceived;

        // Event which is raised if the counters has changed
        public delegate void CounterChangedEventHandler(object sender, uint frameCounter, uint errorCounter);
        public event CounterChangedEventHandler CounterChanged;

        // Event which is raised if an Error or Exception has occurred
        public delegate void MessageBoxTriggerEventHandler(object sender, string messageTitle, string messageText);
        public event MessageBoxTriggerEventHandler MessageBoxTrigger;

        internal AcquisitionWorker acquisitionWorker;
        internal Thread acquisitionThread;

#pragma warning disable IDE1006 // Naming Styles
        private peak.core.Device device { get; set; }
        private peak.core.DataStream dataStream { get; set; }
        private peak.core.NodeMap nodeMapRemoteDevice { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public BackEnd()
        {
            InitializeBackend();
        }

        public void InitializeBackend()
        {
            Debug.WriteLine("--- [BackEnd] Init");

            try
            {
                // Create acquisition worker thread that waits for new images from the camera
                acquisitionWorker = new AcquisitionWorker();
                acquisitionThread = new Thread(new ThreadStart(acquisitionWorker.Start));

                acquisitionWorker.ImageReceived += AcquisitionWorker_ImageReceived;
                acquisitionWorker.CounterChanged += AcquisitionWorker_CounterChanged;
                acquisitionWorker.MessageBoxTrigger += AcquisitionWorker_MessageBoxTrigger;

                // Initialize peak library
                peak.Library.Initialize();
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Exception: " + e.Message);
            }
        }

        public bool Start()
        {
            Debug.WriteLine("--- [BackEnd] Start");
            if (!OpenDevice())
                return false;

            // Start thread execution
            acquisitionThread.Start();

            return true;
        }

        public void Stop()
        {
            Debug.WriteLine("--- [BackEnd] Stop");
            acquisitionWorker.Stop();

            if (acquisitionThread.IsAlive)
                acquisitionThread.Join();

            CloseDevice();

            // Close peak library
            peak.Library.Close();
        }

        public bool OpenDevice()
        {
            Debug.WriteLine("--- [BackEnd] Open device");
            try
            {
                // open device and datastream
                var deviceManager = deviceHandler.CreateDeviceManager();
                device = deviceHandler.OpenFirstAvailableDevice(deviceManager);
                dataStream = deviceHandler.OpenDataStream(device);

                if (dataStream is null)
                    return false;

                // Get nodemap of remote device
                nodeMapRemoteDevice = device.RemoteDevice().NodeMaps()[0];

                deviceHandler.InitializeCameraSettings(nodeMapRemoteDevice, dataStream);

                // Configure worker
                acquisitionWorker.SetNodeMap(nodeMapRemoteDevice);
                acquisitionWorker.SetDataStream(dataStream);
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Exception: " + e.Message);
                MessageBoxTrigger(this, "Exception", e.Message);
                return false;
            }

            return true;
        }

        public void CloseDevice()
        {
            Debug.WriteLine("--- [BackEnd] Close device");

            deviceHandler.StopDeviceAcquisition(nodeMapRemoteDevice);
            deviceHandler.StopAndRevokeDataStream(dataStream);
            deviceHandler.UnlockParametersAndDispose(nodeMapRemoteDevice, dataStream);

            device?.Dispose();
            device = null;
        }

        private void AcquisitionWorker_ImageReceived(object sender, Bitmap image)
        {
            ImageReceived(sender, image);
        }

        private void AcquisitionWorker_CounterChanged(object sender, uint frameCounter, uint errorCounter)
        {
            CounterChanged(sender, frameCounter, errorCounter);
        }

        private void AcquisitionWorker_MessageBoxTrigger(object sender, string messageTitle, string messageText)
        {
            MessageBoxTrigger(sender, messageTitle, messageText);
        }


        #region -- EXPOSURE/GAIN/FOCUS
        // EXPOSURE
        internal double GetExposureValue()
        {
            if (device is not null)
                return deviceHandler.GetCurrentExposureValue(nodeMapRemoteDevice);
            else return 0;
        }

        internal void SetExposureValue(double val)
        {
            if (device is not null)
                deviceHandler.SetCurrentExposureValue(nodeMapRemoteDevice, val);
        }

        internal string GetExposureMode()
        {
            return deviceHandler.GetExposureMode(nodeMapRemoteDevice);
        }

        internal void SetExposureMode(string val)
        {
            if (device is not null)
                deviceHandler.SetExposureMode(nodeMapRemoteDevice, val);
        }

        // GAIN
        internal double GetGainValue()
        {
            if (device is not null)
                return deviceHandler.GetCurrentGainValue(nodeMapRemoteDevice);
            else
                return 0;
        }

        internal void SetGainMode(string val)
        {
            if (device is not null)
                deviceHandler.SetGainMode(nodeMapRemoteDevice, val);
        }

        internal string GetGainMode()
        {
            return deviceHandler.GetGainMode(nodeMapRemoteDevice);
        }

        internal void SetGainValue(double val)
        {
            if (device is not null)
                deviceHandler.SetCurrentGainValue(nodeMapRemoteDevice, val);
        }

        // FOCUS
        internal double GetFocusValue()
        {
            if (device is not null)
                return deviceHandler.GetCurrentFocusStepperVal(nodeMapRemoteDevice);
            else
                return 0;
        }

        internal void SetFocusMode(string val)
        {
            if (device is not null)
                deviceHandler.SetFocusMode(nodeMapRemoteDevice, val);
        }

        internal void SetFocusValue(int val)
        {
            if (device is not null)
                deviceHandler.SetCurrentFocusValue(nodeMapRemoteDevice, val);
        }

        // WHITE BALANCE
        internal void SetWhiteBalanceMode(string val)
        {
            if (device is not null)
                deviceHandler.SetWhiteBalanceMode(nodeMapRemoteDevice, val);
        }
        #endregion
    }
}
