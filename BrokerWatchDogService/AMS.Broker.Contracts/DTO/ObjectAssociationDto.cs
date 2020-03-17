using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public partial class ObjectsAssociationDto
    {
       [DataMember()]
        public int ObjectsAssociationId { get; set; }

        [DataMember()]
        public int Object1Identity { get; set; }

        [DataMember()]
        public int Object2Identity { get; set; }

        [DataMember()]        
        public int ObjectTypeId { get; set; }

        [DataMember()]
        public virtual ObjectTypeDto ObjectType { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }
    }



    public partial class ObjectTypeDto
    {
        public ObjectTypeDto()
        {
            this.ObjectsAssociations = new List<ObjectsAssociationDto>();
        }

        
        public int ObjectTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ObjectsAssociationDto> ObjectsAssociations { get; set; }
    }
}
