using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime.StartPositions
{
    public interface IRandomStartPositions
    {
        Vector2 GetRandom();
    }
}