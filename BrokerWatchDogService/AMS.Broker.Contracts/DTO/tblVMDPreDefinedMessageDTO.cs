using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVMDPreDefinedMessageDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Predefinedmessage { get; set; }

        public tblVMDPreDefinedMessageDTO()
        {
        }

        public tblVMDPreDefinedMessageDTO(Int32 iD, String predefinedmessage)
        {
            this.ID = iD;
            this.Predefinedmessage = predefinedmessage;
        }
    }
}
