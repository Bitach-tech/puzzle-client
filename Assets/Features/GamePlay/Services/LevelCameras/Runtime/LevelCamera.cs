using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Services.LevelCameras.Logs;
using Global.Services.CurrentCameras.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class LevelCamera :
        MonoBehaviour,
        ILevelCamera,
        ILocalAwakeListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            LevelCameraLogger logger)
        {
            _logger = logger;
            _currentCamera = currentCamera;

            _transform = transform;
        }

        private const float _offsetZ = -10f;

        private Camera _camera;
        private ICurrentCamera _currentCamera;

        private LevelCameraLogger _logger;

        private Transform _target;

        private Transform _transform;

        public Camera Camera => _camera;

        public void StartFollow(Transform target)
        {
            _target = target;

            _logger.OnStartFollow(target.name);
        }

        public void StopFollow()
        {
            if (_target == null)
            {
                _logger.OnStopFollowError();
                return;
            }

            _logger.OnStopFollow(_target.name);

            _target = null;
        }

        public void Teleport(Vector2 target)
        {
            var position = new Vector3(target.x, target.y, _offsetZ);
            _transform.position = position;

            _logger.OnTeleport(position);
        }

        public void SetSize(float size)
        {
            _camera.orthographicSize = size;
        }

        public void OnAwake()
        {
            _camera = GetComponent<Camera>();
            _currentCamera.SetCamera(_camera);
        }
    }
}