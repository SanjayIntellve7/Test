using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMBinCollectionPcikedStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> PickedStatusCount { get; set; }

        [DataMember()]
        public String PickedStatus { get; set; }

        public SP_SWMBinCollectionPcikedStatus_ResultDTO()
        {
        }

        public SP_SWMBinCollectionPcikedStatus_ResultDTO(Nullable<Int32> pickedStatusCount, String pickedStatus)
        {
            this.PickedStatusCount = pickedStatusCount;
            this.PickedStatus = pickedStatus;
        }
    }
}
