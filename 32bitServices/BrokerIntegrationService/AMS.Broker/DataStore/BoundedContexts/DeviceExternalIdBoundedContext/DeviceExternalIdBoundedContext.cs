using System.Data.Entity;

namespace AMS.Broker.IntegrationService.DataStore.BoundedContexts.DeviceExternalIdBoundedContext
{
    public class DeviceExternalIdBoundedContext : BaseContext<DeviceExternalIdBoundedContext>
    {
        public DbSet<DeviceExternalIdDefinition> DeviceExternalIdDefinitions { get; set; }
    }
}
