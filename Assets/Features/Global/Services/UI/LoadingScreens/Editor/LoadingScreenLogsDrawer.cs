using Common.ReadOnlyDictionaries.Editor;
using Global.UI.LoadingScreens.Logs;
using UnityEditor;

namespace Global.UI.LoadingScreens.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadingScreenLogs))]
    public class LoadingScreenLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}