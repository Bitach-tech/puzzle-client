using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.UI.LoadingScreens.Logs
{
    [Serializable]
    public class LoadingScreenLogs : ReadOnlyDictionary<LoadingScreenLogType, bool>
    {
    }
}