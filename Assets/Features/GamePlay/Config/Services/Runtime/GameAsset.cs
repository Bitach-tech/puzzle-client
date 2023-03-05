using Common.Local.ComposedSceneConfig;
using Common.Local.Services.Abstract;
using GamePlay.Background.Runtime;
using GamePlay.Common.Paths;
using GamePlay.Common.Scope;
using GamePlay.Level.Assemble.Runtime;
using GamePlay.Level.ImageStorage.Runtime;
using GamePlay.Level.UI.Overlay.Runtime;
using GamePlay.Level.UI.Root.Runtime;
using GamePlay.Level.UI.Win.Runtime;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Menu.Runtime;
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
        [SerializeField] private PuzzleAssemblerAsset _assembler;
        [SerializeField] private ImageStorageAsset _imageStorage;
        [SerializeField] private LevelOverlayAsset _levelOverlay;
        [SerializeField] private LevelUiRootAsset _uiRootAsset;
        [SerializeField] private WinScreenAsset _winScreenAsset;

        [SerializeField] private LevelScope _scopePrefab;

        protected override ILocalServiceFactory[] GetFactories()
        {
            var services = new ILocalServiceFactory[]
            {
                _levelCamera,
                _levelLoop,
                _imageStorage,
                _uiRootAsset
            };

            return services;
        }

        protected override ILocalServiceAsyncFactory[] GetAsyncFactories()
        {
            var services = new ILocalServiceAsyncFactory[]
            {
                _menuUi,
                _background,
                _assembler,
                _levelOverlay,
                _winScreenAsset
            };

            return services;
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}