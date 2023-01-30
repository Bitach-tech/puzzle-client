using UnityEngine;
using UnityEngine.UI;

namespace Common.UiTools.Gradients
{
    [AddComponentMenu("UI/Effects/Text 4 Corners Gradient")]
    public class UITextCornersGradient : BaseMeshEffect
    {
        public Color m_topLeftColor = Color.white;
        public Color m_topRightColor = Color.white;
        public Color m_bottomRightColor = Color.white;
        public Color m_bottomLeftColor = Color.white;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (enabled)
            {
                var rect = graphic.rectTransform.rect;

                var vertex = default(UIVertex);
                for (var i = 0; i < vh.currentVertCount; i++)
                {
                    vh.PopulateUIVertex(ref vertex, i);
                    var normalizedPosition = UIGradientUtils.VerticePositions[i % 4];
                    vertex.color *= UIGradientUtils.Bilerp(m_bottomLeftColor, m_bottomRightColor, m_topLeftColor,
                        m_topRightColor, normalizedPosition);
                    vh.SetUIVertex(vertex, i);
                }
            }
        }
    }
}