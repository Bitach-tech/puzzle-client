using Global.Common;

namespace Global.UI.LoadingScreens.Common
{
    public static class LoadingScreenRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "UI/LoadingScreen/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "LoadingScreen";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "LoadingScreen";
    }
}