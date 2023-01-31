using System;
using DG.Tweening;
using UnityEngine;

namespace GamePlay.Puzzle.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzlePart : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private SpriteMask _mask;
        [SerializeField] private BoxCollider2D _collider;

        private bool _isLocked;
        private Vector2 _defaultPosition;

        public int Id => _id;
        public Vector2 Position => _transform.position;

        public event Action<PuzzlePart> Clicked;

        private void Awake()
        {
            _defaultPosition = _transform.position;
        }

        public void ToStart(Sprite image)
        {
            gameObject.SetActive(true);
            _renderer.sprite = image;
            Lock();
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void MoveToStart(Vector2 position)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_transform.DOMove(position, 1f).SetEase(Ease.InCirc));
            sequence.AppendCallback(Unlock);
            sequence.Play();
        }
        
        public void MoveToTarget()
        {
            _collider.enabled = false;
            
            var sequence = DOTween.Sequence();
            sequence.Append(_transform.DOMove(_defaultPosition, 1f).SetEase(Ease.InCirc));
            sequence.AppendCallback(Lock);
            sequence.Play();
        }

        public void SetPosition(Vector2 position)
        {
            _transform.position = position;
        }

        public void Lock()
        {
            _collider.enabled = false;
            _renderer.sortingLayerName = "Assembled";
            _mask.backSortingLayerID = SortingLayer.NameToID("Assembled");
            _mask.frontSortingLayerID = SortingLayer.NameToID("Assembled");

            _isLocked = true;
            _transform.position = _defaultPosition;
        }
        

        public void Unlock()
        {
            _collider.enabled = true;

            _renderer.sortingLayerName = "Parts";
            _mask.backSortingLayerID = SortingLayer.NameToID("Parts");
            _mask.frontSortingLayerID = SortingLayer.NameToID("Parts");

            _isLocked = false;
        }

        private void OnMouseDown()
        {
            if (_isLocked == true)
                return;

            Clicked?.Invoke(this);
        }
    }
}