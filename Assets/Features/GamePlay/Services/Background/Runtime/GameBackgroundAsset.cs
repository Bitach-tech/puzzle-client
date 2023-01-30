using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Background.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "GameBackground",
        menuName = GamePlayAssetsPaths.GameBackground + "Service")]
    public class GameBackgroundAsset : LocalServiceAsset
    {
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<GameBackground>(_scene);
            var result = await sceneLoader.Load(sceneData);

            var background = result.Searched;

            builder.RegisterComponent(background)
                .As<IGameBackground>()
                .AsCallbackListener();
        }
    }
}