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
    public class ObjectsAssociationMap : EntityTypeConfiguration<ObjectsAssociation>
    {
        public ObjectsAssociationMap()
        {
            // Primary Key
            this.HasKey(t => t.ObjectsAssociationId);

            // Properties
            this.Property(t => t.ObjectsAssociationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ObjectsAssociation");
            this.Property(t => t.ObjectsAssociationId).HasColumnName("objectAssociationId");
            this.Property(t => t.Object1Identity).HasColumnName("object1Identity");
            this.Property(t => t.Object2Identity).HasColumnName("object2Identity");
            this.Property(t => t.ObjectTypeId).HasColumnName("objectTypeId");

            // Relationships
            this.HasRequired(t => t.ObjectType)
                .WithMany(t => t.ObjectsAssociations)
                .HasForeignKey(d => d.ObjectTypeId);

        }
    }
}