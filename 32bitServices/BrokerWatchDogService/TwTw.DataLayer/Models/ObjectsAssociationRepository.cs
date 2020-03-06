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
    public class ObjectsAssociationRepository : IObjectsAssociationRepository
    {
        ObjectsAssociationContext context = new ObjectsAssociationContext();

        public IQueryable<ObjectsAssociation> All
        {
            get { return context.ObjectsAssociations; }
        }

        public IQueryable<ObjectsAssociation> AllIncluding(params Expression<Func<ObjectsAssociation, object>>[] includeProperties)
        {
            IQueryable<ObjectsAssociation> query = context.ObjectsAssociations;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ObjectsAssociation Find(int id)
        {
            return context.ObjectsAssociations.Find(id);
        }

        public void InsertOrUpdate(ObjectsAssociation objectsAssociation)
        {
           var existingAssociation = this.All.FirstOrDefault(
                oa =>
                oa.Object1Identity == objectsAssociation.Object1Identity
                );
           if (existingAssociation!=null)
           {
               context.ObjectsAssociations.Remove(existingAssociation);
                // New entity
           }
           if (objectsAssociation.Object2Identity != 0)
           {
               context.ObjectsAssociations.Add(objectsAssociation);
           }
        }

        public void Delete(int id)
        {
            var objectsassociation = context.ObjectsAssociations.Find(id);
            context.ObjectsAssociations.Remove(objectsassociation);
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

    public interface IObjectsAssociationRepository : IDisposable
    {
        IQueryable<ObjectsAssociation> All { get; }
        IQueryable<ObjectsAssociation> AllIncluding(params Expression<Func<ObjectsAssociation, object>>[] includeProperties);
        ObjectsAssociation Find(int id);
        void InsertOrUpdate(ObjectsAssociation objectsAssociation);
        void Delete(int id);
        void Save();
    }
}