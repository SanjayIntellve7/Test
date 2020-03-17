using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblViolationTypeMasterDTO //01112019
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> ViolationID { get; set; }

        [DataMember()]
        public String ViolationDetails { get; set; }

        public tblViolationTypeMasterDTO()
        {
        }

        public tblViolationTypeMasterDTO(Int32 iD, Nullable<Int32> violationID, String violationDetails)
        {
            this.ID = iD;
            this.ViolationID = violationID;
            this.ViolationDetails = violationDetails;
        }
    }

}
