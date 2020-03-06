using AMS.Broker.IntegrationService.DataStore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace AMS.Broker.IntegrationService.Helpers
{
    public static class Extensions
    {

        public static bool IsBetween(this DateTime input, DateTime date1, DateTime date2) 
        { 
            return (input >= date1 && input <= date2); 
        }

        public static void ForEach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (var item in input)
            {
                action(item);
            }
        }

        public static TEntity ApplyCurrentValues<TEntity>(this CentralDBEntities ctx, TEntity entity) where TEntity : class
        {
            return ((IObjectContextAdapter)ctx).ObjectContext.ApplyCurrentValues<TEntity>(typeof(TEntity).Name, entity);
        }        

    }
}
