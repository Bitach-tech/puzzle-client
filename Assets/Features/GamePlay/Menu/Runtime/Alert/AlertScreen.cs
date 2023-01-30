using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime.Alert
{
    [DisallowMultipleComponent]
    public class AlertScreen : MonoBehaviour
    {
        [SerializeField] private AlertScreenConfigAsset _config;

        [SerializeField] private GameObject _body;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private void Awake()
        {
            _text.text = _text.text.Replace("###", _config.OwnerName);
            _body.SetActive(true);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            _body.SetActive(false);
        }
    }
}