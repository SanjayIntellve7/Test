using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.IntegrationService.DataStore;
using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using EventDTO = AMS.Broker.Contracts.DTO.Event;
using Status = AMS.Broker.Contracts.DTO.Status;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Globalization;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class MatrixControllerService : IMatrixControllerService
    {
        readonly IMatrixControllerService _MatrixControllerService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();       
       
        public long CheckPointer=0;

          public MatrixControllerService()
        {            
           
        }

          ~MatrixControllerService()
        {
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
                  string Message = "MatrixControllerService-ClearMemory -- Exception = " + ex.Message;
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
                  string Message = "MatrixControllerService-ClearMemoryStatic -- Exception = " + ex.Message;
                  //InsertBrokerOperationLog.AddProcessLog(Message);
                  InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
              }
          }

       

        internal static IMatrixControllerService Initialise()
        {
            try
            {
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting ANPR Service");

               
               
                var service = new MatrixControllerService();

                var controllerHost = new ServiceHost(service);

                foreach (var endpoint in controllerHost.Description.Endpoints)
                {
                    if (endpoint.Binding is WSHttpBinding)
                    {
                        (endpoint.Binding as WSHttpBinding).MaxReceivedMessageSize = Int32.MaxValue;
                        (endpoint.Binding as WSHttpBinding).MaxBufferPoolSize = Int32.MaxValue;
                    }
                }
                controllerHost.Open();
                _logger.Info("IMatrix Service Started Successfully");

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016

                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("IMatrixControllerService Initialise() Exception" + ex.Message);

                string Message = "MatrixControllerService-Initialise -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            }
           
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("Matrix ControllerService Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);

            string Message = "MatrixControllerService-Initialise --Unhandled Exception = " + (e.ExceptionObject as Exception).Message;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
        }
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Xml, UriTemplate = "/ConsumeANPRAlert/AnprId")]
     
        
       
        [WebGet(UriTemplate = "DoorClose/{InterfaceId}")]
        public string DoorClose(string InterfaceId)
        {
            try
            {
                string Message = "MatrixControllerService--DoorClose -- InterfaceId = " + InterfaceId;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                AlarmPanelDTO _alarmPanel = null;
                long _InterfaceId = long.Parse(InterfaceId);
                using (var ctx = new CentralDBEntities())
                {
                    var resultDb = (from nvr in ctx.alarmPanel
                                    where nvr.InterfaceId == _InterfaceId
                                    select nvr).First();
                    //  _alarmPanel = Mapper.Map<AlarmPanelDTO>(resultDb);    //amit 06102016 manual mapping 

                    //amit 06102016 manual mapping 
                    if(resultDb!=null)
                    {
                        _alarmPanel = new AlarmPanelDTO();
                        _alarmPanel.InterfaceDeviceIP = resultDb.InterfaceDeviceIP;
                        _alarmPanel.InterfaceDevicePort = resultDb.InterfaceDevicePort;
                        _alarmPanel.AlarmPanelTypeId = resultDb.AlarmPanelTypeId;
                        _alarmPanel.EventTypeTemplateId = resultDb.EventTypeTemplateId;
                    }
                }
                var _url = "http://" + _alarmPanel.InterfaceDeviceIP + ":" + _alarmPanel.InterfaceDevicePort +

"/device.cgi/command?action=lockdoor";
                string urlParameters = "";// "/" + _alert.AlertId.ToString() + "/" + "1";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {                   
                    return "Suc";
                }              
                return "Fail";
            }
            catch (Exception ex)
            {
                _logger.Info("MatrixService DoorClose() Exception" + ex.Message);
                string Message = "MatrixControllerService-DoorClose -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return "Fail";
        }

        [WebGet(UriTemplate = "DoorOpen/{InterfaceId}")]
        public string DoorOpen(string InterfaceId)
        {
            string Message = "MatrixControllerService--DoorOpen -- InterfaceId = " + InterfaceId;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            try
            {
                try
                {
                    AlarmPanelDTO _alarmPanel = null;
                    long _InterfaceId = long.Parse(InterfaceId);
                    using (var ctx = new CentralDBEntities())
                    {
                        var resultDb = (from nvr in ctx.alarmPanel
                                        where nvr.InterfaceId == _InterfaceId
                                        select nvr).First();
                      //  _alarmPanel = Mapper.Map<AlarmPanelDTO>(resultDb);
                        //amit 06102016 manual mapping 
                        if (resultDb != null)
                        {
                            _alarmPanel = new AlarmPanelDTO();
                            _alarmPanel.InterfaceDeviceIP = resultDb.InterfaceDeviceIP;
                            _alarmPanel.InterfaceDevicePort = resultDb.InterfaceDevicePort;
                            _alarmPanel.AlarmPanelTypeId = resultDb.AlarmPanelTypeId;
                            _alarmPanel.EventTypeTemplateId = resultDb.EventTypeTemplateId;
                        }

                    }
                    var _url = "http://" + _alarmPanel.InterfaceDeviceIP + ":" + _alarmPanel.InterfaceDevicePort +"/device.cgi/command?action=unlockdoor";
                    string urlParameters = "";// "/" + _alert.AlertId.ToString() + "/" + "1";
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(_url);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    // List data response.
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                    if (response.IsSuccessStatusCode)
                    {                       
                        return "Suc";
                    }                   
                    return "Fail";
                }
                catch (Exception ex)
                {
                    _logger.Info("MatrixService DoorOpen() Exception" + ex.Message);
                    string Message1 = "MatrixControllerService-DoorOpen -- Exception = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                }

            }
            catch (Exception ex)
            {
                _logger.Info("MatrixService DoorOpen() Exception" + ex.Message);
                string Message1 = "MatrixControllerService-DoorOpen -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return "Fail";
        }


    }
}
