using GamePlay.Puzzle.ImageStorage.Runtime;

namespace GamePlay.Puzzle.Assemble.Runtime
{
    public readonly struct AssembledEvent
    {
        public AssembledEvent(PuzzleImage image)
        {
            Image = image;
        }
        
        public readonly PuzzleImage Image;
    }
}