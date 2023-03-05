using Common.ReadOnlyDictionaries.Editor;
using Global.Cameras.CurrentCameras.Logs;
using UnityEditor;

namespace Global.Cameras.CurrentCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentCameraLogs))]
    public class CurrentCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}