using Global.Publisher.Abstract.Languages;
using Global.UI.Localizations.Definition;

namespace Global.Publisher.Yandex.Languages
{
    public class LanguageProvider : ILanguageProvider
    {
        public LanguageProvider(ILanguageAPI api)
        {
            _externAPI = api;
        }

        private readonly ILanguageAPI _externAPI;

        private bool _isLanguageReceived;
        private Language _selected;

        public Language GetLanguage()
        {
            if (_isLanguageReceived == true)
                return _selected;

            var raw = _externAPI.GetLanguage_Internal();
            _isLanguageReceived = true;

            return raw switch
            {
                "ru" => Language.Ru,
                "en" => Language.Eng,
                _ => Language.Ru
            };
        }
    }
}