using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models.Mappings
{
    public class DeviceExternalIdDefinitionMap : EntityTypeConfiguration<DeviceExternalIdDefinition>
    {
        public DeviceExternalIdDefinitionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.InterfaceId, t.EventFieldId, t.order });

            // Properties
            this.Property(t => t.InterfaceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EventFieldId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.order)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("DeviceExternalIdDefinition");
            this.Property(t => t.InterfaceId).HasColumnName("InterfaceId");
            this.Property(t => t.EventFieldId).HasColumnName("EventFieldId");
            this.Property(t => t.order).HasColumnName("order");

            // Relationships
            this.HasRequired(t => t.EventFieldDefinition)
                .WithMany(t => t.DeviceExternalIdDefinitions)
                .HasForeignKey(d => d.EventFieldId);
            this.HasRequired(t => t.Interface)
                .WithMany(t => t.DeviceExternalIdDefinitions)
                .HasForeignKey(d => d.InterfaceId);

        }
    }
}
