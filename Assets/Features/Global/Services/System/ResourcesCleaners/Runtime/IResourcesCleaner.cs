using Cysharp.Threading.Tasks;

namespace Global.System.ResourcesCleaners.Runtime
{
    public interface IResourcesCleaner
    {
        UniTask CleanUp();
    }
}