using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMKPIBinAlert_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TotalALert { get; set; }

        [DataMember()]
        public Nullable<Int32> Totalassigned { get; set; }

        [DataMember()]
        public Nullable<Int32> TotalClosed { get; set; }

        public SP_SWMKPIBinAlert_ResultDTO()
        {
        }

        public SP_SWMKPIBinAlert_ResultDTO(Nullable<Int32> totalALert, Nullable<Int32> totalassigned, Nullable<Int32> totalClosed)
        {
            this.TotalALert = totalALert;
            this.Totalassigned = totalassigned;
            this.TotalClosed = totalClosed;
        }
    }
}
