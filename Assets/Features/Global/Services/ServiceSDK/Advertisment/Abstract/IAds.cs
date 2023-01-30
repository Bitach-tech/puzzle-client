using Cysharp.Threading.Tasks;

namespace Global.Services.ServiceSDK.Advertisment.Abstract
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}