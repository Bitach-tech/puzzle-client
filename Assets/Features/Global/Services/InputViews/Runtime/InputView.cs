using System;
using Global.Services.CameraUtilities.Runtime;
using Global.Services.Common.Abstract;
using Global.Services.InputViews.Constraints;
using Global.Services.InputViews.ConstraintsStorage;
using Global.Services.InputViews.Logs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using VContainer;

namespace Global.Services.InputViews.Runtime
{
    public class InputView : MonoBehaviour, IInputView, IInputViewRebindCallbacks, IGlobalAwakeListener
    {
        [Inject]
        private void Construct(
            InputViewLogger logger,
            ICameraUtils cameraUtils,
            IInputConstraintsStorage constraintsStorage)
        {
            _constraintsStorage = constraintsStorage;
            _logger = logger;
            _cameraUtils = cameraUtils;
        }

        private ICameraUtils _cameraUtils;
        private IInputConstraintsStorage _constraintsStorage;

        private Controls _controls;
        private Controls.DebugActions _debug;
        private Controls.GamePlayActions _gamePlay;

        private InputViewLogger _logger;

        private bool _isLeftMouseButtonPressed;
        private Vector2 _position;

        public bool IsLeftMouseButtonPressed => _isLeftMouseButtonPressed;
        public Vector2 MousePosition => _position;

        public event Action DebugConsolePreformed;
        public event Action LeftMouseButtonPerformed;

        private void OnDestroy()
        {
            UnListen();

            _controls.Disable();
        }

        public void OnAwake()
        {
            _controls = new Controls();
            _controls.Enable();

            _gamePlay = _controls.GamePlay;
            _debug = _controls.Debug;

            Listen();
        }

        public float GetAngleFrom(Vector2 from)
        {
            var direction = GetDirectionFrom(from);

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (angle < 0f)
                angle += 360f;

            return angle;
        }

        public Vector2 GetDirectionFrom(Vector2 from)
        {
            var screenPosition = Mouse.current.position.ReadValue();
            var worldPosition = _cameraUtils.ScreenToWorld(screenPosition);

            var direction = worldPosition - from;
            direction.Normalize();

            return direction;
        }

        public LineResult GetLineFrom(Vector2 from)
        {
            var screenPosition = Mouse.current.position.ReadValue();
            var worldPosition = _cameraUtils.ScreenToWorld(screenPosition);

            var direction = worldPosition - from;
            direction.Normalize();

            var length = Vector2.Distance(from, worldPosition);

            return new LineResult(direction, length);
        }

        public Vector2 ScreenToWorld()
        {
            var worldPosition = _cameraUtils.ScreenToWorld(_position);

            return worldPosition;
        }

        public void OnBeforeRebind()
        {
            _logger.OnBeforeRebind();
        }

        public void OnAfterRebind()
        {
            _logger.OnAfterRebind();
        }

        private void Listen()
        {
            _gamePlay.RangeAttack.performed += OnLeftMouseButtonPerformed;
            _gamePlay.RangeAttack.canceled += OnLeftMouseButtonCanceled;

            _debug.Console.performed += OnDebugConsolePreformed;
        }

        private void UnListen()
        {
            _gamePlay.RangeAttack.performed -= OnLeftMouseButtonPerformed;
            _gamePlay.RangeAttack.canceled -= OnLeftMouseButtonCanceled;

            _debug.Console.performed -= OnDebugConsolePreformed;
        }

        private void OnLeftMouseButtonPerformed(InputAction.CallbackContext context)
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
                return;

            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                _isLeftMouseButtonPressed = false;

                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }

            _logger.OnRangeAttackPerformed();

            _isLeftMouseButtonPressed = true;
            LeftMouseButtonPerformed?.Invoke();
        }

        private void OnLeftMouseButtonCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }

            _logger.OnRangeAttackCanceled();

            _isLeftMouseButtonPressed = false;
        }

        private void OnDebugConsolePreformed(InputAction.CallbackContext context)
        {
            DebugConsolePreformed?.Invoke();
        }

        private void Update()
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;

                if (touches.Length < 1)
                {
                    _isLeftMouseButtonPressed = false;
                    return;
                }

                if (_isLeftMouseButtonPressed == false)
                    LeftMouseButtonPerformed?.Invoke();
                
                _position = touches[0].rawPosition;
                _isLeftMouseButtonPressed = true;
            }
            else
            {
                _position = Mouse.current.position.ReadValue();
            }
        }
    }
}