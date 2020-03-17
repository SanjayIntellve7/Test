using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SurveillanceWebDashboard_ResultDTO
    {

        [DataMember()]
        public int TotalCount { get; set; }

        [DataMember()]
        public string Entity { get; set; }

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public long DeviceID { get; set; }

        [DataMember()]
        public double Lat { get; set; }

        [DataMember()]
        public double @long { get; set; }

        [DataMember()]
        public Nullable<System.DateTime> StatusDateTime { get; set; }

        [DataMember()]
        public string DeviceStatusType { get; set; }

        [DataMember()]
        public string MessagetypeID { get; set; }

        [DataMember()]
        public Nullable<int> Status { get; set; }
    }
}
