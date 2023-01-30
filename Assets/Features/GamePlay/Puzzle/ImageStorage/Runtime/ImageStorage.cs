using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GamePlay.Puzzle.ImageStorage.Runtime
{
    [DisallowMultipleComponent]
    public class ImageStorage : MonoBehaviour, IImageStorage
    {
        [Inject]
        private void Construct(PuzzleImage[] images)
        {
            _images = images;
        }

        private PuzzleImage[] _images;

        public IReadOnlyList<PuzzleImage> GetImages()
        {
            return new ReadOnlyCollection<PuzzleImage>(_images);
        }
    }
}