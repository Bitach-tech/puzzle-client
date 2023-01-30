using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzleTarget : MonoBehaviour
    {
        [SerializeField] private int _id;

        public int Id => _id;
        public Vector2 Position => transform.position;

        public void SetId(int id)
        {
            _id = id;
        }
    }
}