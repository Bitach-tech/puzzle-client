using Common.UI.UniversalPlates.Runtime.Abstract;
using Common.UI.UniversalPlates.Setup;
using Common.UI.UniversalPlates.Setup.Colors;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [DisallowMultipleComponent]
    public class UniversalPlateColorSetter : UniversalProperty
    {
        [SerializeField] private UniversalPlateColorConfig _color;
        [SerializeField] private UniversalPlateBrightnessConfig _brightness;

        [SerializeField] private ProceduralImage _plate;
        [SerializeField] private ProceduralImage _center;

        public override void UpdateProperty()
        {
            if (_plate == null
                || _center == null
                || _color == null
                || _brightness == null)
                return;

            var baseColor = _color.Value;
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