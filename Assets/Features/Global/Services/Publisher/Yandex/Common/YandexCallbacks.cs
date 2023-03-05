using System;
using UnityEngine;

namespace Global.Publisher.Yandex.Common
{
    public class YandexCallbacks : MonoBehaviour
    {
        public event Action<string> UserDataReceived;
        public event Action InterstitialShown;
        public event Action<string> InterstitialFailed;
        public event Action RewardedAdClosed;
        public event Action<string> RewardedAdError;
        public event Action<string> PurchaseSuccess;
        public event Action<string> PurchaseFailed;
        public event Action Reviewed;

        public void OnUserDataReceived(string data)
        {
            UserDataReceived?.Invoke(data);
        }

        public void OnInterstitialShown()
        {
            InterstitialShown?.Invoke();
        }

        public void OnInterstitialError(string error)
        {
            InterstitialFailed?.Invoke(error);
        }

        public void OnRewardedClose()
        {
            RewardedAdClosed?.Invoke();
        }

        public void OnRewardedError(string error)
        {
            RewardedAdError?.Invoke(error);
        }

        public void OnPurchaseSuccess(string id)
        {
            PurchaseSuccess?.Invoke(id);
        }

        public void OnPurchaseFailed(string error)
        {
            PurchaseFailed?.Invoke(error);
        }

        public void OnReview()
        {
            Reviewed?.Invoke();
        }
    }
}