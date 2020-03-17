using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class BMCRemedyTxnDto
    {
        [DataMember()]
        public String IncidentNumber  { get; set; }

        [DataMember()]
        public String CustomerFirstName { get; set; }

        [DataMember()]
        public String CustomerLastName { get; set; }

        [DataMember()]
        public String ServiceType  { get; set; }

        [DataMember()]
        public String Impact { get; set; }

        [DataMember()]
        public String Urgency { get; set; }

        [DataMember()]
        public String Summary { get; set; }

        [DataMember()]
        public String OperationalCategorizationTier1  { get; set; }

        [DataMember()]
        public String OperationalCategorizationTier2 { get; set; }

        [DataMember()]
        public String OperationalCategorizationTier3 { get; set; }

        [DataMember()]
        public String DetailedDescription  { get; set; }

        [DataMember()]
        public String AssignedGroup  { get; set; }

        [DataMember()]
        public String Assignee { get; set; }

        [DataMember()]
        public String TicketStatus { get; set; }


        [DataMember()]
        public String SubmitDate { get; set; }

        [DataMember()]
        public String ResolutionDetails { get; set; }

        public BMCRemedyTxnDto()
        {
        }

        public BMCRemedyTxnDto(String incidentNumber, String customerFirstName, String customerLastName, String serviceType, String impact, String urgency, String summary,
            String operationalCategorizationTier1, String operationalCategorizationTier2, String operationalCategorizationTier3, String detailedDescription, String assignedGroup, String assignee, String ticketStatus,
            String submitDate, String resolutionDetails)
        {
            this.IncidentNumber = incidentNumber;
            this.CustomerFirstName = customerFirstName;
            this.CustomerLastName = customerLastName;
            this.ServiceType = serviceType;
            this.Impact = impact;
            this.Urgency = urgency;
            this.Summary = summary;
            this.OperationalCategorizationTier1 = operationalCategorizationTier1;
            this.OperationalCategorizationTier2 = operationalCategorizationTier2;
            this.OperationalCategorizationTier3 = operationalCategorizationTier3;
             this.DetailedDescription = detailedDescription;
            this.AssignedGroup = assignedGroup;
            this.Assignee = assignee;
             this.TicketStatus = ticketStatus;
            this.SubmitDate = submitDate;
            this.ResolutionDetails = resolutionDetails;
        }
    }
}
