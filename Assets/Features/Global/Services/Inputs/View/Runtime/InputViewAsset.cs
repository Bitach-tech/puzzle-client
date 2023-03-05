using Common.DiContainer.Abstract;
using Global.Inputs.Common;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputRouter.ServiceName,
        menuName = InputRouter.ServicePath)]
    public class InputViewAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;
        [SerializeField] [Indent] private InputView _prefab;

        public void Create(IDependencyRegister builder, IGlobalServiceBinder serviceBinder, IGlobalCallbacks callbacks)
        {
            builder.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            builder.Register<InputView>()
                .AsImplementedInterfaces()
                .AsCallbackListener();

            builder.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>();
        }
    }
}