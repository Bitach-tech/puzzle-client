using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using GamePlay.Level.UI.Root.Common;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.UI.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelUiRootRoutes.ServiceName,
        menuName = LevelUiRootRoutes.ServicePath)]
    public class LevelUiRootAsset : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private UiConstraints _constraints;

        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, ILocalCallbacks callbacks)
        {
            builder.Register<LevelUiRoot>()
                .WithParameter(_constraints)
                .As<ILevelUiRoot>();
        }
    }
}