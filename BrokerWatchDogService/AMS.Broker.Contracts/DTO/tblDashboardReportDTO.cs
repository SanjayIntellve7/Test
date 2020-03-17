using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class tblDashboardReportDTO
    {

        [DataMember]
        public int ReportId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ReportParentID { get; set; }

        [DataMember]
        public string Controller { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public string SVG { get; set; }

        [DataMember]
        public bool IsAccess { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
