using GamePlay.Common.Paths;

namespace GamePlay.Background.Common
{
    public static class BackgroundRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Background/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Background";

        public const string ConfigPath = _paths + "Config";
        public const string ConfigName = GamePlayAssetsPrefixes.Config + "Background";
    }
}