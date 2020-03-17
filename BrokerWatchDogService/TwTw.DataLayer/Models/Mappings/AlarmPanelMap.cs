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
    public class AlarmPanelMap : EntityTypeConfiguration<AlarmPanel>
    {
        public AlarmPanelMap()
        {
            // Primary Key
            this.HasKey(t => t.AlarmPanelId);

            // Properties
            this.Property(t => t.AlarmPanelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AlarmPanel");
            this.Property(t => t.AlarmPanelId).HasColumnName("AlarmPanelId");

            // Relationships
            this.HasRequired(t => t.Interface)
                .WithOptional(t => t.AlarmPanel);

            // Relationships
            this.HasRequired(t => t.EventTypeTemplate);
        }
    }
}
