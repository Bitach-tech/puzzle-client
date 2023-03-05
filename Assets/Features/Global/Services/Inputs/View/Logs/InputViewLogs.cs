using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Inputs.View.Logs
{
    [Serializable]
    public class InputViewLogs : ReadOnlyDictionary<InputViewLogType, bool>
    {
    }
}