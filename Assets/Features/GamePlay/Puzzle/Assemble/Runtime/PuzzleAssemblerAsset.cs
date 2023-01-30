using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using Features.GamePlay.Puzzle.Assemble.Runtime.Background;
using Features.GamePlay.Puzzle.Assemble.Runtime.StartPositions;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "PuzzleAssemble",
        menuName = GamePlayAssetsPaths.PuzzleAssembler + "Service")]
    public class PuzzleAssemblerAsset : LocalServiceAsset
    {
        [SerializeField] [Indent] [Scene] private string _scene;
        [SerializeField] [Indent] private PickHandlerConfigAsset _config;
        [SerializeField] [Indent] private PuzzleAssembler _prefab;

        public override async UniTask Create(
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
                .As<IPuzzleAssembler>()
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

            builder.Register<PartPicker>();
            builder.Register<PickHandler>()
                .WithParameter(_config);
        }
    }
}