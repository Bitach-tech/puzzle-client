using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.StartPositions
{
    [DisallowMultipleComponent]
    public class RandomStartPositions : MonoBehaviour, IRandomStartPositions
    {
        [SerializeField] private float _randomRadius = 0.5f;
        [SerializeField] private Transform[] _points;
        public Vector2 GetRandom()
        {
            var index = Random.Range(0, _points.Length);
            var position = new Vector2(
                Random.Range(-_randomRadius, _randomRadius),
                Random.Range(-_randomRadius, _randomRadius));
            
            return (Vector2)_points[index].position + position;
        }
    }
}