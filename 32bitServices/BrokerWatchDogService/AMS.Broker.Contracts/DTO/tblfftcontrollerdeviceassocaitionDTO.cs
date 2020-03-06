using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblfftcontrollerdeviceassocaitionDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> ControllerID { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorID { get; set; }

        [DataMember()]
        public Nullable<Int32> ZoneID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public Nullable<Int32> PresetNo { get; set; }

        public tblfftcontrollerdeviceassocaitionDTO()
        {
        }

        public tblfftcontrollerdeviceassocaitionDTO(Int32 iD, Nullable<Int32> controllerID, Nullable<Int32> sensorID, Nullable<Int32> zoneID, Nullable<Int32> deviceID, Nullable<Int32> presetNo)
        {
            this.ID = iD;
            this.ControllerID = controllerID;
            this.SensorID = sensorID;
            this.ZoneID = zoneID;
            this.DeviceID = deviceID;
            this.PresetNo = presetNo;
        }
    }
}
