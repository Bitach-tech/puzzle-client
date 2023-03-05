using GamePlay.LevelCameras.Common;
using UnityEngine;

namespace GamePlay.LevelCameras.Runtime
{
    [CreateAssetMenu(fileName = LevelCameraRoutes.ConfigName,
        menuName = LevelCameraRoutes.ConfigPath)]
    public class LevelCameraConfigAsset : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _followSpeed;
        [SerializeField] [Min(0f)] private float _maxOverSightDistance;
        [SerializeField] [Min(0f)] private float _minOverSightDistance;
        [SerializeField] [Min(0f)] private float _xAxisMagnitudeMultiplier;

        public float FollowSpeed => _followSpeed;
        public float MinOverSightDistance => _minOverSightDistance;
        public float MaxOverSightDistance => _maxOverSightDistance;
        public float XAxisMagnitudeMultiplier => _xAxisMagnitudeMultiplier;
    }
}