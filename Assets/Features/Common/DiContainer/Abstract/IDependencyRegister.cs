using UnityEngine;

namespace Common.DiContainer.Abstract
{
    public interface IDependencyRegister
    {
        IRegistration Register<T>();
        IRegistration RegisterInstance<T>(T instance);
        IRegistration RegisterComponent<T>(T component) where T : MonoBehaviour;
        void Inject<T>(T component) where T : MonoBehaviour;
    }
}