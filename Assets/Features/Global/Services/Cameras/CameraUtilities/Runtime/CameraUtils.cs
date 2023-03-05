using Global.Cameras.CameraUtilities.Logs;
using Global.Cameras.CurrentCameras.Runtime;
using UnityEngine;

namespace Global.Cameras.CameraUtilities.Runtime
{
    public class CameraUtils : ICameraUtils
    {
        public CameraUtils(ICurrentCamera currentCamera, CameraUtilsLogger logger)
        {
            _currentCamera = currentCamera;
            _logger = logger;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly CameraUtilsLogger _logger;

        public Vector2 ScreenToWorld(Vector2 screen)
        {
            if (_currentCamera.Current == null)
            {
                _logger.OnNoCameraError();
                return Vector2.zero;
            }

            var world = (Vector2)_currentCamera.Current.ScreenToWorldPoint(screen);

            _logger.OnScreenToWorld(screen, world);

            return world;
        }
    }
}