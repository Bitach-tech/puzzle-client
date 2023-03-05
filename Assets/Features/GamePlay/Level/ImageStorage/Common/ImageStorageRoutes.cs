using GamePlay.Common.Paths;

namespace GamePlay.Level.ImageStorage.Common
{
    public static class ImageStorageRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Assemble/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Assemble";

        public const string ImagePath = _paths + "Image";
        public const string ImageName = "LevelImage";
    }
}