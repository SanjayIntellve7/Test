using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTw.Domain.ObjectsAssociations
{
    [Table("ObjectType")]
    public partial class ObjectType
    {
        public ObjectType()
        {
            this.ObjectsAssociations = new List<ObjectsAssociation>();
        }

        [Key]
        public int ObjectTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ObjectsAssociation> ObjectsAssociations { get; set; }
    }
}
