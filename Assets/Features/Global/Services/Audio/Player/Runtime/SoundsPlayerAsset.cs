using Common.DiContainer.Abstract;
using Global.Audio.Player.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ServiceName,
        menuName = AudioRoutes.ServicePath)]
    public class SoundsPlayerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private SoundState _state;
        [SerializeField] private SoundsPlayer _prefab;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var player = Instantiate(_prefab);
            player.name = "SoundsPlayer";

            var trigger = player.GetComponent<SoundsTrigger>();
            var switcher = player.GetComponent<SoundsVolumeSwitcher>();

            builder.RegisterInstance(_state);
            
            builder.RegisterComponent(player)
                .As<IVolumeSwitcher>()
                .AsCallbackListener();

            builder.RegisterComponent(switcher)
                .AsCallbackListener();

            callbacks.Listen(trigger);
            serviceBinder.AddToModules(player);
        }
    }
}