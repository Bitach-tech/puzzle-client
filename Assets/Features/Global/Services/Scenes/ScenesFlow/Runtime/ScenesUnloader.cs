using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Result;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Runtime
{
    public class ScenesUnloader : ISceneUnloader
    {
        public ScenesUnloader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

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