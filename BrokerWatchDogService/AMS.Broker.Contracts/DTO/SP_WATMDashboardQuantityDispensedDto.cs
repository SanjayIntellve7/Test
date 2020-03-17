using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMDashboardQuantityDispensed_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalQuantityDispensed { get; set; }

        public SP_WATMDashboardQuantityDispensed_ResultDTO()
        {
        }

        public SP_WATMDashboardQuantityDispensed_ResultDTO(Int32 iD, Nullable<Decimal> totalQuantityDispensed)
        {
            this.ID = iD;
            this.TotalQuantityDispensed = totalQuantityDispensed;
        }
    }
}
