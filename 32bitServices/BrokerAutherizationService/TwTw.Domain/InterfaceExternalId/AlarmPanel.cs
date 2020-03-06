using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTw.Domain.InterfaceExternalId
{
    [Table("AlarmPanel")]
    public partial class AlarmPanel
    {
        [Key]
        public int AlarmPanelId { get; set; }
        [ForeignKey("EventTypeTemplate")]
        public int EventTypeTemplateId { get; set; }
        public virtual InterfaceExternalIdDefinition Interface { get; set; }
        public virtual EventTypeTemplate EventTypeTemplate { get; set; }

        //trupti01Sept15
        public virtual int AlarmPanelTypeId { get; set; }
        public virtual string InterfaceDeviceIP { get; set; }
        public virtual string InterfaceDevicePort { get; set; }
    }
}
