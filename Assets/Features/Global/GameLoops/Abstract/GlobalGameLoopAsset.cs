using Common.DiContainer.Abstract;
using Global.Setup.Service;
using UnityEngine;

namespace Global.GameLoops.Abstract
{
    public abstract class GlobalGameLoopAsset : ScriptableObject
    {
        public abstract GlobalGameLoop Create(IDependencyRegister register, IGlobalServiceBinder binder);
    }
}