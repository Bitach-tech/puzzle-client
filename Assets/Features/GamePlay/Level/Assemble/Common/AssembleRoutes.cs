using GamePlay.Common.Paths;

namespace GamePlay.Level.Assemble.Common
{
    public static class AssembleRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Assemble/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Assemble";
        
        public const string PickConfigPath = _paths + "PickConfig";
        public const string PickConfigName = GamePlayAssetsPrefixes.Config + "PickHandler";
    }
}