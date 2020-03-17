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
    public class EventTypeTemplateRepository : IEventTypeTemplateRepository
    {
        InterfaceExternalIdContext context = new InterfaceExternalIdContext();

        public IQueryable<EventTypeTemplate> All
        {
            get { return context.EventTypeTemplates; }
        }

        public IQueryable<EventTypeTemplate> AllIncluding(params Expression<Func<EventTypeTemplate, object>>[] includeProperties)
        {
            IQueryable<EventTypeTemplate> query = context.EventTypeTemplates;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public EventTypeTemplate Find(int id)
        {
            return context.EventTypeTemplates.Find(id);
        }

        public void InsertOrUpdate(EventTypeTemplate eventtypetemplate)
        {
            if (eventtypetemplate.EventTypeTemplateId == default(int)) {
                // New entity
                context.EventTypeTemplates.Add(eventtypetemplate);
            } else {
                // Existing entity
                context.Entry(eventtypetemplate).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var eventtypetemplate = context.EventTypeTemplates.Find(id);
            context.EventTypeTemplates.Remove(eventtypetemplate);
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

    public interface IEventTypeTemplateRepository : IDisposable
    {
        IQueryable<EventTypeTemplate> All { get; }
        IQueryable<EventTypeTemplate> AllIncluding(params Expression<Func<EventTypeTemplate, object>>[] includeProperties);
        EventTypeTemplate Find(int id);
        void InsertOrUpdate(EventTypeTemplate eventtypetemplate);
        void Delete(int id);
        void Save();
    }
}