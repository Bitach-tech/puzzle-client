using Global.Inputs.Common;
using Global.System.Loggers.Runtime;
using UnityEngine;

namespace Global.Inputs.View.Logs
{
    [CreateAssetMenu(fileName = InputRouter.LogsName,
        menuName = InputRouter.LogsPath)]
    public class InputViewLogSettings : LogSettings<InputViewLogs, InputViewLogType>
    {
        [SerializeField] private LogParameters _parameters;

        public LogParameters LogParameters => _parameters;
    }
}