using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPIDSSensorMasterDTO
    {  
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public Nullable<Int32> ControllerID { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorID { get; set; }

        [DataMember()]
        public String SensorName { get; set; }

        [DataMember()]
        public String ChannelNumber { get; set; }

        public tblPIDSSensorMasterDTO()
        {
        }

        public tblPIDSSensorMasterDTO(Int64 iD, Nullable<Int32> deviceID, Nullable<Int32> controllerID, Int32 sensorID, String sensorName, String channelNumber)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.ControllerID = controllerID;
            this.SensorID = sensorID;
            this.SensorName = SensorName;
            this.ChannelNumber = channelNumber;
        }

    }
}
