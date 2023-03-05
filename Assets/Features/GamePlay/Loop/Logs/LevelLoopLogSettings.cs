using GamePlay.Loop.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = LevelLoopRoutes.LogsName,
        menuName = LevelLoopRoutes.LogsPath)]
    public class LevelLoopLogSettings : LogSettings<LevelLoopLogs, LevelLoopLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}