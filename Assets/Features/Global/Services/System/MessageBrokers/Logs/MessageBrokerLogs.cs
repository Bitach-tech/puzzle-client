using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.System.MessageBrokers.Logs
{
    [Serializable]
    public class MessageBrokerLogs : ReadOnlyDictionary<MessageBrokerLogType, bool>
    {
    }
}