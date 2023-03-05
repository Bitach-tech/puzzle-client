using Global.Common;

namespace Global.Scenes.CurrentSceneHandlers.Common
{
    public static class CurrentSceneHandlerRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Scenes/CurrentHandler/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentSceneHandler";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CurrentSceneHandler";
    }
}