using UnityEngine;

namespace Global.Cameras.CameraUtilities.Runtime
{
    public interface ICameraUtils
    {
        Vector2 ScreenToWorld(Vector2 screen);
    }
}