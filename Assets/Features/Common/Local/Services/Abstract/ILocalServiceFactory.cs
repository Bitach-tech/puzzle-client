using Common.DiContainer.Abstract;

namespace Common.Local.Services.Abstract
{
    public interface ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ILocalCallbacks callbacks);
    }
}