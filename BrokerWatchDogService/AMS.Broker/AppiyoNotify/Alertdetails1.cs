using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.WatchDogService.AppiyoNotify
{
    public class Alertdetails1
    {
        public string processId { get; set; }
        public Alertdetails ProcessVariables { get; set; }
        public string workflowId { get; set; }
        public string projectId { get; set; }
        
    }

    public class MeonMembers
    {
        public string custID { get; set; }
    }

    public class EscMeonMembers
    {
        public string esccustID { get; set; }
    }
}

