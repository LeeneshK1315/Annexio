using System.Collections.Generic;

namespace Annexio.Models
{
    public class CountriesViewModel
    {
        public List<Countries> Countries { get; set; }
        public CountryDetails Details { get; set; }
        public List<CountryDetails> CountryDetails { get; set; }
        public Regions Regions { get; set; }
        public SubRegions SubRegions { get; set; }
    }
}