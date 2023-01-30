using System;
using Global.Services.ScenesFlow.Handling.Result;
using UnityEngine.SceneManagement;

namespace Global.Services.ScenesFlow.Handling.Data
{
    public class TypedSceneLoadData<T> : SceneLoadData<TypedSceneLoadResult<T>>
    {
        public TypedSceneLoadData(string name) : base(name)
        {
        }

        public override TypedSceneLoadResult<T> CreateLoadResult(Scene scene)
        {
            var searched = Search(scene);

            return new TypedSceneLoadResult<T>(scene, searched);
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