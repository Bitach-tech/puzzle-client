using Global.Scenes.ScenesFlow.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.ScenesFlow.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.LogsName,
        menuName = ScenesFlowRoutes.LogsPath)]
    public class ScenesFlowLogSettings : LogSettings<ScenesFlowLogs, ScenesFlowLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}