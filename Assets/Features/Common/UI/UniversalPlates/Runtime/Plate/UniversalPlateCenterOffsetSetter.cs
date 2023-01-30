using Common.UI.UniversalPlates.Runtime.Abstract;
using Common.UI.UniversalPlates.Setup;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [DisallowMultipleComponent]
    public class UniversalPlateCenterOffsetSetter : UniversalProperty
    {
        [SerializeField] private UniversalPlateCenterOffsetConfig _config;

        [SerializeField] private RectTransform _center;

        public override void UpdateProperty()
        {
            if (_config == null || _center == null)
                return;

            _center.offsetMin = new Vector2(_config.Value, _config.Value);
            _center.offsetMax = new Vector2(-_config.Value, -_config.Value);
        }
    }
}