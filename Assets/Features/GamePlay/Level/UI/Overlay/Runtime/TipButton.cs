using GamePlay.Level.Assemble.Runtime;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Level.UI.Overlay.Runtime
{
    [DisallowMultipleComponent]
    public class TipButton : MonoBehaviour
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
            Msg.Publish(new TipRequestEvent());
        }
    }
}