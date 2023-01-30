using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Runtime.Abstract;
using Global.Services.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Menu.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuAssetsPaths.ServicePrefix + "UI", menuName = MenuAssetsPaths.UI)]
    public class MenuUIAsset : LocalServiceAsset
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var request = new TypedSceneLoadData<MenuUI>(_scene);

            var result = await sceneLoader.Load(request);
            var ui = result.Searched;

            builder.RegisterComponent(ui)
                .WithParameter(_constraints)
                .As<IMenuUI>()
                .AsCallbackListener();
        }
    }
}