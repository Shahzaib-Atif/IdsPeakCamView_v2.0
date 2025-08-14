using ImageProcessingLibrary;
using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using peak.core;
using peak.ipl;
using System.Diagnostics;

/// 
/// This class includes some static functions related to IDS Peak device manager
///

namespace simple_ids_cam_view.Services
{
    internal class DeviceManagerHandler
    {
        // Create instance of the device manager
        internal static peak.DeviceManager CreateDeviceManager()
        {
            try
            {
                var deviceManager = peak.DeviceManager.Instance();
                deviceManager.Update();

                if (!deviceManager.Devices().Any())
                {
                    ExceptionHelper.DisplayErrorMessage("No camera device found!");
                    return null;
                }

                return deviceManager;
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Error: " + e.Message);
                ExceptionHelper.DisplayErrorMessage("Failed to create device manager");
                return null;
            }
        }

        // Open the first openable device
        internal static Device OpenFirstAvailableDevice(peak.DeviceManager deviceManager)
        {
            if (deviceManager is null) return null;

            var deviceCount = deviceManager.Devices().Count;

            for (var i = 0; i < deviceCount; ++i)
            {
                if (deviceManager.Devices()[i].IsOpenable())
                {
                    return deviceManager.Devices()[i].OpenDevice(DeviceAccessType.Control);
                }
                else if (i == deviceCount - 1)
                {
                    Debug.WriteLine("--- [BackEnd] Error: Device could not be openend");
                    ExceptionHelper.DisplayErrorMessage("Device could not be openend");
                    return null;
                }
            }

            return null;
        }

        // open datastream
        internal static DataStream OpenDataStream(Device device)
        {
            if (device is null) return null;

            var dataStreams = device.DataStreams();

            if (!dataStreams.Any())
            {
                Debug.WriteLine("--- [BackEnd] Error: Device has no DataStream");
                ExceptionHelper.DisplayErrorMessage("Device has no DataStream");
                return null;
            }

            try
            {
                return dataStreams[0].OpenDataStream();
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Error: Failed to open DataStream");
                ExceptionHelper.DisplayErrorMessage("Failed to open DataStream\n" + e.Message);
                return null;
            }
        }

        // To prepare for untriggered continuous image acquisition, load the default user set if available
        // and wait until execution is finished
        private static void LoadUserSet(NodeMap nodeMap)
        {
            try
            {
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("UserSetSelector").SetCurrentEntry("Default");
                nodeMap.FindNode<peak.core.nodes.CommandNode>("UserSetLoad").Execute();
                nodeMap.FindNode<peak.core.nodes.CommandNode>("UserSetLoad").WaitUntilDone();
            }
            catch
            {
                Debug.WriteLine("--- [BackEnd] Error: Userset not available");
                ExceptionHelper.DisplayErrorMessage("Userset not available");
            }
        }

        // Get the payload size for correct buffer allocation
        private static void AllocateImageBuffers(NodeMap nodeMap, DataStream dataStream)
        {
            if (nodeMap is null || dataStream is null) return;

            dataStream.Flush(DataStreamFlushMode.DiscardAll);

            // Clear all old buffers
            foreach (var buffer in dataStream.AnnouncedBuffers())
            {
                dataStream.RevokeBuffer(buffer);
            }

            var payloadSize = nodeMap.FindNode<peak.core.nodes.IntegerNode>("PayloadSize").Value();

            // Get number of minimum required buffers
            var numBuffersMinRequired = dataStream.NumBuffersAnnouncedMinRequired();

            // Allocate and announce image buffers and queue them
            for (var count = 0; count < numBuffersMinRequired; ++count)
            {
                var buffer = dataStream.AllocAndAnnounceBuffer((uint)payloadSize, IntPtr.Zero);
                dataStream.QueueBuffer(buffer);
            }
        }

        // If device was opened, try to stop acquisition
        internal static void StopDeviceAcquisition(NodeMap nodeMap)
        {
            if (nodeMap is null) return;

            try
            {
                nodeMap.FindNode<peak.core.nodes.CommandNode>("AcquisitionStop").Execute();
                nodeMap.FindNode<peak.core.nodes.CommandNode>("AcquisitionStop").WaitUntilDone();
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Exception: " + e.Message);
                ExceptionHelper.ShowWarningMessage(e.Message);
            }
        }

