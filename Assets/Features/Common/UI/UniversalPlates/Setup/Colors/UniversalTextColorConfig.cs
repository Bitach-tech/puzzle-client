using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup.Colors
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiTextColor_", menuName = "UI/TextColor")]
    public class UniversalTextColorConfig : ScriptableObject
    {
        [SerializeField] [Indent] private Color _text;

        public Color Value => _text;
    }
}