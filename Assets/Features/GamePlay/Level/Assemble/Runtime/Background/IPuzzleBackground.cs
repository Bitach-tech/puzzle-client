using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.Background
{
    public interface IPuzzleBackground
    {
        void Enable(Sprite sprite);
        void Disable();
    }
}