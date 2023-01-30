using Cysharp.Threading.Tasks;
using GamePlay.Config.Services.Runtime;
using Global.Bootstrappers;
using Global.GameLoops.Abstract;
using Global.Services.Common.Config.Abstract;
using Global.Services.Common.Scope;
using Global.Services.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.DiContainer.Runtime.ContainerBuilder;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class GlobalBootstrapMock : MonoBehaviour
    {
        private static bool _isBootstrapped = false;

        [SerializeField] private GlobalScope _scope;
        [SerializeField] private GlobalGameLoopAsset _gameLoop;
        [SerializeField] private GameAsset _game;
        [SerializeField] [Scene] private string _servicesScene;

        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            if (_isBootstrapped == true)
                return;

            _isBootstrapped = true;

            Process().Forget();
        }

        private void OnDestroy()
        {
            _isBootstrapped = false;
        }

        private async UniTask Process()
        {
            await BootstrapGlobal();
            await BootstrapLocal();
        }

        private async UniTask BootstrapGlobal()
        {
            var servicesScene = new Scene();

            SceneManager.sceneLoaded += (scene, mode) => { servicesScene = scene; };

            await SceneManager.LoadSceneAsync(_servicesScene, LoadSceneMode.Additive).ToUniTask();
            await UniTask.WaitUntil(() => servicesScene.name == "");

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

            binder.AddToModules(_scope);

            var services = _services.GetAssets();
            var servicesTasks = new UniTask[services.Length];

            _gameLoop.Create(dependencyRegister, binder);

            for (var i = 0; i < servicesTasks.Length; i++)
                servicesTasks[i] = services[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(servicesTasks);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => _scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                dependencyRegister.RegisterAll(builder);
            }

            dependencyRegister.ResolveAllWithCallbacks(_scope.Container, callbacks);

            await callbacks.InvokeFlowCallbacks();
        }

        private async UniTask BootstrapLocal()
        {
            var result = await _game.Load(_scope, _scope.Container.Resolve<ISceneLoader>());

            result.OnLoaded();
        }
    }
}