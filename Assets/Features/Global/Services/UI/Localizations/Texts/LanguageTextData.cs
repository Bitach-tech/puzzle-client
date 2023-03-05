using System;
using Common.NestedScriptableObjects.Attributes;
using Global.UI.Localizations.Common;
using Global.UI.Localizations.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Texts
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.DataName, menuName = LocalizationRoutes.DataPath)]
    public class LanguageTextData : ScriptableObject
    {
        [SerializeField] [NestedScriptableObjectField] [Indent]
        private LanguageEntry _ru;

        [SerializeField] [NestedScriptableObjectField] [Indent]
        private LanguageEntry _eng;

        private Language _selected;
        private Action<string> _localizeCallback;

        public void AttachText(Action<string> localizeCallback)
        {
            _localizeCallback = localizeCallback;

            _localizeCallback?.Invoke(GetText());
        }

        public void SelectLanguage(Language language)
        {
            _selected = language;

            _localizeCallback?.Invoke(GetText());
        }

        private string GetText()
        {
            return _selected switch
            {
                Language.Ru => _ru.Text,
                Language.Eng => _eng.Text,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}