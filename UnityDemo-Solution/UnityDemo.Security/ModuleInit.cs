using Microsoft.Practices.Unity;
using UnityDemo.Common;
using System.ComponentModel.Composition;

namespace UnityDemo.Security
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IUserDomain, UserDomain>();
        }
    }
}
