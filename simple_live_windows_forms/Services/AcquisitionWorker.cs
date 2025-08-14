/*!
 * \brief   The AcquisitionWorker class is used in a worker thread to capture
 *          images from the device continuously and do an image conversion into
 *          a desired pixel format.
 */

using System.Diagnostics;
using deviceHandler = simple_ids_cam_view.Services.DeviceManagerHandler;

namespace simple_ids_cam_view.Services
{
    public class AcquisitionWorker
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

        private peak.core.DataStream dataStream;
        private peak.core.NodeMap nodeMap;
        private peak.ipl.ImageConverter imageConverter;

        private readonly peak.ipl.PixelFormat targetPixelFormat = new(peak.ipl.PixelFormatName.BGRa8);

        internal bool IsRunning { private set; get; } // flag to start or stop the thread
        private uint frameCounter;
        private uint errorCounter;
        internal bool isSingleAcquisition = false;  // Flag to control single acquisition mode


        public AcquisitionWorker()
        {
            Debug.WriteLine("--- [AcquisitionWorker] Init");
            IsRunning = false;
            frameCounter = 0;
            errorCounter = 0;
        }

        public void SetNodeMap(peak.core.NodeMap nodeMap) => this.nodeMap = nodeMap;
        public void SetDataStream(peak.core.DataStream dataStream) => this.dataStream = dataStream;


        public void Start()
        {
            Debug.WriteLine("--- [AcquisitionWorker] Start Acquisition");
            try
            {
                // lock critical features
                deviceHandler.LockCriticalFeatures(nodeMap);

                // pre-allocate conversion buffers
                imageConverter = new peak.ipl.ImageConverter();
                deviceHandler.PreAllocateImageConversionBuffers(imageConverter, targetPixelFormat, nodeMap);

                // Start acquisition
                deviceHandler.StartAcquisition(nodeMap, dataStream);
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [AcquisitionWorker] Exception: " + e.Message);
                MessageBoxTrigger(this, "Exception", e.Message);
            }

            IsRunning = true;

            while (IsRunning)
                ProcessFrames();

            imageConverter?.Dispose();
        }


        public void Stop()
        {
            Debug.WriteLine("--- [AcquisitionWorker] Pause Acquisition");
            IsRunning = false; // this will end the thread
        }


        private void ProcessFrames()
        {
            try
            {
                // Get buffer from device's datastream
                var buffer = dataStream.WaitForFinishedBuffer(5000);

                // convert image to buffer
                var iplImg = deviceHandler.ConvertBufferToImage(buffer, imageConverter, targetPixelFormat);

                // create a deep copy
                var imageCopy = deviceHandler.CreateDeepCopy(iplImg);

                // Queue buffer so that it can be used again 
                dataStream.QueueBuffer(buffer);

                // notify image received
                if (ImageReceived != null)
                {
                    Debug.WriteLine("--- [AcquisitionWorker] Send image Nr. " + (frameCounter + 1));
                    ImageReceived(this, imageCopy);
                }

                frameCounter++;

                if (isSingleAcquisition)
                {
                    IsRunning = false;
                    isSingleAcquisition = false;
                }
            }
            catch (Exception e)
            {
                errorCounter++;
                Debug.WriteLine("--- [AcquisitionWorker] Exception: " + e.Message);
                MessageBoxTrigger(this, "Exception", e.Message);
            }

            // Raise event with current frame and error counter
            CounterChanged(this, frameCounter, errorCounter);
        }
    }
}
