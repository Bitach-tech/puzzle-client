using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.Borders
{
    [DisallowMultipleComponent]
    public class PuzzleBorders : MonoBehaviour, IPuzzleBorders
    {
        [SerializeField] private Transform _leftDown;
        [SerializeField] private Transform _rightUp;

        public Vector2 Clamp(Vector2 world)
        {
            var leftDown = _leftDown.position;
            var rightUp = _rightUp.position;
            
            world.x = Mathf.Clamp( world.x, leftDown.x, rightUp.x);
            world.y = Mathf.Clamp( world.y, leftDown.y, rightUp.y);

            return world;
        }
    }
}