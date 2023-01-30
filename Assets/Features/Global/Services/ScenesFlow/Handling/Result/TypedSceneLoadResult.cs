using UnityEngine.SceneManagement;

namespace Global.Services.ScenesFlow.Handling.Result
{
    public class TypedSceneLoadResult<T> : SceneLoadResult
    {
        public TypedSceneLoadResult(Scene scene, T searched) : base(scene)
        {
            Searched = searched;
        }

        public readonly T Searched;
    }
}