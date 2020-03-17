using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{   
    [DataContract()]
    public partial class EquipmentTypeDto
    {
        [DataMember()]
        public int ID { get; set; }

        [DataMember()]
        public int EqpTypeId { get; set; }

        [DataMember()]
        public String EqpTypeName { get; set; }

        public EquipmentTypeDto()
        {
        }
    }
}
