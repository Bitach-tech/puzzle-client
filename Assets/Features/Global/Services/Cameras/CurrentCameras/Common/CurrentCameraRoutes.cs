using Global.Common;

namespace Global.Cameras.CurrentCameras.Common
{
    public static class CurrentCameraRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Camera/Current/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentCamera";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CurrentCamera";
    }
}