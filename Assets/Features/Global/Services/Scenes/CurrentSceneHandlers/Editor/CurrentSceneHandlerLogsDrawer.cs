using Common.ReadOnlyDictionaries.Editor;
using Global.Scenes.CurrentSceneHandlers.Logs;
using UnityEditor;

namespace Global.Scenes.CurrentSceneHandlers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentSceneHandlerLogs))]
    public class CurrentSceneHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}