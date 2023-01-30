using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime.Background
{
    public interface IPuzzleBackground
    {
        void Enable(Sprite sprite);
        void Disable();
    }
}