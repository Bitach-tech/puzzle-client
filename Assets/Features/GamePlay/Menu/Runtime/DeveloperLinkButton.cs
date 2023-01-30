using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class DeveloperLinkButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Application.OpenURL("https://yandex.ru/games/developer?name=noncasted");
        }
    }
}