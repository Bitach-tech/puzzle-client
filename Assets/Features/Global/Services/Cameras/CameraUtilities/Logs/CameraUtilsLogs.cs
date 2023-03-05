using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.CameraUtilities.Logs
{
    [Serializable]
    public class CameraUtilsLogs : ReadOnlyDictionary<CameraUtilsLogType, bool>
    {
    }
}