using Common.ReadOnlyDictionaries.Editor;
using Global.Inputs.Constranits.Storage;
using UnityEditor;

namespace Global.Inputs.View.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}