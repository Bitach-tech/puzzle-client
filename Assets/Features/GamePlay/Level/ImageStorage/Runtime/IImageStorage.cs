using System.Collections.Generic;

namespace GamePlay.Level.ImageStorage.Runtime
{
    public interface IImageStorage
    {
        IReadOnlyList<LevelImage> GetImages();
    }
}