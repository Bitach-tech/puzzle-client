using GamePlay.Common.Paths;

namespace GamePlay.Menu.Common
{
    public static class MenuRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Menu/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Menu";

        public const string AlertPath = _paths + "Alert";
        public const string AlertName = GamePlayAssetsPrefixes.Service + "Alert";
    }
}