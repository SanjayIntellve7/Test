using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblSWMVehicleMasterDTO
    {       
        [DataMember]
        public string DriverMobile { get; set; }
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string SimNo { get; set; }
        [DataMember]
        public List<int> tblSWMVehicleTXData_ID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string VehicleType { get; set; }
        [DataMember]
        public string WardNo { get; set; }
    }
}
