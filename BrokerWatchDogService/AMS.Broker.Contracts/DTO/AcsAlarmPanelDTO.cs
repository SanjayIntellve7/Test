using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class AcsAlarmPanelDTO
    {
        public int AlarmPanelId { get; set; }

        public int? AlarmPanelTypeId { get; set; }

        public int? EventTypeTemplateId { get; set; }

        public string InterfaceDeviceIP { get; set; }

        public string InterfaceDevicePort { get; set; }
    }
}
