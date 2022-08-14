using Annexio.Controllers.Api;
using Annexio.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Annexio.App_Start
{
    public class SolveController : IDependencyResolver
    {
        private static readonly ICountriesRepository countriesRepository = new CountriesRepository();
        public object GetService(Type type)
        {
            return type == typeof(CountriesController) ? new CountriesController(countriesRepository) : null;
        }
        public IEnumerable<object> GetServices(Type type)
        {
            return new List<object>();
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
        }
    }
}