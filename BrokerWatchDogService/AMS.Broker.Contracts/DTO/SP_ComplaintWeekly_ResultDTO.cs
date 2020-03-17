using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ComplaintWeekly_ResultDTO
    {
        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Int32> ComplaintCount { get; set; }

         [DataMember()]
        public string Status { get; set; }
       

        public SP_ComplaintWeekly_ResultDTO()
        {
        }

        public SP_ComplaintWeekly_ResultDTO(String weekDay, Nullable<DateTime> tXDate, Nullable<Int32> complaintCount, string status)
        {
            this.WeekDay = weekDay;
            this.TXDate = tXDate;
            this.ComplaintCount = complaintCount;
            this.Status = status;
        }
    }
}
