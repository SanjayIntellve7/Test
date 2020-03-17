using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class UniqueFault
    {
        [DataMember]
        public IEnumerable<string> FieldNames { get; set; }
        [DataMember]
        public string EntityName { get; set; }
    }
}
