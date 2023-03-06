using GamePlay.Loop.Events;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Level.UI.Overlay.Runtime
{
    [DisallowMultipleComponent]
    public class QuitButton : MonoBehaviour
    {
        [SerializeField] private GameObject _contextMenu;

        [SerializeField] private Button _menu;
        [SerializeField] private Button _accept;
        [SerializeField] private Button _cancel;

        private void OnEnable()
        {
            _menu.onClick.AddListener(OnMenuClicked);
            _accept.onClick.AddListener(OnAcceptClicked);
            _cancel.onClick.AddListener(OnCancelClicked);
        }
        
        private void OnDisable()
        {
            _menu.onClick.RemoveListener(OnMenuClicked);
            _accept.onClick.RemoveListener(OnAcceptClicked);
            _cancel.onClick.RemoveListener(OnCancelClicked);
            
            _contextMenu.SetActive(false);
        }

        private void OnMenuClicked()
        {
            _contextMenu.SetActive(true);
        }
        
        private void OnAcceptClicked()
        {
            Msg.Publish(new MenuRequestEvent());    
        }

        private void OnCancelClicked()
        {
            _contextMenu.SetActive(false);
        }
    }
}