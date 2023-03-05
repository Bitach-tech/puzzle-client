namespace GamePlay.Level.Assemble.Runtime.Handler
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