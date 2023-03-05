using System;
using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Level.Assemble.Runtime;
using GamePlay.Level.ImageStorage.Runtime;
using GamePlay.Level.UI.Root.Runtime;
using GamePlay.Level.UI.Win.Runtime;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Events;
using GamePlay.Loop.Logs;
using GamePlay.Menu.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Publisher.Abstract.Advertisment;
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
            IImageStorage imageStorage,
            LevelLoopLogger logger,
            int imagesCount)
        {
            _imagesCount = imagesCount;
            _ads = ads;
            _assembler = assembler;
            _winScreen = winScreen;
            _imageStorage = imageStorage;
            _menuUI = menuUI;
            _levelUiRoot = levelUiRoot;
            _logger = logger;
            _currentCamera = currentCamera;
            _levelCamera = levelCamera;
        }

        private readonly IAds _ads;
        private readonly IAssembler _assembler;
        private readonly IWinScreen _winScreen;
        private readonly IImageStorage _imageStorage;

        private readonly ICurrentCamera _currentCamera;
        private readonly ILevelCamera _levelCamera;

        private readonly LevelLoopLogger _logger;

        private readonly IMenuUI _menuUI;
        private readonly ILevelUiRoot _levelUiRoot;

        private readonly int _imagesCount;

        private IDisposable _assembleListener;
        private IDisposable _playClickListener;
        private IDisposable _menuClickListener;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _assembleListener = Msg.Listen<AssembledEvent>(OnAssembled);
            _playClickListener = Msg.Listen<PlayClickEvent>(OnPlayClicked);
            _menuClickListener = Msg.Listen<MenuRequestEvent>(OnMenuClicked);
        }

        public void OnDisabled()
        {
            _assembleListener?.Dispose();
            _playClickListener?.Dispose();
            _menuClickListener?.Dispose();
        }

        private void OnAssembled(AssembledEvent data)
        {
            _winScreen.Open();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            // _levelUiRoot.Open();
            // _assembler.Stop();
            // _ads.ShowInterstitial();
            //
            // var storedImages = _imageStorage.GetShuffledImages();
            // var images = new List<LevelImage>();
            //
            // var counter = 0;
            //
            // while (counter < _imagesCount && counter < storedImages.Count)
            // {
            //     images.Add(storedImages[counter]);
            //     counter++;
            // }
            //
            // _assembler.Begin(images.ToArray(), data.Difficulty);
        }

        private void OnMenuClicked(MenuRequestEvent data)
        {
            //_assembler.Stop();
            _menuUI.Open();
        }
    }
}