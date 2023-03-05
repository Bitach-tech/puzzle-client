using Common.ReadOnlyDictionaries.Editor;
using Global.UI.UiStateMachines.Logs;
using UnityEditor;

namespace Global.UI.UiStateMachines.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UiStateMachineLogs))]
    public class UiStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}