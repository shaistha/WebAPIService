using APIService.DataAccessRepository;
using APIService.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace APIService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            //Registering dependency
            container.RegisterType<IDataAccessRepository, clsDataAccessRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}