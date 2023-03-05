using UnityEngine;

namespace GamePlay.LevelCameras.Runtime
{
    public interface ILevelCamera
    {
        Camera Camera { get; }

        void StartFollow(Transform target);
        void StopFollow();
        void Teleport(Vector2 target);
        void SetSize(float size);
    }
}