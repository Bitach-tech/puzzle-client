using Global.Common;

namespace Global.System.Loggers.Common
{
    public static class LoggerRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/Logger/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentSceneHandler";

        public const string HeaderName = "LoggerHeader_";
        public const string HeaderPath = _paths + "Header";
    }
}