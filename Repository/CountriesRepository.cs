using Annexio.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Annexio.Helpers;
using System.Web.Http;

namespace Annexio.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        string Baseurl = "https://restcountries.com";
        public async Task<List<Countries>> GetCountries()
        {
            List<Countries> allCountries = new List<Countries>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + string.Format("/v2/all?fields=name,region,subregion,alpha3Code"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage Res = await client.GetAsync(client.BaseAddress);
                if (Res.IsSuccessStatusCode)
                {
                    var stringResponse = await Res.Content.ReadAsStringAsync();
                    allCountries = JsonConvert.DeserializeObject<List<Countries>>(stringResponse);
                }
                else
                {
                    throw new HttpRequestException(Res.ReasonPhrase);
                }

                return allCountries;
            }
        }

        [HttpGet]
        [CacheFilter(TimeDuration = 100)]
        public async Task<CountryDetails> GetCountryDetailByCountryCode(string alpha3Code)
        {
            CountryDetails countryDetails = new CountryDetails();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + string.Format("/v2/alpha/{0}?fields=name,capital,population,currencies,languages,borders", alpha3Code));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(client.BaseAddress);
                if (Res.IsSuccessStatusCode)
                {
                    var stringResponse = await Res.Content.ReadAsStringAsync();
                    countryDetails = JsonConvert.DeserializeObject<CountryDetails>(stringResponse);
                }
                else
                {
                    throw new HttpRequestException(Res.ReasonPhrase);
                }

                return countryDetails;
            }
        }

        [HttpGet]
        [CacheFilter(TimeDuration = 100)]
        public async Task<Regions> GetRegionDetails(string regionName)
        {
            Regions region = new Regions();

            region.name = regionName;

            HttpClient client = new HttpClient();
            var msg = await client.GetStringAsync(Baseurl + string.Format("/v2/region/{0}?fields=name,population,subregion,alpha3Code", regionName));

            region.Countries = System.Text.Json.JsonSerializer.Deserialize<List<Countries>>(msg);

            region.population = region.Countries.Sum(c => Convert.ToInt64(c.population));

            region.SubRegions = region.Countries.Select(c => c.subregion).Distinct().ToList();

            return region;
        }

        [HttpGet]
        [CacheFilter(TimeDuration = 100)]
        public async Task<SubRegions> GetSubRegionDetails(string subRegionName)
        {
            SubRegions subRegion = new SubRegions();

            subRegion.name = subRegionName;

            HttpClient client = new HttpClient();
            var msg = await client.GetStringAsync(Baseurl + string.Format("/v2/subregion/{0}?fields=name,population,region,alpha3Code,subregion", subRegionName));

            List<Countries> countries = System.Text.Json.JsonSerializer.Deserialize<List<Countries>>(msg);

            subRegion.Countries = countries.Where(c => c.subregion.Equals(subRegionName)).ToList();

            subRegion.population = subRegion.Countries.Sum(c => Convert.ToInt64(c.population));

            subRegion.Region = subRegion.Countries.Where(c => !String.IsNullOrEmpty(c.region)).FirstOrDefault().region;

            return subRegion;
        }
    }
}