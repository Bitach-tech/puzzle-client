using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Plugins.YandexGames.EikoYandex.Editor.Scripts
{
    public class YandexSettings : EditorWindow
    {
        private const string _cssPath = "TemplateData/style.css";
        private const string _lanscape = "width: 100%; height: 100%;";
        private const string _portrait = "aspect-ratio: 0.5625;";
        private const string _replaceTag = "!DisplayMode!";

        private YandexSettingsWrapper _wrapper;

        [MenuItem("Yandex/Settings")]
        static void Init()
        {
            YandexSettings window = (YandexSettings)EditorWindow.GetWindow(typeof(YandexSettings));
            if (EditorPrefs.HasKey(nameof(YandexSettings)))
            {
                window._wrapper = JsonUtility.FromJson<YandexSettingsWrapper>(
                    EditorPrefs.GetString(nameof(YandexSettings)));
            }
            else
            {
                window._wrapper = new YandexSettingsWrapper();
            }

            window.Show();
        }

        private void OnDisable()
        {
            EditorPrefs.SetString(
                nameof(YandexSettings),
                JsonUtility.ToJson(_wrapper)
            );
        }

        private void OnGUI()
        {
            if (_wrapper == null)
                return;

            _wrapper.mode = (DisplayMode)EditorGUILayout.EnumPopup("DisplayMode", _wrapper.mode);
        }

        [PostProcessBuild(1)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.WebGL)
                return;
            
            var yandex = JsonUtility.FromJson<YandexSettingsWrapper>(
                EditorPrefs.GetString(nameof(YandexSettings)));

            var pathToCss = Path.Combine(pathToBuiltProject, _cssPath);
            string str;

            using (var reader = File.OpenText(pathToCss))
                str = reader.ReadToEnd();

            str = str.Replace(_replaceTag, yandex.mode == DisplayMode.Portrait ? _portrait : _lanscape);

            using (var file = new StreamWriter(pathToCss))
                file.Write(str);
        }
    }
}