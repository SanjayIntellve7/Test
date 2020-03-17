using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class WATMAllDeviceCollection
    {

        [DataMember]
        public List<WATMDeviceCollection> WATMDeviceCollection { get; set; }


    }

}