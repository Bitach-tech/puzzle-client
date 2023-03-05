using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Level.Assemble.Runtime
{
    public interface IAssembler
    {
        void AssemblePreview(PuzzleImage image);
        void AssembleCurrent();
        void Begin();
        void Cancel();
    }
}