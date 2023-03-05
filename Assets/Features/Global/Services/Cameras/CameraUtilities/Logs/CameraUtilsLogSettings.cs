using Global.Cameras.CameraUtilities.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CameraUtilities.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.LogsName,
        menuName = CameraUtilsRoutes.LogsPath)]
    public class CameraUtilsLogSettings : LogSettings<CameraUtilsLogs, CameraUtilsLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}