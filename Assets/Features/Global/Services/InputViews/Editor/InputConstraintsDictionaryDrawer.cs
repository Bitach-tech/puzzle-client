using Common.ReadOnlyDictionaries.Editor;
using Global.Services.InputViews.ConstraintsStorage;
using UnityEditor;

namespace Global.Services.InputViews.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}