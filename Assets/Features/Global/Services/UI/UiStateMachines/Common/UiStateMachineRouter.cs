using Global.Common;

namespace Global.UI.UiStateMachines.Common
{
    public static class UiStateMachineRouter
    {
        private const string _paths = GlobalAssetsPaths.Root + "UI/StateMachine/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "UiStateMachine";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "UiStateMachine";

        public const string ConstraintsPrefix = "UiConstraints_";
        public const string ConstraintsPath = _paths + "Constraints";
    }
}