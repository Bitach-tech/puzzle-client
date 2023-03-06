using GamePlay.Loop.Events;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Level.UI.Win.Runtime
{
    [DisallowMultipleComponent]
    public class ReplayButton : MonoBehaviour
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
            Msg.Publish(new ReplayRequestEvent());
        }
    }
}