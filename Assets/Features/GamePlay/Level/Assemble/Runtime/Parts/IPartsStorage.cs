using System.Collections.Generic;

namespace GamePlay.Level.Assemble.Runtime.Parts
{
    public interface IPartsStorage
    {
        IReadOnlyList<PuzzlePart> Available { get; }

        void Add(PuzzlePart part);
        void OnLocked(PuzzlePart part);

        void OnReset();
    }
}