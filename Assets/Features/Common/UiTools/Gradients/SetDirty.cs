using UnityEngine;
using UnityEngine.UI;

namespace Common.UiTools.Gradients
{
    public class SetDirty : MonoBehaviour
    {
        public Graphic m_graphic;

        // Use this for initialization
        private void Reset()
        {
            m_graphic = GetComponent<Graphic>();
        }

        // Update is called once per frame
        private void Update()
        {
            m_graphic.SetVerticesDirty();
        }
    }
}