using System;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    public interface IInputView
    {
        event Action DebugConsolePreformed;

        bool IsLeftMouseButtonPressed { get; }
        Vector2 Position { get; }

        float GetAngleFrom(Vector2 from);
        Vector2 GetDirectionFrom(Vector2 from);
        LineResult GetLineFrom(Vector2 from);
        Vector2 ScreenToWorld();
    }
}