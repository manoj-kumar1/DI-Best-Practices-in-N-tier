using UnityDemo.Common;
using Microsoft.Practices.Unity;
using System.ComponentModel.Composition;

namespace UnityDemo.Security.Data
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IUserData, UserData>();
        }
    }
}
