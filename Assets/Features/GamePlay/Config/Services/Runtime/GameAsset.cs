using System.Collections.Generic;
using Common.Local.ComposedSceneConfig;
using Common.Local.Services.Abstract;
using Features.GamePlay.Puzzle.Assemble.Runtime;
using GamePlay.Common.Paths;
using GamePlay.Menu.Runtime;
using GamePlay.Puzzle.ImageStorage.Runtime;
using GamePlay.Puzzle.Loop.Runtime;
using GamePlay.Puzzle.Overlay.Runtime;
using GamePlay.Services.Background.Runtime;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Services.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class GameAsset : ComposedSceneAsset
    {
        [SerializeField] private LevelCameraAsset _levelCamera;
        [SerializeField] private LevelLoopAsset _levelLoop;
        [SerializeField] private MenuUIAsset _menuUi;
        [SerializeField] private GameBackgroundAsset _background;
        [SerializeField] private LevelOverlayAsset _levelOverlay;
        [SerializeField] private ImageStorageAsset _imageStorage;
        [SerializeField] private PuzzleLoopAsset _puzzleLoop;
        [SerializeField] private PuzzleAssemblerAsset _assembler;

        [SerializeField] private LevelScope _scopePrefab;

        protected override LocalServiceAsset[] AssignServices()
        {
            var list = new List<LocalServiceAsset>
            {
                _levelCamera,
                _levelLoop,
                _menuUi,
                _background,
                _levelOverlay,
                _imageStorage,
                _puzzleLoop,
                _assembler
            };

            return list.ToArray();
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}