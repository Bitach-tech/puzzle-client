using Common.UI.UniversalPlates.Setup.Colors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiConfig_CommonColors", menuName = "UI/CommonColors")]
    public class UniversalPlateCommonColorsConfig : ScriptableObject
    {
        [SerializeField] [Indent] private TextPlateConfig _menuHeader;
        [SerializeField] [Indent] private TextPlateConfig _menuButton;

        [SerializeField] [Indent] private TextPlateConfig _quizHeader;
        [SerializeField] [Indent] private TextPlateConfig _quizAnswer;

        [SerializeField] [Indent] private TextPlateConfig _deathHeader;
        [SerializeField] [Indent] private TextPlateConfig _deathButton;

        [SerializeField] [Indent] private TextPlateConfig _finalHeader;
        [SerializeField] [Indent] private TextPlateConfig _finalButton;

        [SerializeField] [Indent] private UniversalPlateColorConfig _overlaySounds;
    }
}