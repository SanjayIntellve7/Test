using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    

    [DataContract()]
    public class IncidentEvidenceInfoDTO
    {
        [DataMember()]
        public string Location { get; set; }

        [DataMember()]
        public string Source { get; set; }

        [DataMember()]
        public string Owner { get; set; }

        [DataMember()]
        public string AttachDateTime { get; set; }

        [DataMember()]
        public string EvidenceType { get; set; }

        [DataMember()]
        public string RefAlertID { get; set; }

        [DataMember()]
        public string RefIrID { get; set; }

        [DataMember()]
        public string AttachedCameraID { get; set; }

        [DataMember()]
        public Guid ResourceID { get; set; }

        [DataMember()]
        public string AlertID { get; set; }       

        [DataMember()]
        public double Lattitude { get; set; }

        [DataMember()]
        public double Longitude { get; set; }
    }
}
