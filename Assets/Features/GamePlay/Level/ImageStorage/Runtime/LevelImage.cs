using GamePlay.Level.ImageStorage.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ImageStorageRoutes.ImageName,
        menuName = ImageStorageRoutes.ImagePath)]
    public class LevelImage : ScriptableObject
    {
        [SerializeField] private Sprite _preview;
        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite[] _images;

        public Sprite Preview => _preview;
        public Sprite Background => _background;
        public Sprite[] Images => _images;

        public void SetPreview(Sprite preview)
        {
            _preview = preview;
        }
        
        public void SetBackground(Sprite background)
        {
            _background = background;
        }

        public void SetImages(Sprite[] images)
        {
            _images = images;
        }
    }
}