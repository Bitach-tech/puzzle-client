using GamePlay.Common.Paths;

namespace GamePlay.Loop.Common
{
    public static class LevelLoopRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Loop/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Loop";

        public const string LogsPath = _paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "Loop";
    }
}