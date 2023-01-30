﻿using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Runtime
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

        public void OnReset()
        {
            _available.Clear();
            
            _available.AddRange(_all);
        }
    }
}