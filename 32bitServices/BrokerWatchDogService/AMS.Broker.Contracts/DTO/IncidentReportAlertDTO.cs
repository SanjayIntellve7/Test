using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class IncidentReportAlertDTO
    {
        [DataMember()]
        public Int64 IncidentReportAlertsId { get; set; }

        [DataMember()]
        public Int64 IncidentReportId { get; set; }

        [DataMember()]
        public Int64 AlertId { get; set; }

        [DataMember()]
        public Nullable<Int32> Sequence { get; set; }

        [DataMember()]
        public String IncidentReportEvidence { get; set; }

         [DataMember()]
        public DateTime AttachedDateTime { get; set; }

        public IncidentReportAlertDTO()
        {
        }

        public IncidentReportAlertDTO(Int64 incidentReportAlertsId, Int64 incidentReportId, Int64 alertId, Nullable<Int32> sequence, String incidentReportEvidence, DateTime AttachedDateTime)
        {
            this.IncidentReportAlertsId = incidentReportAlertsId;
            this.IncidentReportId = incidentReportId;
            this.AlertId = alertId;
            this.Sequence = sequence;
            this.IncidentReportEvidence = incidentReportEvidence;
            this.AttachedDateTime = AttachedDateTime;
        }
    }
}

