using Cysharp.Threading.Tasks;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using Plugins.YandexGames.Runtime;
using UnityEngine;

namespace Global.Services.ServiceSDK.Advertisment.Yandex
{
    public class InterstitialHandler
    {
        public InterstitialHandler(
            YandexCallbacks callbacks,
            AdsInternal ads)
        {
            _callbacks = callbacks;
            _ads = ads;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly AdsInternal _ads;

        private UniTaskCompletionSource<InterstitialResult> _completion;

        public async UniTask Show()
        {
            _callbacks.InterstitialShown += OnShown;
            _callbacks.InterstitialFailed += OnFailed;

            _completion = new UniTaskCompletionSource<InterstitialResult>();

            _ads.ShotInterstitial();
            await _completion.Task;

            _callbacks.InterstitialShown -= OnShown;
            _callbacks.InterstitialFailed -= OnFailed;
        }

        private void OnShown()
        {
            _completion.TrySetResult(InterstitialResult.Success);
        }

        private void OnFailed(string message)
        {
            Debug.LogError($"Interstitial failed: {message}");
            _completion.TrySetResult(InterstitialResult.Fail);
        }
    }
}