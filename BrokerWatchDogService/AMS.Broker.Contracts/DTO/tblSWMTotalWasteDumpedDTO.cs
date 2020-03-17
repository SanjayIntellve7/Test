using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSWMTotalWasteDumpedDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String TotalWasteDumped { get; set; }

        [DataMember()]
        public Nullable<DateTime> WasteDumpedDate { get; set; }

        [DataMember()]
        public Nullable<Int32> WardNo { get; set; }

        public tblSWMTotalWasteDumpedDTO()
        {
        }

        public tblSWMTotalWasteDumpedDTO(Int64 iD, String totalWasteDumped, Nullable<DateTime> wasteDumpedDate, Nullable<Int32> wardNo)
        {
            this.ID = iD;
            this.TotalWasteDumped = totalWasteDumped;
            this.WasteDumpedDate = wasteDumpedDate;
            this.WardNo = wardNo;
        }
    }
}
