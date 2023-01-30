using Common.UI.UniversalPlates.Runtime.Abstract;
using Common.UI.UniversalPlates.Setup;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [DisallowMultipleComponent]
    public class UniversalPlateRadiusSetter : UniversalProperty
    {
        [SerializeField] private UniversalPlateRadiusConfig _config;

        [SerializeField] private UniformModifier _plate;
        [SerializeField] private UniformModifier _outline;
        [SerializeField] private UniformModifier _center;

        public override void UpdateProperty()
        {
            if (_config == null
                || _plate == null
                || _outline == null
                || _center == null)
                return;

            _plate.Radius = _config.Out;
            _outline.Radius = _config.Out;
            _center.Radius = _config.In;
        }
    }
}