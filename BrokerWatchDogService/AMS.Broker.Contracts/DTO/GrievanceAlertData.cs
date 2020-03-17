using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class GrievanceAlertData
    {

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string PostedDateTime { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }

        [DataMember]
        public string LocationAddress { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string WardNo { get; set; }

        [DataMember]
        public string SiteImageUrl { get; set; }

        [DataMember]
        public long AlertID { get; set; }

        [DataMember]
        public string ComplaintType { get; set; }

        }
}
