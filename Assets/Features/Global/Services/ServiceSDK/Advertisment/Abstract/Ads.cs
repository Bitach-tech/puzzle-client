using Cysharp.Threading.Tasks;
using Plugins.YandexGames.Runtime;
using UnityEngine;

namespace Global.Services.ServiceSDK.Advertisment.Abstract
{
    [DisallowMultipleComponent]
    public class Ads : MonoBehaviour, IAds
    {
        private UniTaskCompletionSource<RewardAdResult> _rewardedCompletion;

        private void OnEnable()
        {
            YandexSDK.instance.onRewardedAdReward += OnRewardShowed;
            YandexSDK.instance.onRewardedAdClosed += OnRewardClosed;
            YandexSDK.instance.onRewardedAdError += OnRewardError;
        }

        private void OnDisable()
        {
            YandexSDK.instance.onRewardedAdReward -= OnRewardShowed;
            YandexSDK.instance.onRewardedAdClosed -= OnRewardClosed;
            YandexSDK.instance.onRewardedAdError -= OnRewardError;
        }

        public void ShowInterstitial()
        {
            YandexSDK.instance.ShowInterstitial();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            _rewardedCompletion = new UniTaskCompletionSource<RewardAdResult>();

            YandexSDK.instance.ShowRewarded("1");

            var result = await _rewardedCompletion.Task;
            AudioListener.pause = false;

            return result;
        }

        private void OnRewardShowed(string data)
        {
            //_rewardedCompletion.TrySetResult(RewardAdResult.Applied);
        }

        private void OnRewardClosed(int data)
        {
            _rewardedCompletion.TrySetResult(RewardAdResult.Canceled);
        }

        private void OnRewardError(string data)
        {
            _rewardedCompletion.TrySetResult(RewardAdResult.Error);
        }
    }
}