using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace UnityDemo.Common
{
    /// <summary>
    /// To register all the internal type with unity.
    /// </summary>
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
