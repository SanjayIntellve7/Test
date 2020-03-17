using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class OntPortRootObject
    {
        public string ifAdminStatus { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ifOperStatus { get; set; }
        public string serviceNames { get; set; }
    }
}
