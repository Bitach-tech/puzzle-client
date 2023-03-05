using System.Collections.Generic;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Storage;
using Global.UI.UiStateMachines.Common;
using UnityEngine;

namespace Global.UI.UiStateMachines.Runtime
{
    [CreateAssetMenu(fileName = UiStateMachineRouter.ConstraintsPrefix,
        menuName = UiStateMachineRouter.ConstraintsPath)]
    public class UiConstraints : ScriptableObject
    {
        [SerializeField] private InputConstraintsDictionary _input;

        public IReadOnlyDictionary<InputConstraints, bool> Input => _input;
    }
}