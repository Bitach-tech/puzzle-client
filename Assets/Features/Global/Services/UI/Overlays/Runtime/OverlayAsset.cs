using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.UI.Overlays.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Overlays.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = OverlayRouter.ServiceName,
        menuName = OverlayRouter.ServicePath)]
    public class OverlayAsset : ScriptableObject, IGlobalServiceAsyncFactory
    {
        [SerializeField] [Scene] private string _scene;

        public async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var data = new InternalScene<OverlayBootstrapper>(_scene);
            var result = await sceneLoader.LoadAsync(data);

            var bootstrapper = result.Searched;

            foreach (var listener in bootstrapper.EventListeners)
                callbacks.Listen(listener);
        }
    }
}