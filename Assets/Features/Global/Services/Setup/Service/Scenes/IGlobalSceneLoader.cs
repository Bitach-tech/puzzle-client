using Cysharp.Threading.Tasks;

namespace Global.Setup.Service.Scenes
{
    public interface IGlobalSceneLoader
    {
        UniTask<InternalSceneLoadResult<T>> LoadAsync<T>(InternalScene<T> scene);
    }
}