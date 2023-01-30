using System;
using UnityEngine;

namespace Plugins.YandexGames.Runtime
{
    public class YandexCallbacks : MonoBehaviour
    {
        public event Action<UserData> UserDataReceived;
        public event Action InterstitialShown;
        public event Action<string> InterstitialFailed;
        public event Action<int> RewardedAdOpened;
        public event Action<string> RewardedAdReward;
        public event Action<int> RewardedAdClosed;
        public event Action<string> RewardedAdError;
        public event Action<string> PurchaseSuccess;
        public event Action<string> PurchaseFailed;
        public event Action Closed;
        
        public void StoreUserData(string data)
        {
            UserDataReceived?.Invoke(JsonUtility.FromJson<UserData>(data));
        }
        
        public void OnInterstitialShown()
        {
            InterstitialShown?.Invoke();
        }

        public void OnInterstitialError(string error)
        {
            InterstitialFailed?.Invoke(error);
        }

        public void OnRewardedOpen(int placement)
        {
            RewardedAdOpened?.Invoke(placement);
        }

        public void OnRewarded(int placement)
        {
            RewardedAdReward?.Invoke(placement.ToString());
        }

        public void OnRewardedClose(int placement)
        {
            RewardedAdClosed?.Invoke(placement);
        }

        public void OnRewardedError(string placement)
        {
            RewardedAdError?.Invoke(placement);
        }

        public void OnPurchaseSuccess(string id)
        {
            PurchaseSuccess?.Invoke(id);
        }

        public void OnPurchaseFailed(string error)
        {
            PurchaseFailed?.Invoke(error);
        }

        public void OnClose()
        {
            Closed?.Invoke();
        }
    }
}