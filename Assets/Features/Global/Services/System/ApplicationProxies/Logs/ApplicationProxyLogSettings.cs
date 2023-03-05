using Global.System.ApplicationProxies.Common;
using Global.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ApplicationProxies.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.LogsName,
        menuName = ApplicationProxyRoutes.LogsPath)]
    public class ApplicationProxyLogSettings : LogSettings<ApplicationProxyLogs, ApplicationProxyLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}