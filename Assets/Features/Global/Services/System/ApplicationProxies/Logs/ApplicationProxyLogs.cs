using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.System.ApplicationProxies.Logs
{
    [Serializable]
    public class ApplicationProxyLogs : ReadOnlyDictionary<ApplicationProxyLogType, bool>
    {
    }
}