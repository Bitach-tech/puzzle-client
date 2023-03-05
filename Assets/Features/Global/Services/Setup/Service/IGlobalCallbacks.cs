using Global.Setup.Service.Callbacks;

namespace Global.Setup.Service
{
    public interface IGlobalCallbacks
    {
        void Listen(object listener);
        void AddInternalCallbackLoop(IGlobalInternalCallbackLoop callbackLoop);
    }
}