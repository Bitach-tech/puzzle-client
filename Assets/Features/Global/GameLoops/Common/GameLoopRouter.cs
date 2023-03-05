using Global.Common;

namespace Global.GameLoops.Common
{
    public static class GameLoopRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "GameLoop";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "GameLoop";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "GameLoop";
    }
}