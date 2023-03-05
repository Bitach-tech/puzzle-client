using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Menu.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.UI.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Menu.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuRoutes.ServiceName,
        menuName = MenuRoutes.ServicePath)]
    public class MenuUIAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public async UniTask Create(
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