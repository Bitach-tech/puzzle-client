using Global.UI.UiStateMachines.Runtime;
using UnityEngine;
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

        private UiConstraints _constraints;
        private IUiStateMachine _stateMachine;

        public UiConstraints Constraints => _constraints;
        public string Name => "WinScreen";

        private void Awake()
        {
            _body.SetActive(false);
        }

        public void Open()
        {
            _stateMachine.EnterAsStack(this);
            _body.SetActive(true);
        }

        public void Close()
        {
            _stateMachine.Exit(this);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }
    }
}