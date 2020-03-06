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

namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GatewayService : IGatewayService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private IGatewayService _gatewayService;

        static Timer _PingClientTimer;

        private GatewayService()
        {
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
            }
        }
        

        internal static GatewayService Initialise()
        {
            try
            {

            _logger.Info("------------------------------------");
            _logger.Info("starting Gateway service");
            InsertBrokerOperationLog.AddProcessLog("starting Gateway service");
            var service = new GatewayService();
            var controllerHost = new ServiceHost(service);
            controllerHost.Open();

            _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
            _logger.Info("------------------------------------");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);  //amit 04112016       

            return service;
            }
            catch (Exception ex)
            {
                _logger.Info("GatewayService Initialise() Exception" + ex.Message);
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)  //amit 04112016    
        {
            _logger.Info("GatewayService Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);          
                  
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
                                    string _strUrl = "http://" + strIp + ":6532/soap/ControllerCallBackCommService";
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

            }
            //get active station
            //ping active station
            //update station status if not ping
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public BrokerStatus Ping()
        {
            

            return _gatewayService.Ping();
           
        }
        
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ValidateCredentials(string username, string password)
        {
            return _gatewayService.ValidateCredentials(username, password);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ValidateUserName(string username)
        {
            return _gatewayService.ValidateUserName(username);
        }
    }
}