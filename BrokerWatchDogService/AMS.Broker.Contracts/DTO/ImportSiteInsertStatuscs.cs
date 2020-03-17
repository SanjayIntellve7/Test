using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ImportSiteInsertStatuscs
    {
        public List<SiteErrorStatus> ErrorStatusList { get; set; }
        public List<SiteSuccessStatus> SuccessStatusList { get; set; }
    }

    public class SiteErrorStatus
    {
        public string ErrorInterfaceName { get; set; }
        public string ErrorInterfaceType { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SiteSuccessStatus
    {
        public string SuccessInterfaceName { get; set; }
        public string SuccessInterfaceType { get; set; }
        public string SuccessMessage { get; set; }
    }
}
