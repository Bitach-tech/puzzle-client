using Common.ReadOnlyDictionaries.Editor;
using Global.Services.InputViews.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(InputViewLogs))]
    public class InputViewLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}