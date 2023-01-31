using GamePlay.Services.LevelLoops.Events;
using Global.Services.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Services.Overlays.SoundSwitches.Runtime
{
    [DisallowMultipleComponent]
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

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
            Msg.Publish(new MenuRequestEvent());
        }
    }
}