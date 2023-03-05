using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Runtime.Abstract;

namespace Common.Local.Services.Abstract
{
    public interface ILocalServiceAsyncFactory
    {
        public UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks);
    }
}