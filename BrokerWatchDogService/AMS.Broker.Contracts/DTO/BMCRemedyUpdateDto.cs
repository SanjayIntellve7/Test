using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class BMCRemedyUpdateDto
    {
        [DataMember()]
        public String IncidentNumber { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String StatusReason { get; set; }

        [DataMember()]
        public String ResolutionDetails { get; set; }

        public BMCRemedyUpdateDto()
        {
        }

        public BMCRemedyUpdateDto(String incidentNumber, String status, String statusReason, String resolutionDetails)
        {
            this.IncidentNumber = incidentNumber;
            this.StatusReason = statusReason;
            this.Status = status;
            this.ResolutionDetails = resolutionDetails;
        }
    }
}
