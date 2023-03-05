using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Result;

namespace Global.Scenes.ScenesFlow.Runtime.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(SceneLoadResult result);

        UniTask Unload(IReadOnlyList<SceneLoadResult> scenes);
    }
}