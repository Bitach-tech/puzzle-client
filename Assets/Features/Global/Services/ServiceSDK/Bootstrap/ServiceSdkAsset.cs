using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Common.Abstract;
using Global.Services.Common.Abstract.Scenes;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using Global.Services.ServiceSDK.Authentications.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.ServiceSDK.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "ServiceSDK",
        menuName = GlobalAssetsPaths.ServiceSDK + "Service")]
    public class ServiceSdkAsset : GlobalServiceAsset
    {
        [SerializeField] private Ads _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var ads = Instantiate(_prefab);
            ads.name = "ServiceSDK";

            var auth = ads.GetComponent<Authentication>();

            builder.RegisterComponent(ads)
                .As<IAds>();

            builder.RegisterComponent(auth)
                .As<IAuthentication>();

            serviceBinder.AddToModules(ads);
        }
    }
}