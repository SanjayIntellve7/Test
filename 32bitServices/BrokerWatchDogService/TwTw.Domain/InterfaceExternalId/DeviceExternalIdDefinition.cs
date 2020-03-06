using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwTw.Domain.InterfaceExternalId
{
    public partial class DeviceExternalIdDefinition
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Interface")]
        public int InterfaceId { get; set; }
        //[Key]
        [Column(Order = 2)]
        [ForeignKey("EventFieldDefinition")]
        public int EventFieldId { get; set; }
        public int order { get; set; }
        public virtual EventFieldDefinition EventFieldDefinition { get; set; }
        public virtual InterfaceExternalIdDefinition Interface { get; set; }
    }
}
