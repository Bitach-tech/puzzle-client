using Global.GameLoops.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GameLoopRouter.LogsName,
        menuName = GameLoopRouter.LogsPath)]
    public class GameLoopLogSettings : LogSettings<GameLoopLogs, GameLoopLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}