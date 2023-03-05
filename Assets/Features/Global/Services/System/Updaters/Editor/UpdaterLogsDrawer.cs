using Common.ReadOnlyDictionaries.Editor;
using Global.System.Updaters.Logs;
using UnityEditor;

namespace Global.System.Updaters.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UpdaterLogs))]
    public class UpdaterLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}