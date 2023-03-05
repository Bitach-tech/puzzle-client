using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service.Scenes;

namespace Global.Setup.Service
{
    public interface IGlobalServiceAsyncFactory
    {
        public UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks);
    }
}