using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwTw.Domain.InterfaceExternalId
{
    [Table("EventFieldDefinition")]
    public partial class EventFieldDefinition
    {
        public EventFieldDefinition()
        {
            this.DeviceExternalIdDefinitions = new List<DeviceExternalIdDefinition>();
        }

        public int EventFieldId { get; set; }
        [ForeignKey("EventTypeTemplate")]
        public int EventTypeId { get; set; }
        public string FieldName { get; set; }
        public int StartByte { get; set; }
        public int NumberOfBytes { get; set; }
        public int FieldTypeId { get; set; }
        public virtual ICollection<DeviceExternalIdDefinition> DeviceExternalIdDefinitions { get; set; }
        public virtual EventFieldType EventFieldType { get; set; }
        public virtual EventTypeTemplate EventTypeTemplate { get; set; }
    }
}
