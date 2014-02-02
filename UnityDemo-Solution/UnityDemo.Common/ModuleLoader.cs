using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace UnityDemo.Common
{
    public static class ModuleLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);
                    
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);

                        IEnumerable<IModule> modules =
                            exports.Select(export => export.Value as IModule).Where(m => m != null);

                        var registrar = new ModuleRegistrar(container);
                        foreach (IModule module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    internal class ModuleRegistrar : IModuleRegistrar
    {
        private readonly IUnityContainer _container;

        public ModuleRegistrar(IUnityContainer container)
        {
            this._container = container;
            //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            { 
                //register with interception 
            }
            else
            {
                this._container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithContainerControlledLife<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
