using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblBarcoVideoWallTxnDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> PerspectiveID { get; set; }

        [DataMember()]
        public Nullable<Int32> DisplayID { get; set; }

        [DataMember()]
        public Nullable<DateTime> AssignDateTime { get; set; }

        [DataMember()]
        public String AuthToken { get; set; }

        [DataMember()]
        public String Operation { get; set; }

        public tblBarcoVideoWallTxnDTO()
        {
        }

        public tblBarcoVideoWallTxnDTO(Int64 iD, Nullable<Int32> perspectiveID, Nullable<Int32> displayID, Nullable<DateTime> assignDateTime, String authToken, String operation)
        {
            this.ID = iD;
            this.PerspectiveID = perspectiveID;
            this.DisplayID = displayID;
            this.AssignDateTime = assignDateTime;
            this.AuthToken = authToken;
            this.Operation = operation;
        }
    }
}
