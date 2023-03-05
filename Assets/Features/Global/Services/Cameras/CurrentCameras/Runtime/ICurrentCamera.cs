using UnityEngine;

namespace Global.Cameras.CurrentCameras.Runtime
{
    public interface ICurrentCamera
    {
        Camera Current { get; }

        void SetCamera(Camera current);
    }
}