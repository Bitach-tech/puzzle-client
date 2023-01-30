using Global.Services.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Services.Overlays.SoundSwitches.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class SoundSwitcher : MonoBehaviour
    {
        [SerializeField] private Image _cross;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _cross.gameObject.SetActive(false);
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
            _cross.gameObject.SetActive(!_cross.gameObject.activeSelf);

            Msg.Publish(new SoundSwitchClickEvent());
        }
    }
}