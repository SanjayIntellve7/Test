using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetANPRStatusLabel_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> LHSFromDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> LHSToDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> RHSFromDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> RHSToDateTime { get; set; }

        public SP_GetANPRStatusLabel_ResultDTO()
        {
        }
        public SP_GetANPRStatusLabel_ResultDTO(Nullable<DateTime> lHSFromDateTime, Nullable<DateTime> lHSToDateTime, Nullable<DateTime> rHSFromDateTime, Nullable<DateTime> rHSToDateTime)
        {
            this.LHSFromDateTime = lHSFromDateTime;
            this.LHSToDateTime = lHSToDateTime;
            this.RHSFromDateTime = rHSFromDateTime;
            this.RHSToDateTime = rHSToDateTime;
        }
    }
}
