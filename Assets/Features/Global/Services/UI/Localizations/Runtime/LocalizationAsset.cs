using Common.DiContainer.Abstract;
using Global.Setup.Service;
using Global.UI.Localizations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.ServiceName, menuName = LocalizationRoutes.ServicePath)]
    public class LocalizationAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private LocalizationStorage _storage;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Localization>()
                .WithParameter<ILocalizationStorage>(_storage)
                .AsCallbackListener();
        }
    }
}