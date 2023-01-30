using UnityEngine.SceneManagement;

namespace Global.Services.ScenesFlow.Handling.Result
{
    public class EmptySceneLoadResult : SceneLoadResult
    {
        public EmptySceneLoadResult(Scene scene) : base(scene)
        {
        }
    }
}