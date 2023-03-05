using GamePlay.Level.Assemble.Runtime.Background;
using GamePlay.Level.Assemble.Runtime.Parts;
using GamePlay.Level.Assemble.Runtime.StartPositions;
using GamePlay.Level.Assemble.Runtime.Targets;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzleBootstrapper : MonoBehaviour
    {
        [SerializeField] private PartsStorage _parts;
        [SerializeField] private TargetsStorage _targets;
        [SerializeField] private RandomStartPositions _randomStartPositions;
        [SerializeField] private PuzzleBackground _background;
        
        public PartsStorage Parts => _parts;
        public TargetsStorage Targets => _targets;
        public RandomStartPositions RandomStartPositions => _randomStartPositions;
        public PuzzleBackground Background => _background;
    }
}