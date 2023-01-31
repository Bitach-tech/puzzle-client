using UnityEngine;

namespace GamePlay.Puzzle.Assemble.Runtime.StartPositions
{
    public interface IRandomStartPositions
    {
        Vector2 GetRandom();
    }
}