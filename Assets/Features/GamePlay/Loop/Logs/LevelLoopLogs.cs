using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Loop.Logs
{
    [Serializable]
    public class LevelLoopLogs : ReadOnlyDictionary<LevelLoopLogType, bool>
    {
    }
}