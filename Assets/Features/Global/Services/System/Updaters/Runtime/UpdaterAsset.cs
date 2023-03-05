using Common.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.Updaters.Common;
using Global.System.Updaters.Logs;
using Global.System.Updaters.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Updaters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UpdaterRouter.ServiceName,
        menuName = UpdaterRouter.ServicePath)]
    public class UpdaterAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private UpdaterLogSettings _logSettings;
        [SerializeField] [Indent] private Updater _prefab;

        public void Create(IDependencyRegister builder, IGlobalServiceBinder serviceBinder, IGlobalCallbacks callbacks)
        {
            var updater = Instantiate(_prefab);
            updater.name = "Updater";

            builder.Register<UpdaterLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(updater)
                .As<IUpdater>()
                .As<IUpdateSpeedModifier>()
                .As<IUpdateSpeedSetter>()
                .AsSelfResolvable()
                .AsCallbackListener();

            serviceBinder.AddToModules(updater);
        }
    }
}