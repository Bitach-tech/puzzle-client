using Cysharp.Threading.Tasks;
using Global.Services.Common.Abstract.Scenes;
using UnityEngine.SceneManagement;

namespace Global.Bootstrappers
{
    public class GlobalSceneLoader : IGlobalSceneLoader
    {
        public async UniTask<InternalSceneLoadResult<T>> Load<T>(InternalScene<T> scene)
        {
            var targetScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name != scene.Name)
                    return;

                targetScene = loadedScene;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            var handle = SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == scene.Name);

            return scene.CreateLoadResult(targetScene);
        }
    }
}