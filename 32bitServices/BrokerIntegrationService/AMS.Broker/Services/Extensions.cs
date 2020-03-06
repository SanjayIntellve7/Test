using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.Services
{
    public static class Extensions
    {
        public static void CallIfNotNull<TActionArgs>(this Action<TActionArgs> handler, TActionArgs args)
        {
            var handler2 = handler;
            if (handler2 != null)
            {
                handler2(args);
            }
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}