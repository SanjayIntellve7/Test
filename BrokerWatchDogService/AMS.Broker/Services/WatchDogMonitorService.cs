using AMS.Broker.Contracts.Services;
using AMS.Broker.WatchDogService.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WatchDogMonitorService : IWatchDogMonitorService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public bool isInitialiseFail = false;
        public static BrokerService _BrokerInstance = null;

        internal static IWatchDogMonitorService Initialise(BrokerService _BrokerService)
        {
            try
            {
                _BrokerInstance = _BrokerService;
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting WatchDogMonitorService Service");

                Uri httpUrl = new Uri("https://localhost:6530/WatchDogMonitorService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(WatchDogMonitorService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IWatchDogMonitorService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();
                _logger.Info("WatchDogMonitor Service started successfully");
                InsertBrokerOperationLog.AddProcessLog("WatchDogMonitor Service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("WatchDogMonitor Initialise() Exception" + ex.Message);
                string Message = "WatchDogMonitor-Initialise() -- Exception  = " + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
                _BrokerInstance.isInitialiseFail = true;
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public bool PingWatchDogMonitor()
        {
            InsertBrokerOperationLog.AddProcessLog("WatchDogMonitor service PingWatchDog() :Start ");
            try
            {
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
