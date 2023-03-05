using GamePlay.Common.Paths;

namespace GamePlay.LevelCameras.Common
{
    public static class LevelCameraRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "LevelCamera";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "CameraUtils";

        public const string ConfigPath = _paths + "Config";
        public const string ConfigName = GamePlayAssetsPrefixes.Config + "LevelCamera";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "LevelCamera";
    }
}