using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Level.UI.Win.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.UI.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.UI.Win.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = WinRoutes.ServiceName, menuName = WinRoutes.ServicePath)]
    public class WinScreenAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public async UniTask Create(IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<WinScreen>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);

            var screen = loadResult.Searched;

            builder.RegisterComponent(screen)
                .WithParameter(_constraints)
                .As<IWinScreen>()
                .AsCallbackListener();
        }
    }
}