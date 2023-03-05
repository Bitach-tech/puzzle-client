using Global.Common;

namespace Global.System.Updaters.Common
{
    public static class UpdaterRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/Updater/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Updater";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Updater";
    }
}