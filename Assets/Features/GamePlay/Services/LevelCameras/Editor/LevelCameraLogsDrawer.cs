using Common.ReadOnlyDictionaries.Editor;
using GamePlay.LevelCameras.Logs;
using UnityEditor;

namespace GamePlay.LevelCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelCameraLogs))]
    public class LevelCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}