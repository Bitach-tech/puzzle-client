using GamePlay.Level.UI.Overlay.Runtime;
using Global.Publisher.Abstract.Advertisment;
using Global.UI.UiStateMachines.Runtime;
using UnityEngine;

namespace GamePlay.Level.UI.Root.Runtime
{
    public class LevelUiRoot : IUiState, ILevelUiRoot
    {
        public LevelUiRoot(
            IUiStateMachine uiStateMachine,
            IAds ads,
            ILevelOverlay overlay,
            UiConstraints constraints)
        {
            _overlay = overlay;
            _uiStateMachine = uiStateMachine;
            Constraints = constraints;
        }

        private readonly IUiStateMachine _uiStateMachine;

        private readonly WaitForSeconds _wait = new(180f);
        private readonly ILevelOverlay _overlay;

        public UiConstraints Constraints { get; }
        public string Name => "Paint";

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
            _overlay.Open();
        }

        public void Recover()
        {
        }

        public void Exit()
        {
        }
    }
}