using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMQuantityDispensedTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> TempDate { get; set; }

        [DataMember()]
        public String QtyDispensed { get; set; }

        public SP_WATMQuantityDispensedTrend_ResultDTO()
        {
        }

        public SP_WATMQuantityDispensedTrend_ResultDTO(Nullable<DateTime> tempDate, String qtyDispensed)
        {
            this.TempDate = tempDate;
            this.QtyDispensed = qtyDispensed;
        }
    }
}
