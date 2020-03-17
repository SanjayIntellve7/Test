using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class ChallanDetails
    {
        [DataMember]
        public string ChallanId { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string ChallanDate { get; set; }
        [DataMember]
        public string JunctionName { get; set; }
        [DataMember]
        public string OwnerName { get; set; }
        [DataMember]
        public string OwnerAddress { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string ViolationType { get; set; }
        [DataMember]
        public string EqpId { get; set; }
        [DataMember]
        public string VehicleColor { get; set; }
        [DataMember]
        public string MakeModel { get; set; }
        [DataMember]
        public string ChallanAmount { get; set; }
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public string ImageFileName { get; set; }
        [DataMember]
        public string ImageFileName1 { get; set; }
        [DataMember]
        public string ImageFileName2 { get; set; }
        [DataMember]
        public string ImageFileName3 { get; set; }
        [DataMember]
        public string ChallanType { get; set; }

    }
}
