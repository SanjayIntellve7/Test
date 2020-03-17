using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_EchallanCollectionTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<Double> TotalCOllection { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        public SP_EchallanCollectionTrend_ResultDTO()
        {
        }

        public SP_EchallanCollectionTrend_ResultDTO(Nullable<Double> totalCOllection, String junctionName)
        {
            this.TotalCOllection = totalCOllection;
            this.JunctionName = junctionName;
        }
    }
}
