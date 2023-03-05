using Global.UI.Localizations.Texts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime.Alert
{
    [DisallowMultipleComponent]
    public class AlertScreen : MonoBehaviour
    {
        [SerializeField] private AlertScreenConfigAsset _config;
        [SerializeField] private LocalizedText _localized;

        [SerializeField] private GameObject _body;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private void Awake()
        {
            _body.SetActive(true);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
            OnTextChanged();
            _localized.Changed += OnTextChanged;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
            _localized.Changed -= OnTextChanged;
        }

        private void OnClicked()
        {
            _body.SetActive(false);
        }

        private void OnTextChanged()
        {
            _text.text = _text.text.Replace("###", _config.OwnerName);
        }
    }
}