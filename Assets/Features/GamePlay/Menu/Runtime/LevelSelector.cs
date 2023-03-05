using System;
using GamePlay.Level.ImageStorage.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private GameObject _adSign;
        [SerializeField] private Button _button;
        [SerializeField] private Image _view;
        
        private bool _isRewardable;
        private int _id;
        private LevelImage _image;

        public event Action<LevelImage, bool, int> Selected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void Construct(LevelImage image, bool isRewardable, int id)
        {
            _isRewardable = isRewardable;
            _id = id;
            _image = image;
            _view.sprite = image.Preview;

            if (_isRewardable == true)
                _adSign.SetActive(true);
            else
                _adSign.SetActive(false);
        }

        private void OnClicked()
        {
            _adSign.SetActive(false);

            Selected?.Invoke(_image, _isRewardable, _id);

            _isRewardable = false;
        }
    }
}