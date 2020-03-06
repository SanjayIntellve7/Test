using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class IncidentReport
    {
        [DataMember]
        public DateTime CreationDate { get; set; }

         [DataMember]
         public string CreationDateAsString { get; set; }

         [DataMember]
         public string Owner { get; set; }

        [DataMember]
        public Int64 Id { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public List<Alert> Alerts { get; set; }

        [DataMember]
        public List<DeviceDto>Cameras { get; set; }

        [DataMember]
        public List<IncidentReportResource> Resources { get; set; }

        [DataMember]
        public List<long> IncidentReports { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public List<AttachedIncidentReport> AttachedIncidentRpt { get; set; }
    }


    [DataContract]
    public class IncidentReportResource
    {
        [DataMember] 
        public DateTime Appended {get; set;}

        [DataMember]
        public Guid ResourceId { get; set; }
    }


    [DataContract]
    public class AttachedIncidentReport
    {
        [DataMember]
        public string AttachedDatetime { get; set; }

        [DataMember]
        public long ReportID { get; set; }
    }

}
