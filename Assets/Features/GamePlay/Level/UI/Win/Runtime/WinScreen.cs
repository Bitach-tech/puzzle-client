using GamePlay.Loop.Events;
using Global.System.MessageBrokers.Runtime;
using Global.UI.UiStateMachines.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace GamePlay.Level.UI.Win.Runtime
{
    [DisallowMultipleComponent]
    public class WinScreen : MonoBehaviour, IWinScreen, IUiState
    {
        [Inject]
        private void Construct(IUiStateMachine stateMachine, UiConstraints constraints)
        {
            _stateMachine = stateMachine;
            _constraints = constraints;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private Button _menuButton;

        private UiConstraints _constraints;
        private IUiStateMachine _stateMachine;

        public UiConstraints Constraints => _constraints;
        public string Name => "WinScreen";

        private void Awake()
        {
            _body.SetActive(false);
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuClicked);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuClicked);
        }

        public void Open()
        {
            _stateMachine.EnterAsStack(this);
            _body.SetActive(true);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        private void OnMenuClicked()
        {
            Msg.Publish(new MenuRequestEvent());
        }
    }
}