using Common.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Puzzle.Assemble.Runtime.Background;
using GamePlay.Puzzle.Assemble.Runtime.Handler;
using GamePlay.Puzzle.Assemble.Runtime.Parts;
using GamePlay.Puzzle.Assemble.Runtime.StartPositions;
using GamePlay.Puzzle.Assemble.Runtime.Targets;
using GamePlay.Puzzle.ImageStorage.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Puzzle.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzleAssembler : MonoBehaviour, IPuzzleAssembler, ILocalAwakeListener
    {
        [Inject]
        private void Construct(
            IPartsStorage parts,
            ITargetsStorage targets,
            IRandomStartPositions positions,
            IPuzzleBackground background,
            PartPicker picker,
            PickHandler handler)
        {
            _background = background;
            _targets = targets;
            _handler = handler;
            _picker = picker;
            _positions = positions;
            _parts = parts;
        }

        private const int _beginDelay = 1500;

        private IPartsStorage _parts;
        private ITargetsStorage _targets;
        private IRandomStartPositions _positions;

        private UniTask _current;
        private PartPicker _picker;
        private PickHandler _handler;
        private IPuzzleBackground _background;

        public void OnAwake()
        {
            _parts.OnReset();
            _background.Disable();
            
            foreach (var part in _parts.Available)
                part.Disable();
        }
        
        public void Begin(PuzzleImage image)
        {
            _parts.OnReset();
            _targets.OnReset();

            for (var i = 0; i < image.Images.Length; i++)
                _parts.Available[i].ToStart(image.Images[i]);
            
            _background.Enable(image.Background);

            _current = Assemble();
        }

        public void Cancel()
        {
            _background.Disable();
            _parts.OnReset();
            
            foreach (var part in _parts.Available)
                part.Disable();
            
            _current.SuppressCancellationThrow();
        }

        private async UniTask Assemble()
        {
            await UniTask.Delay(_beginDelay);
            
            foreach (var part in _parts.Available)
                part.MoveToStart(_positions.GetRandom());
            
            while (_parts.Available.Count != 0)
            {
                var pickedPart = await _picker.Pick();

                await _handler.OnPicked(pickedPart);
            }
        }
    }
}