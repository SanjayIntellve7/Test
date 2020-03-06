using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwTw.Domain.InterfaceExternalId
{
    public partial class EventFieldType
    {
        public EventFieldType()
        {
        }

        [Key]
        public int FieldTypeId { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public virtual ICollection<EventFieldDefinition> EventFieldDefinitions { get; set; }
    }
}
