using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPredefinedMsgMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Msg { get; set; }

        [DataMember()]
        public Boolean IsEnable { get; set; }

        [DataMember()]
        public String Event_ { get; set; }

        public tblPredefinedMsgMasterDTO()
        {
        }

        public tblPredefinedMsgMasterDTO(Int32 iD, String msg, Boolean isEnable, String event_)
        {
            this.ID = iD;
            this.Msg = msg;
            this.IsEnable = isEnable;
            this.Event_ = event_;
        }
    }
}
