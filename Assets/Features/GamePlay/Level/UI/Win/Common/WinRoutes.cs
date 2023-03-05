using GamePlay.Common.Paths;

namespace GamePlay.Level.UI.Win.Common
{
    public static class WinRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Win/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Win";
    }
}