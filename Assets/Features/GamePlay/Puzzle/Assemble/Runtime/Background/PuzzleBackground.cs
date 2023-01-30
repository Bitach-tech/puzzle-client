using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime.Background
{
    [DisallowMultipleComponent]
    public class PuzzleBackground : MonoBehaviour, IPuzzleBackground
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        public void Enable(Sprite sprite)
        {
            gameObject.SetActive(true);
            _renderer.sprite = sprite;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}