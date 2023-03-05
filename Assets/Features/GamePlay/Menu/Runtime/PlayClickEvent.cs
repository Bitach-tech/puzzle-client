using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayClickEvent
    {
        public PlayClickEvent(LevelImage difficulty)
        {
            Difficulty = difficulty;
        }

        public readonly LevelImage Difficulty;
    }
}