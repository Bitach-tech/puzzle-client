using GamePlay.Common.Paths;
using UnityEngine;

namespace Common.UiTools.ButtonReponses
{
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ConfigPrefix + "ButtonResponse",
        menuName = GamePlayAssetsPaths.Config + "ButtonResponse")]
    public class ButtonResponseConfig : ScriptableObject
    {
        [SerializeField] private float _overSize = 1.1f;
        [SerializeField] private float _switchTime = 0.3f;

        public float OverSize => _overSize;
        public float SwitchTime => _switchTime;
    }
}