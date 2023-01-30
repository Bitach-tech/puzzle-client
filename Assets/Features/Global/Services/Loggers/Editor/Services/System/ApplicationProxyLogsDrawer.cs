using Common.ReadOnlyDictionaries.Editor;
using Global.Services.ApplicationProxies.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.System
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ApplicationProxyLogs))]
    public class ApplicationProxyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}