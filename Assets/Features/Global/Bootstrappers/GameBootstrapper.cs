using System.Diagnostics;
using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Scope;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.DiContainer.Runtime.ContainerBuilder;

namespace Global.Bootstrappers
{
    [DisallowMultipleComponent]
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GlobalScope _scope;
        [SerializeField] [Scene] private string _servicesScene;

        [SerializeField] private GameLoopAsset _gameLoop;
        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(_servicesScene, LoadSceneMode.Additive);

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;

                Bootstrap(scene).Forget();
            }
        }

        private async UniTaskVoid Bootstrap(Scene servicesScene)
        {
            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

            var gameLoop = _gameLoop.Create(dependencyRegister, binder);

            var factories = _services.GetFactories();
            var asyncFactories = _services.GetAsyncFactories();

            var factoryWatch = new Stopwatch();
            factoryWatch.Start();

            foreach (var factory in factories)
                factory.Create(dependencyRegister, binder, callbacks);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(asyncFactoriesTasks);

            var scope = Instantiate(_scope);
            scope.IsRoot = true;

            binder.AddToModules(scope);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                dependencyRegister.RegisterAll(builder);
            }

            dependencyRegister.ResolveAllWithCallbacks(scope.Container, callbacks);

            await callbacks.InvokeFlowCallbacks();

            gameLoop.OnAwake();

            gameLoop.Begin();
        }
    }
}