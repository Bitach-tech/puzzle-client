using UnityEngine;

namespace GamePlay.Services.Background.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class LineView : MonoBehaviour
    {
        [SerializeField] private GameObject _switchableCell;

        private RectTransform _transform;

        public Vector2 Position => _transform.anchoredPosition;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        public void SetPosition(Vector2 position)
        {
            _transform.anchoredPosition = position;
        }

        public void Rotate(float angle)
        {
            _transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public void DisableOneCell()
        {
            _switchableCell.SetActive(false);
        }
    }
}