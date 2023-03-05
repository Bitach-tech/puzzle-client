using Cysharp.Threading.Tasks;

namespace Global.Setup.Service.Callbacks
{
    public interface IGlobalAsyncBootstrapListener
    {
        UniTask OnBootstrapAsync();
    }
}