using Common.ReadOnlyDictionaries.Editor;
using Global.Services.CurrentSceneHandlers.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.Utils
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentSceneHandlerLogs))]
    public class CurrentSceneHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}