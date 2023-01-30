using Common.ReadOnlyDictionaries.Editor;
using Global.Services.CameraUtilities.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.Utils
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CameraUtilsLogs))]
    public class CameraUtilsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}