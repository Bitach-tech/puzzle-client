using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Loop.Logs;
using UnityEditor;

namespace GamePlay.Loop.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelLoopLogs))]
    public class LevelLoopLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}