using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Texts
{
    [InlineEditor]
    public class LanguageEntry : ScriptableObject
    {
        [SerializeField] private string _text;

        public string Text => _text;
    }
}