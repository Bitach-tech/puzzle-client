using GamePlay.Level.Assemble.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AssembleRoutes.PickConfigName,
        menuName = AssembleRoutes.PickConfigPath)]
    public class PickHandlerConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] [Min(0f)] private float _dropDistance;

        public float DropDistance => _dropDistance;
    }
}