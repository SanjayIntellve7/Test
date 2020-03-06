using AMS.Broker.Contracts.Services;
using AMS.Broker.IntegrationService.Helpers;
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
using System.Xml;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public sealed class IclockACSIntegrationService : IIclockACSIntegrationService
    {
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();


        public IclockACSIntegrationService()
        {
            try
            {
                // _alertCreationService = alertCreationService;
            }
            catch (Exception ex)
            {
                _logger.Info("IclockACSIntegrationService Service constructor Exception" + ex.Message);
                InsertIntegrationLog.AddProcessLogIntegration("IclockACSIntegrationService Service constructor Exception" + ex.Message);//jatin
            }
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
                string Message = "IclockACSIntegrationService -ClearMemory() -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            }
        }
        public static void ClearMemoryStatic()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "IclockACSTransaction Service -ClearMemoryStatic() -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        ~IclockACSIntegrationService()
        {
        }

        internal static IclockACSIntegrationService Initialise()//IAlertsGetOperationService alertservice
        {
            try
            {
                _logger.Info("");
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting IclockACSTransaction Service.");

                InsertIntegrationLog.AddProcessLogIntegration("");
                InsertIntegrationLog.AddProcessLogIntegration("------------------------------------");
                InsertIntegrationLog.AddProcessLogIntegration("starting IclockACS TransactionService.");//jatin

                var service = new IclockACSIntegrationService();
                // var controllerHost = new ServiceHost(service);
                // controllerHost.Open();
                //
                Uri httpUrl = new Uri("https://localhost:6530/IclockACSIntegrationService");

                WebServiceHost controllerHost
                = new WebServiceHost(typeof(IclockACSIntegrationService), httpUrl);

                WebHttpBinding _webhttpbis = new WebHttpBinding(WebHttpSecurityMode.Transport);

                _webhttpbis.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.CloseTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.OpenTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.SendTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.MaxBufferPoolSize = 2147483647;//524288;
                _webhttpbis.MaxReceivedMessageSize = 2147483647;//1073741823;
                _webhttpbis.MaxBufferSize = 2147483647;//1073741823;
                _webhttpbis.CrossDomainScriptAccessEnabled = true;

                XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
                myReaderQuotas.MaxStringContentLength = 2147483647;
                myReaderQuotas.MaxArrayLength = 2147483647;
                myReaderQuotas.MaxBytesPerRead = 2147483647;
                myReaderQuotas.MaxDepth = 2147483647;
                myReaderQuotas.MaxNameTableCharCount = 2147483647;

                _webhttpbis.GetType().GetProperty("ReaderQuotas").SetValue(_webhttpbis, myReaderQuotas, null);

                var endpoint = controllerHost.AddServiceEndpoint(typeof(IIclockACSIntegrationService), _webhttpbis, "");//WSHttpBinding

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
                controllerHost.Open();

                //if (cams3SdkUser == null)
                //{
                //    cams3SdkUser = new Cams3SdkUser();                    
                //}
                //
                _logger.Info(string.Format("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri));
                _logger.Info("------------------------------------");
                _logger.Info("");
                InsertIntegrationLog.AddProcessLogIntegration(string.Format("listening at " + controllerHost.Description.Endpoints[0].ListenUri));//jatin
                InsertIntegrationLog.AddProcessLogIntegration("------------------------------------");
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016     

                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("IclockACSTransactionService Initialise() Exception" + ex.Message);
            }
            return null;
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("IclockACSTransaction Service   Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);

        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ACUnlock(string IPAddress, string Port)
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("AcsAdapterService", "ACUnlockDoorOpen", "IPAddress=" + IPAddress, "Port=" + Port);
                if (json == null)
                    return false;
                json = JsonServicesHelper.RemoveJsonpSyntax(json);
                return JsonServicesHelper.Deserialize<bool>(json);
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool GetDoorState(int machineID, int val, string IPAddress, string Port)
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("AcsAdapterService", "GetDoorState", "machineID=" + machineID, "val=" + val, "IPAddress=" + IPAddress, "Port=" + Port);
                if (json == null)
                    return false;
                if (json.Contains("false"))
                    return false;

                if (json.Contains("true"))
                    return true;

                //json = JsonServicesHelper.RemoveJsonpSyntax(json);
                //return JsonServicesHelper.Deserialize<bool>(json);
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool GeDeviceStatus(string IPAddress, string Port)
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("AcsAdapterService", "GetAcsDeviceStatus", "IPAddress=" + IPAddress, "Port=" + Port);
                if (json == null)
                    return false;
                // json = json.Replace("IclockACSTransactionService", "ACUnlock");
                json = JsonServicesHelper.RemoveJsonpSyntax(json);
                var res = JsonServicesHelper.Deserialize<bool>(json);

                return res;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool AnnunciatorCommand(string IPAddress, string Port)
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("AcsAdapterService", "AnnunciatorCommand", "IPAddress=" + IPAddress, "Port=" + Port);
                if (json == null)
                    return false;
                // json = json.Replace("IclockACSTransactionService", "ACUnlock");
                json = JsonServicesHelper.RemoveJsonpSyntax(json);
                var res = JsonServicesHelper.Deserialize<bool>(json);

                return res;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
