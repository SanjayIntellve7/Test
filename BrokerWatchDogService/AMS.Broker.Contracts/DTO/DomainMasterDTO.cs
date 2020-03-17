using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class DomainMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String DomainName { get; set; }

        public DomainMasterDTO()
        {
        }

        public DomainMasterDTO(Int32 iD, String domainName)
        {
            this.ID = iD;
            this.DomainName = domainName;
        }
    }
}
