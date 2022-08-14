using Annexio.Repository;
using Annexio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Annexio.Helpers;

namespace Annexio.Controllers.Api
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesRepository countriesRepository;

        public CountriesController(ICountriesRepository countries)
        {
            countriesRepository = countries;
        }

        [Route("api/countries/getCountriesList")]
        [CacheFilter(TimeDuration = 100)]
        public async Task<IHttpActionResult> GetCountriesList()
        {
            List<Countries> allCountries = await countriesRepository.GetCountries();
            return Ok(allCountries);
        }
    }
}
