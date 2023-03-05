using Cysharp.Threading.Tasks;
using GamePlay.Level.Assemble.Runtime.Parts;

namespace GamePlay.Level.Assemble.Runtime
{
    public class PartPicker
    {
        public PartPicker(IPartsStorage storage)
        {
            _storage = storage;
        }
        
        private readonly IPartsStorage _storage;

        private UniTaskCompletionSource<PuzzlePart> _completion;

        public async UniTask<PuzzlePart> Pick()
        {
            _completion = new UniTaskCompletionSource<PuzzlePart>();
            
            foreach (var part in _storage.Available)
                part.Clicked += OnClicked;
            
            var picked = await _completion.Task;
            
            foreach (var part in _storage.Available)
                part.Clicked -= OnClicked;

            return picked;
        }

        public void Cancel()
        {
            _completion?.TrySetCanceled();
        }

        private void OnClicked(PuzzlePart part)
        {
            _completion.TrySetResult(part);
        }
    }
}