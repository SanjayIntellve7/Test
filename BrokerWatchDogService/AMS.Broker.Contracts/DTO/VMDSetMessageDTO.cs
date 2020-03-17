using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
  
    [DataContract()]
    public partial class VMDSetMessageDTO //01112019
    {
        [DataMember()]
        public string AllSelectedDevId { get; set; }

        [DataMember()]
        public string VmdMessage { get; set; }

        [DataMember()]
        public Guid authToken { get; set; }

       [DataMember()]
        public  string deviceid { get; set; }

        [DataMember()]
       public string imagebyte { get; set; }
    }
}
