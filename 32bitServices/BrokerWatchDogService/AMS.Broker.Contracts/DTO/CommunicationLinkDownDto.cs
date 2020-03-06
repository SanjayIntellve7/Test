using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class CommunicationLinkDownDto
    {
        public string Severity { get; set; }

        public string EventType { get; set; }

        public string WaitTime { get; set; }

        public string RestoreEventype { get; set; }

        public List<Step> Step { get; set; }

    }

    public class Step
    {
        public string PingRouter { get; set; }
        public string ID { get; set; }
        public string PingCamera { get; set; }

    }
}
