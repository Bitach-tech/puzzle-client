using Global.Common;

namespace Global.System.MessageBrokers.Common
{
    public class MessageBrokerRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/MessageBroker/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "MessageBroker";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "MessageBroker";
    }
}