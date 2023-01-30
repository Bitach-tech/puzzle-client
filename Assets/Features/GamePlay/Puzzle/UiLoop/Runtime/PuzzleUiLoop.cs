using System.Collections;
using GamePlay.Puzzle.ImageStorage.Runtime;
using GamePlay.Puzzle.Overlay.Runtime;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Puzzle.Loop.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzleUiLoop : MonoBehaviour, IUiState, IPuzzleUiLoop
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            IAds ads,
            ILevelOverlay overlay,
            UiConstraints constraints)
        {
            _overlay = overlay;
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;

        private readonly WaitForSeconds _wait = new(180f);
        private ILevelOverlay _overlay;

        public UiConstraints Constraints => _constraints;
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
            StopAllCoroutines();
        }
    }
}