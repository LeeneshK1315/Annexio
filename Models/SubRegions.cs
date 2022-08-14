using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Annexio.Models
{
    public class SubRegions
    {
        public string name { get; set; }
        public long population { get; set; }
        public List<Models.Countries> Countries { get; set; }
        public string Region { get; set; }
    }
}