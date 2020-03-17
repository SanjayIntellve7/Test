using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetITMSHomeDashboard_ResultDTO
    {


        [DataMember()]
        public Nullable<int> TotalCount { get; set; }

        [DataMember()]
        public string Entity { get; set; }

        [DataMember()]
        public Nullable<long> AlertId { get; set; }

        [DataMember()]
        public string MessageTypeId { get; set; }

        [DataMember()]
        public string JunctionName { get; set; }

        [DataMember()]
        public string ZoneName { get; set; }

        [DataMember()]
        public string VehNum { get; set; }

        [DataMember()]
        public string EqpId { get; set; }

        [DataMember()]
        public double Lat { get; set; }

        [DataMember()]
        public double Long { get; set; }

        [DataMember()]
        public int DeviceStatus { get; set; }
       

      
    }
}
