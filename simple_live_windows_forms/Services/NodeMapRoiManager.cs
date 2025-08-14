using ImageProcessingLibrary.Helpers;
using ImageProcessingLibrary.Models;
using peak.core;
using static ImageProcessingLibrary.Models.ImageRoiStruct;

namespace simple_ids_cam_view.Services
{
    internal class NodeMapRoiManager
    {
        internal static bool UpdateROI(NodeMap nodeMap)
        {
            var currentRoi = new ImageRoiStruct(ImageROI.Width, ImageROI.Height, ImageROI.Offset_X, ImageROI.Offset_Y);

            try
            {
                // Get the minimum ROI and set it. After that there are no size restrictions anymore
                var minRoi = SetMinimumRoi(nodeMap);

                // Get the maximum ROI values
                var maxRoi = GetMaxRoi(nodeMap);

                if (IsOffsetOutOfBounds(currentRoi, minRoi, maxRoi))
                {
                    ExceptionHelper.ShowWarningMessage("UpdateROI: Limit check 1 failed!");
                    return false;
                }

                if (IsSizeOutOfBounds(currentRoi, minRoi, maxRoi))
                {
                    ExceptionHelper.ShowWarningMessage("UpdateROI: Limit check 2 failed!");
                    return false;
                }

                // Now, set final AOI
                SetFinalAOI(nodeMap, currentRoi);
                return true;
            }
            catch (Exception e)
            {
                ExceptionHelper.DisplayErrorMessage(e.Message);
                return false;
            }
        }

        // Get the minimum ROI and set it. After that there are no size restrictions anymore
        private static ImageRoiStruct SetMinimumRoi(NodeMap nodeMap)
        {
            var w_min = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Width").Minimum();
            var h_min = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Height").Minimum();
            var x_min = nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetX").Minimum();
            var y_min = nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetY").Minimum();

            nodeMap.FindNode<peak.core.nodes.IntegerNode>("Width").SetValue(w_min);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("Height").SetValue(h_min);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetX").SetValue(x_min);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetY").SetValue(y_min);

            return new ImageRoiStruct((int)w_min, (int)h_min, (int)x_min, (int)y_min);
        }

        // Get the maximum ROI values
        private static ImageRoiStruct GetMaxRoi(NodeMap nodeMap)
        {
            var w_max = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Width").Maximum();
            var h_max = nodeMap.FindNode<peak.core.nodes.IntegerNode>("Height").Maximum();
            var x_max = nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetX").Maximum();
            var y_max = nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetY").Maximum();

            return new ImageRoiStruct((int)w_max, (int)h_max, (int)x_max, (int)y_max);
        }

        // set final AOI
        private static void SetFinalAOI(NodeMap nodeMap, ImageRoiStruct roi)
        {
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("Width").SetValue(roi.Width);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("Height").SetValue(roi.Height);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetX").SetValue(roi.Offset_X);
            nodeMap.FindNode<peak.core.nodes.IntegerNode>("OffsetY").SetValue(roi.Offset_Y);
        }

        private static bool IsOffsetOutOfBounds(ImageRoiStruct roi, ImageRoiStruct minRoi, ImageRoiStruct maxRoi)
        {
            return roi.Offset_X < minRoi.Offset_X ||
                   roi.Offset_Y < minRoi.Offset_Y ||
                   roi.Offset_X > maxRoi.Offset_X ||
                   roi.Offset_Y > maxRoi.Offset_Y;
        }

        private static bool IsSizeOutOfBounds(ImageRoiStruct roi, ImageRoiStruct minRoi, ImageRoiStruct maxRoi)
        {
            return roi.Width < minRoi.Width ||
                   roi.Height < minRoi.Height ||
                   roi.Offset_X + roi.Width > maxRoi.Width ||
                   roi.Offset_Y + roi.Height > maxRoi.Height;
        }
    }
}
