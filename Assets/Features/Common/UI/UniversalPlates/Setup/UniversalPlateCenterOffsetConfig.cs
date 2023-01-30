using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiCenterOffset_", menuName = "UI/CenterOffset")]
    public class UniversalPlateCenterOffsetConfig : ScriptableObject
    {
        [SerializeField] [Indent] [Min(0f)] private float _offset;

        public float Value => _offset;
    }
}