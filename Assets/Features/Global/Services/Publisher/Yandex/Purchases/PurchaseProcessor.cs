using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Yandex.Common;
using UnityEngine;

namespace Global.Publisher.Yandex.Purchases
{
    public class PurchaseProcessor : IPurchaseProcessor
    {
        public PurchaseProcessor(YandexCallbacks callbacks)
        {
            _callbacks = callbacks;
        }

        private readonly YandexCallbacks _callbacks;

        public async UniTask<PurchaseResult> Purchase(IPurchaseIdProvider idProvider)
        {
            var targetId = idProvider.GetId();
            var completion = new UniTaskCompletionSource<PurchaseResult>();

            void OnSuccess(string id)
            {
                Debug.Log($"Received success payment id: {targetId}");

                if (targetId != id)
                    return;

                completion.TrySetResult(PurchaseResult.Success);
            }

            void OnFail(string message)
            {
                Debug.LogError(message);

                completion.TrySetResult(PurchaseResult.Fail);
            }

            _callbacks.PurchaseSuccess += OnSuccess;
            _callbacks.PurchaseFailed += OnFail;

            var result = await completion.Task;

            _callbacks.PurchaseSuccess -= OnSuccess;
            _callbacks.PurchaseFailed -= OnFail;

            return result;
        }
    }
}