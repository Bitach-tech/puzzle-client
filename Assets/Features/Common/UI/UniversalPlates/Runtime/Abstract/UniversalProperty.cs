using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Abstract
{
    public abstract class UniversalProperty : MonoBehaviour
    {
        private void Awake()
        {
            UpdateProperty();
        }

        public abstract void UpdateProperty();
    }
}