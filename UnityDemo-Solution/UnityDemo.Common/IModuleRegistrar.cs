using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace UnityDemo.Common
{
    /// <summary>
    /// Allows objects implementing IModule to register types in unity.
    /// </summary>
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        void RegisterTypeWithContainerControlledLife<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
