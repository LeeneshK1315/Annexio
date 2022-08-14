using Annexio.Models;
using Annexio.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountriesRepository countriesRepository;

        public HomeController(ICountriesRepository countries)
        {
            countriesRepository = countries;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetCountryDetails(string alpha3Code)
        {
           CountryDetails countryDetails = await countriesRepository.GetCountryDetailByCountryCode(alpha3Code);

            var viewModel = new CountriesViewModel()
            {
                Details = countryDetails
            };

            return PartialView("_CountryDetails", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> GetRegionDetails(string region)
        {
            Regions regionDetails = await countriesRepository.GetRegionDetails(region);

            var viewModel = new CountriesViewModel()
            {
                Regions = regionDetails
            };

            return PartialView("_RegionDetails", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> GetSubRegionDetails(string subRegion)
        {
            SubRegions subRegionDetails = await countriesRepository.GetSubRegionDetails(subRegion);

            var viewModel = new CountriesViewModel()
            {
                SubRegions = subRegionDetails
            };

            return PartialView("_SubRegionDetails", viewModel);
        }
    }
}