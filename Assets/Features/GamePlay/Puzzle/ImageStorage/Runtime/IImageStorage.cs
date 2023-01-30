using System.Collections.Generic;

namespace GamePlay.Puzzle.ImageStorage.Runtime
{
    public interface IImageStorage
    {
        IReadOnlyList<PuzzleImage> GetImages();
    }
}