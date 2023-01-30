using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup.Colors
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiPlateColor_", menuName = "UI/PlateColor")]
    public class UniversalPlateColorConfig : ScriptableObject
    {
        [SerializeField] [Indent] private Color _color;

        public Color Value => _color;
    }
}