using UnityEngine;

namespace Global.Setup.Service
{
    public interface IGlobalServiceBinder
    {
        void AddToModules(MonoBehaviour service);
    }
}