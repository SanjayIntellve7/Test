using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMCollectionTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> TempDate { get; set; }

        [DataMember()]
        public String TotalCollection { get; set; }

        public SP_WATMCollectionTrend_ResultDTO()
        {
        }

        public SP_WATMCollectionTrend_ResultDTO(Nullable<DateTime> tempDate, String totalCollection)
        {
            this.TempDate = tempDate;
            this.TotalCollection = totalCollection;
        }
    }
}
