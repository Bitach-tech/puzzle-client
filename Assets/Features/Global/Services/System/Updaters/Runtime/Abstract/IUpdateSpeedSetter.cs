namespace Global.System.Updaters.Runtime.Abstract
{
    public interface IUpdateSpeedSetter
    {
        void Set(float speed);

        void Pause();
        void Continue();
    }
}