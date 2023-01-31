using GamePlay.Puzzle.ImageStorage.Runtime;

namespace GamePlay.Puzzle.Assemble.Runtime
{
    public interface IPuzzleAssembler
    {
        void AssemblePreview(PuzzleImage image);
        void AssembleCurrent();
        void Begin();
        void Cancel();
    }
}