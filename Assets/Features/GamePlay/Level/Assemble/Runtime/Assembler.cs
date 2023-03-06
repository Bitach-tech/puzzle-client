using System;
using System.Threading;
using Common.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Assemble.Runtime.Background;
using GamePlay.Level.Assemble.Runtime.Handler;
using GamePlay.Level.Assemble.Runtime.Parts;
using GamePlay.Level.Assemble.Runtime.StartPositions;
using GamePlay.Level.Assemble.Runtime.Targets;
using GamePlay.Level.ImageStorage.Runtime;
using Global.Publisher.Abstract.Advertisment;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class Assembler : MonoBehaviour, IAssembler, ILocalAwakeListener, ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            IPartsStorage parts,
            ITargetsStorage targets,
            IRandomStartPositions positions,
            IPuzzleBackground background,
            IAds ads,
            PartPicker picker,
            PickHandler handler)
        {
            _ads = ads;
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

        private PartPicker _picker;
        private PickHandler _handler;
        private IPuzzleBackground _background;
        private LevelImage _image;

        private CancellationTokenSource _cancellation;

        private IDisposable _tipRequestListener;
        private IAds _ads;

        public void OnAwake()
        {
            _parts.OnReset();
            _background.Disable();

            foreach (var part in _parts.Available)
                part.Disable();
        }

        public void OnEnabled()
        {
            _tipRequestListener = Msg.Listen<TipRequestEvent>(OnTipRequested);
        }

        public void OnDisabled()
        {
            _tipRequestListener?.Dispose();
        }

        public void AssemblePreview(LevelImage image)
        {
            _image = image;
            _parts.OnReset();
            _targets.OnReset();

            for (var i = 0; i < image.Images.Length; i++)
                _parts.Available[i].ToStart(image.Images[i]);

            _background.Enable(image.Background);
        }

        public void AssembleCurrent()
        {
            AssemblePreview(_image);
        }

        public void Begin()
        {
            _cancellation = new CancellationTokenSource();
            Assemble().Forget();
        }

        public void Cancel()
        {
            _background.Disable();
            _parts.OnReset();
            _picker.Cancel();
            _handler.Cancel();
            
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;

            foreach (var part in _parts.All)
                part.Disable();
        }

        private async UniTask Assemble()
        {
            await UniTask.Delay(_beginDelay, DelayType.DeltaTime, PlayerLoopTiming.Update, _cancellation.Token);

            foreach (var part in _parts.Available)
                part.MoveToStart(_positions.GetRandom());

            while (_parts.Available.Count != 0)
            {
                var pickedPart = await _picker.Pick();

                await _handler.OnPicked(pickedPart);
            }

            Msg.Publish(new AssembledEvent(_image));
        }

        private void OnTipRequested(TipRequestEvent data)
        {
            if (_parts.Available.Count == 0)
                return;

            ProcessTip().Forget();
        }

        private async UniTask ProcessTip()
        {
            var assembledCount = 3;

            if (_parts.Available.Count < 3)
                assembledCount = _parts.Available.Count;

            await _ads.ShowRewarded();

            for (var i = 0; i < assembledCount; i++)
            {
                var random = Random.Range(0, _parts.Available.Count);
                var part = _parts.Available[random];

                part.MoveToTarget();
                _parts.OnLocked(part);
                _targets.OnTaken(part.Id);
            }

            if (_parts.Available.Count == 0)
                Msg.Publish(new AssembledEvent(_image));
        }
        
        // private void Update()
        // {
        //     if (Input.GetKey(KeyCode.A) == false)
        //         return;
        //     
        //     var assembledCount = 3;
        //
        //     if (_parts.Available.Count < 3)
        //         assembledCount = _parts.Available.Count;
        //
        //     for (var i = 0; i < assembledCount; i++)
        //     {
        //         var random = Random.Range(0, _parts.Available.Count);
        //         var part = _parts.Available[random];
        //
        //         Debug.Log(part.transform.parent.name);
        //         part.MoveToTarget();
        //         _parts.OnLocked(part);
        //         _targets.OnTaken(part.Id);
        //     }
        //
        //     if (_parts.Available.Count == 0)
        //         Msg.Publish(new AssembledEvent(_image));
        // }
    }
}