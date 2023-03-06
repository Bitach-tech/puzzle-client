using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime.Parts
{
    public class PartsStorage : MonoBehaviour, IPartsStorage
    {
        [SerializeField] private PuzzlePart[] _all;
        
        private readonly List<PuzzlePart> _available = new();

        public IReadOnlyList<PuzzlePart> Available => _available;
        public IReadOnlyList<PuzzlePart> All => _all;

        public void Add(PuzzlePart part)
        {
            _available.Add(part);
        }

        public void OnLocked(PuzzlePart part)
        {
            _available.Remove(part);
        }

        public void OnReset()
        {
            _available.Clear();
            
            _available.AddRange(_all);
        }
    }
}