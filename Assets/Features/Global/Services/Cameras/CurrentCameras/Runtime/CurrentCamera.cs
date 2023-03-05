using Global.Cameras.CurrentCameras.Logs;
using UnityEngine;

namespace Global.Cameras.CurrentCameras.Runtime
{
    public class CurrentCamera : ICurrentCamera
    {
        public CurrentCamera(CurrentCameraLogger logger)
        {
            _logger = logger;
        }

        private readonly CurrentCameraLogger _logger;

        private Camera _current;

        public Camera Current
        {
            get
            {
                _logger.OnUsed(_current);

                return _current;
            }
        }

        public void SetCamera(Camera current)
        {
            _current = current;

            _logger.OnSetted(current);
        }
    }
}