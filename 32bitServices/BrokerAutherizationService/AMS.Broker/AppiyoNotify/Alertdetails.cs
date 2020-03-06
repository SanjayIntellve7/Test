using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.AppiyoNotify
{
    public class Alertdetails
    {
        public string id { get; set; }
        public string alertId { get; set; }
        public string severity { get; set; }
        public string device { get; set; }
        public string message { get; set; }
        public string mailId { get; set; }
        public string escalationMailId { get; set; }
        public string toGroupId { get; set; }
        public string toUser { get; set; }
        public string mocAuthToken { get; set; }
        public int[] userIds { get; set; }
        public int[] escalationUserIds { get; set; }
        


    }
}
