using GamePlay.Puzzle.Assemble.Runtime.Background;
using GamePlay.Puzzle.Assemble.Runtime.Parts;
using GamePlay.Puzzle.Assemble.Runtime.StartPositions;
using GamePlay.Puzzle.Assemble.Runtime.Targets;
using UnityEngine;

namespace GamePlay.Puzzle.Assemble.Runtime
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