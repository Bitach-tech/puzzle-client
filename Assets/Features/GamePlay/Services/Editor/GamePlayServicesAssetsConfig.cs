using GamePlay.Common.Paths;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Runtime;
using UnityEngine;

namespace GamePlay.Services.Editor
{
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ConfigPrefix + "ServicesAssets",
        menuName = GamePlayAssetsPaths.Config + "ServicesAssets")]
    public class GamePlayServicesAssetsConfig : ScriptableObject
    {
        [SerializeField] private LevelCameraAsset _levelCamera;
        [SerializeField] private LevelLoopAsset _levelLoop;
    }
}