using Common.DiContainer.Abstract;
using Global.GameLoops.Abstract;
using Global.GameLoops.Common;
using Global.GameLoops.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.ServiceName,
        menuName = GameLoopRouter.ServicePath)]
    public class GameLoopAsset : GlobalGameLoopAsset
    {
        [SerializeField] [Indent] private GameLoopLogSettings _logSettings;

        [SerializeField] [Indent] private GameLoop _prefab;

        public override GlobalGameLoop Create(IDependencyRegister register, IGlobalServiceBinder binder)
        {
            var gameLoop = Instantiate(_prefab);
            gameLoop.name = "GameLoop";

            register.Register<GameLoopLogger>()
                .WithParameter(_logSettings);

            register.RegisterComponent(gameLoop)
                .AsImplementedInterfaces()
                .AsSelfResolvable();

            binder.AddToModules(gameLoop);

            return gameLoop;
        }
    }
}