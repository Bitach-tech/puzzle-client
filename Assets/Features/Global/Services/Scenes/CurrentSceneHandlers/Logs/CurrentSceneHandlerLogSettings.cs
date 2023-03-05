using Global.Scenes.CurrentSceneHandlers.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.CurrentSceneHandlers.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = CurrentSceneHandlerRoutes.LogsName,
        menuName = CurrentSceneHandlerRoutes.LogsPath)]
    public class CurrentSceneHandlerLogSettings : LogSettings<CurrentSceneHandlerLogs, CurrentSceneHandlerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}