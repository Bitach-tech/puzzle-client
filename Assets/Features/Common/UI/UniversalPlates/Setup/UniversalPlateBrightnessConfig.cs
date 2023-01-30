using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiBrightness_", menuName = "UI/Brightness")]
    public class UniversalPlateBrightnessConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] [Indent] private float _brightness;

        public float Value => _brightness;
    }
}