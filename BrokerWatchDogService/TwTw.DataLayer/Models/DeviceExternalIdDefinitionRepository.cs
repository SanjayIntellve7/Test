using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models
{ 
    public class DeviceExternalIdDefinitionRepository : IDeviceExternalIdDefinitionRepository
    {
        InterfaceExternalIdContext context = new InterfaceExternalIdContext();

        public IQueryable<DeviceExternalIdDefinition> All
        {
            get { return context.DeviceExternalIdDefinitions; }
        }

        public IQueryable<DeviceExternalIdDefinition> AllIncluding(params Expression<Func<DeviceExternalIdDefinition, object>>[] includeProperties)
        {
            IQueryable<DeviceExternalIdDefinition> query = context.DeviceExternalIdDefinitions;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public DeviceExternalIdDefinition Find(int interfaceId, int eventFieldId)
        {
            return
                context.DeviceExternalIdDefinitions.FirstOrDefault(
                    e => e.InterfaceId == interfaceId && e.EventFieldId == eventFieldId);
        }

        public void Delete(int interfaceId, int eventFieldId)
        {
            var deviceexternaliddefinition = context.DeviceExternalIdDefinitions.FirstOrDefault(
                    e => e.InterfaceId == interfaceId && e.EventFieldId == eventFieldId);
            context.DeviceExternalIdDefinitions.Remove(deviceexternaliddefinition);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IDeviceExternalIdDefinitionRepository : IDisposable
    {
        IQueryable<DeviceExternalIdDefinition> All { get; }
        IQueryable<DeviceExternalIdDefinition> AllIncluding(params Expression<Func<DeviceExternalIdDefinition, object>>[] includeProperties);
        DeviceExternalIdDefinition Find(int interfaceId, int eventFieldId);
        void Delete(int interfaceId, int eventFieldId);
        void Save();
    }
}