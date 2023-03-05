using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Handling.Result;

namespace Global.Scenes.ScenesFlow.Runtime.Abstract
{
    public interface ISceneLoader
    {
        UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult;
    }
}