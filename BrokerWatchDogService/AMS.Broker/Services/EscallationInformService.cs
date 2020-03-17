using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.DataStore;
using AMS.Broker.WatchDogService;
using AMS.Broker.WatchDogService.DataStore;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class EscallationInformService : IEscallationInformService
    {
        readonly IEscallationInformService _EscallationInformService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static IEscallationInformService _serviceInstance = new EscallationInformService();
        public static IEscallationInformService ServiceInstance { get { return _serviceInstance; } }

        public string IsEscallationInformEnable = Storage.IsEscallationInformEnable;
        public string EscallationWaitInterval = Storage.EscallationWaitInterval;
        public string EscallationTime = Storage.EscallationTime;

        public System.Threading.Thread EascallationThread;

        public static BrokerService _BrokerInstance = null;

        public EscallationInformService()
        {
            try
            { 
                if (IsEscallationInformEnable == "1")
                {                   
                    StartThread();
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("EscallationInformService EscallationInformService() Exception" + ex.Message);
            }
        }


        internal static IEscallationInformService Initialise(BrokerService _BrokerService)
        {
            try
            {
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting EscallationInform Service ");
                _BrokerInstance = _BrokerService;
                Uri httpUrl = new Uri("https://localhost:6530/EscallationInformService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(EscallationInformService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IEscallationInformService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();
                _logger.Info("EscallationInformService started successfully");              

                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("EscallationInformService Initialise() Exception" + ex.Message);

                _BrokerInstance.isInitialiseFail = true;
            }
            return null;
        }

        public void StartThread()
        {
            try
            {
                EascallationThread = new System.Threading.Thread(new System.Threading.ThreadStart(ProcessEscallation));
                EascallationThread.Start();
            }
            catch (Exception ex)
            {
                var msg = "EscallationInformService- StartThread()  Exception:" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(msg);
            }
        }

        public void InsertNotifiedAlert(string AlertID, string strIp,bool IsSuccess)
        {
            try
            {
                int alertID = int.Parse(AlertID);
                DateTime currentDateTime=DateTime.Now;
                using (var context = new CentralDBEntities())
                {
                    var _tblAlertEscalationLog = new tblAlertEscalationLog
                            {
                                AlertID = alertID,
                                IdentifierIP = strIp,
                                EscalationDatetime=currentDateTime,
                                EscalationStatus = IsSuccess,
                            };

                    context.tblAlertEscalationLog.Add(_tblAlertEscalationLog);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var msg = "EscallationInformService- InsertNotifiedAlert()  Exception:" + ex.Message;                
                InsertBrokerOperationLog.AddProcessLog(msg);
            }
        }

        public void InformEscallationTask(string alertID, string strIp)
        {
            try
            {
                string msg = "EscallationInformService-InformEscallationTask() Start -- Message = " + alertID + "--!--strIp: " + strIp;              
                InsertBrokerOperationLog.AddProcessLog(msg);//jatin
                string NotificationMessage = "Alert: " + alertID + " Escalated";           
               
                string _strUrl = "https://" + strIp + ":6532/soap/ControllerCallBackCommService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                msg = "EscallationInformService- InformEscallationTask()  _strUrl= " + _strUrl;
                //InsertBrokerOperationLog.AddProcessLog(Message1);
                InsertBrokerOperationLog.AddProcessLog(msg);//jatin

                AMS.Broker.ControllerCallBackCommServiceRef.ControllerCallBackCommServiceClient _serVice = new AMS.Broker.ControllerCallBackCommServiceRef.ControllerCallBackCommServiceClient("WSHttpBinding_IControllerCallBackCommService", ar.ToString());
                if (Storage.IsCloudServer == "1")
                {
                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(30);
                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(30);
                }
                else
                {
                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(10);
                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(10);
                }
                _serVice.RaiseAlertEscallation(NotificationMessage, alertID);
                _serVice.Close();

                 msg = "EscallationInformService-InformEscallationTask() Successfully -- Message = " + alertID + "--!--strIp: " + strIp;
                InsertBrokerOperationLog.AddProcessLog(msg);//jatin
                //Task.Run(() => InsertNotifiedAlert(alertID, strIp));
                InsertNotifiedAlert(alertID, strIp,true);
                
            }
            catch (OutOfMemoryException ex)
            {
                InsertNotifiedAlert(alertID, strIp, false);
                _logger.Info("EscallationInformService InformEscallationTask() Exception:" + ex.Message);
                string Message1 = "EscallationInformService- InformEscallationTask() Exception:" + ex.Message;               
                InsertBrokerOperationLog.AddProcessLog(Message1);//jatin 
                _logger.Error(ex);
            }
            catch (Exception ex)
            {
                _logger.Info("EscallationInformService InformEscallationTask() Exception:" + ex.Message);
                string Message1 = "EscallationInformService- InformEscallationTask() Exception 1:" + ex.Message;               
                InsertBrokerOperationLog.AddProcessLog(Message1);//jatin               
                InsertNotifiedAlert(alertID, strIp, false);
            }
        }

        public void ProcessEscallation()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        var time = new SqlParameter
                        {
                            ParameterName = "time",
                            Value = Int32.Parse(EscallationTime)
                        };

                        //call store procedure for getting alert IDs 
                        using (var context = new CentralDBEntities())
                        {
                            var AlertEscallationResult = context.Database.SqlQuery<SP_AlertEscalationNotification_Result>(
                            "exec SP_AlertEscalationNotification @time", time).ToList<SP_AlertEscalationNotification_Result>();
                            if (AlertEscallationResult != null)
                            {
                                var msg = "EscallationInformService- ProcessEscallation() AlertEscallationResult Count : " + AlertEscallationResult.Count;
                                InsertBrokerOperationLog.AddProcessLog(msg);

                                foreach (var alert in AlertEscallationResult)
                                {
                                    Task.Run(() => InformEscallation(alert.AlertID.ToString()));
                                }
                            }
                        }                        
                     
                        //wait for interval time
                        int waitTime = 120000;
                        try
                        {
                            waitTime = Int32.Parse(EscallationWaitInterval) * 60 * 1000;
                        }
                        catch (Exception ex)
                        {
                            var msg = "EscallationInformService- ProcessEscallation()  Exception:" + ex.Message;
                            InsertBrokerOperationLog.AddProcessLog(msg);
                        }

                        new ManualResetEvent(false).WaitOne(waitTime);
                        InsertBrokerOperationLog.AddProcessLog("ProcessEscallation Wait Time End ...");
                    }
                    catch (Exception ex)
                    {
                        var msg = "EscallationInformService- ProcessEscallation()  Exception 1 :" + ex.Message;
                        InsertBrokerOperationLog.AddProcessLog(msg);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void InformEscallation(string AlertID)
        {
            try
            {
                var msg = "EscallationInformService- InformEscallation()  Alert ID :" + AlertID;
                InsertBrokerOperationLog.AddProcessLog(msg);
                //call store procedure for geetting loggedin user
                using (var context = new CentralDBEntities())
                {
                    var LoginStationResult = context.Database.SqlQuery<SP_ReturnAlertEscalationNotificationMember_Result>(
                    "exec SP_ReturnAlertEscalationNotificationMember").ToList<SP_ReturnAlertEscalationNotificationMember_Result>();

                    foreach (var stn in LoginStationResult)
                    {
                        //Task.Run(() => InformEscallationTask(AlertID, stn.IPAddress));
                        InformEscallationTask(AlertID, stn.IPAddress);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = "EscallationInformService- InformEscallation()  Exception :" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(msg);
            }
        }


        public void Test()
        {
            return;
        }
    }
}
