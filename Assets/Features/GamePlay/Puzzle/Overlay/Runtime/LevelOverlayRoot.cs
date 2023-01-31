using Common.Local.Services.Abstract.Callbacks;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Puzzle.Overlay.Runtime
{
    [DisallowMultipleComponent]
    public class LevelOverlayRoot : MonoBehaviour, IUiState, ILocalAwakeListener, ILocalSwitchListener, ILevelOverlay
    {
        [Inject]
        private void Construct(IUiStateMachine uiStateMachine, UiConstraints constraints)
        {
            _constraints = constraints;
            _uiStateMachine = uiStateMachine;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private GameObject _assembled;
        
        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        public UiConstraints Constraints => _constraints;
        public string Name => "ToolSelection";

        public void OnAwake()
        {
            _body.SetActive(false);
        }

        public void OnEnabled()
        {
        }

        public void OnDisabled()
        {
        }

        public void Open()
        {
            _uiStateMachine.EnterAsStack(this);
            _body.SetActive(true);
            _assembled.SetActive(false);
        }

        public void ShowAssembledScreen()
        {
            _assembled.SetActive(true);
        }

        public void HideAssembledScreen()
        {
            _assembled.SetActive(false);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }
    }
}