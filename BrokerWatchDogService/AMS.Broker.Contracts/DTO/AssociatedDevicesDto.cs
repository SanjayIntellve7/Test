using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public partial class AssociatedDevicesDto
    {
        [DataMember()]
        public Int32 AssociationId { get; set; }

        [DataMember()]
        public Int32 Object1Identity { get; set; }

        [DataMember()]
        public Int32 Object2Identity { get; set; }

        [DataMember()]
        public string Object2Name { get; set; }
    }
}