using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwTw.Domain.ObjectsAssociations;

namespace TwTw.DataLayer.Models
{ 
    public class ObjectTypeRepository : IObjectTypeRepository
    {
        ObjectsAssociationContext context = new ObjectsAssociationContext();

        public IQueryable<ObjectType> All
        {
            get { return context.ObjectTypes; }
        }

        public IQueryable<ObjectType> AllIncluding(params Expression<Func<ObjectType, object>>[] includeProperties)
        {
            IQueryable<ObjectType> query = context.ObjectTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ObjectType Find(int id)
        {
            return context.ObjectTypes.Find(id);
        }

        public void InsertOrUpdate(ObjectType objecttype)
        {
            if (objecttype.ObjectTypeId == default(int)) {
                // New entity
                context.ObjectTypes.Add(objecttype);
            } else {
                // Existing entity
                context.Entry(objecttype).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var objecttype = context.ObjectTypes.Find(id);
            context.ObjectTypes.Remove(objecttype);
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

    public interface IObjectTypeRepository : IDisposable
    {
        IQueryable<ObjectType> All { get; }
        IQueryable<ObjectType> AllIncluding(params Expression<Func<ObjectType, object>>[] includeProperties);
        ObjectType Find(int id);
        void InsertOrUpdate(ObjectType objecttype);
        void Delete(int id);
        void Save();
    }
}