using Common.ReadOnlyDictionaries.Editor;
using Global.Services.ScenesFlow.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.Scenes
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}