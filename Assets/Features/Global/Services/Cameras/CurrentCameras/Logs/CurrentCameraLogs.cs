using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.CurrentCameras.Logs
{
    [Serializable]
    public class CurrentCameraLogs : ReadOnlyDictionary<CurrentCameraLogType, bool>
    {
    }
}