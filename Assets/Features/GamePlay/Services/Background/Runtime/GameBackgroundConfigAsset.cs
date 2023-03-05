using GamePlay.Background.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Background.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BackgroundRoutes.ConfigName,
        menuName = BackgroundRoutes.ConfigPath)]
    public class GameBackgroundConfigAsset : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _lineWidth;
        [SerializeField] [Min(0f)] private float _distanceBetweenLines;
        [SerializeField] [Min(0f)] private float _speed;

        public float LineWidth => _lineWidth;
        public float DistanceBetweenLines => _distanceBetweenLines;
        public float Speed => _speed;
    }
}