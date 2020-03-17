using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTMapDashboard_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Todayconsumption { get; set; }

        [DataMember()]
        public Nullable<Int32> YesterdayConsumption { get; set; }

        [DataMember()]
        public Nullable<Int32> LastWeekConsumption { get; set; }

        [DataMember()]
        public Nullable<Int32> Thismonthconsumption { get; set; }

        public SP_IOTMapDashboard_ResultDTO()
        {
        }

        public SP_IOTMapDashboard_ResultDTO(Nullable<Int32> todayconsumption, Nullable<Int32> yesterdayConsumption, Nullable<Int32> lastWeekConsumption, Nullable<Int32> thismonthconsumption)
        {
            this.Todayconsumption = todayconsumption;
            this.YesterdayConsumption = yesterdayConsumption;
            this.LastWeekConsumption = lastWeekConsumption;
            this.Thismonthconsumption = thismonthconsumption;
        }
    }
}
