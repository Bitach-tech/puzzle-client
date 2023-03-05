using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayClickEvent
    {
        public PlayClickEvent(PuzzleImage difficulty)
        {
            Difficulty = difficulty;
        }

        public readonly PuzzleImage Difficulty;
    }
}