using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;
using Global.System.Pauses.Runtime;

namespace Global.Publisher.Yandex.Advertisement
{
    public class Ads : IAds
    {
        private Ads(YandexCallbacks callbacks, IPause pause, IAdsAPI api)
        {
            _callbacks = callbacks;
            _pause = pause;
            _api = api;
        }

        private readonly IAdsAPI _api;
        private readonly YandexCallbacks _callbacks;

        private readonly IPause _pause;

        public void ShowInterstitial()
        {
            ProcessInterstitial().Forget();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            _pause.Pause();

            var handler = new RewardedHandler(_callbacks, _api);
            var result = await handler.Show();

            _pause.Continue();

            return result;
        }

        private async UniTaskVoid ProcessInterstitial()
        {
            _pause.Pause();

            var handler = new InterstitialHandler(_callbacks, _api);
            await handler.Show();

            _pause.Continue();
        }
    }
}