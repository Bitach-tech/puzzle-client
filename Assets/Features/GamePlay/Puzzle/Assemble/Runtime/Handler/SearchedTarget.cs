namespace Features.GamePlay.Puzzle.Assemble.Runtime
{
    public readonly struct SearchedTarget
    {
        public SearchedTarget(PuzzleTarget part, float distance)
        {
            Part = part;
            Distance = distance;
        }
        
        public readonly PuzzleTarget Part;
        public readonly float Distance;
    }
}