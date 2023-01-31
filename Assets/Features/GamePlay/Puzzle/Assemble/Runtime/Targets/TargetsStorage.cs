using System;
using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using UnityEngine;

namespace GamePlay.Puzzle.Assemble.Runtime.Targets
{
    [DisallowMultipleComponent]
    public class TargetsStorage : MonoBehaviour, ITargetsStorage, ILocalAwakeListener
    {
        [SerializeField] private PuzzleTarget[] _targets;

        private readonly List<PuzzleTarget> _all = new();
        private readonly List<PuzzleTarget> _available = new();

        public IReadOnlyList<PuzzleTarget> Available => _available;
        
        public void OnAwake()
        {
            foreach (var target in _targets)
            {
                _all.Add(target);
                _available.Add(target);
            }
        }
        
        public void OnTaken(PuzzleTarget target)
        { 
            Debug.Log($"On taken: {_available.Count}");
            _available.Remove(target);
        }

        public void OnTaken(int id)
        {
            foreach (var target in _available)
            {
                if (target.Id != id)
                    continue;
                
                OnTaken(target);
                return;
            }
            
            Debug.LogError($"{id} not found");
        }

        public void OnReset()
        {
            _available.Clear();
            
            _available.AddRange(_all);
        }
    }
}