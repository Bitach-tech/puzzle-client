using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Services.Common.Config.Abstract;
using Global.Services.Common.Scope;
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
            Bootstrap().Forget();
        }

        private async UniTaskVoid Bootstrap()
        {
            var servicesScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                servicesScene = scene;
            }

            await SceneManager.LoadSceneAsync(_servicesScene, LoadSceneMode.Additive).ToUniTask();

            Debug.Log($"{servicesScene.name}   {_servicesScene}");
            await UniTask.WaitUntil(() => servicesScene.name == _servicesScene);
            Debug.Log(0);


            SceneManager.sceneLoaded -= OnSceneLoaded;

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

            var services = _services.GetAssets();
            var servicesTasks = new UniTask[services.Length];

            Debug.Log(1);

            var gameLoop = _gameLoop.Create(dependencyRegister, binder);
            Debug.Log(2);


            for (var i = 0; i < servicesTasks.Length; i++)
                servicesTasks[i] = services[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            Debug.Log(3);

            await UniTask.WhenAll(servicesTasks);

            Debug.Log(4);

            var scope = Instantiate(_scope);
            scope.IsRoot = true;
            binder.AddToModules(scope);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                Debug.Log(5);

                await UniTask.Create(async () => scope.Build());
                Debug.Log(6);
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                Debug.Log(7);

                dependencyRegister.RegisterAll(builder);
                Debug.Log(8);
            }

            Debug.Log(9);


            dependencyRegister.ResolveAllWithCallbacks(scope.Container, callbacks);

            Debug.Log(10);


            await callbacks.InvokeFlowCallbacks();

            Debug.Log(11);

            gameLoop.OnAwake();
            Debug.Log(12);

            gameLoop.Begin();
            Debug.Log(13);
        }
    }
}