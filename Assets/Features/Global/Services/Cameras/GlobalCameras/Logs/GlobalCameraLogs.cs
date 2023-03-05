using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.GlobalCameras.Logs
{
    [Serializable]
    public class GlobalCameraLogs : ReadOnlyDictionary<GlobalCameraLogType, bool>
    {
    }
}