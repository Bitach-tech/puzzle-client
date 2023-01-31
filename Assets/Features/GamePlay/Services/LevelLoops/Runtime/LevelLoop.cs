using System;
using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Menu.Runtime;
using GamePlay.Puzzle.Assemble.Runtime;
using GamePlay.Puzzle.ImageStorage.Runtime;
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
        private IDisposable _restartClickListener;
        private IDisposable _assembledListener;
        private IPuzzleUiLoop _puzzleUiLoop;
        private IPuzzleAssembler _assembler;

        private readonly List<PuzzleImage> _assembled = new();

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
            _restartClickListener = Msg.Listen<RestartRequestEvent>(OnRestartClicked);
            _assembledListener = Msg.Listen<AssembledEvent>(OnAssembled);
        }

        public void OnDisabled()
        {
            _playClickListener?.Dispose();
            _menuClickListener?.Dispose();
            _restartClickListener?.Dispose();
            _assembledListener?.Dispose();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            _assembler.AssemblePreview(data.Image);
            _puzzleUiLoop.Open();

            if (_assembled.Contains(data.Image) == true)
                _puzzleUiLoop.ShowAssembledScreen();
            else
                _assembler.Begin();
        }

        private void OnMenuClicked(MenuRequestEvent data)
        {
            _ads.ShowInterstitial();
            _assembler.Cancel();
            _menuUI.Open();
        }

        private void OnRestartClicked(RestartRequestEvent data)
        {
            _puzzleUiLoop.HideAssembledScreen();
            _assembler.Cancel();
            _assembler.AssembleCurrent();
            _assembler.Begin();
        }

        private void OnAssembled(AssembledEvent data)
        {
            _puzzleUiLoop.ShowAssembledScreen();
            _assembled.Add(data.Image);
        }
    }
}