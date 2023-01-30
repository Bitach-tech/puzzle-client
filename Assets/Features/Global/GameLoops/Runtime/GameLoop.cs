using Common.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Services.Runtime;
using Global.GameLoops.Abstract;
using Global.GameLoops.Logs;
using Global.Services.Common.Scope;
using Global.Services.CurrentCameras.Runtime;
using Global.Services.CurrentSceneHandlers.Runtime;
using Global.Services.GlobalCameras.Runtime;
using Global.Services.LoadingScreens.Runtime;
using Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : GlobalGameLoop
    {
        [Inject]
        private void Construct(
            GlobalScope scope,
            ISceneLoader loader,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ICurrentSceneHandler currentSceneHandler,
            ICurrentCamera currentCamera,
            GameLoopLogger logger)
        {
            _logger = logger;
            _scope = scope;
            _loader = loader;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _currentSceneHandler = currentSceneHandler;
            _currentCamera = currentCamera;
        }

        [SerializeField] private GameAsset _game;

        private ICurrentCamera _currentCamera;
        private ICurrentSceneHandler _currentSceneHandler;
        private IGlobalCamera _globalCamera;

        private ISceneLoader _loader;
        private ILoadingScreen _loadingScreen;

        private GameLoopLogger _logger;

        private GlobalScope _scope;

        public override void OnAwake()
        {
        }

        public override void Begin()
        {
            _logger.OnLoadLevel();
            Debug.Log(1);
            LoadScene(_game).Forget();
        }

        private async UniTaskVoid LoadScene(ComposedSceneAsset asset)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var unload = _currentSceneHandler.Unload();
            var result = await asset.Load(_scope, _loader);

            await unload;
            await _currentSceneHandler.FinalizeUnloading();

            _currentSceneHandler.OnLoaded(result);
            _globalCamera.Disable();
            _loadingScreen.Hide();

            result.OnLoaded();
        }
    }
}