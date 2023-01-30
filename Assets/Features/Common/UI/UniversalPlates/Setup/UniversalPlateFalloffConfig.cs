using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiFalloff_", menuName = "UI/Falloff")]
    public class UniversalPlateFalloffConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] [Indent] private float _falloff;

        public float Value => _falloff;
    }
}