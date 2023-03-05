using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Background.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Background.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BackgroundRoutes.ServiceName,
        menuName = BackgroundRoutes.ServicePath)]
    public class GameBackgroundAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [Scene] private string _scene;

        public async UniTask Create(
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