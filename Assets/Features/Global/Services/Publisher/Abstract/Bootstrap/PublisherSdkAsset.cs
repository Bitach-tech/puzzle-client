using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using UnityEngine;

namespace Global.Publisher.Abstract.Bootstrap
{
    public abstract class PublisherSdkAsset : ScriptableObject, IGlobalServiceAsyncFactory
    {
        public abstract UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks);
    }
}