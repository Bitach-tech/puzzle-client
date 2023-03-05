using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using GamePlay.Loop.Common;
using GamePlay.Loop.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelLoopRoutes.ServiceName,
        menuName = LevelLoopRoutes.ServicePath)]
    public class LevelLoopAsset : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [Min(0)] private int _randomCount;
        [SerializeField] [Indent] private LevelLoopLogSettings _logSettings;

        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, ILocalCallbacks callbacks)
        {
            builder.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            builder.Register<LevelLoop>()
                .WithParameter(_randomCount)
                .AsCallbackListener();
        }
    }
}