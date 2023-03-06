using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Level.Assemble.Runtime;
using GamePlay.Level.UI.Root.Runtime;
using GamePlay.Level.UI.Win.Runtime;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Events;
using GamePlay.Loop.Logs;
using GamePlay.Menu.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Saves;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop :
        ILocalLoadListener,
        ILocalSwitchListener
    {
        public LevelLoop(
            ICurrentCamera currentCamera,
            ILevelCamera levelCamera,
            IMenuUI menuUI,
            ILevelUiRoot levelUiRoot,
            IAds ads,
            IAssembler assembler,
            IWinScreen winScreen,
            IDataStorage dataStorage,
            LevelLoopLogger logger)
        {
            _ads = ads;
            _assembler = assembler;
            _winScreen = winScreen;
            _dataStorage = dataStorage;
            _menuUI = menuUI;
            _levelUiRoot = levelUiRoot;
            _logger = logger;
            _currentCamera = currentCamera;
            _levelCamera = levelCamera;
        }

        private readonly IAds _ads;
        private readonly IAssembler _assembler;
        private readonly IWinScreen _winScreen;
        private readonly IDataStorage _dataStorage;

        private readonly ICurrentCamera _currentCamera;
        private readonly ILevelCamera _levelCamera;

        private readonly LevelLoopLogger _logger;

        private readonly IMenuUI _menuUI;
        private readonly ILevelUiRoot _levelUiRoot;

        private IDisposable _assembleListener;
        private IDisposable _playListener;
        private IDisposable _menuListener;
        private IDisposable _replayListener;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _assembleListener = Msg.Listen<AssembledEvent>(OnAssembled);
            _playListener = Msg.Listen<PlayRequestEvent>(OnPlayRequested);
            _menuListener = Msg.Listen<MenuRequestEvent>(OnMenuRequested);
            _replayListener = Msg.Listen<ReplayRequestEvent>(OnReplayRequested);
        }

        public void OnDisabled()
        {
            _assembleListener?.Dispose();
            _playListener?.Dispose();
            _menuListener?.Dispose();
            _replayListener?.Dispose();
        }

        private void OnAssembled(AssembledEvent data)
        {
            _winScreen.Open();
            var save = _dataStorage.GetLevels();
            save.OnAssembled(data.Image.Index);
        }

        private void OnPlayRequested(PlayRequestEvent data)
        {
            _assembler.Cancel();
            _levelUiRoot.Open();

            var save = _dataStorage.GetLevels();

            _assembler.AssemblePreview(data.Image);

            if (save.IsAssembled(data.Image.Index) == false)
            {
                _ads.ShowInterstitial();
                _assembler.Begin();
            }
            else
            {
                _winScreen.Open();
            }
        }

        private void OnReplayRequested(ReplayRequestEvent data)
        {
            _assembler.Cancel();
            _assembler.AssembleCurrent();
            _assembler.Begin();
            _winScreen.Close();
        }

        private void OnMenuRequested(MenuRequestEvent data)
        {
            _assembler.Cancel();
            _menuUI.Open();
        }
    }
}