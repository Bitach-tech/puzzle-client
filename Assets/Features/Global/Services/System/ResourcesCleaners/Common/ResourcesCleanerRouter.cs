using Global.Common;

namespace Global.System.ResourcesCleaners.Common
{
    public class ResourcesCleanerRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/ResourcesCleaner/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "ResourcesCleaner";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "ResourcesCleaner";
    }
}