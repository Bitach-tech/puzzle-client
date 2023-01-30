using System.Runtime.InteropServices;

namespace Plugins.YandexGames.Runtime
{
    public class AdsInternal
    {
        [DllImport("__Internal")]
        public static extern void ShowFullscreenAd();

        [DllImport("__Internal")]
        public static extern int ShowRewardedAd(string placement);

        public void ShotInterstitial()
        {
            ShowFullscreenAd();
        }

        public void ShowRewarded()
        {
            ShowRewardedAd("1");
        }
    }
}