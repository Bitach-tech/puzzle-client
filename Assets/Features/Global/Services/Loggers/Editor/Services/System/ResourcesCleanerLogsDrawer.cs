using Common.ReadOnlyDictionaries.Editor;
using Global.Services.ResourcesCleaners.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.System
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ResourcesCleanerLogs))]
    public class ResourcesCleanerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}