using Cysharp.Threading.Tasks;

namespace Global.Setup.Service.Callbacks
{
    public interface IGlobalInternalCallbackLoop
    {
        UniTask Run();
    }
}