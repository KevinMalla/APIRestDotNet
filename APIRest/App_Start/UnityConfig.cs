using APIRest.Interfaces;
using APIRest.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace APIRest.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IJokeDataService, JokeDataService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}