using System.Web.Mvc;
using Microsoft.Practices.Unity;
using UnitityFacebookDemo.Classes.SocialMediaConnector;
using Unity.Mvc4;

namespace UnitityFacebookDemo
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
      container.RegisterType<ISocialMediaConnector, FacebookConnector>();

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    }
  }
}