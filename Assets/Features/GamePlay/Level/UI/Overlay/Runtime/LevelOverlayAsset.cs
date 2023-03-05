using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Level.UI.Overlay.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.UI.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.UI.Overlay.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelOverlayRoutes.ServiceName,
        menuName = LevelOverlayRoutes.ServicePath)]
    public class LevelOverlayAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<LevelOverlayRoot>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);
            var root = loadResult.Searched;

            builder.RegisterComponent(root)
                .As<ILevelOverlay>()
                .WithParameter(_constraints)
                .AsCallbackListener();
        }
    }
}