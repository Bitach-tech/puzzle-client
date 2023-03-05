using Common.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;

namespace Global.Scenes.CurrentSceneHandlers.Runtime
{
    public interface ICurrentSceneHandler
    {
        public void OnLoaded(ComposedSceneLoadResult loaded);

        public UniTask Unload();

        public UniTask FinalizeUnloading();
    }
}