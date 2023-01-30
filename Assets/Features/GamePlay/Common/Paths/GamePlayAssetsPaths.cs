namespace GamePlay.Common.Paths
{
    public class GamePlayAssetsPaths
    {
        public const string Root = "GamePlay/";
        public const string Config = Root + "Config/";

        public const string LogsPrefix = "LogSettings_";
        public const string ServicePrefix = "LocalService_";
        public const string ConfigPrefix = "LocalConfig_";

        private const string _services = Root + "Services/";

        public const string LevelCamera = _services + "LevelCamera/";
        public const string LevelLoop = _services + "LevelLoop/";
        public const string GameBackground = _services + "GameBackground/";
        public const string PaintCanvas = _services + "PaintCanvas/";
        public const string LevelOverlay = _services + "LevelOverlay/";
        public const string ImageStorage = _services + "ImageStorage/";
        
        public const string PuzzleLoop = _services + "PuzzleLoop/";
        public const string PickHandler = _services + "PickHandler/";
        public const string PuzzleAssembler = _services + "PuzzleAssembler/";
    }
}