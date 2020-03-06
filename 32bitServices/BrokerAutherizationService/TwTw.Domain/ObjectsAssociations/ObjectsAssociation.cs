using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTw.Domain.ObjectsAssociations
{
    [Table("ObjectsAssociation")]
    public partial class ObjectsAssociation
    {
        [Key]
        public int ObjectsAssociationId { get; set; }
        public int Object1Identity { get; set; }
        public int Object2Identity { get; set; }
        [ForeignKey("ObjectType")]
        public int ObjectTypeId { get; set; }
        public virtual ObjectType ObjectType { get; set; }
    }
}
