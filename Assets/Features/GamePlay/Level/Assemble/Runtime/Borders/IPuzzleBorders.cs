using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.Borders
{
    public interface IPuzzleBorders
    {
        Vector2 Clamp(Vector2 world);
    }
}