using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.DataStore
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext() : base(Storage.CentralDBEntitiesString)//"name=CentralDBEntities")//amit 17052017
        {
        }
    }
}
