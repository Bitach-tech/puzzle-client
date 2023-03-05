using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Level.Assemble.Runtime
{
    public readonly struct AssembledEvent
    {
        public AssembledEvent(LevelImage image)
        {
            Image = image;
        }
        
        public readonly LevelImage Image;
    }
}