using Global.Common;

namespace Global.Debugs.Console.Common
{
    public static class DebugConsoleRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Debug/Console/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentCamera";
    }
}