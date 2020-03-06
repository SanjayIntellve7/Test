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
    public class EventTypeTemplateMap : EntityTypeConfiguration<EventTypeTemplate>
    {
        public EventTypeTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.EventTypeTemplateId);

            // Properties
            this.Property(t => t.EventTypeTemplateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EventTemplateName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ExternalId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Discriminator)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EventTypeTemplate");
            this.Property(t => t.EventTypeTemplateId).HasColumnName("EventTypeTemplateId");
            this.Property(t => t.EventTemplateName).HasColumnName("EventTemplateName");
            this.Property(t => t.ExternalId).HasColumnName("ExternalId");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
        }
    }
}
