using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTw.Domain.InterfaceExternalId
{
    [Table("EventTypeTemplate")]
    public partial class EventTypeTemplate
    {
        public EventTypeTemplate()
        {
            this.EventFieldDefinitions = new List<EventFieldDefinition>();
        }

        [Key]
        public int EventTypeTemplateId { get; set; }
        public string EventTemplateName { get; set; }
        public string ExternalId { get; set; }
        public string Discriminator { get; set; }
        public virtual ICollection<EventFieldDefinition> EventFieldDefinitions { get; set; }
    }
}
