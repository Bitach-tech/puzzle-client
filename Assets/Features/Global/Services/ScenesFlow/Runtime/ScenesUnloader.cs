using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Services.ScenesFlow.Handling.Result;
using Global.Services.ScenesFlow.Logs;
using Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Global.Services.ScenesFlow.Runtime
{
    public class ScenesUnloader : MonoBehaviour, ISceneUnloader
    {
        [Inject]
        private void Construct(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private ScenesFlowLogger _logger;

        public async UniTask Unload(SceneLoadResult result)
        {
            if (result == null)
                return;

            _logger.OnSceneUnload(result.Scene);

            var task = SceneManager.UnloadSceneAsync(result.Scene);

            await task.ToUniTask();
        }

        public async UniTask Unload(IReadOnlyList<SceneLoadResult> scenes)
        {
            if (scenes == null || scenes.Count == 0)
                return;

            var tasks = new UniTask[scenes.Count];

            foreach (var scene in scenes)
                _logger.OnSceneUnload(scene.Scene);

            for (var i = 0; i < scenes.Count; i++)
                tasks[i] = SceneManager.UnloadSceneAsync(scenes[i].Scene).ToUniTask();

            await UniTask.WhenAll(tasks);
        }
    }
}