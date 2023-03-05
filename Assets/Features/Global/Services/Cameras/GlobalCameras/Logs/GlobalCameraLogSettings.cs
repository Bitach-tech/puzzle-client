using Global.Cameras.GlobalCameras.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.GlobalCameras.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalCameraRoutes.LogsName,
        menuName = GlobalCameraRoutes.LogsPath)]
    public class GlobalCameraLogSettings : LogSettings<GlobalCameraLogs, GlobalCameraLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}