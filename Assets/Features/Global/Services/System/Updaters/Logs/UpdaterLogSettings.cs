using Global.System.Loggers.Runtime;
using Global.System.Updaters.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Updaters.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = UpdaterRouter.LogsName,
        menuName = UpdaterRouter.LogsPath)]
    public class UpdaterLogSettings : LogSettings<UpdaterLogs, UpdaterLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}