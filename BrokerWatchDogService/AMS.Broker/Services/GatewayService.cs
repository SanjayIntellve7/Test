using AMS.Broker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NLog;
using System.Timers;
using AMS.Broker.WatchDogService.DataStore;
using AutoMapper;
using System.ServiceModel.Channels;
using AMS.Broker.Contracts.DTO;
using System.ServiceModel.Description;

namespace AMS.Broker.WatchDogService.Services
{
   // [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
   // [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GatewayService : IGatewayService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private IGatewayService _gatewayService;

        static Timer _PingClientTimer;

        private GatewayService()
        {
           // _logger.Info("GatewayService GatewayService() Request come");
            _gatewayService = BrokerService.Container.Resolve<IGatewayService>();
        }
        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("GatewayService ClearMemory() Exception:" + ex.Message);
            }
        }             
        

        internal static GatewayService Initialise()
        {
            try
            {                           

                //amit 16042018
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting Gateway service.");

                var service = new GatewayService();
                // var controllerHost = new ServiceHost(service);
                // controllerHost.Open();
                //
                Uri httpUrl = new Uri("https://localhost:6530/GatewayService");

                WebServiceHost controllerHost
                = new WebServiceHost(typeof(GatewayService), httpUrl);

                WebHttpBinding _webhttpbis = new WebHttpBinding(WebHttpSecurityMode.Transport);
                _webhttpbis.MaxReceivedMessageSize = 2147483647;//2147483647 //1073741823
                _webhttpbis.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.CloseTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.OpenTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.SendTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.MaxBufferPoolSize = 524288;
               
            
             //   _webhttpbis.CrossDomainScriptAccessEnabled = true;
             
                var endpoint = controllerHost.AddServiceEndpoint(typeof(IGatewayService), _webhttpbis, "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };

                controllerHost.Description.Behaviors.Add(throttleBehavior);
                WebHttpBehavior behavior = new WebHttpBehavior();
                behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;

                endpoint.Behaviors.Add(behavior);

                var _ServiceMetadataBehavior = controllerHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (_ServiceMetadataBehavior == null)
                {
                    _ServiceMetadataBehavior = new ServiceMetadataBehavior();
                    _ServiceMetadataBehavior.HttpsGetEnabled = true;
                    _ServiceMetadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    controllerHost.Description.Behaviors.Add(_ServiceMetadataBehavior);
                }
                else
                {
                    _ServiceMetadataBehavior.HttpsGetEnabled = true;
                    _ServiceMetadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                }
                _ServiceMetadataBehavior.HttpGetEnabled = true;
                _ServiceMetadataBehavior.HttpsGetEnabled = true;
                controllerHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");//WSHttpBinding

                controllerHost.Open();
                //
                _logger.Info(string.Format("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri));
                _logger.Info("------------------------------------");
                _logger.Info("");              
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016       
                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("GatewayService Initialise() Exception" + ex.Message);

                InsertBrokerOperationLog.AddProcessLog("GatewayService Initialise() Exception:" + ex.Message);
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)  //amit 04112016    
        {
            _logger.Info("GatewayService Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);

            InsertBrokerOperationLog.AddProcessLog("GatewayService Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);//amit 03052019
                  
        }
        public void StartTimer()
        {
            try
            {
                //get time from config file

                int pingTimeInterval = Storage.PingStationMinuteTimer;
                pingTimeInterval = pingTimeInterval * 60  * 1000; //min to seconds

                if (_PingClientTimer == null)
                    _PingClientTimer = new Timer(pingTimeInterval);
                _PingClientTimer.Elapsed += new ElapsedEventHandler(PingClient);
                _PingClientTimer.Start();
            }
            catch (Exception ex)
            {
                _logger.Info("GatewayService StartTimer() Exception" + ex.Message);

                InsertBrokerOperationLog.AddProcessLog("GatewayService StartTimer() Exception:" + ex.ToString());
            }

        }

        public void PingClient(object sender, ElapsedEventArgs e)
        {
            _PingClientTimer.Stop();
            try
            {
                using (var context = new CentralDBEntities())
                {
                    //var result2 = stationEntity.Select(x => x.IsActive == true && !x.Identifier.Contains("Webclient") && !x.Identifier.Contains("Mobile")).ToArray();

                    var fromStation = context.Station.Where(it => it.IsActive == true && !it.Identifier.Contains("Webclient") && !it.Identifier.Contains("Mobile"));
                    var result = fromStation.Select(Mapper.Map<AMS.Broker.Contracts.DTO.Station>).ToArray();
                    if (result.Count()> 0)
                    {
                        foreach (var actstation in result)
                        {
                            string strIp = actstation.LocationDescription;
                            if (strIp != "")
                            {
                                try
                                {
                                    //string _strUrl = "http://" + strIp + ":4532/soap/LoginStatusService";
                                    string _strUrl = "http://" + strIp + ":6532/ControllerCallBackCommService";
                                    EndpointAddress ar = new EndpointAddress(_strUrl);
                                    AMS.Broker.WatchDogService.LoginStatusServiceRef.LoginStatusClient _serVice = new AMS.Broker.WatchDogService.LoginStatusServiceRef.LoginStatusClient("WSHttpBinding_ILoginStatus", ar.ToString()); //WSHttpBinding_ILoginStatus
                                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(3);
                                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(3);
                                    int nRetVal = _serVice.CheckStatus();
                                    _serVice.Close();
                                    if (nRetVal < 1)
                                    {
                                        actstation.IsActive = false;
                                        context.SaveChanges();
                                        ClearMemory();
                                    }
                                    if (nRetVal==1)
                                    {
                                        actstation.IsActive = true;
                                        context.SaveChanges();
                                        ClearMemory();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var station = context.Station.FirstOrDefault(x => x.LocationDescription == strIp);
                                    station.IsActive = false;
                                    context.SaveChanges();
                                    ClearMemory();                                  
                                }
                            }                                                       
                           
                        }                        
                    }

                }

                _PingClientTimer.Start();
            }
            catch (Exception ex)
            {
                _logger.Info("GatewayService PingClient() Exception" + ex.Message);
                InsertBrokerOperationLog.AddProcessLog("GatewayService PingClient() Exception" + ex.Message);
            }
            //get active station
            //ping active station
            //update station status if not ping
        }

        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped)]//ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        public BrokerStatus Ping()
        {
            InsertBrokerOperationLog.AddProcessLog("Gateway service Ping() Start : " );
            return _gatewayService.Ping();           
        }

        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]        
        public bool ValidateCredentials(string username, string password)
        {
            InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateCredentials() username : " + username + "--password--" + password);
            return _gatewayService.ValidateCredentials(username, password);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ValidateUserName(string username)
        {
            InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateUserName() username : " + username);
            return _gatewayService.ValidateUserName(username);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool PingWatchDog()
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("Gateway service PingWatchDog() Start: ");
                return true;
            }
            catch(Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Gateway service PingWatchDog() Exception : " + ex.Message);
            }
            return false;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string TestCommunication()
        {
            return "Service Communication";
        }
    }
}