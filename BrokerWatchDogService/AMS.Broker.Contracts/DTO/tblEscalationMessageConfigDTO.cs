using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblEscalationMessageConfigDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> EscalationConfigDetailsID { get; set; }

        [DataMember()]
        public Nullable<Int32> MessageTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> MaxTime { get; set; }

        public tblEscalationMessageConfigDTO()
        {
        }

        public tblEscalationMessageConfigDTO(Int32 iD, Nullable<Int32> escalationConfigDetailsID, Nullable<Int32> messageTypeID, Nullable<Int32> maxTime)
        {
            this.ID = iD;
            this.EscalationConfigDetailsID = escalationConfigDetailsID;
            this.MessageTypeID = messageTypeID;
            this.MaxTime = maxTime;
        }
    }
}
