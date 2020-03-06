using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(Info)), KnownType(typeof(DeviceDto)), Serializable]
    [DebuggerDisplay("{AlertId}")]
    public class SPTest_ResultDto
    {
        [DataMember]
        public long AlertId { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public System.DateTime Sent { get; set; }

        [DataMember]
        public string StatusId { get; set; }

        [DataMember]
        public string MessageTypeId { get; set; }

        [DataMember]
        public string ScopeId { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Restriction { get; set; }

        [DataMember]
        public string Addresses { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public string References { get; set; }

        [DataMember]
        public string Incidents { get; set; }

        [DataMember]
        public Nullable<long> DeviceId { get; set; }

        [DataMember]
        public Nullable<System.DateTime> ReceivedDateTime { get; set; }

        [DataMember]
        public Nullable<System.Guid> MembershipUserId { get; set; }

        [DataMember]
        public string AlertOwner { get; set; }
    }
}
