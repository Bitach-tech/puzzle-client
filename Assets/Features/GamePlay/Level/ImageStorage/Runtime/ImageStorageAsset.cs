using System.Collections.Generic;
using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Common.NestedScriptableObjects.Attributes;
using GamePlay.Level.ImageStorage.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ImageStorageRoutes.ServiceName,
        menuName = ImageStorageRoutes.ServicePath)]
    public class ImageStorageAsset : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [NestedScriptableObjectList]
        private List<LevelImage> _images;

        [SerializeField] private ImageStorage _prefab;

        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
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