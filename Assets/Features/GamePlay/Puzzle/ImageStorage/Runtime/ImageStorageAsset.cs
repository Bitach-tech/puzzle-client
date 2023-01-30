using System.Collections.Generic;
using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Common.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Puzzle.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "ImageStorage",
        menuName = GamePlayAssetsPaths.ImageStorage + "Service")]
    public class ImageStorageAsset : LocalServiceAsset
    {
        [SerializeField] [NestedScriptableObjectList]
        private List<PuzzleImage> _images;

        [SerializeField] private ImageStorage _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var storage = Instantiate(_prefab);
            storage.name = "ImageStorage";

            var array = _images.ToArray();

            builder.RegisterComponent(storage)
                .As<IImageStorage>()
                .WithParameter(array);

            serviceBinder.AddToModules(storage);
        }
    }
}