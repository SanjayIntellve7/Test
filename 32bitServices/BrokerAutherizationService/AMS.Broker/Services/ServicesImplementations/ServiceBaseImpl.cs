using AMS.Broker.AutherizationService;
using AMS.Broker.Contracts;
using AMS.Broker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.Services.ServicesImplementations
{
    public class ServiceBaseImpl
    {
        //protected IStationsService StationsService;
        protected ServiceBaseImpl()
        {
            try
            {
                //StationsService = BrokerService.Container.Resolve<IStationsService>();
            }
            catch (Exception ex)
            { }

        }
    }
}
