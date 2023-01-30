using System.Collections.Generic;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    public interface ITargetsStorage
    {
        IReadOnlyList<PuzzleTarget> Available { get; }

        void OnTaken(PuzzleTarget target);
        void OnReset();
    }
}