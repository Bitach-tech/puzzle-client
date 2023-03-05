using GamePlay.Common.Paths;

namespace GamePlay.Level.UI.Overlay.Common
{
    public static class LevelOverlayRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Overlay/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Overlay";
    }
}