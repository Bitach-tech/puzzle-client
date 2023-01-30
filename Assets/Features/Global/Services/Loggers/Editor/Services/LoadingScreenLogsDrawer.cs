using Common.ReadOnlyDictionaries.Editor;
using Global.Services.LoadingScreens.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadingScreenLogs))]
    public class LoadingScreenLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}