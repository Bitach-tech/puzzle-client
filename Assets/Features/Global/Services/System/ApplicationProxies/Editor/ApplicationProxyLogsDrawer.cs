using Common.ReadOnlyDictionaries.Editor;
using Global.System.ApplicationProxies.Logs;
using UnityEditor;

namespace Global.System.ApplicationProxies.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ApplicationProxyLogs))]
    public class ApplicationProxyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}