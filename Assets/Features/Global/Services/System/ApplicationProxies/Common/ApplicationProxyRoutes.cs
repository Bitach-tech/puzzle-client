using Global.Common;

namespace Global.System.ApplicationProxies.Common
{
    public static class ApplicationProxyRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/ApplicationProxy/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "ApplicationProxy";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "ApplicationProxy";
    }
}