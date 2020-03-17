using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ComplaintlapsedTime_ResultDTO
    {
         [DataMember()]
        public Nullable<Int32> LagTime { get; set; }

        [DataMember()]
        public String WeekName { get; set; }

        [DataMember()]
        public Nullable<DateTime> SentDate { get; set; }

        public SP_ComplaintlapsedTime_ResultDTO()
        {
        }

        public SP_ComplaintlapsedTime_ResultDTO(Nullable<Int32> lagTime, String weekName, Nullable<DateTime> sentDate)
        {
            this.LagTime = lagTime;
            this.WeekName = weekName;
            this.SentDate = sentDate;
        }
    }
}
