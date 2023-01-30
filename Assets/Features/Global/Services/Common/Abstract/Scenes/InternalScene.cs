using System;
using UnityEngine.SceneManagement;

namespace Global.Services.Common.Abstract.Scenes
{
    public class InternalScene<T>
    {
        public InternalScene(string name)
        {
            Name = name;
        }

        public readonly string Name;

        public InternalSceneLoadResult<T> CreateLoadResult(Scene scene)
        {
            var searched = Search(scene);

            return new InternalSceneLoadResult<T>(scene, searched);
        }

        private T Search(Scene scene)
        {
            var rootObjects = scene.GetRootGameObjects();
            foreach (var rootObject in rootObjects)
                if (rootObject.TryGetComponent(out T searched) == true)
                    return searched;

            throw new NullReferenceException($"Searched {typeof(T)} is not found");
        }
    }
}