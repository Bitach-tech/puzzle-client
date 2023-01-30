using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Common.Abstract;
using Global.Services.Common.Abstract.Scenes;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Overlays.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "Overlay",
        menuName = GlobalAssetsPaths.Overlay + "Service")]
    public class OverlayAsset : GlobalServiceAsset
    {
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var data = new InternalScene<OverlayBootstrapper>(_scene);
            var result = await sceneLoader.Load(data);

            var bootstrapper = result.Searched;

            foreach (var listener in bootstrapper.EventListeners)
                callbacks.Listen(listener);
        }
    }
}