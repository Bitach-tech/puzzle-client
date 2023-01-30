using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiConfig_Common", menuName = "UI/Common")]
    public class UniversalPlateCommonConfig : ScriptableObject
    {
        [SerializeField] [Indent] private UniversalPlateBrightnessConfig _brightness;
        [SerializeField] [Indent] private UniversalPlateCenterOffsetConfig _centerOffset;
        [SerializeField] [Indent] private UniversalPlateFalloffConfig _falloff;
        [SerializeField] [Indent] private UniversalPlateRadiusConfig _radius;
    }
}