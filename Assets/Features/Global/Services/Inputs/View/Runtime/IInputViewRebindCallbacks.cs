namespace Global.Inputs.View.Runtime
{
    public interface IInputViewRebindCallbacks
    {
        void OnBeforeRebind();
        void OnAfterRebind();
    }
}