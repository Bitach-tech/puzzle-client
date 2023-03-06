using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Assemble.Common;
using GamePlay.Level.Assemble.Runtime.Background;
using GamePlay.Level.Assemble.Runtime.Borders;
using GamePlay.Level.Assemble.Runtime.Handler;
using GamePlay.Level.Assemble.Runtime.Parts;
using GamePlay.Level.Assemble.Runtime.StartPositions;
using GamePlay.Level.Assemble.Runtime.Targets;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AssembleRoutes.ServiceName,
        menuName = AssembleRoutes.ServicePath)]
    public class PuzzleAssemblerAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [Indent] [Scene] private string _scene;
        [SerializeField] [Indent] private PickHandlerConfigAsset _config;
        [SerializeField] [Indent] private Assembler _prefab;

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<PuzzleBootstrapper>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);

            var bootstrapper = loadResult.Searched;

            var assembler = Instantiate(_prefab);
            assembler.name = "PuzzleAssembler";

            builder.RegisterComponent(assembler)
                .As<IAssembler>()
                .AsCallbackListener();

            builder.RegisterComponent(bootstrapper.Parts)
                .As<IPartsStorage>()
                .AsCallbackListener();
            
            builder.RegisterComponent(bootstrapper.Targets)
                .As<ITargetsStorage>()
                .AsCallbackListener();
            
            builder.RegisterComponent(bootstrapper.RandomStartPositions)
                .As<IRandomStartPositions>();
            
            builder.RegisterComponent(bootstrapper.Background)
                .As<IPuzzleBackground>();

            builder.RegisterComponent(bootstrapper.Borders)
                .As<IPuzzleBorders>();
            
            builder.Register<PartPicker>();
            builder.Register<PickHandler>()
                .WithParameter(_config);
        }
    }
}