using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Annexio.Models
{
    public class CountryDetails
    {
        public List<Currency> currencies { get; set; }
        public List<Language> languages { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
        public int population { get; set; }
        public List<string> borders { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string nativeName { get; set; }
    }
}