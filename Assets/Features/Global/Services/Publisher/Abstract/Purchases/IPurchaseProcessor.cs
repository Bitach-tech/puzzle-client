using Cysharp.Threading.Tasks;

namespace Global.Publisher.Abstract.Purchases
{
    public interface IPurchaseProcessor
    {
        UniTask<PurchaseResult> Purchase(IPurchaseIdProvider idProvider);
    }
}