using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwTw.Domain.ObjectsAssociations;

namespace TwTw.DataLayer.Models.Mappings
{
    public class ObjectTypeMap : EntityTypeConfiguration<ObjectType>
    {
        public ObjectTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ObjectTypeId);

            // Properties
            this.Property(t => t.ObjectTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ObjectType");
            this.Property(t => t.ObjectTypeId).HasColumnName("ObjectTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
