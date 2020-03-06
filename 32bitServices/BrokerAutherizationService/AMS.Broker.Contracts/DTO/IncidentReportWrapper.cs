using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class IncidentReportWrapper
    {

        [DataMember]
        public IncidentReport Report { get; set; }

        [DataMember]
        public bool AlertExistsInAnotherReport { get; set; }

        //[DataMember]
        //public Alert Alert { get; set; }

        [DataMember]
        public string Message { get; set; }

       

    }
}
