using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMBinAlertWeekly_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> AlertCount { get; set; }

        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TempDate { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        public SP_SWMBinAlertWeekly_ResultDTO()
        {
        }

        public SP_SWMBinAlertWeekly_ResultDTO(Nullable<Int32> alertCount, String weekDay, Nullable<DateTime> tempDate, String messageTypeId)
        {
            this.AlertCount = alertCount;
            this.WeekDay = weekDay;
            this.TempDate = tempDate;
            this.MessageTypeId = messageTypeId;
        }
    }
}
