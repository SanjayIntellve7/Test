using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblDashboardGroupMasterDTO
    {
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public string Name { get; set; }

        //[DataMember]
        //public List<tblDashboardGroupAssociationDTO> Reports { get; set; }

        [DataMember]
        public tblDashboardReportHierarchyDTO Reports { get; set; } // jatin 05022020

        public override string ToString()
        {
            return Name;
        }
    }
}
