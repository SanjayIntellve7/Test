using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblAdditionalViolationDetailsDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> ViolationID { get; set; }

        [DataMember()]
        public String ViolationDesc { get; set; }

        public tblAdditionalViolationDetailsDTO()
        {
        }

        public tblAdditionalViolationDetailsDTO(Int32 iD, Nullable<Int32> violationID, String violationDesc)
        {
            this.ID = iD;
            this.ViolationID = violationID;
            this.ViolationDesc = violationDesc;
        }
    }
}
