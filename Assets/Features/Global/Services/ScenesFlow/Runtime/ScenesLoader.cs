using Cysharp.Threading.Tasks;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Handling.Result;
using Global.Services.ScenesFlow.Logs;
using Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Global.Services.ScenesFlow.Runtime
{
    public class ScenesLoader : MonoBehaviour, ISceneLoader
    {
        [Inject]
        private void Construct(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private ScenesFlowLogger _logger;

        public async UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult
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

            Debug.Log($"Load scene: {scene.Name}");

            var handle = SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == scene.Name);

            _logger.OnSceneLoad(targetScene);

            return scene.CreateLoadResult(targetScene);
        }
    }
}