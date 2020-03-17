using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetITMSEChallanHomeDashboard_ResultDTO
    {
        [DataMember()]
        public Nullable<decimal> ChallanAmount { get; set; }

        [DataMember()]
        public string Entity { get; set; }

        [DataMember()]
        public Nullable<long> DeviceID { get; set; }

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public Nullable<double> Lat { get; set; }

        [DataMember()]
        public Nullable<double> Long { get; set; }

        [DataMember()]
        public string JunctionName { get; set; }

        [DataMember()]
        public string ZoneName { get; set; }

        [DataMember()]
        public int DeviceStatus { get; set; }
    }
}
