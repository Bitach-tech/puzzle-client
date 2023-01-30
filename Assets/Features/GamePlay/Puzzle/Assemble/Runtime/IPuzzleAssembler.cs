using GamePlay.Puzzle.ImageStorage.Runtime;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    public interface IPuzzleAssembler
    {
        void Begin(PuzzleImage image);
        void Cancel();
    }
}