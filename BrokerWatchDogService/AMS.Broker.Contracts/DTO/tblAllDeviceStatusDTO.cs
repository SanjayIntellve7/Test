using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblAllDeviceStatusDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int64> DeviceID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatusTypeID { get; set; }

        [DataMember()]
        public String StatusDescription { get; set; }

        [DataMember()]
        public Nullable<DateTime> StatusDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatus { get; set; }

        [DataMember()]
        public String DeviceType { get; set; }

        public tblAllDeviceStatusDTO()
        {
        }

        public tblAllDeviceStatusDTO(Int32 iD, Nullable<Int64> deviceID, Nullable<Int32> deviceStatusTypeID, String statusDescription, Nullable<DateTime> statusDateTime, Nullable<Int32> deviceStatus, string deviceType)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.DeviceStatusTypeID = deviceStatusTypeID;
            this.StatusDescription = statusDescription;
            this.StatusDateTime = statusDateTime;
            this.DeviceStatus = deviceStatus;
            this.DeviceType = deviceType;
        }
    }
}
