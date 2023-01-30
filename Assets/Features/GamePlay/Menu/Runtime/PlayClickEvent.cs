using GamePlay.Puzzle.ImageStorage.Runtime;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayClickEvent
    {
        public PlayClickEvent(PuzzleImage image)
        {
            Image = image;
        }

        public readonly PuzzleImage Image;
    }
}