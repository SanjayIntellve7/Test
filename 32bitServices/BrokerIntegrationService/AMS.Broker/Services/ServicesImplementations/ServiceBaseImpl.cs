using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using System;

namespace AMS.Broker.IntegrationService.Services.ServicesImplementations
{
    public class ServiceBaseImpl
    {
        protected IStationsService StationsService;
        protected ServiceBaseImpl()
        {
            try
            {
                StationsService = BrokerService.Container.Resolve<IStationsService>();
            }
            catch (Exception ex)
            { }
           
        }
    }
}
