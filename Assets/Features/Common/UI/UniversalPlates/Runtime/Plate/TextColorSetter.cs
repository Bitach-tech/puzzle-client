using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class TextColorSetter : IFeature
    {
        [SerializeField] [ColorPalette("Text")]
        private Color _color;

        [SerializeField] private TMP_Text _text;

        public void Update()
        {
            if (_text == null)
                return;

            _text.color = _color;
        }
    }
}