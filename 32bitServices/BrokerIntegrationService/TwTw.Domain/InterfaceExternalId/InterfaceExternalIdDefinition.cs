using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwTw.Domain.InterfaceExternalId
{
    [Table("Interface")]
    public partial class InterfaceExternalIdDefinition
    {
        public InterfaceExternalIdDefinition()
        {
            this.DeviceExternalIdDefinitions = new List<DeviceExternalIdDefinition>();
        }

        [Key]
        public int InterfaceId { get; set; }
        public int AccountId { get; set; }
        public int InterfaceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SiteId { get; set; }
        public AlarmPanel AlarmPanel { get; set; }
        
        public IList<DeviceExternalIdDefinition> DeviceExternalIdDefinitions { get; set; }
    }
}
