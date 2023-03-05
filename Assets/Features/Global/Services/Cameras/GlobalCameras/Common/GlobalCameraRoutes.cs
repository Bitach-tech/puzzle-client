using Global.Common;

namespace Global.Cameras.GlobalCameras.Common
{
    public static class GlobalCameraRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Camera/Global/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "GlobalCamera";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "GlobalCamera";
    }
}