using Common.DiContainer.Abstract;
using Global.Debugs.Console.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Debugs.Console.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DebugConsoleRoutes.ServiceName,
        menuName = DebugConsoleRoutes.ServicePath)]
    public class DebugConsoleAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private DebugConsole _prefab;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var debugConsole = Instantiate(_prefab);
            debugConsole.name = "DebugConsole";

            builder.RegisterComponent(debugConsole)
                .AsCallbackListener();

            serviceBinder.AddToModules(debugConsole);
        }
    }
}