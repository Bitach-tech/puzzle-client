using Common.DiContainer.Abstract;
using Global.Scenes.CurrentSceneHandlers.Common;
using Global.Scenes.CurrentSceneHandlers.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.CurrentSceneHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentSceneHandlerRoutes.ServiceName,
        menuName = CurrentSceneHandlerRoutes.ServicePath)]
    public class CurrentSceneHandlerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private CurrentSceneHandlerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<CurrentSceneHandlerLogger>()
                .WithParameter(_logSettings);

            builder.Register<CurrentSceneHandler>()
                .As<ICurrentSceneHandler>();
        }
    }
}