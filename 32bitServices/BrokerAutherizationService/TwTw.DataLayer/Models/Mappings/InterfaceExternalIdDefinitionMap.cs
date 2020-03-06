using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models.Mappings
{
    public class InterfaceExternalIdDefinitionMap : EntityTypeConfiguration<InterfaceExternalIdDefinition>
    {
        public InterfaceExternalIdDefinitionMap()
        {
            // Primary Key
            this.HasKey(t => t.InterfaceId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Interface");
            this.Property(t => t.InterfaceId).HasColumnName("InterfaceId");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.InterfaceTypeId).HasColumnName("InterfaceTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.SiteId).HasColumnName("SiteId");

        }
    }
}
