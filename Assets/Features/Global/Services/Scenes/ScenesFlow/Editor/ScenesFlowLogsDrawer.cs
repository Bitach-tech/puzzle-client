using Common.ReadOnlyDictionaries.Editor;
using Global.Scenes.ScenesFlow.Logs;
using UnityEditor;

namespace Global.Scenes.ScenesFlow.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}