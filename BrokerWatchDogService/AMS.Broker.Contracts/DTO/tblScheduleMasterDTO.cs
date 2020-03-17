using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblScheduleMasterDTO
    {
        [DataMember()]
        public int ID { get; set; }

        [DataMember()]
        public string ScheduleName { get; set; }

        [DataMember()]
        public List<tblWeekTimeDetailsDTO> ScheduleTimeDetails { get; set; }
    }
}
