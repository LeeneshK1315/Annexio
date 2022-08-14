using Annexio.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Annexio
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICountriesRepository, CountriesRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}