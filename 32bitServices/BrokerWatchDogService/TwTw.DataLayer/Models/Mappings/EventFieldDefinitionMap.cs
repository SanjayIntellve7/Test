using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models.Mappings
{
    public class EventFieldDefinitionMap : EntityTypeConfiguration<EventFieldDefinition>
    {
        public EventFieldDefinitionMap()
        {
            // Primary Key
            this.HasKey(t => t.EventFieldId);

            // Properties
            this.Property(t => t.FieldName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EventFieldDefinition");
            this.Property(t => t.EventFieldId).HasColumnName("EventFieldId");
            this.Property(t => t.EventTypeId).HasColumnName("EventTypeId");
            this.Property(t => t.FieldName).HasColumnName("FieldName");
            this.Property(t => t.StartByte).HasColumnName("StartByte");
            this.Property(t => t.NumberOfBytes).HasColumnName("NumberOfBytes");
            this.Property(t => t.FieldTypeId).HasColumnName("FieldTypeId");

            // Relationships
            this.HasRequired(t => t.EventFieldType)
                .WithMany(t => t.EventFieldDefinitions)
                .HasForeignKey(d => d.FieldTypeId);
            this.HasRequired(t => t.EventTypeTemplate)
                .WithMany(t => t.EventFieldDefinitions)
                .HasForeignKey(d => d.EventTypeId);

        }
    }
}
