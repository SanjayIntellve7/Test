using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class GeotrackLiveDataDto
    {
        [DataMember]
        public string imei { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string regno { get; set; }

        [DataMember]
        public string ignstatus { get; set; }

        [DataMember]
        public long datetime { get; set; }

        [DataMember]
        public string lat { get; set; }

        [DataMember]
        public string lon { get; set; }

        [DataMember]
        public string speed { get; set; }

        [DataMember]
        public string alt { get; set; }

        [DataMember]
        public string heading { get; set; }

        [DataMember]
        public string gpstatus { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string battery { get; set; }
    }
}

