using System;
using Common.UI.UniversalPlates.Setup;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class FalloffSetter : IFeature
    {
        [SerializeField] private UniversalPlateFalloffConfig _config;

        [SerializeField] private ProceduralImage _plate;
        [SerializeField] private ProceduralImage _outline;
        [SerializeField] private ProceduralImage _center;

        public void Update()
        {
            if (_config == null
                || _plate == null
                || _outline == null
                || _center == null)
                return;

            _plate.FalloffDistance = _config.Value;
            _outline.FalloffDistance = _config.Value;
            _center.FalloffDistance = _config.Value;
        }
    }
}