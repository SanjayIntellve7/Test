using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSWMWardMasterDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String SupervisorName { get; set; }

        [DataMember()]
        public String SIName { get; set; }

        [DataMember()]
        public String Designation { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String Zone { get; set; }

        [DataMember()]
        public String MobileNo { get; set; }

        [DataMember()]
        public String SubZone { get; set; }

        public tblSWMWardMasterDTO()
        {
        }

        public tblSWMWardMasterDTO(Int64 iD, String wardName, String supervisorName, String sIName, String designation, String wardNo, String zone, String mobileNo, String subZone)
        {
            this.ID = iD;
            this.WardName = wardName;
            this.SupervisorName = supervisorName;
            this.SIName = sIName;
            this.Designation = designation;
            this.WardNo = wardNo;
            this.Zone = zone;
            this.MobileNo = mobileNo;
            this.SubZone = subZone;
        }
    }
}
