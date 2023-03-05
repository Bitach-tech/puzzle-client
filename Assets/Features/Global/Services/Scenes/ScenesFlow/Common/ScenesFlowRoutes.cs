using Global.Common;

namespace Global.Scenes.ScenesFlow.Common
{
    public static class ScenesFlowRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Scenes/Flow/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentSceneHandler";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CurrentSceneHandler";
    }
}