using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMDispenserStatusChart_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> TempDate { get; set; }

        [DataMember()]
        public Nullable<Int32> StatusCount { get; set; }

        public SP_WATMDispenserStatusChart_ResultDTO()
        {
        }

        public SP_WATMDispenserStatusChart_ResultDTO(Nullable<DateTime> tempDate, Nullable<Int32> statusCount)
        {
            this.TempDate = tempDate;
            this.StatusCount = statusCount;
        }
    }
}
