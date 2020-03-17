using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models.Mappings
{
    public class EventFieldTypeMap : EntityTypeConfiguration<EventFieldType>
    {
        public EventFieldTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.FieldTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Format)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EventFieldType");
            this.Property(t => t.FieldTypeId).HasColumnName("FieldTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Format).HasColumnName("Format");
        }
    }
}
