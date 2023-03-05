using Global.Common;

namespace Global.UI.Overlays.Common
{
    public static class OverlayRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "UI/Overlay/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Overlay";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Overlay";
    }
}