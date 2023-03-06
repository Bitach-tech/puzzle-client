using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Assemble.Runtime.Borders;
using GamePlay.Level.Assemble.Runtime.Parts;
using GamePlay.Level.Assemble.Runtime.Targets;
using Global.Inputs.View.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.Handler
{
    public class PickHandler : IUpdatable
    {
        public PickHandler(
            IInputView inputView,
            ITargetsStorage targets,
            IUpdater updater,
            IPartsStorage parts,
            IPuzzleBorders borders,
            PickHandlerConfigAsset config)
        {
            _parts = parts;
            _borders = borders;
            _inputView = inputView;
            _targets = targets;
            _updater = updater;
            _config = config;
        }

        private readonly IInputView _inputView;
        private readonly ITargetsStorage _targets;
        private readonly IUpdater _updater;
        private readonly IPartsStorage _parts;
        private readonly IPuzzleBorders _borders;
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
                part.Lock();
            }

            _updater.Remove(this);
        }

        public void Cancel()
        {
            _completion?.TrySetCanceled();
        }

        public void OnUpdate(float delta)
        {
            var world = _inputView.ScreenToWorld();
            world = _borders.Clamp(world);
            
            _current.SetPosition(world);
            
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