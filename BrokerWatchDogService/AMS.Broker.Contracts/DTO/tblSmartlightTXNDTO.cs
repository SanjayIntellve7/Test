using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSmartlightTXNDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public Nullable<DateTime> UPTime { get; set; }

        [DataMember()]
        public String Consumption { get; set; }

        [DataMember()]
        public Nullable<Double> ConsumptionValue { get; set; }

        [DataMember()]
        public String LightStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDatetime { get; set; }

        public tblSmartlightTXNDTO()
        {
        }

        public tblSmartlightTXNDTO(Int32 iD, Nullable<Int32> deviceID, Nullable<DateTime> uPTime, String consumption, Nullable<Double> consumptionValue, String lightStatus, Nullable<DateTime> receivedDatetime)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.UPTime = uPTime;
            this.Consumption = consumption;
            this.ConsumptionValue = consumptionValue;
            this.LightStatus = lightStatus;
            this.ReceivedDatetime = receivedDatetime;
        }
    }
}
