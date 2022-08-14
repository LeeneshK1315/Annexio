using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Annexio.Models
{
    public class Regions
    {
        public string name { get; set; }
        public long population { get; set; }
        public List<Models.Countries> Countries { get; set; }
        public List<string> SubRegions { get; set; }
    }
}