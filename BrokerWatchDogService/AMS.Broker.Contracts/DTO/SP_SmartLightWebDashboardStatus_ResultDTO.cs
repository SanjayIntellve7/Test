using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SP_SmartLightWebDashboardStatus_ResultDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string WardNo { get; set; }

        [DataMember]
        public string WardName { get; set; }

        [DataMember]
        public string FeederPillarNo { get; set; }

        [DataMember]
        public string PollNumber { get; set; }

        [DataMember]
        public string ExternalID { get; set; }

        [DataMember]
        public double Lat { get; set; }

        [DataMember]
        public double Long { get; set; }

        [DataMember]
        public Nullable<System.DateTime> ReadTimeStamp { get; set; }

        [DataMember]
        public Nullable<double> Current { get; set; }

        [DataMember]
        public Nullable<double> Voltage { get; set; }

        [DataMember]
        public Nullable<double> PowerFactor { get; set; }

        [DataMember]
        public Nullable<double> Watt { get; set; }

        [DataMember]
        public string LightStatus { get; set; }
    }
}
