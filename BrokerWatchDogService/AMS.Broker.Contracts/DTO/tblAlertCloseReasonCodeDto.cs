using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{  
    [DataContract()]
    public partial class tblAlertCloseReasonCodeDto
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public string ReasonCode { get; set; }
    }
}
