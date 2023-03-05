using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using GamePlay.LevelCameras.Common;
using GamePlay.LevelCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraAsset : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraConfigAsset _config;
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCamera _prefab;

        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ILocalCallbacks callbacks)
        {
            var levelCamera = Instantiate(_prefab);
            levelCamera.name = "LevelCamera";

            builder.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            builder.Register<LevelCameraConfig>()
                .WithParameter(_config)
                .As<ILevelCameraConfig>();

            builder.RegisterComponent(levelCamera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            serviceBinder.AddToModules(levelCamera);
        }
    }
}