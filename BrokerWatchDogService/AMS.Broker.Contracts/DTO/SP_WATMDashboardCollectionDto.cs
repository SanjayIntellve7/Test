using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMDashboardCollection_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalCollection { get; set; }

        public SP_WATMDashboardCollection_ResultDTO()
        {
        }

        public SP_WATMDashboardCollection_ResultDTO(Int32 iD, Nullable<Decimal> totalCollection)
        {
            this.ID = iD;
            this.TotalCollection = totalCollection;
        }
    }
}
