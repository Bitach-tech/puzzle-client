using System.Collections.Generic;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    public interface IPartsStorage
    {
        IReadOnlyList<PuzzlePart> Available { get; }

        void Add(PuzzlePart part);
        void OnLocked(PuzzlePart part);

        void OnReset();
    }
}