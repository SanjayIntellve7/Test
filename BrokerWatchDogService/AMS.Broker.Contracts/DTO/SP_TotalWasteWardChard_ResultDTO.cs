using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_TotalWasteWardChard_ResultDTO
    {
        [DataMember()]
        public Nullable<Double> TotalWasteDumped { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        public SP_TotalWasteWardChard_ResultDTO()
        {
        }

        public SP_TotalWasteWardChard_ResultDTO(Nullable<Double> totalWasteDumped, String wardName)
        {
            this.TotalWasteDumped = totalWasteDumped;
            this.WardName = wardName;
        }
    }
}
