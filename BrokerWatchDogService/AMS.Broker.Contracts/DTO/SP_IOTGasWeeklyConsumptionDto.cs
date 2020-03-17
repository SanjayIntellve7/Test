using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTGasWeeklyConsumption_ResultDTO
    {
        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Int32> GasConsumption { get; set; }

        public SP_IOTGasWeeklyConsumption_ResultDTO()
        {
        }

        public SP_IOTGasWeeklyConsumption_ResultDTO(String weekDay, Nullable<DateTime> tXDate, Nullable<Int32> gasConsumption)
        {
            this.WeekDay = weekDay;
            this.TXDate = tXDate;
            this.GasConsumption = gasConsumption;
        }
    }
}
