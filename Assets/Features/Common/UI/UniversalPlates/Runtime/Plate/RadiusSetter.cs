using System;
using Common.UI.UniversalPlates.Setup;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class RadiusSetter : IFeature
    {
        [SerializeField] private UniversalPlateRadiusConfig _config;

        [SerializeField] private UniformModifier _plate;
        [SerializeField] private UniformModifier _outline;
        [SerializeField] private UniformModifier _center;

        public void Update()
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