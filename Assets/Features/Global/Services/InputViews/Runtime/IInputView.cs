using System;
using UnityEngine;

namespace Global.Services.InputViews.Runtime
{
    public interface IInputView
    {
        event Action DebugConsolePreformed;
        event Action LeftMouseButtonPerformed;
        bool IsLeftMouseButtonPressed { get; }
        Vector2 MousePosition { get; }

        float GetAngleFrom(Vector2 from);
        Vector2 GetDirectionFrom(Vector2 from);
        LineResult GetLineFrom(Vector2 from);
        Vector2 ScreenToWorld();
    }
}