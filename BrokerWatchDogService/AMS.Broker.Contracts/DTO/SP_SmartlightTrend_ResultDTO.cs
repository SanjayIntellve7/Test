using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public partial class SP_SmartlightTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> Tempdate { get; set; }

        [DataMember()]
        public Nullable<Int32> ID { get; set; }

        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDatetime { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public Nullable<DateTime> Uptime { get; set; }

        [DataMember()]
        public String Consumption { get; set; }

        [DataMember()]
        public Nullable<Double> ConsumptionValue { get; set; }

        [DataMember()]
        public String LightStatus { get; set; }

        [DataMember()]
        public Nullable<Double> EnergyCost { get; set; }

        [DataMember()]
        public String BurnTime { get; set; }

        public SP_SmartlightTrend_ResultDTO()
        {
        }

        public SP_SmartlightTrend_ResultDTO(Nullable<DateTime> tempdate, Nullable<Int32> iD, Nullable<Int32> hour, Nullable<DateTime> receivedDatetime, Nullable<Int32> deviceID, Nullable<DateTime> uptime, String consumption, Nullable<Double> consumptionValue, String lightStatus, Nullable<Double> energyCost, String burnTime)
        {
            this.Tempdate = tempdate;
            this.ID = iD;
            this.Hour = hour;
            this.ReceivedDatetime = receivedDatetime;
            this.DeviceID = deviceID;
            this.Uptime = uptime;
            this.Consumption = consumption;
            this.ConsumptionValue = consumptionValue;
            this.LightStatus = lightStatus;
            this.EnergyCost = energyCost;
            this.BurnTime = burnTime;
        }
    }
}
