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

namespace GamePlay.Puzzle.Overlay.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "ToolSelection",
        menuName = GamePlayAssetsPaths.LevelOverlay + "Service")]
    public class LevelOverlayAsset : LocalServiceAsset
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
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