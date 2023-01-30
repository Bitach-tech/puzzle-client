using Common.ReadOnlyDictionaries.Editor;
using Global.Services.GlobalCameras.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.Utils
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GlobalCameraLogs))]
    public class GlobalCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}