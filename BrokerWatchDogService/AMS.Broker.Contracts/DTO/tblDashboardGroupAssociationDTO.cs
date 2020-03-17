using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblDashboardGroupAssociationDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int ReportId { get; set; }

        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public tblDashboardReportDTO Report { get; set; }

    }
}
