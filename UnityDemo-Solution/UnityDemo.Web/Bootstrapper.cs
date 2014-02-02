using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using UnityDemo.Common;

namespace UnityDemo.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        //container.RegisterType<IUserData, UserData>();
        //container.RegisterType<IUserDomain, UserDomain>();

        //Module initialization thru MEF
        ModuleLoader.LoadContainer(container, ".\\bin", "UnityDemo.*.dll");
    }
  }
}