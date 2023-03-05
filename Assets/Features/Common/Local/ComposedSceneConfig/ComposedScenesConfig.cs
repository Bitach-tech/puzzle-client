using NaughtyAttributes;
using UnityEngine;

namespace Common.Local.ComposedSceneConfig
{
    [CreateAssetMenu(fileName = "ComposedSceneConfig",
        menuName = "Local/Config/ComposedScene")]
    public class ComposedScenesConfig : ScriptableObject
    {
        [SerializeField] [Scene] private string _servicesScene;

        public string ServicesScene => _servicesScene;
    }
}