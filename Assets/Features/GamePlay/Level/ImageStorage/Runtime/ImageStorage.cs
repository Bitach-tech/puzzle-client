using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using VContainer;

namespace GamePlay.Level.ImageStorage.Runtime
{
    [DisallowMultipleComponent]
    public class ImageStorage : MonoBehaviour, IImageStorage
    {
        [Inject]
        private void Construct(LevelImage[] images)
        {
            _images = images;
        }

        private LevelImage[] _images;

        public IReadOnlyList<LevelImage> GetImages()
        {
            return new ReadOnlyCollection<LevelImage>(_images);
        }
    }
}