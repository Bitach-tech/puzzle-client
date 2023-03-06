using System;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Setup.Service.Callbacks;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Runtime
{
    public class InputView : IInputView, IInputViewRebindCallbacks, IGlobalAwakeListener, IUpdatable
    {
        public InputView(
            InputViewLogger logger,
            ICameraUtils cameraUtils,
            IInputConstraintsStorage constraintsStorage,
            IUpdater updater)
        {
            _constraintsStorage = constraintsStorage;
            _updater = updater;
            _logger = logger;
            _cameraUtils = cameraUtils;

            _controls = new Controls();
            _gamePlay = _controls.GamePlay;
            _debug = _controls.Debug;
        }

        private readonly ICameraUtils _cameraUtils;
        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IUpdater _updater;

        private readonly InputViewLogger _logger;

        private readonly Controls _controls;
        private readonly Controls.DebugActions _debug;
        private readonly Controls.GamePlayActions _gamePlay;

        private bool _isLeftMouseButtonPressed;
        private Vector2 _position;

        public bool IsLeftMouseButtonPressed => _isLeftMouseButtonPressed;
        public Vector2 Position => _position;

        public event Action DebugConsolePreformed;

        public void OnAwake()
        {
            _controls.Enable();

            Listen();
            
            _updater.Add(this);
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

            Debug.Log($"Raw: {_position}, world: {worldPosition}");
            
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

        public void OnUpdate(float delta)
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;

                _isLeftMouseButtonPressed = false;

                if (touches.Length < 1)
                    return;

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