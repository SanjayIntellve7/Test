using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblWeekTimeDetailsDTO
    {
        [DataMember()]
        public int ID { get; set; }

        [DataMember()]
        public Int32 WeekNameMasterID { get; set; }

        [DataMember()]
        public System.TimeSpan StartTime { get; set; }

        [DataMember()]
        public System.TimeSpan EndTime { get; set; }

        [DataMember()]
        public int ScheduleMasterID { get; set; }

    }
}
