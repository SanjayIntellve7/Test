using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class OntRootObject
    {
        public string ifAdminStatus { get; set; }
        public string bponOntPlannedCfgFile1 { get; set; }
        public string acknowledged { get; set; }
        public string replaceable { get; set; }
        public string bponOntSerialNumber { get; set; }
        public string ontEquippedType { get; set; }
        public string bponOntSubscriberId1 { get; set; }
        public string ifLastChange { get; set; }
        public string bponOntSubscriberId2 { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string ifOperStatus { get; set; }
        public string bponOntSwActiveVersion { get; set; }
        public string pccOntState { get; set; }
        public string bponOntPlannedVariant { get; set; }
    }
}
