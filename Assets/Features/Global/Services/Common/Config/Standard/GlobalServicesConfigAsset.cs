using Global.Common;
using Global.Services.ApplicationProxies.Runtime;
using Global.Services.CameraUtilities.Runtime;
using Global.Services.Common.Abstract;
using Global.Services.Common.Config.Abstract;
using Global.Services.CurrentCameras.Runtime;
using Global.Services.CurrentSceneHandlers.Runtime;
using Global.Services.DebugConsoles.Runtime;
using Global.Services.GlobalCameras.Runtime;
using Global.Services.InputViews.Runtime;
using Global.Services.LoadingScreens.Runtime;
using Global.Services.Loggers.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.Overlays.Runtime;
using Global.Services.ResourcesCleaners.Runtime;
using Global.Services.ScenesFlow.Runtime;
using Global.Services.ServiceSDK.Bootstrap;
using Global.Services.SoundsPlayers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using Global.Services.Updaters.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Common.Config.Standard
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.BootstrapPrefix + "Services",
        menuName = GlobalAssetsPaths.BootstrapConfig)]
    public class GlobalServicesConfigAsset : GlobalServicesConfig
    {
        [SerializeField] private ApplicationProxyAsset _applicationProxy;
        [SerializeField] private CameraUtilsAsset _cameraUtils;
        [SerializeField] private CurrentCameraAsset _currentCamera;
        [SerializeField] private CurrentSceneHandlerAsset _currentSceneHandler;
        [SerializeField] private GlobalCameraAsset _globalCamera;
        [SerializeField] private InputViewAsset _inputView;
        [SerializeField] private LoadingScreenAsset _loadingScreen;
        [SerializeField] private LoggerAsset _logger;
        [SerializeField] private ResourcesCleanerAsset _resourcesCleaner;
        [SerializeField] private ScenesFlowAsset _scenesFlow;
        [SerializeField] private UpdaterAsset _updater;
        [SerializeField] private DebugConsoleAsset _debugConsole;
        [SerializeField] private MessageBrokerAsset _messageBroker;
        [SerializeField] private UiStateMachineAsset _uiStateMachine;
        [SerializeField] private SoundsPlayerAsset _soundsPlayer;
        [SerializeField] private OverlayAsset _overlay;
        [SerializeField] private ServiceSdkAsset _serviceSdk;

        public override GlobalServiceAsset[] GetAssets()
        {
            return new GlobalServiceAsset[]
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _currentSceneHandler,
                _globalCamera,
                _inputView,
                _loadingScreen,
                _logger,
                _resourcesCleaner,
                _scenesFlow,
                _updater,
                _debugConsole,
                _messageBroker,
                _uiStateMachine,
                _soundsPlayer,
                _overlay,
                _serviceSdk
            };
        }
    }
}