using Common.Local.Services.Abstract.Callbacks;
using Global.Services.Updaters.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.Background.Runtime
{
    public class GameBackground : MonoBehaviour, IUpdatable, ILocalAwakeListener, IGameBackground
    {
        [Inject]
        private void Construct(IUpdater updater)
        {
            _updater = updater;
        }

        [SerializeField] private RectTransform _start;
        [SerializeField] private RectTransform _target;
        [SerializeField] private RectTransform _linesRoot;

        [SerializeField] private LineView _linePrefab;

        [SerializeField] private GameBackgroundConfigAsset _config;

        private CellLine[] _lines;

        private IUpdater _updater;

        public void OnAwake()
        {
            _updater.Add(this);

            var linesFactory = new CellLineFactory(_linePrefab, _linesRoot, _config);

            _lines = linesFactory.Create(_start, _target);
        }

        public void OnUpdate(float delta)
        {
            foreach (var line in _lines)
                line.Update(delta);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}