using Common.DiContainer.Abstract;
using Global.Scenes.ScenesFlow.Common;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.ScenesFlow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.ServiceName,
        menuName = ScenesFlowRoutes.ServicePath)]
    public class ScenesFlowAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ScenesFlowLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<ScenesFlowLogger>()
                .WithParameter(_logSettings);

            builder.Register<ScenesLoader>()
                .As<ISceneLoader>();

            builder.Register<ScenesUnloader>()
                .As<ISceneUnloader>();
        }
    }
}