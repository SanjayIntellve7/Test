using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    public class AlertKpi
    {
        public IEnumerable<Alert> Alerts { get; set; }
        public int Count { get; set; }
        public Severity Severity { get; set; }
        public string Username;
    }
}
