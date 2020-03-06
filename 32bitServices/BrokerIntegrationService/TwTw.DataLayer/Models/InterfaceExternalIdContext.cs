using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AMS.Broker.DataStore;
using TwTw.DataLayer.Models.Mappings;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models
{
    public class InterfaceExternalIdContext : BaseContext<InterfaceExternalIdContext>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TwTw.DataLayer.Models.InterfaceExternalIdContext>());

        public DbSet<InterfaceExternalIdDefinition> InterfaceExternalIdDefinitions { get; set; }
        public DbSet<DeviceExternalIdDefinition> DeviceExternalIdDefinitions { get; set; }
        public DbSet<EventTypeTemplate> EventTypeTemplates { get; set; }
        public DbSet<EventFieldDefinition> EventFieldDefinitions { get; set; }
        public DbSet<EventFieldType> EventFieldTypes { get; set; }
        public DbSet<AlarmPanel> AlarmPanels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventTypeTemplateMap());
            modelBuilder.Configurations.Add(new EventFieldTypeMap());
            modelBuilder.Configurations.Add(new EventFieldDefinitionMap());
            modelBuilder.Configurations.Add(new DeviceExternalIdDefinitionMap());
            modelBuilder.Configurations.Add(new InterfaceExternalIdDefinitionMap());
            modelBuilder.Configurations.Add(new AlarmPanelMap());
        }
    }
}