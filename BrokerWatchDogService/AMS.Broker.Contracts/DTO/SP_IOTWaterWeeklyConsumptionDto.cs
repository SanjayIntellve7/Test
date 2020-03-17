using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTWaterWeeklyConsumption_ResultDTO
    {
        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Int32> WaterConsumption { get; set; }

        public SP_IOTWaterWeeklyConsumption_ResultDTO()
        {
        }

        public SP_IOTWaterWeeklyConsumption_ResultDTO(String weekDay, Nullable<DateTime> tXDate, Nullable<Int32> waterConsumption)
        {
            this.WeekDay = weekDay;
            this.TXDate = tXDate;
            this.WaterConsumption = waterConsumption;
        }
    }
}
