using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Result
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