using Global.Audio.Player.Runtime;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.Debugs.Console.Runtime;
using Global.Inputs.View.Runtime;
using Global.Publisher.Abstract.Bootstrap;
using Global.Scenes.CurrentSceneHandlers.Runtime;
using Global.Scenes.ScenesFlow.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Service;
using Global.System.ApplicationProxies.Runtime;
using Global.System.Loggers.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.Pauses.Runtime;
using Global.System.ResourcesCleaners.Runtime;
using Global.System.Updaters.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using LocalizationAsset = Global.UI.Localizations.Runtime.LocalizationAsset;

namespace Global.Setup.Implementation
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Global/Config")]
    public class GlobalServicesConfigAsset : GlobalServicesConfig
    {
        [FoldoutGroup("Audio")] [SerializeField]
        private SoundsPlayerAsset _soundsPlayer;

        [FoldoutGroup("Camera")] [SerializeField]
        private CameraUtilsAsset _cameraUtils;
        [FoldoutGroup("Camera")] [SerializeField]
        private CurrentCameraAsset _currentCamera;
        [FoldoutGroup("Camera")] [SerializeField]
        private GlobalCameraAsset _globalCamera;

        [FoldoutGroup("Debugs")] [SerializeField]
        private DebugConsoleAsset _debugConsole;

        [FoldoutGroup("Input")] [SerializeField]
        private InputViewAsset _inputView;

        [FoldoutGroup("Publisher")] [SerializeField]
        private PublisherSdkAsset _publisherSdk;

        [FoldoutGroup("Scenes")] [SerializeField]
        private CurrentSceneHandlerAsset _currentSceneHandler;
        [FoldoutGroup("Scenes")] [SerializeField]
        private ScenesFlowAsset _scenesFlow;

        [FoldoutGroup("System")] [SerializeField]
        private ApplicationProxyAsset _applicationProxy;
        [FoldoutGroup("System")] [SerializeField]
        private LoggerAsset _logger;
        [FoldoutGroup("System")] [SerializeField]
        private MessageBrokerAsset _messageBroker;
        [FoldoutGroup("System")] [SerializeField]
        private PauseAsset _pause;
        [FoldoutGroup("System")] [SerializeField]
        private ResourcesCleanerAsset _resourcesCleaner;
        [FoldoutGroup("System")] [SerializeField]
        private UpdaterAsset _updater;

        [FoldoutGroup("UI")] [SerializeField] private LoadingScreenAsset _loadingScreen;
        [FoldoutGroup("UI")] [SerializeField] private LocalizationAsset _localization;
        [FoldoutGroup("UI")] [SerializeField] private OverlayAsset _overlay;
        [FoldoutGroup("UI")] [SerializeField] private UiStateMachineAsset _uiStateMachine;

        public override IGlobalServiceFactory[] GetFactories()
        {
            return new IGlobalServiceFactory[]
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _currentSceneHandler,
                _globalCamera,
                _inputView,
                _logger,
                _resourcesCleaner,
                _scenesFlow,
                _updater,
                _debugConsole,
                _messageBroker,
                _uiStateMachine,
                _soundsPlayer,
                _localization,
                _pause
            };
        }

        public override IGlobalServiceAsyncFactory[] GetAsyncFactories()
        {
            return new IGlobalServiceAsyncFactory[]
            {
                _loadingScreen,
                _overlay,
                _publisherSdk,
            };
        }
    }
}