using Common.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
    public class LoggerAsset : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Logger>()
                .As<ILogger>();
        }
    }
}