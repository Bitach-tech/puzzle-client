using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime
{
    [DisallowMultipleComponent]
    public class UniversalPlate : MonoBehaviour
    {
        [SerializeReference]
        [ListDrawerSettings(
            DraggableItems = false,
            Expanded = true,
            ShowIndexLabels = false,
            ShowPaging = false,
            ShowItemCount = false,
            HideRemoveButton = false)]
        private List<IFeature> _features = new();

        private void Awake()
        {
            UpdateProperties();
        }

        public void UpdateProperties()
        {
            foreach (var feature in _features)
                feature.Update();
        }
    }
}