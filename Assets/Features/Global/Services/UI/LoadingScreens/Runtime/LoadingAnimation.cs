using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Global.UI.LoadingScreens.Runtime
{
    [DisallowMultipleComponent]
    public class LoadingAnimation : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _speed;

        [SerializeField] private ProceduralImage _image;

        private float _progress;

        private void Update()
        {
            _progress += Time.deltaTime * _speed;

            if (_progress > 1f)
                _progress = 0f;

            _image.fillAmount = _progress;
        }
    }
}