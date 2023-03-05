using Common.DiContainer.Abstract;
using Global.Cameras.CameraUtilities.Common;
using Global.Cameras.CameraUtilities.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CameraUtilities.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.ServiceName,
        menuName = CameraUtilsRoutes.ServicePath)]
    public class CameraUtilsAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private CameraUtilsLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<CameraUtilsLogger>()
                .WithParameter(_logSettings);

            builder.Register<CameraUtils>()
                .As<ICameraUtils>()
                .AsCallbackListener();
        }
    }
}