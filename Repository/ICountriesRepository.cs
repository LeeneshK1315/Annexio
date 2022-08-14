using Annexio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Repository
{
    public interface ICountriesRepository
    {
        Task<List<Countries>> GetCountries();
        Task<CountryDetails> GetCountryDetailByCountryCode(string alpha3Code);
        Task<Regions> GetRegionDetails(string regionName);
        Task<SubRegions> GetSubRegionDetails(string subRegionName);
    }
}
