using Global.Services.ScenesFlow.Handling.Result;
using UnityEngine.SceneManagement;

namespace Global.Services.ScenesFlow.Handling.Data
{
    public abstract class SceneLoadData<T> where T : SceneLoadResult
    {
        public SceneLoadData(string name)
        {
            Name = name;
        }

        public readonly string Name;

        public abstract T CreateLoadResult(Scene scene);
    }
}