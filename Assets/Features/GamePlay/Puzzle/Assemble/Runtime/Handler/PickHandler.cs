using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Puzzle.Assemble.Runtime.Parts;
using GamePlay.Puzzle.Assemble.Runtime.Targets;
using Global.Services.InputViews.Runtime;
using Global.Services.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Puzzle.Assemble.Runtime.Handler
{
    public class PickHandler : IUpdatable
    {
        public PickHandler(
            IInputView inputView,
            ITargetsStorage targets,
            IUpdater updater,
            IPartsStorage parts,
            PickHandlerConfigAsset config)
        {
            _parts = parts;
            _inputView = inputView;
            _targets = targets;
            _updater = updater;
            _config = config;
        }

        private readonly IInputView _inputView;
        private readonly ITargetsStorage _targets;
        private readonly IUpdater _updater;
        private readonly IPartsStorage _parts;
        private readonly PickHandlerConfigAsset _config;

        private UniTaskCompletionSource<PuzzleTarget> _completion;

        private PuzzlePart _current;

        public async UniTask OnPicked(PuzzlePart part)
        {
            _current = part;
            _updater.Add(this);
            _completion = new UniTaskCompletionSource<PuzzleTarget>();

            var target = await _completion.Task;

            if (target != null)
            {
                _parts.OnLocked(_current);
                _targets.OnTaken(target);
                part.Lock(target.Position);
            }

            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            _current.SetPosition(_inputView.ScreenToWorld());
            
            if (_inputView.IsLeftMouseButtonPressed == true)
                return;

            var targets = new List<SearchedTarget>();

            foreach (var target in _targets.Available)
            {
                var distance = Vector2.Distance(_current.Position, target.Position);

                targets.Add(new SearchedTarget(target, distance));
            }

            var nearest = targets[0];

            for (var i = 1; i < targets.Count; i++)
            {
                if (targets[i].Distance >= nearest.Distance)
                    continue;

                nearest = targets[i];
            }

            if (nearest.Distance > _config.DropDistance)
            {
                _completion.TrySetResult(null);
                return;
            }
            
            if (nearest.Part.Id != _current.Id)
            {
                _completion.TrySetResult(null);
                return;
            }

            _completion.TrySetResult(nearest.Part);
        }
    }
}