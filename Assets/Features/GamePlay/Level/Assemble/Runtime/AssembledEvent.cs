using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Level.Assemble.Runtime
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