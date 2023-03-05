using Common.ReadOnlyDictionaries.Editor;
using Global.Cameras.CameraUtilities.Logs;
using UnityEditor;

namespace Global.Cameras.CameraUtilities.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CameraUtilsLogs))]
    public class CameraUtilsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}