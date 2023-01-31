using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Menu.Runtime;
using GamePlay.Puzzle.Assemble.Runtime;
using GamePlay.Puzzle.UiLoop.Runtime;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Events;
using GamePlay.Services.LevelLoops.Logs;
using Global.Services.CurrentCameras.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelLoops.Runtime
{
    [DisallowMultipleComponent]
    public class LevelLoop :
        MonoBehaviour,
        ILocalLoadListener,
        ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            ILevelCamera levelCamera,
            IMenuUI menuUI,
            IPuzzleUiLoop puzzleUiLoop,
            IAds ads,
            IPuzzleAssembler assembler,
            LevelLoopLogger logger)
        {
            _assembler = assembler;
            _puzzleUiLoop = puzzleUiLoop;
            _ads = ads;
            _menuUI = menuUI;
            _logger = logger;
            _currentCamera = currentCamera;
            _levelCamera = levelCamera;
        }

        private IAds _ads;

        private ICurrentCamera _currentCamera;
        private ILevelCamera _levelCamera;

        private LevelLoopLogger _logger;

        private IMenuUI _menuUI;

        private IDisposable _playClickListener;
        private IDisposable _menuClickListener;
        private IPuzzleUiLoop _puzzleUiLoop;
        private IPuzzleAssembler _assembler;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _playClickListener = Msg.Listen<PlayClickEvent>(OnPlayClicked);
            _menuClickListener = Msg.Listen<MenuRequestEvent>(OnMenuClicked);
        }

        public void OnDisabled()
        {
            _playClickListener?.Dispose();
            _menuClickListener?.Dispose();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            _assembler.Begin(data.Image);
            _puzzleUiLoop.Open();
        }

        private void OnMenuClicked(MenuRequestEvent data)
        {
            _ads.ShowInterstitial();
            _assembler.Cancel();
            _menuUI.Open();
        }
    }
}