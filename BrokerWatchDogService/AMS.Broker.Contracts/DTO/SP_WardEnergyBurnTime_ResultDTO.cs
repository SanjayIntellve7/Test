using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SP_WardEnergyBurnTime_ResultDTO
    {
        [DataMember]
        public string WardName { get; set; }

        [DataMember]
        public string WardNo { get; set; }

        [DataMember]
        public string LedId { get; set; }

        [DataMember]
        public Nullable<System.DateTime> ReadTimeStamp { get; set; }

        [DataMember]
        public string OnOffStatus { get; set; }

        [DataMember]
        public Nullable<System.TimeSpan> Time { get; set; }

        [DataMember]
        public Nullable<System.TimeSpan> Lead { get; set; }

        [DataMember]
        public Nullable<int> Hour { get; set; }
                        
        [DataMember]
        public Nullable<double> Watt { get; set; }
    }
}
