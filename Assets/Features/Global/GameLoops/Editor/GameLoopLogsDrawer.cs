using Common.ReadOnlyDictionaries.Editor;
using Global.GameLoops.Logs;
using UnityEditor;

namespace Global.GameLoops.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GameLoopLogs))]
    public class GameLoopLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}