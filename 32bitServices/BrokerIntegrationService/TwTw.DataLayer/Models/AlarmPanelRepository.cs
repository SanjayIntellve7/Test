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
    public class AlarmPanelRepository : IAlarmPanelRepository
    {
        InterfaceExternalIdContext context = new InterfaceExternalIdContext();

        public IQueryable<AlarmPanel> All
        {
            get { return context.AlarmPanels; }
        }

        public IQueryable<AlarmPanel> AllIncluding(params Expression<Func<AlarmPanel, object>>[] includeProperties)
        {
            IQueryable<AlarmPanel> query = context.AlarmPanels;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public AlarmPanel Find(int id)
        {
            return context.AlarmPanels.Find(id);
        }

        public void InsertOrUpdate(AlarmPanel alarmpanel)
        {
            if (alarmpanel.AlarmPanelId == default(int)) {
                // New entity
                context.AlarmPanels.Add(alarmpanel);
            } else {
                // Existing entity
                context.Entry(alarmpanel).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var alarmpanel = context.AlarmPanels.Find(id);
            context.AlarmPanels.Remove(alarmpanel);
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

    public interface IAlarmPanelRepository : IDisposable
    {
        IQueryable<AlarmPanel> All { get; }
        IQueryable<AlarmPanel> AllIncluding(params Expression<Func<AlarmPanel, object>>[] includeProperties);
        AlarmPanel Find(int id);
        void InsertOrUpdate(AlarmPanel alarmpanel);
        void Delete(int id);
        void Save();
    }
}