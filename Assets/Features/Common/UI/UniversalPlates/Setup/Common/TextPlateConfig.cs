using System;
using Common.UI.UniversalPlates.Setup.Colors;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup.Common
{
    [Serializable]
    public class TextPlateConfig
    {
        [SerializeField] private UniversalPlateColorConfig _plate;
        [SerializeField] private UniversalTextColorConfig _text;
    }
}