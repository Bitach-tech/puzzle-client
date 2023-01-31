using GamePlay.Puzzle.ImageStorage.Runtime;

namespace GamePlay.Puzzle.Assemble.Runtime
{
    public interface IPuzzleAssembler
    {
        void Begin(PuzzleImage image);
        void Cancel();
    }
}