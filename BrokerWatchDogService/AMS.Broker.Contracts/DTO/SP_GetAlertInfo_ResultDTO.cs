using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetAlertInfo_ResultDTO
    {
        [DataMember()]
        public Nullable<int> Count { get; set; }

        [DataMember()]
        public string Entity { get; set; }

        [DataMember()]
        public string SeverityId { get; set; }
    }
}
