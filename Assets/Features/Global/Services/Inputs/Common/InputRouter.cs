using Global.Common;

namespace Global.Inputs.Common
{
    public static class InputRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "Input/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CameraUtils";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CameraUtiles";
    }
}