using Global.Common;
using Global.GameLoops.Logs;
using Global.Services.ApplicationProxies.Logs;
using Global.Services.CameraUtilities.Logs;
using Global.Services.CurrentCameras.Logs;
using Global.Services.CurrentSceneHandlers.Logs;
using Global.Services.GlobalCameras.Logs;
using Global.Services.InputViews.Logs;
using Global.Services.LoadingScreens.Logs;
using Global.Services.MessageBrokers.Logs;
using Global.Services.ResourcesCleaners.Logs;
using Global.Services.ScenesFlow.Logs;
using Global.Services.UiStateMachines.Logs;
using Global.Services.Updaters.Logs;
using UnityEngine;

namespace Global.Services.Loggers.Editor
{
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ConfigPrefix + "Logs",
        menuName = GlobalAssetsPaths.Config + "Logs", order = 1)]
    public class GlobalLogsConfig : ScriptableObject
    {
        [SerializeField] private ApplicationProxyLogSettings _applicationProxy;
        [SerializeField] private CameraUtilsLogSettings _cameraUtils;
        [SerializeField] private CurrentCameraLogSettings _currentCamera;
        [SerializeField] private CurrentSceneHandlerLogSettings _currentSceneHandler;
        [SerializeField] private GlobalCameraLogSettings _globalCamera;
        [SerializeField] private InputViewLogSettings _inputView;
        [SerializeField] private LoadingScreenLogSettings _loadingScreen;
        [SerializeField] private ResourcesCleanerLogSettings _resourcesCleaner;
        [SerializeField] private ScenesFlowLogSettings _scenesFlow;
        [SerializeField] private UiStateMachineLogSettings _uiStateMachine;
        [SerializeField] private UpdaterLogSettings _updater;
        [SerializeField] private GameLoopLogSettings _gameLoop;
        [SerializeField] private MessageBrokerLogSettings _messageBroker;
    }
}