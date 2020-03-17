using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class GallagherAcsDoorResult
    {
        public string id { get; set; }
        public string href { get; set; }
        public string name { get; set; }
    }
    public class GallagherAcsDoorObject
    {
        public List<GallagherAcsDoorResult> results { get; set; }
    }
}
