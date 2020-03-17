using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVMDDeviceMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String UniqueId { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public Nullable<Double> Latitude { get; set; }

        [DataMember()]
        public Nullable<Double> Longitude { get; set; }

        [DataMember()]
        public String Address { get; set; }

        [DataMember()]
        public Boolean Status { get; set; }

        public tblVMDDeviceMasterDTO()
        {
        }

        public tblVMDDeviceMasterDTO(Int32 iD, String name, String uniqueId, String iPAddress, Nullable<Double> latitude, Nullable<Double> longitude, String address, Boolean status)
        {
            this.ID = iD;
            this.Name = name;
            this.UniqueId = uniqueId;
            this.IPAddress = iPAddress;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Address = address;
            this.Status = status;
        }
    }
}
