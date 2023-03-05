using Global.Audio.Player.Runtime;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Overlays.SoundSwitches.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class SoundSwitchButton : MonoBehaviour, ISoundSwitchButton
    {
        [SerializeField] private GameObject _cross;
        [SerializeField] private SoundState _state;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _cross.SetActive(false);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
            _state.Changed += OnStateChanged;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
            _state.Changed -= OnStateChanged;
        }

        private void OnClicked()
        {
            Msg.Publish(new SoundSwitchEvent());
        }

        private void OnStateChanged(bool isMuted)
        {
            if (isMuted == true)
                _cross.SetActive(true);
            else
                _cross.SetActive(false);
        }
    }
}