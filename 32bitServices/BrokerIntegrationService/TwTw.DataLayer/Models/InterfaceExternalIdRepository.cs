using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwTw.Domain;
using TwTw.Domain.InterfaceExternalId;

namespace TwTw.DataLayer.Models
{ 
    public class InterfaceExternalIdRepository : IInterfaceExternalIdDefinitionRepository
    {
        InterfaceExternalIdContext context = new InterfaceExternalIdContext();

        public IQueryable<InterfaceExternalIdDefinition> All
        {
            get { return context.InterfaceExternalIdDefinitions; }
        }

        public IQueryable<InterfaceExternalIdDefinition> AllIncluding(params Expression<Func<InterfaceExternalIdDefinition, object>>[] includeProperties)
        {
            IQueryable<InterfaceExternalIdDefinition> query = context.InterfaceExternalIdDefinitions;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public InterfaceExternalIdDefinition Find(int id)
        {
            return context.InterfaceExternalIdDefinitions.Find(id);
        }

        public void InsertOrUpdate(InterfaceExternalIdDefinition interfaceexternaliddefinition)
        {
            if (interfaceexternaliddefinition.InterfaceId == default(int)) {
                // New entity
                throw new Exception("Interface does not exist!");
            } else
            {

               // InterfaceExternalIdDefinition interfaceDef = this.Find(interfaceexternaliddefinition.InterfaceId);
              //  interfaceexternaliddefinition.DeviceExternalIdDefinitions.Clear();
                context.Entry(interfaceexternaliddefinition).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var interfaceexternaliddefinition = context.InterfaceExternalIdDefinitions.Find(id);
            interfaceexternaliddefinition.DeviceExternalIdDefinitions.Clear();
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

    public interface IInterfaceExternalIdDefinitionRepository : IDisposable
    {
        IQueryable<InterfaceExternalIdDefinition> All { get; }
        IQueryable<InterfaceExternalIdDefinition> AllIncluding(params Expression<Func<InterfaceExternalIdDefinition, object>>[] includeProperties);
        InterfaceExternalIdDefinition Find(int id);
        void InsertOrUpdate(InterfaceExternalIdDefinition interfaceexternaliddefinition);
        void Delete(int id);
        void Save();
    }
}