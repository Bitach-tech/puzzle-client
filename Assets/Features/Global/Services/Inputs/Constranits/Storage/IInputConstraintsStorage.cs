using System.Collections.Generic;
using Global.Inputs.Constranits.Definition;

namespace Global.Inputs.Constranits.Storage
{
    public interface IInputConstraintsStorage
    {
        bool this[InputConstraints key] { get; }

        void Add(IReadOnlyDictionary<InputConstraints, bool> constraint);
        void Remove(IReadOnlyDictionary<InputConstraints, bool> constraint);
    }
}