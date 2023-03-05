using System.Collections.Generic;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.DiContainer.Runtime.ContainerBuilder;

namespace Common.Local.ComposedSceneConfig
{
    public abstract class ComposedSceneAsset : ScriptableObject
    {
        [SerializeField] private ComposedScenesConfig _config;

        public async UniTask<ComposedSceneLoadResult> Load(LifetimeScope parent, ISceneLoader loader)
        {
            var factories = GetFactories();
            var asyncFactories = GetAsyncFactories();

            var sceneLoader = new ComposedSceneLoader(loader);
            var asyncFactoriesTasks = new List<UniTask>();

            var loadServicesScene = await sceneLoader.Load(new EmptySceneLoadData(_config.ServicesScene));
            var servicesScene = loadServicesScene.Scene;
            var transformer = new LocalServiceTransformer(servicesScene);

            var serviceBinder = new LocalServiceBinder(transformer);
            var selfCallbacks = new LocalCallbacks();
            var builder = new ContainerBuilder();

            foreach (var factory in factories)
                factory.Create(builder, serviceBinder, selfCallbacks);

            foreach (var service in asyncFactories)
            {
                var task = service.Create(builder, serviceBinder, sceneLoader, selfCallbacks);
                asyncFactoriesTasks.Add(task);
            }

            await UniTask.WhenAll(asyncFactoriesTasks);

            var scopePrefab = AssignScope();
            var scope = Instantiate(scopePrefab);
            serviceBinder.AddToModules(scope);

            selfCallbacks.InvokeRegisterCallbacks(builder);

            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void Register(IContainerBuilder container)
            {
                builder.RegisterAll(container);
            }

            builder.ResolveAllWithCallbacks(scope.Container, selfCallbacks);

            selfCallbacks.Resolve(scope.Container);

            selfCallbacks.InvokeAwakeCallbacks();
            await selfCallbacks.InvokeAsyncAwakeCallbacks();

            selfCallbacks.InvokeEnableCallback();

            selfCallbacks.InvokeBootstrapCallbacks();
            await selfCallbacks.InvokeAsyncBootstrapCallbacks();

            return new ComposedSceneLoadResult(
                sceneLoader.Results,
                selfCallbacks.SwitchCallbacks,
                scope,
                selfCallbacks.InvokeLoadedCallbacks);
        }

        protected abstract ILocalServiceFactory[] GetFactories();
        protected abstract ILocalServiceAsyncFactory[] GetAsyncFactories();

        protected abstract LifetimeScope AssignScope();
    }
}