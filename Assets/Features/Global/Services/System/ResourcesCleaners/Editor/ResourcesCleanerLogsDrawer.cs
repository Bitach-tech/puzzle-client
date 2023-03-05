using Common.ReadOnlyDictionaries.Editor;
using Global.System.ResourcesCleaners.Logs;
using UnityEditor;

namespace Global.System.ResourcesCleaners.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ResourcesCleanerLogs))]
    public class ResourcesCleanerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}