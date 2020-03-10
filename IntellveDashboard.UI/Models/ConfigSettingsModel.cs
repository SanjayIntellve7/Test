using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Models
{
    public class ConfigSettingsModel
    { 

        public BROKER_SERVICE_HOSTS broker_SERVICE_HOSTS { get; set; }
        
        public class BROKER_SERVICE_HOSTS
        {
            public string AutherizationServiceIp { get; set; }
        }

        public WEB_API_SERVICE_HOSTS web_API_SERVICE_HOSTS { get; set; }

        public class WEB_API_SERVICE_HOSTS
        {
            public string dashboard_WEB_API_HOST { get; set; }
        }
    }
}
