using Global.Common;

namespace Global.Publisher.Common
{
    public static class PublisherRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Publisher/";
        private const string _servicePrefix = GlobalAssetsPrefixes.Service + "Audio/";

        public const string ServiceName = _servicePrefix + "Publisher";
        public const string ServicePath = _paths + "Service";
    }
}