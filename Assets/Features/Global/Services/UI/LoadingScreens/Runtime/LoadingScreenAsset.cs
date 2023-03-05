using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.UI.LoadingScreens.Common;
using Global.UI.LoadingScreens.Logs;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.LoadingScreens.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoadingScreenRouter.ServiceName,
        menuName = LoadingScreenRouter.ServicePath)]
    public class LoadingScreenAsset : ScriptableObject, IGlobalServiceAsyncFactory
    {
        [SerializeField] [Indent] private LoadingScreenLogSettings _logSettings;
        [SerializeField] [Indent] [Scene] private string _scene;

        public async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var result = await sceneLoader.LoadAsync(new InternalScene<LoadingScreen>(_scene));

            var loadingScreen = result.Searched;

            builder.Register<LoadingScreenLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(loadingScreen)
                .As<ILoadingScreen>();

            serviceBinder.AddToModules(loadingScreen);
        }
    }
}