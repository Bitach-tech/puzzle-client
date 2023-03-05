using Common.ReadOnlyDictionaries.Editor;
using Global.Cameras.GlobalCameras.Logs;
using UnityEditor;

namespace Global.Cameras.GlobalCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GlobalCameraLogs))]
    public class GlobalCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}