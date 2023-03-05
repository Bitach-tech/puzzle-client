using System;
using Common.ReadOnlyDictionaries.Runtime;
using Global.Inputs.Constranits.Definition;

namespace Global.Inputs.Constranits.Storage
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
    }
}