using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTEnergyWeeklyConsumption_ResultDTO
    {
        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Int32> EnergyConsumption { get; set; }

        public SP_IOTEnergyWeeklyConsumption_ResultDTO()
        {
        }

        public SP_IOTEnergyWeeklyConsumption_ResultDTO(String weekDay, Nullable<DateTime> tXDate, Nullable<Int32> energyConsumption)
        {
            this.WeekDay = weekDay;
            this.TXDate = tXDate;
            this.EnergyConsumption = energyConsumption;
        }
    }
}
