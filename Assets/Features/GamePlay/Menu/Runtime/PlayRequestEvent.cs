using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayRequestEvent
    {
        public PlayRequestEvent(LevelImage image)
        {
            Image = image;
        }

        public readonly LevelImage Image;
    }
}