        // If data stream was opened, try to stop it and revoke its image buffers
        internal static void StopAndRevokeDataStream(DataStream dataStream)
        {
            if (dataStream is null) return;

            try
            {
                dataStream.KillWait();
                dataStream.StopAcquisition(AcquisitionStopMode.Default);
                dataStream.Flush(DataStreamFlushMode.DiscardAll);

                foreach (var buffer in dataStream.AnnouncedBuffers())
                {
                    dataStream.RevokeBuffer(buffer);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Exception: " + e.Message);
                ExceptionHelper.ShowWarningMessage(e.Message);
            }
        }

        //Unlock Parameters And Dispose objects
        internal static void UnlockParametersAndDispose(NodeMap nodeMap, DataStream dataStream)
        {
            if (nodeMap is null) return;

            try
            {
                // Unlock parameters after acquisition stop
                nodeMap.FindNode<peak.core.nodes.IntegerNode>("TLParamsLocked").SetValue(0);
                dataStream?.Dispose();
                nodeMap?.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- [BackEnd] Exception: " + e.Message);
                ExceptionHelper.ShowWarningMessage(e.Message);
            }
        }

        internal static void LockCriticalFeatures(NodeMap nodeMap)
        {
            // Lock critical features to prevent them from changing during acquisition
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("TLParamsLocked").SetValue(1);
        }

        //Pre-allocate conversion buffers
        internal static void PreAllocateImageConversionBuffers(
            peak.ipl.ImageConverter imageConverter, PixelFormat targetPixelFormat, NodeMap nodeMap)
        {
            var inputPixelFormat = (peak.ipl.PixelFormatName)nodeMap
                    .FindNode<peak.core.nodes.EnumerationNode>("PixelFormat")
                    .CurrentEntry()
                    .Value();
            var width = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Width").Value();
            var height = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Height").Value();

            // Pre-allocate conversion buffers to speed up first image conversion
            // while the acquisition is running
            // NOTE: Re-create the image converter, so old conversion buffers get freed
            imageConverter.PreAllocateConversion(inputPixelFormat, targetPixelFormat, (uint)width, (uint)height);
        }

        internal static void StartAcquisition(NodeMap nodeMap, DataStream dataStream)
        {
            // Start acquisition
            dataStream.StartAcquisition();
            var acquisitionStartNode = nodeMap.FindNode<peak.core.nodes.CommandNode>("AcquisitionStart");
            acquisitionStartNode.Execute();
            acquisitionStartNode.WaitUntilDone();
        }

        internal static peak.ipl.Image ConvertBufferToImage(
            peak.core.Buffer buffer, peak.ipl.ImageConverter imageConverter, PixelFormat targetPixelFormat)
        {
            // Create IDS peak IPL image
            // NOTE: This `peak.ipl.Image` still uses the underlying memory of `buffer`
            var iplImg = ids_peak_ipl_extension.BufferToImage(buffer);

            // Debayering and convert IDS peak IPL Image to RGB8 format
            // NOTE: Use `ImageConverter`, since the `ConvertTo` function re-allocates
            // the conversion buffers on every call
            iplImg = imageConverter.Convert(iplImg, targetPixelFormat);

            return iplImg;
        }

        internal static Bitmap CreateDeepCopy(peak.ipl.Image iplImg)
        {
            var width = Convert.ToInt32(iplImg.Width());
            var height = Convert.ToInt32(iplImg.Height());
            var stride = Convert.ToInt32(iplImg.PixelFormat().CalculateStorageSizeOfPixels(iplImg.Width()));

            var data = iplImg.Data();

            var image = new Bitmap(width, height, stride,
                System.Drawing.Imaging.PixelFormat.Format32bppRgb, data);

            // Create a deep copy of the Bitmap, so it doesn't use memory of the IDS peak IPL Image.
            // Warning: Don't use image.Clone(), because it only creates a shallow copy!
            var imageCopy = new Bitmap(image);

            // The other images are not needed anymore.
            image.Dispose();
            iplImg.Dispose();

            return imageCopy;
        }

        #region -- EXPOSURE
        internal static double GetCurrentExposureValue(NodeMap nodeMap)
        {
            return nodeMap.FindNode<peak.core.nodes.FloatNode>("ExposureTime").Value();
        }

        internal static void SetCurrentExposureValue(NodeMap nodeMap, double value)
        {
            // only proceed if AutoMode is Off
            if (GetExposureMode(nodeMap) == AutoMode.Off)
                nodeMap.FindNode<peak.core.nodes.FloatNode>("ExposureTime").SetValue(value);
        }

        internal static string GetExposureMode(NodeMap nodeMap)
        {
            return nodeMap.FindNode<peak.core.nodes.EnumerationNode>("ExposureAuto").CurrentEntry().SymbolicValue();
        }

        internal static void SetExposureMode(NodeMap nodeMap, string str)
        {
            // ensures that input string can only be Continuous or Off
            if (str == AutoMode.Off || str == AutoMode.Continuous)
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("ExposureAuto").SetCurrentEntry(str);
        }
        #endregion

        #region -- GAIN
        internal static void SetGainMode(NodeMap nodeMap, string mode)
        {
            // ensures that input string can only be Continuous or Off
            if (mode == AutoMode.Off || mode == AutoMode.Continuous)
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("GainAuto").SetCurrentEntry(mode);
        }

        internal static string GetGainMode(NodeMap nodeMap)
        {
            return nodeMap.FindNode<peak.core.nodes.EnumerationNode>("GainAuto").CurrentEntry().SymbolicValue();
        }

        internal static void SetCurrentGainValue(NodeMap nodeMap, double value)
        {
            // only proceed if AutoMode is Off
            if (GetGainMode(nodeMap) == AutoMode.Off)
            {
                // Before accessing Gain, make sure GainSelector is set correctly to "AnalogAll"
                //nodeMap.FindNode<peak.core.nodes.EnumerationNode>("GainSelector").SetCurrentEntry("AnalogAll");
                // Set Gain
                nodeMap.FindNode<peak.core.nodes.FloatNode>("Gain").SetValue(value);
            }
        }

        internal static double GetCurrentGainValue(NodeMap nodeMap)
        {
            return nodeMap.FindNode<peak.core.nodes.FloatNode>("Gain").Value();
        }
        #endregion


        #region -- FOCUS
        internal static void SetFocusMode(NodeMap nodeMap, string mode)
        {
            // ensures that input string can only be Continuous or Off
            if (mode == AutoMode.Off || mode == AutoMode.Continuous)
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("FocusAuto").SetCurrentEntry(mode);
        }

        private static string GetFocusMode(NodeMap nodeMap)
        {
            return nodeMap.FindNode<peak.core.nodes.EnumerationNode>("FocusAuto").CurrentEntry().SymbolicValue();
        }

        internal static void SetCurrentFocusValue(NodeMap nodeMap, int val)
        {
            // only proceed if AutoMode is Off
            if (GetFocusMode(nodeMap) == AutoMode.Off)
            {
                // Before accessing FocusStepper, make sure OpticControllerSelector is set correctly (OpticController0)
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("OpticControllerSelector").SetCurrentEntry("OpticController0");

                // set the focus stepper value here
                nodeMap.FindNode<peak.core.nodes.IntegerNode>("FocusStepper").SetValue(val);
            }
        }

        internal static long GetCurrentFocusStepperVal(NodeMap nodeMap)
        {
            // Determine the current FocusStepper
            long value = nodeMap.FindNode<peak.core.nodes.IntegerNode>("FocusStepper").Value();
            return value;
        }
        #endregion

        // WHITE BALANCE
        internal static void SetWhiteBalanceMode(NodeMap nodeMap, string mode)
        {
            // ensures that input string can only be Continuous or Off
            if (mode == AutoMode.Off || mode == AutoMode.Continuous)
                nodeMap.FindNode<peak.core.nodes.EnumerationNode>("BalanceWhiteAuto").SetCurrentEntry(mode);
        }


        #region -- Mirror (ReverseX, ReverseY)

        internal static void MirrorX(NodeMap nodeMap)
        {
            if (nodeMap is null) return;

            try
            {
                // Determine the current status of ReverseX
                bool value = nodeMap.FindNode<peak.core.nodes.BooleanNode>("ReverseX").Value();
                if (value is false) // Set ReverseX to true
                    nodeMap.FindNode<peak.core.nodes.BooleanNode>("ReverseX").SetValue(true);
            }
            catch (Exception e)
            {
                ExceptionHelper.DisplayErrorMessage(e.Message);
            }
        }

        internal static void MirrorY(NodeMap nodeMap)
        {
            if (nodeMap is null) return;

            try
            {
                // Determine the current status of ReverseY
                bool value = nodeMap.FindNode<peak.core.nodes.BooleanNode>("ReverseY").Value();
                if (value is false) // Set ReverseY to true
                    nodeMap.FindNode<peak.core.nodes.BooleanNode>("ReverseY").SetValue(true);
            }
            catch (Exception e)
            {
                ExceptionHelper.DisplayErrorMessage(e.Message);
            }
        }

        #endregion


        // load initial camera settings
        internal static void InitializeCameraSettings(NodeMap nodeMapRemoteDevice, DataStream dataStream)
        {
            // load the default user set and allocate buffers
            LoadUserSet(nodeMapRemoteDevice);

            // update ROI
            NodeMapRoiManager.UpdateROI(nodeMapRemoteDevice);

            // allocate image buffers
            AllocateImageBuffers(nodeMapRemoteDevice, dataStream);

            // flip the image
            MirrorX(nodeMapRemoteDevice);
            MirrorY(nodeMapRemoteDevice);

            // initialize white-balance, gain, exposure
            SetWhiteBalanceMode(nodeMapRemoteDevice, AutoMode.Off);

            // load gain & exposure values from the project settings
            SetGainMode(nodeMapRemoteDevice, ProjectSettings.GainAutoMode);
            SetCurrentGainValue(nodeMapRemoteDevice, ProjectSettings.GainValue);

            SetExposureMode(nodeMapRemoteDevice, ProjectSettings.ExposureAutoMode);
            SetCurrentExposureValue(nodeMapRemoteDevice, ProjectSettings.ExposureValue);

        }
    }
}
