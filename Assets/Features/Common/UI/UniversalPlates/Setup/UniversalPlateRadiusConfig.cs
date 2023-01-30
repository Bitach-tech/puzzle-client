using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UiRadius_", menuName = "UI/Radius")]
    public class UniversalPlateRadiusConfig : ScriptableObject
    {
        [SerializeField] [Indent] [Min(0f)] private float _out;
        [SerializeField] [Indent] [Min(0f)] private float _in;

        public float Out => _out;
        public float In => _in;
    }
}