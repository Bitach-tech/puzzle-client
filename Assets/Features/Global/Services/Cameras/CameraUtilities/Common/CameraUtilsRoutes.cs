using Global.Common;

namespace Global.Cameras.CameraUtilities.Common
{
    public static class CameraUtilsRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Camera/Utils/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CameraUtils";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CameraUtiles";
    }
}