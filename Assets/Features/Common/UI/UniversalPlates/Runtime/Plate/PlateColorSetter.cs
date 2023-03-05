using System;
using Common.UI.UniversalPlates.Setup;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class PlateColorSetter : IFeature
    {
        [SerializeField] [ColorPalette("UI")] private Color _color;
        [SerializeField] private UniversalPlateBrightnessConfig _brightness;

        [SerializeField] private ProceduralImage _plate;
        [SerializeField] private ProceduralImage _center;

        public void Update()
        {
            if (_plate == null
                || _center == null
                || _brightness == null)
                return;

            var baseColor = _color;
            var brightness = _brightness.Value;

            _center.color = baseColor;

            var plateColor = new Color(
                baseColor.r * brightness,
                baseColor.g * brightness,
                baseColor.b * brightness,
                baseColor.a * brightness);

            _plate.color = plateColor;
        }
    }
}