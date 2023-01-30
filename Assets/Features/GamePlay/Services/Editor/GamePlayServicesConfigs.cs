using GamePlay.Common.Paths;
using GamePlay.Services.LevelCameras.Runtime;
using UnityEngine;

namespace GamePlay.Services.Editor
{
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ConfigPrefix + "ServicesConfigs",
        menuName = GamePlayAssetsPaths.Config + "ServicesConfigs")]
    public class GamePlayServicesConfigs : ScriptableObject
    {
        [SerializeField] private LevelCameraConfigAsset _levelCamera;
    }
}