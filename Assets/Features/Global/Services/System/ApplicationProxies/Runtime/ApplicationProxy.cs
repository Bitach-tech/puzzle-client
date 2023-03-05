using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [DisallowMultipleComponent]
    public class ApplicationProxy : IApplicationFlow
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}