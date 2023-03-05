using Global.Common;

namespace Global.Audio.Player.Common
{
    public static class AudioRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Audio/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "AudioPlayer";

        public const string StatePath = _paths + "State";
        public const string StateName = GlobalAssetsPrefixes.Service + "AudioState";
    }
}