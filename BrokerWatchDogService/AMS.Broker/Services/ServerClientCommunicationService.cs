using AMS.Broker.Contracts.Services;
using AMS.Broker.WatchDogService.DataStore;
using AMS.Broker.WatchDogService.Helpers;
using AMS.Broker.WatchDogService.Services.ServicesImplementations;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using AutoMapper;
using AMS.Broker.Contracts.DTO;
using System.Collections;
using System.Net.Http;
using System.Xml.Linq;
using System.Timers;
using System.Device.Location;
using System.Security;
using System.Xml.Serialization;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;
using AMS.Broker.DataStore;
using System.Net.Mail;
using AMS.Broker.Helpers;


namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class ServerClientCommunicationService : IServerClientCommunicationService
    {

        readonly IServerClientCommunicationService _ServerClientCommunicationService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();           
        static bool exitFlag = false;    

        private static IServerClientCommunicationService _serviceInstance = new ServerClientCommunicationService();

        public static IServerClientCommunicationService ServiceInstance { get { return _serviceInstance; } }

        public string IsServerClinetCommEnable = Storage.ServerClientCommEnable;
        public string TimeInterval = Storage.ServerClientCommInterval;
        public System.Threading.Thread ServerClientCommThread;
        public int waitTime = 60 * 60 * 1000;
        public IList<tblMachineStatusDTO> tblMachineStatusDTOList = new List<tblMachineStatusDTO>();
        public DeviceDto _SystemDevice;
        public static  BrokerService _BrokerInstance = null;

        public ServerClientCommunicationService()
        {
            try
            {
                if (IsServerClinetCommEnable == "1")
                {

                    try
                    {
                        waitTime = Int32.Parse(TimeInterval) * 60 * 1000;
                    }
                    catch (Exception EX)
                    {
                    }
                    GetServerClientCollection();
                    GetSystemDevice();
                    StartServerClientStatusThread();
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunicationService ServerClientCommunicationService() Exception" + ex.Message);
            }
        }

        public void GetSystemDevice()
        {
            try
            {
                _SystemDevice=new DeviceDto();
                using (var context = new CentralDBEntities())
                {
                    var _device  = context.Device.FirstOrDefault(x => x.Type == "SystemAlarm");
                    if (_device != null)
                    {
                        _SystemDevice.ActiveAlert = _device.ActiveAlert;
                        _SystemDevice.Altitude = _device.Altitude;
                        _SystemDevice.CameraGUID = _device.CameraGuid;
                        _SystemDevice.Description = _device.Description;
                        _SystemDevice.DeviceId = _device.DeviceId;
                        _SystemDevice.ExternalId = _device.ExternalId;
                       // _SystemDevice.InterfaceId = int.Parse(_device.InterfaceId.ToString());
                        _SystemDevice.IsMovable = false;//_device.IsMovable;
                        _SystemDevice.Lat = _device.Lat;
                        _SystemDevice.LocationDescription = _device.LocationDescription;
                        _SystemDevice.Long = _device.Long;
                        _SystemDevice.Metadata = _device.Metadata;
                        _SystemDevice.Name = _device.Name;
                        _SystemDevice.NvrId = _device.NvrId;
                        _SystemDevice.SiteId = int.Parse(_device.SiteId.ToString());
                        _SystemDevice.Type = _device.Type;
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunicationService GetSystemDevice() Exception" + ex.Message);
            }
        }

        internal static  IServerClientCommunicationService Initialise(BrokerService _BrokerService)
        {
            try
            {
                _BrokerInstance = _BrokerService;
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting Server Client Communication Service");

                Uri httpUrl = new Uri("https://localhost:6530/ServerClientCommunicationService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(ServerClientCommunicationService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IServerClientCommunicationService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();              
                _logger.Info("ServerClientCommunication Service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("ServerClientCommunication Initialise() Exception" + ex.Message);
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Initialise() Exception" + ex.Message);              
                _BrokerInstance.isInitialiseFail = true;
            }
            return null;
        }               
      

        private void GetServerClientCollection()
        {
            InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication GetServerClientCollection(): Start");
            try
            {
               
                using (var context = new CentralDBEntities())
                {
                    var machinDetails = context.tblMachineStatus.Where(x=>x.UpdateFlag==1);
                    if (machinDetails != null)
                    {
                        foreach (var machine in machinDetails)
                        {
                            tblMachineStatusDTO _tblMachineStatusDTO = new tblMachineStatusDTO();
                            _tblMachineStatusDTO.ID = machine.ID;
                            _tblMachineStatusDTO.IPAddress = machine.IPAddress;
                            _tblMachineStatusDTO.MachineName = machine.MachineName;
                            _tblMachineStatusDTO.Port = machine.Port;
                            _tblMachineStatusDTO.ServiceName = machine.ServiceName;
                            _tblMachineStatusDTO.UpdateFlag = machine.UpdateFlag;
                            tblMachineStatusDTOList.Add(_tblMachineStatusDTO);
                        }
                    }
                }

               // return tblMachineStatusDTOList;
            }
            catch (SecurityException ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication GetServerClientCollection() SecurityException : " + ex.Message);
                _logger.Info("ServerClientCommunication GetServerClientCollection() Exception:" + ex.Message);
                _logger.Error(ex);
            }
            finally
            {
                ClearMemory();
            }
            //
           // return null;
        }             


        public void ClearMemory()
        {
            try
            {
                long bytes1 = GC.GetTotalMemory(false);
                _logger.Info("ServerClientCommunication Service Memory Before Collect " + bytes1);
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                long bytes3 = GC.GetTotalMemory(true); // Get memory              
                _logger.Info("ServerClientCommunication Service Memory After garbage collection " + bytes3);
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("IServerClientCommunicationService ClearMemory() Exception" + ex.Message);
            }
        }

        public void StartServerClientStatusThread()
        {
            try
            {
                ServerClientCommThread = new System.Threading.Thread(new System.Threading.ThreadStart(ServerClientStatusThread));
                ServerClientCommThread.Start();
            }
            catch (Exception ex)
            {
                _logger.Info("ServerClientCommunication StartCameraStatusTimer() Exception" + ex.Message);

                InsertBrokerOperationLog.AddProcessLog("IServerClientCommunicationService StartServerClientStatusThread() Exception" + ex.Message);
            }

        }
        public void ServerClientStatusThread()
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientStatusThread Process Started ...");
                while (true)
                {
                    try
                    {                       
                        Task t = Task.Factory.StartNew(delegate
                       {

                           // IsGoahead = false;
                           try
                           {                          
                               if (tblMachineStatusDTOList != null)
                               {
                                   foreach (var machine in tblMachineStatusDTOList)
                                   {
                                       string _strIp = machine.IPAddress;
                                       int port = Int32.Parse(machine.Port);
                                       System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                                       bool success=false;
                                       try
                                       {                                         
                                          clientSocket.Connect(_strIp, port);                                          
                                          success = true;
                                       }
                                       catch (Exception ex)
                                       {
                                           success = false;
                                       }                                                                          
                                                                             

                                       if (!success)
                                       {
                                           string strLogs = "\tMachine " + machine.MachineName + " Offline\t IPAddress" + machine.IPAddress + "\t Port" + machine.Port + "\t ServiceName" + machine.ServiceName;
                                           InsertBrokerOperationLog.AddProcessLog(strLogs.ToString());
                                          //checkalert
                                          CheckAlert(machine.IPAddress, machine.Port.ToString(),success);
                                       }
                                       else
                                       {
                                           string strLogs = "\tMachine " + machine.MachineName + " Online\t IPAddress" + machine.IPAddress + "\t Port" + machine.Port + "\t ServiceName" + machine.ServiceName;
                                           InsertBrokerOperationLog.AddProcessLog(strLogs.ToString());
                                           clientSocket.Close();//amit 12032018
                                       }

                                       UpdateServerClientStatus(_strIp, port.ToString(), success);
                                   }
                               }
                           }
                           catch (Exception ex)
                           {
                               InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service ServerClientStatusThread Exception : " + ex.Message);
                           }


                       }).ContinueWith((MyResult) =>
                       {

                       }, TaskScheduler.FromCurrentSynchronizationContext());
                        //
                    }
                    catch (Exception ex)
                    {
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication ServerClientStatusThread() Exception : " + ex.Message);
                    }

                    new ManualResetEvent(false).WaitOne(waitTime);   
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service ServerClientStatusThread Process Exception Final : " + ex.Message);
            }
        }

        public void CheckAlert(string strIpAdd,string strPort,bool Status)
        {
            try
            {
                bool isAlertTrigger = false;
                string machineName = "";
                string ServiceName = "";
                try
                {
                    using (var context = new CentralDBEntities())
                    {
                        var machinDetails = context.tblMachineStatus.FirstOrDefault(x => x.IPAddress == strIpAdd && x.Port == strPort);
                        if (machinDetails != null)
                        {
                            if (machinDetails.ServiceStatus != null)
                            {
                                if (machinDetails.ServiceStatus != Status)
                                    isAlertTrigger = true;
                            }
                            else
                            {
                                isAlertTrigger = true;
                            }

                            machineName = machinDetails.MachineName;
                            ServiceName = machinDetails.ServiceName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication CheckAlert() Exception : " + ex.Message);
                }

                if (isAlertTrigger == true)
                {
                    Task.Run(() => CreateAlert(machineName, strIpAdd, ServiceName));
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication CheckAlert() Exception Final : " + ex.Message);
            }
        }

        public void UpdateServerClientStatus(string StrIPAddress,string StrPort,bool StrStatus)
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    var machinDetails = context.tblMachineStatus.FirstOrDefault(x => x.IPAddress == StrIPAddress && x.Port == StrPort);
                    if (machinDetails != null)
                    {
                        machinDetails.ServiceStatus = StrStatus;                   
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service UpdateServerClientStatus ex: " + ex.Message);
            }
        }

        public void CreateAlert(string machineName,string Ipaddress ,string ServiceName)
        {
            try
            {
                string Message3 = "ServerClientCommunication service CreateAlert start machineName:" + machineName;
                InsertBrokerOperationLog.AddProcessLog(Message3);

                string _alarmType = "";
                string _Code = "";
                //int eventID = Int32.Parse(eventId.ToString());


                int nQualifire = Int32.Parse("1");
              //  AMS.Broker.DataStore.Device _device = new AMS.Broker.DataStore.Device();
              
                EventCodeDto _errorCode = new EventCodeDto();
                EventTemplateDto evtdto = new EventTemplateDto();// Mapper.Map<EventTemplateDto>(alerttemplate);

                using (var contextErrorCode = new CentralDBEntities())
                {
                    var errorCodetemplates = from dc in contextErrorCode.EventCode
                                             where dc.EventAssociated == "System Down"
                                             select dc;
                    var errorctemplate = errorCodetemplates.FirstOrDefault();

                    if (errorctemplate != null)
                    {
                        //amit manual mapping 06102016
                        var alerttemplates = from tc in contextErrorCode.EventTemplate
                                             where tc.EventCodeId == errorctemplate.EventCode1//nEvtCode
                                             where tc.EventQualifierId == nQualifire
                                             where tc.EventTypeTeplateId == 1
                                             select tc;//EventTemplateId

                        var alerttemplate = alerttemplates.FirstOrDefault();
                        if (alerttemplate != null)
                        {
                            evtdto.Category = alerttemplate.Category;
                            evtdto.Certainty = alerttemplate.Certainty;
                            evtdto.Description = alerttemplate.Description;
                            evtdto.EventCodeId = alerttemplate.EventCodeId;
                            evtdto.EventQualifierId = alerttemplate.EventQualifierId;
                            evtdto.EventTemplateId = alerttemplate.EventTemplateId;
                            evtdto.EventType = alerttemplate.EventType;
                            evtdto.EventTypeTeplateId = alerttemplate.EventTypeTeplateId;
                            evtdto.Headline = alerttemplate.Headline;
                            evtdto.Instruction = alerttemplate.Instruction;
                            evtdto.MessageType = alerttemplate.MessageType;
                            evtdto.ResponseType = alerttemplate.ResponseType;
                            evtdto.Scope = alerttemplate.Scope;
                            evtdto.Severity = alerttemplate.Severity;
                            evtdto.Status = alerttemplate.Status;
                            evtdto.Urgency = alerttemplate.Urgency;
                        }
                    }
                }

                if (_alarmType != "")
                {
                    _Code = _alarmType;
                }
                else
                {
                    _Code = evtdto.Headline;
                }
                        
                var alert = new AlertDTO
                {
                    DeviceId = _SystemDevice.DeviceId,
                    Sender = ServiceName+":"+machineName + ":" + Ipaddress,      //// Device-DeviceID                    
                    Source = _SystemDevice.Name,  ////InterfaceId from deviceDTO   ////Should be Name of the Interface
                    //SentAsString = DateTime.Now.ToString(), ////EventDto event datetime
                    Sent = DateTime.Now,
                    Identifier = Guid.NewGuid().ToString(),
                    StatusId = (AMS.Broker.Contracts.DTO.Status)Enum.Parse(typeof(AMS.Broker.Contracts.DTO.Status), (string)evtdto.Status),////Status FROM EventTemplateDto
                    MessageTypeId = Contracts.DTO.MessageType.Alert,////////MessageType FROM EventTemplateDto
                    ScopeId = (Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), (string)evtdto.Scope),////Scope FROM EventTemplateDto
                    Code = ServiceName + ":" + machineName + ":" + Ipaddress,//eventDB.EventCode,/////EventDto Eeventcode
                    Addresses = _SystemDevice.Name,//(string)wcfEvent.Payload["Address"],////site address from site table
                    MembershipUserId = new Guid(),
                    InfoCollection = new List<InfoDTO>()
                                                    {
                                                        new InfoDTO
                                                            {
                                                                Headline = "",//evtdto.Headline, use as identifier
                                                                Description =  (string)evtdto.Description,////Description FROM EventTemplateDto
                                                                Instruction =  (string)evtdto.Instruction,////Instruction FROM EventTemplateDto
                                                                Contact = "",//(string)wcfEvent.Payload["Contact"],////Contactid get from account id get from site id
                                                                UrgencyId = (Contracts.DTO.Urgency)Enum.Parse(typeof(Contracts.DTO.Urgency), (string)evtdto.Urgency),
                                                                SeverityId = (Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), (string)evtdto.Severity),
                                                                CertaintyId = (Contracts.DTO.Certainty)Enum.Parse(typeof(Contracts.DTO.Certainty), (string)evtdto.Certainty),
                                                                //EventCode=eventID,
                                                                Event = evtdto.Headline,//eventDB.EventCode,////Actual event code from event                                                               
                                                                AreasCollection = new List<AreaDTO>()
                                                                    {
                                                                        new AreaDTO
                                                                            {
                                                                                SiteId =long.Parse(_SystemDevice.SiteId.ToString()),
                                                                                Latitude = Convert.ToDouble(_SystemDevice.Lat),
                                                                                Longitude = Convert.ToDouble(_SystemDevice.Long),
                                                                                Altitude =  Convert.ToDouble(_SystemDevice.Altitude)
                                                                            }
                                                                    }
                                                            }
                                                    }
                };
                               

                try
                {
                    long ALertId = SubmitSystemAlert(alert);                                   
                }
                catch (Exception es)
                {
                    _logger.Info("ServerClientCommunication service CreateAlert() Exception" + es.Message);

                    string Message = "ServerClientCommunication service Service CreateAlert Exception:" + es.Message;
                    InsertBrokerOperationLog.AddProcessLog(Message);
                }
            }
            catch (Exception ex)
            {
                string Message = "ServerClientCommunication Service CreateAlert Exception 1:" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }           
        }

        public static long SubmitSystemAlert(AMS.Broker.Contracts.DTO.Alert alert)
        {
            long nVerAlertid = 0;
            try
            {
                //string Message = "AlertsCreationService -SubmitNewAlertMycs() -- Start:";               
                //InsertTransactionLog.InsertLog(Message);//jatin
                long result = 0;
                Guid parsedGuid;
                if (alert.Identifier == null || !Guid.TryParse(alert.Identifier, out parsedGuid)) alert.Identifier = Guid.NewGuid().ToString();
                using (var context = new CentralDBEntities())
                {
                    //bool alertAlreadyExists = false;//context.Alert.Any(x => x.Identifier.Equals(alert.Identifier, StringComparison.OrdinalIgnoreCase));
                    //if (!alertAlreadyExists)
                    //{
                    try
                    {
                        alert.Severity = alert.InfoCollection[0].SeverityId;
                        alert.Urgency = alert.InfoCollection[0].UrgencyId;
                        alert.ReceivedDateTime = DateTime.Now;
                        // var alertDb = Mapper.Map<DataStore.Alert>(alert);
                        //amit 22092016
                        AMS.Broker.DataStore.Alert alertDb = new AMS.Broker.DataStore.Alert
                        {
                            //AlertId = alert.AlertId,
                            DeviceId = alert.DeviceId,
                            Sender = alert.Sender,
                            Source = alert.Source,
                            Sent = alert.Sent,
                            Identifier = alert.Identifier,
                            StatusId = alert.StatusId.ToString(),//(Status)Enum.Parse(typeof(Status), (string)alert.StatusId),
                            MessageTypeId = alert.MessageTypeString, //(MessageType)Enum.Parse(typeof(MessageType), (string)_data.MessageTypeId),
                            ScopeId = alert.ScopeId.ToString(),//(Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), (string)_data.ScopeId),
                            Code = alert.Code,
                            Addresses = alert.Addresses,
                            Alertzone = alert.AlertZone,
                            //Severity = (Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), (string)alert.InfoCollection.FirstOrDefault().SeverityId),
                            ReceivedDateTime = DateTime.Parse(alert.ReceivedDateTime.ToString()),

                            MembershipUserId = new Guid(alert.MembershipUserId.ToString()),
                            //AlertOwner = alert.AlertOwner,
                            Info = new List<AMS.Broker.DataStore.Info>()
                                {
                                        new AMS.Broker.DataStore.Info
                                            { 
                                                SenderName=alert.InfoCollection.FirstOrDefault().SenderName,
                                                Headline = alert.InfoCollection.FirstOrDefault().Headline,
                                                Description =alert.InfoCollection.FirstOrDefault().Description,
                                                Instruction =alert.InfoCollection.FirstOrDefault().Instruction,
                                                Contact = alert.InfoCollection.FirstOrDefault().Contact,
                                                UrgencyId = alert.InfoCollection.FirstOrDefault().UrgencyId.ToString(),//(Contracts.DTO.Urgency)Enum.Parse(typeof(Contracts.DTO.Urgency), (string)alert.InfoCollection.FirstOrDefault().UrgencyId),
                                                SeverityId = alert.InfoCollection.FirstOrDefault().SeverityId.ToString(),//(Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity),alert.InfoCollection.FirstOrDefault().SeverityId),
                                                CertaintyId = alert.InfoCollection.FirstOrDefault().CertaintyId.ToString(),//(Contracts.DTO.Certainty)Enum.Parse(typeof(Contracts.DTO.Certainty), alert.InfoCollection.FirstOrDefault().CertaintyId),
                                                Event = alert.InfoCollection.FirstOrDefault().Event,  
                                               //EventCode=Int32.Parse(alert.InfoCollection.FirstOrDefault().EventCode.ToString()),
                                                Area = new List<AMS.Broker.DataStore.Area>()
                                                    {
                                                        new AMS.Broker.DataStore.Area
                                                            {
                                                               // AreaId=int.Parse(alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().AreaId.ToString()),
                                                                SiteId = int.Parse(alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().SiteId.ToString()),
                                                                //InfoId=alert.InfoCollection.FirstOrDefault().InfoId,
                                                                Latitude = alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().Latitude,
                                                                Longitude = alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().Longitude,
                                                                Altitude =alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().Altitude,
                                                                Description=""//alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().Description,
                                                              //  Celing=alert.InfoCollection.FirstOrDefault().AreasCollection.FirstOrDefault().Celing,
                                                            }
                                                    }
                                            }
                                    },

                        };

                        try
                        {
                            context.Configuration.AutoDetectChangesEnabled = false;
                            context.Configuration.ValidateOnSaveEnabled = false;
                            context.Alert.Add(alertDb);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SubmitSystemAlert() Exception for save changes:" + ex.Message);
                        }

                        alert.AlertId = alertDb.AlertId;
                        result = alert.AlertId;
                        nVerAlertid = alert.AlertId;
                        alert.Severity = alert.InfoCollection[0].SeverityId;
                        alert.Urgency = alert.InfoCollection[0].UrgencyId;


                        string AlertPushMode = Storage.AlertPushMode;
                        if (AlertPushMode == "")
                            AlertPushMode = "0";

                        try
                        {

                            if (alert.DeviceDto == null)
                            {
                                using (var devicecontext = new CentralDBEntities())
                                {
                                    var devicetemplates = from dc in devicecontext.Device
                                                          where dc.DeviceId == alert.DeviceId
                                                          select dc;
                                    var devicetemplate = devicetemplates.FirstOrDefault();
                                    int count = devicetemplates.Count();
                                    if (count > 0)
                                    {
                                        //alert.DeviceDto = Mapper.Map<DeviceDto>(devicetemplate); ;// Mapper.Map<DeviceDto>(alerttemplate);
                                        //amit 29092016
                                        if (devicetemplate is NvrCamera)
                                        {
                                            var _entity1 = devicetemplate as NvrCamera;

                                            NvrCameraDto DevDto = new NvrCameraDto()
                                            {
                                                DeviceId = _entity1.DeviceId,
                                                ExternalId = _entity1.ExternalId,
                                                Description = _entity1.Description,
                                                Metadata = _entity1.Metadata,
                                                Type = _entity1.Type,
                                                Lat = _entity1.Lat,
                                                Long = _entity1.Long,
                                                Altitude = _entity1.Altitude,
                                                LocationDescription = _entity1.LocationDescription,
                                                CameraGUID = _entity1.CameraGuid,
                                                NvrId = _entity1.NvrId,
                                                SiteId = _entity1.SiteId.HasValue ? _entity1.SiteId.Value : 0,
                                                ActiveAlert = _entity1.ActiveAlert,
                                                InterfaceId = _entity1.InterfaceId.HasValue ? _entity1.InterfaceId.Value : 0,
                                                IsMovable = false,//_entity1.IsMovable,
                                                Name = _entity1.Name,
                                                AnalyticAlgorithmTypeId = _entity1.AnalyticAlgorithmTypeId, //None                                 
                                                FPS = _entity1.FPS,
                                                Version = _entity1.Version,
                                                MaxBlobSize = _entity1.MaxBlobSize,
                                                MinBlobSize = _entity1.MinBlobSize,
                                                AlarmDelay = _entity1.AlarmDelay,
                                                UpdateRate = _entity1.UpdateRate,
                                                Width = _entity1.Width,
                                                Height = _entity1.Height,
                                                ZoneRows = _entity1.ZoneRows,
                                                ZoneColumns = _entity1.ZoneColumns,
                                                ZoneData = null,
                                                AnalyticsEventTemplateId = _entity1.AnalyticsEventTemplateId,
                                                IsPtz = _entity1.IsPtz,
                                                CameraIp = _entity1.CameraIp,
                                                LineStart = _entity1.LineStart,
                                                LineEnd = _entity1.LineEnd,
                                                DirectionFlag = _entity1.DirectionFlag,
                                                CameraUrl = _entity1.CameraUrl,
                                                CamUser = _entity1.CamUser,
                                                CamPassword = _entity1.CamPassword,
                                                CameraPort = _entity1.CameraPort,
                                                CameraType = _entity1.CameraType,
                                                MaxBlobHeight = _entity1.MaxBlobHeight,
                                                MaxBlobWidth = _entity1.MaxBlobWidth,
                                                MinBlobHeight = _entity1.MinBlobHeight,
                                                MinBlobWidth = _entity1.MinBlobWidth,
                                                AnalyticsServerIp = _entity1.AnalyticsServerIp,
                                                Lane1 = _entity1.Lane1,
                                                Lane2 = _entity1.Lane2,
                                                Lane3 = _entity1.Lane3,
                                                NoOfLens = _entity1.NoOfLens,
                                                ChanelNo = _entity1.ChanelNo,
                                                IsEdgeAnalytics = _entity1.IsEdgeAnalytics,
                                                IPAddress = _entity1.NVR.IPAddress
                                            };
                                            alert.DeviceDto = DevDto;
                                        }
                                        else
                                        {

                                            DeviceDto DevDto = new DeviceDto
                                            {
                                                DeviceId = devicetemplate.DeviceId,
                                                ExternalId = devicetemplate.ExternalId,
                                                Description = devicetemplate.Description,
                                                Metadata = devicetemplate.Metadata,
                                                Type = devicetemplate.Type,
                                                Lat = devicetemplate.Lat,
                                                Long = devicetemplate.Long,
                                                Altitude = devicetemplate.Altitude,
                                                LocationDescription = devicetemplate.LocationDescription,
                                                CameraGUID = devicetemplate.CameraGuid,
                                                NvrId = devicetemplate.NvrId,
                                                SiteId = devicetemplate.SiteId.HasValue ? devicetemplate.SiteId.Value : 0,
                                                ActiveAlert = devicetemplate.ActiveAlert,
                                                InterfaceId = devicetemplate.InterfaceId.HasValue ? devicetemplate.InterfaceId.Value : 0,
                                                IsMovable = devicetemplate.IsMovable,
                                                Name = devicetemplate.Name
                                            };
                                            alert.DeviceDto = DevDto;
                                        }
                                        //We have commented GetSingleAlert method in controller and taken care below
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SubmitSystemAlert() Exception() after save changes:" + ex.Message);
                        }
                        //
                        if (AlertPushMode == "1")
                        {
                            Task.Run(() => InformAboutRaisedAlertsNew(alert));
                        }

                        Task.Run(() => SendSMS(alert));

                        Task.Run(() => SendMail(alert));
                        
                    
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("ServerClientCommunication Service SubmitSystemAlert() Exception:" + ex.Message);
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SubmitSystemAlert():" + ex.Message);
                    }               

                }

                //_logger.Info("------------------------------------");
                _logger.Info("ServerClientCommunication Service SubmitSystemAlert() AlertID: " + nVerAlertid.ToString()); //alertDb.AlertId;
                string Message1 = "ServerClientCommunication Service SubmitSystemAlert():-AlertID: " + nVerAlertid.ToString() + "--!--Headline " + alert.Code;
                InsertBrokerOperationLog.AddProcessLog(Message1);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("ServerClientCommunication Service SubmitSystemAlert() Exception:" + ex.Message);

                string Message = "ServerClientCommunication Service SubmitSystemAlert() -- Exception = " + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
                return 0;
            }
            return 0;
        }
        public static void InformAboutRaisedAlertsNew(AlertDTO _AlertDTO)
        {
            StationsServiceRef.StationsServiceClient _serVice = null;
            try
            {
                // string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                string _strUrl = "";
                if (Storage.WorkingMode.ToLower().Contains("primary"))
                {
                    _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                }
                else
                {                   
                    _strUrl = "https://" + Storage.SecondaryStationServiceEnpoint + ":6530/soap/StationsService";
                    
                }

                EndpointAddress ar = new EndpointAddress(_strUrl);
                _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());
                if (Storage.IsCloudServer == "1")
                {
                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(30);
                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(30);
                }
                else
                {
                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(5);
                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(5);
                }
                //
                _serVice.InformAboutRaisedAlertsNew(_AlertDTO, "");//(_AlertDTO, "");
            }
            catch (OutOfMemoryException ex)
            {
                _logger.Info("ServerClientCommunication Service SubmitSystemAlert() InformAboutRaisedAlertsNew() Exception:" + ex.Message);
                //InsertTransactionLog.InsertLog("FFTTransaction Service InformAboutRaisedAlertsNew() Exception:" + ex.Message);//jatin

            }
            catch (Exception ex)
            {
                _logger.Info("ServerClientCommunication Service SubmitSystemAlert() InformAboutRaisedAlertsNew() Exception 1:" + ex.Message);
               // InsertTransactionLog.InsertLog("FFTTransaction Service InformAboutRaisedAlertsNew() Exception 1:" + ex.Message);//jatin
                Console.WriteLine(ex.Message);
            }
            if (_serVice != null)
            {
                _serVice.Close();
                _serVice = null;
            }
        }


        public static void SendMail(AlertDTO alert) //amit 030520198
        {
            try
            {
              //  if (Storage.SendEmailFlag == "1") //trupti 23 feb 2016 1 for send mail 
               // {
                    string siteName = null;
                    int sitetypeID = 0;
                    try
                    {
                        using (var ctx = new CentralDBEntities())
                        {
                            var _siteDetails = ctx.Site.Where(x => x.SiteId == alert.DeviceDto.SiteId).FirstOrDefault();
                            if (_siteDetails != null)
                            {
                                siteName = _siteDetails.Name;
                                sitetypeID = Int32.Parse(_siteDetails.siteTypeId.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    string msg = "Alert Information";
                    msg += "\n Alert Id: " + alert.AlertId;
                    msg += "\n Camera Name: " + alert.DeviceDto.Name;
                    msg += "\n Alert Type: " + alert.Code;
                    msg += "\n Zone Name: " + siteName;
                    msg += "\n Alert DateTime: " + alert.Sent;

                    var _contactDetails = Storage.ServerClientToEmailId.Split(','); //_EmergencycontactCollection.Where(x => x.SiteID == alert.DeviceDto.SiteId);
                    if (_contactDetails != null)
                    {
                        foreach (var _to in _contactDetails)
                        {
                            Task.Run(() => SendMail(msg, _to));
                        }
                    }                 
                //}
            }
            catch (Exception ex)
            {
            }
        }


        private static void SendMail(string strMessage, string _receiver) //amit 030520198
        {
            try
            {
              /*  string Message = "ServerClientCommunication Service -SendMail() -- strMessage = " + strMessage + "--!--_receiver:" + _receiver;
                InsertBrokerOperationLog.AddProcessLog(Message);//jatin
                String Msg = null;

                var smtpConfiguration = GetSMTPConfiguration();
                foreach (var smtpconfig in smtpConfiguration)
                {
                    string fromEmail = smtpconfig.FromAddress; //ConfigurationManager.AppSettings["FromEmainId"]; //"developmentoperation.2020@gmail.com";//ConfigurationSettings.AppSettings["emailFromAddress"];
                    string mailid = _receiver; //ConfigurationManager.AppSettings["ToEmainId"];//"amit.pawar@2020imaging.com"; //ConfigurationSettings.AppSettings["emailToAddress"];
                    string SMTPServer = smtpconfig.SMTPServer;//ConfigurationManager.AppSettings["SMTPServer"];
                    string SMTPPort = smtpconfig.SMTPPort; //ConfigurationManager.AppSettings["SMTPPort"];
                    string SMTPPass = smtpconfig.SMTPPassword;//ConfigurationManager.AppSettings["SMTPPass"];
                    string SMTPUser = smtpconfig.SMTPUser;//ConfigurationManager.AppSettings["SMTPUser"];
                    bool UseAuthentication = (bool)smtpconfig.UseAuthentication;//ConfigurationManager.AppSettings["SMTPUser"];
                    bool UseSSL = (bool)smtpconfig.UseSSL;///ConfigurationManager.AppSettings["UseSSL"];                 
                    SmtpClient emailClient;
                    MailMessage message;
                    message = new MailMessage();
                    message.From = new MailAddress(fromEmail);
                    message.ReplyTo = new MailAddress(fromEmail);
                    if (SetMailAddressCollection(message.To, mailid))
                    {
                        try
                        {
                            message.Subject = smtpconfig.EmailDisplayName;//email subject
                            message.Body = strMessage;
                            message.IsBodyHtml = true;
                            emailClient = new SmtpClient();//smtp.gmail.com");
                            emailClient.Host = SMTPServer;//"2020imaging.com";
                            emailClient.Port = Int32.Parse(SMTPPort.ToString());//25;//587;
                            emailClient.UseDefaultCredentials = UseAuthentication;
                            emailClient.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPass);//"zicom.com");//dtzbplwebovxsovg
                            emailClient.EnableSsl = UseSSL;
                            emailClient.Send(message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception:" + ex.Message);
                        }
                    }
                    return;
                }*/
                
                try
                {
                    if (Storage.SendEmailFlag == "1")
                    {
                        string Message = "ServerClientCommunication -SendMail() Start -- strMessage = " + strMessage + "--!--_receiver:" + _receiver;
                        InsertBrokerOperationLog.AddProcessLog(Message);//jatin
                        var json = JsonServicesHelper.GetJsonResponse("EmailNotificationService", "SendEmailNotification", "Message=" + strMessage, "Receiver=" + _receiver);
                        if (json == null)
                        {
                            InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication  SendMail() :End");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string Message = "ServerClientCommunication -SendMail() -- Exception = " + ex.Message;
                    InsertBrokerOperationLog.AddProcessLog(Message);//jatin
                }           
       

            }
            catch (Exception ex)
            {
                string Message = "ServerClientCommunication Service -SendMail() -- Exception = " + ex.Message;              
                InsertBrokerOperationLog.AddProcessLog(Message);//jatin
            }
            finally
            {
                // ClearMemory();
            }
        }

        private static bool SetMailAddressCollection(MailAddressCollection toAddresses, string mailId)
        {
            bool successfulAddressCreation = true;
            toAddresses.Add(new MailAddress(mailId));
            return successfulAddressCreation;
        }

        public static List<tblSMTPConfigurationDTO> GetSMTPConfiguration() //amit 23102017
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    List<tblSMTPConfigurationDTO> smtpconfigList = new List<tblSMTPConfigurationDTO>();
                    var smsconfig = context.tblSMTPConfiguration;
                    if (smsconfig != null)
                    {
                        foreach (var smtp in smsconfig)
                        {
                            tblSMTPConfigurationDTO _tblSMTPConfigurationDTO = new tblSMTPConfigurationDTO();
                            _tblSMTPConfigurationDTO.ID = smtp.ID;
                            _tblSMTPConfigurationDTO.Name = smtp.Name;
                            _tblSMTPConfigurationDTO.EmailDisplayName = smtp.EmailDisplayName;
                            _tblSMTPConfigurationDTO.FromAddress = smtp.FromAddress;
                            _tblSMTPConfigurationDTO.SMTPPassword = smtp.SMTPPassword;
                            _tblSMTPConfigurationDTO.SMTPPort = smtp.SMTPPort;
                            _tblSMTPConfigurationDTO.SMTPServer = smtp.SMTPServer;
                            _tblSMTPConfigurationDTO.SMTPUser = smtp.SMTPUser;
                            _tblSMTPConfigurationDTO.UseAuthentication = smtp.UseAuthentication;
                            _tblSMTPConfigurationDTO.UseSSL = smtp.UseSSL;
                            smtpconfigList.Add(_tblSMTPConfigurationDTO);
                        }
                    }

                    return smtpconfigList;
                }
            }
            catch (Exception ex)
            {
                string Message12 = "tblPrimarySecondaryCamGuidMappingDTO -GetSMTPConfiguration() --Exception :" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message12);//jatin
            }
            finally
            {
                //ClearMemory();
            }
            return null;
        }


        public static bool SendSMS(AlertDTO alert) //amit 030520198
        {
            try
            {
                string siteName = null;
                int sitetypeID = 0;
                try
                {
                    using (var ctx = new CentralDBEntities())
                    {
                        var _siteDetails = ctx.Site.Where(x => x.SiteId == alert.DeviceDto.SiteId).FirstOrDefault();
                        if (_siteDetails != null)
                        {
                            siteName = _siteDetails.Name;
                            sitetypeID = Int32.Parse(_siteDetails.siteTypeId.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                string msg = "Alert Information,";
                msg += " Alert Id: " + alert.AlertId + ",";
                msg += " Camera Name: " + alert.DeviceDto.Name + ",";
                msg += " Alert Type: " + alert.Code + ",";
                msg += " Zone Name: " + siteName + ",";
                msg += " Alert DateTime: " + alert.Sent;
          
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SendSMS() Start:msg-:" + msg);

                var SMSUrlData = "";
                using (var context = new CentralDBEntities())
                {
                    try
                    {
                        var SmsData = context.tblSMSConfiguration.FirstOrDefault();
                        if (SmsData != null)
                        {
                            SMSUrlData = SmsData.Url;
                        }
                    }
                    catch (Exception ex)
                    { }
                }

                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service Start:SMSUrlData-:" + SMSUrlData);
                //SendSmsEmergencyContact
                if (SMSUrlData != "")
                {

                    Task.Run(() => SendSmsEmergencyContact(msg));
                    
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        

        public static void SendSmsEmergencyContact(string _msg)
        {

            try
            {
                var PhnLst = Storage.ServerClientSMSMobNo.Split(','); //amit 030520198
                foreach (var Itm in PhnLst)
                {
                    var _mobNumber = Itm;
                    if (_mobNumber != null && _mobNumber != "")
                    {
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SendSmsEmergencyContact() Send SMS Successflly to MobNumber: " + _mobNumber + "--!--strMessage" + _msg);

                        if (_mobNumber != null && _mobNumber != "")
                        {
                            var json = JsonServicesHelper.GetJsonResponse("SMSNotificationService", "SendSmsNotification", "MobNo=" + _mobNumber, "Msg=" + _msg);
                            if (json == null)
                            {
                                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service :End");
                            }
                            // return 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service SendSmsEmergencyContact()  Exception:" + ex.Message);
            }

           /* var SMSUrlData = "";
            using (var context = new CentralDBEntities())
            {
                try
                {
                    var SmsData = context.tblSMSConfiguration.FirstOrDefault();
                    if (SmsData != null)
                    {
                        SMSUrlData = SmsData.Url;
                    }
                }
                catch (Exception ex)
                { }
            }

            var PhnLst = Storage.ServerClientSMSMobNo.Split(',');

            foreach (var Itm in PhnLst)
            {
                var _mobNumber = Itm;
                if (_mobNumber != null && _mobNumber != "")
                {
                    _msg = _msg.Replace("&", "and");
                    string result = "";
                    WebRequest request = null;
                    HttpWebResponse response = null;
                    bool IsMsgSent = false;
                    // PickSmsDetails();
                    try
                    {
                      
                        String sendToPhoneNumber = _mobNumber;
                        String url = SMSUrlData;//"http://enterprise.smsgupshup.com/GatewayAPI/rest?method=sendMessage&send_to=@mobno&msg=@msg&userid=2000135572 &password=Tk8sB5&v=1.1&msg_type=TEXT&auth_scheme=PLAIN";//
                        url = url.Replace("@mobno", sendToPhoneNumber);
                        url = url.Replace("@msg", _msg);                       
                        request = WebRequest.Create(url);                       
                        response = (HttpWebResponse)request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        StreamReader reader = new
                        System.IO.StreamReader(stream, ec);
                        result = reader.ReadToEnd();
                        result = result.ToLower();
                        if (result.Contains("success") || result.Contains("Success") || result.Contains("DONE") || result.Contains("done") || result.Contains("ok") || result.Contains("OK") || result.Contains("1701"))
                        {
                            IsMsgSent = true;                           
                        }
                        Console.WriteLine(result);
                        reader.Close();
                        stream.Close();
                      
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        string Message = "SOPSendSMS sendsms() Exception" + ex.Message;
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication Service Exception: "+ex.Message);//jatin
                    }
                    finally
                    {
                        if (response != null)
                            response.Close();
                    }

                    // return 1;
                }
                else
                {
                    string Message = "Mobile number is not available";                    
                    InsertBrokerOperationLog.AddProcessLog(Message);//jatin
                    return 0;
                }
            }
            return 0;*/
        }

        public void UpdateServerClientStatus()
        {
            try
            {              

            }
            catch (Exception ex)
            {               
            }
        }
    }
}

