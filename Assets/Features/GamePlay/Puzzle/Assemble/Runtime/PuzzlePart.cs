using System;
using DG.Tweening;
using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzlePart : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private SpriteMask _mask;
        private bool _isLocked;
        private Vector2 _defaultPosition;
        private Vector2 _startPosition;

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
            Lock(_defaultPosition);
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
            _startPosition = position;
            var sequence = DOTween.Sequence();
            sequence.Append(_transform.DOMove(position, 1f).SetEase(Ease.InCirc));
            sequence.AppendCallback(Unlock);
            sequence.Play();
        }

        public void Lock(Vector2 position)
        {
            _renderer.sortingLayerName = "Assembled";
            _mask.backSortingLayerID = SortingLayer.NameToID("Assembled");
            _mask.frontSortingOrder = SortingLayer.NameToID("Assembled");
            
            _isLocked = true;
            _transform.position = position;
        }

        public void SetPosition(Vector2 position)
        {
            _transform.position = position;
        }

        public void Unlock()
        {
            _renderer.sortingLayerName = "Parts";
            _mask.backSortingLayerID = SortingLayer.NameToID("Parts");
            _mask.frontSortingOrder = SortingLayer.NameToID("Parts");

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