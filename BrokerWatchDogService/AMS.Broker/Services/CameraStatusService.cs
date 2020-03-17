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


namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class CameraStatusService : ICameraStatusService
    {

       // readonly ICameraStatusService _CameraStatusService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();     
        private System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();    
        public IEnumerable<DeviceDto> DeviceCollection = null;
        private static ICameraStatusService _serviceInstance = new CameraStatusService();
        public static ICameraStatusService ServiceInstance { get { return _serviceInstance; } }

        

        public Dictionary<int, string> _CameraStatusDtoCollection = new Dictionary<int, string>();

        private Thread CameraStatusThread; // jatin 27112018

       public int AnprStatAlertTime = Int32.Parse(Storage.AnprDeviceStatusAlertTime);

        public CameraStatusService()
        {            
        }

        public CameraStatusService(bool flag)
        {
            //bool camStatus = IsDeviceAlive("192.168.0.171", 554);//nvrCamera.CameraIp, nPort);
            if (Storage.IsCameraStatusEnable == "1")
            {
                DeviceCollection = GetDevicesCollection();
                StartCameraStatusTimer();

            }
        }

        internal static ICameraStatusService Initialise()
        {
            try
            {
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting Camera Status service");

                Uri httpUrl = new Uri("https://localhost:6530/CameraStatusService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(CameraStatusService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(ICameraStatusService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();

                CameraStatusService _Obje = new CameraStatusService(false); //createobject fro param constructor

                _logger.Info("Camera Status service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService Initialise() Exception" + ex.Message);
            }
            return null;
        }
                       
        
        public void ProcessStatusData(long deviceID, string strDatetime, string msg, string machineIP, string machineIdentifier, string deviceName, string deviceIP, string siteId, string authToken, string isOperatorFeedbackFlag)
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessStatusData(): Start msg:" + msg + "--!--deviceIP:" + deviceIP + "--!--deviceID:" + deviceID + "---!--deviceName:" + deviceName + "---!--isOperatorFeedbackFlag:" + isOperatorFeedbackFlag);

                string _isoperatorfeedbackflag = isOperatorFeedbackFlag;

                Guid _authToken = new Guid(authToken);

                //deviceIp devicename,branchname 
                string siteName = "";
                DateTime _dt = DateTime.Parse(strDatetime);
                int alertid = 0;
                string _msg = msg;
                if(_msg.Length>98)
                    _msg = _msg.Substring(0, 98);
                using (var context = new CentralDBEntities())
                {
                    //get 
                    int _siteid = Int32.Parse(siteId);
                    var siteDetails = context.Site.FirstOrDefault(x => x.SiteId == _siteid);
                    if (siteDetails != null)
                    {
                        siteName = siteDetails.Name;
                    }

                }
                //
                string _strSqlConn = "user id=" + Storage.CamStatusDBUsername + ";password=" + Storage.CamStatusDBPassword + ";server=" + Storage.CamStatusDBServer + ";" + "Trusted_Connection=false;" + "database=" + Storage.CamStatusDB;
                try
                {
                    using (SqlConnection connection = new SqlConnection(_strSqlConn))
                    {
                        connection.Open();

                        try
                        {
                            SqlCommand insertCommand = new SqlCommand("INSERT INTO tbliballmonitoringlog (MachineIdentifier, MachineIP, BranchName, DeviceID,DeviceIP,DeviceName,DeviceStatus,Statusdatetime) VALUES (@MachineIdentifier, @MachineIP, @BranchName, @DeviceID, @DeviceIP, @DeviceName, @DeviceStatus, @Statusdatetime)", connection);

                            insertCommand.Parameters.Add(new SqlParameter("@MachineIdentifier", machineIdentifier));
                            insertCommand.Parameters.Add(new SqlParameter("@MachineIP", machineIP));
                            insertCommand.Parameters.Add(new SqlParameter("@BranchName", siteName));
                            insertCommand.Parameters.Add(new SqlParameter("@DeviceID", deviceID));
                            insertCommand.Parameters.Add(new SqlParameter("@DeviceIP", deviceIP));
                            insertCommand.Parameters.Add(new SqlParameter("@DeviceName", deviceName));
                            insertCommand.Parameters.Add(new SqlParameter("@DeviceStatus", _msg));
                            insertCommand.Parameters.Add(new SqlParameter("@Statusdatetime", _dt));
                            insertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        { 
                        }

                        try
                        {
                            if (_isoperatorfeedbackflag != "0" && _isoperatorfeedbackflag != null)
                            {

                                SqlCommand insertCommanddata = new SqlCommand("INSERT INTO tblThinClientOperatorFeedback (AuthToken,MachineIdentifier, MachineIP,StatusDateTime,Status, DeviceId,AlertID,Remarks) VALUES (@AuthToken,@MachineIdentifier, @MachineIP, @StatusDateTime, @Status,@DeviceId,@AlertID,@Remarks)", connection);
                                insertCommanddata.Parameters.Add(new SqlParameter("@AuthToken", _authToken));
                                insertCommanddata.Parameters.Add(new SqlParameter("@MachineIdentifier", machineIdentifier));
                                insertCommanddata.Parameters.Add(new SqlParameter("@MachineIP", machineIP));
                                insertCommanddata.Parameters.Add(new SqlParameter("@StatusDateTime", _dt));
                                insertCommanddata.Parameters.Add(new SqlParameter("@Status", 3));//3 means offline camera
                                insertCommanddata.Parameters.Add(new SqlParameter("@DeviceId", deviceID));
                                insertCommanddata.Parameters.Add(new SqlParameter("@AlertID", alertid));
                                insertCommanddata.Parameters.Add(new SqlParameter("@Remarks", _msg));
                                insertCommanddata.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessStatusData() tblThinClientOperatorFeedback :SqlException:" + ex.Message);
                        }
                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessStatusData():SqlException:"+ex.Message);
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessStatusData():Exception:" + ex.Message);
                }
                
                // 
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessStatusData():Exception1:" + ex.Message);
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool UpdateThinClientCameraStatus(long deviceID, string strDatetime, string authToken, string machineIP, string machineIdentifier, int status, int alertID, string remark)
        {
            try
            {
                var res = ProcessUpdateCameraStatusData(deviceID, strDatetime, authToken, machineIP, machineIdentifier, status, alertID, remark);
                if (res == true)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool ProcessUpdateCameraStatusData(long deviceID, string strDatetime, string authToken, string machineIP, string machineIdentifier, int status, int alertID, string remark)
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessUpdateCameraStatusData(): Start authToken:" + authToken + "--!--machineIP:" + machineIP + "--!--deviceID:" + deviceID);

                //deviceIp devicename,branchname 
                string siteName = "";
                DateTime _dt = DateTime.Parse(strDatetime);
                Guid _authToken = new Guid(authToken);
                string _remark = remark;  
                //
                string _strSqlConn = "user id=" + Storage.CamStatusDBUsername + ";password=" + Storage.CamStatusDBPassword + ";server=" + Storage.CamStatusDBServer + ";" + "Trusted_Connection=false;" + "database=" + Storage.CamStatusDB;
                try
                {
                    using (SqlConnection connection = new SqlConnection(_strSqlConn))
                    {
                        connection.Open();
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO tblThinClientOperatorFeedback (AuthToken,MachineIdentifier, MachineIP,StatusDateTime,Status, DeviceId,AlertID,Remarks) VALUES (@AuthToken,@MachineIdentifier, @MachineIP, @StatusDateTime, @Status,@DeviceId,@AlertID,@Remarks)", connection);

                        insertCommand.Parameters.Add(new SqlParameter("@AuthToken", _authToken));
                        insertCommand.Parameters.Add(new SqlParameter("@MachineIdentifier", machineIdentifier));
                        insertCommand.Parameters.Add(new SqlParameter("@MachineIP", machineIP));
                        insertCommand.Parameters.Add(new SqlParameter("@StatusDateTime", _dt));
                        insertCommand.Parameters.Add(new SqlParameter("@Status", status));
                        insertCommand.Parameters.Add(new SqlParameter("@DeviceId", deviceID));
                        insertCommand.Parameters.Add(new SqlParameter("@AlertID", alertID));
                        insertCommand.Parameters.Add(new SqlParameter("@Remarks", _remark));
                        insertCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessUpdateCameraStatusData():SqlException:" + ex.Message);
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessUpdateCameraStatusData():Exception:" + ex.Message);
                }
                // 
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Camera status service ProcessUpdateCameraStatusData():Exception1:" + ex.Message);
            }
            return false;
        }



        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void InformToServerAboutCameraOffline(long deviceID, string strDatetime, string msg, string machineIP, string machineIdentifier, string deviceName, string deviceIP, string siteId, string authToken, string isOperatorFeedbackFlag)
        {
            try
            {
                Task.Run(() => ProcessStatusData(deviceID, strDatetime, msg, machineIP, machineIdentifier, deviceName, deviceIP, siteId, authToken, isOperatorFeedbackFlag));
               
            }
            catch (Exception ex)
            { 
            }
        }

        private IEnumerable<DeviceDto> GetDevicesCollection()
        {

            InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection(): Start");
            try
            {
                using (var context = new CentralDBEntities())
                {
                    IList<DeviceDto> result = new List<DeviceDto>();

                    var resultsCollection = context.Device.Where(x => x.Type == "NvrCamera");

                    var result2 = resultsCollection.Select(x => x).ToList();

                    foreach (var _entity in result2)
                    {
                        if (_entity is AMS.Broker.DataStore.NvrCamera)
                        {
                            try
                            {
                                var _entity1 = _entity as AMS.Broker.DataStore.NvrCamera;

                                var _deviceDto = new NvrCameraDto()
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
                                    IsMovable = _entity1.IsMovable,
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
                                result.Add(_deviceDto);
                            }
                            catch (Exception ES)
                            {
                                InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection()Exception : " + ES.Message);
                            }
                        }
                        //else
                        //{
                        //    try
                        //    {
                        //        var _deviceDto = new DeviceDto
                        //        {
                        //            DeviceId = _entity.DeviceId,
                        //            ExternalId = _entity.ExternalId,
                        //            Description = _entity.Description,
                        //            Metadata = _entity.Metadata,
                        //            Type = _entity.Type,
                        //            Lat = _entity.Lat,
                        //            Long = _entity.Long,
                        //            Altitude = _entity.Altitude,
                        //            LocationDescription = _entity.LocationDescription,
                        //            CameraGUID = _entity.CameraGuid,
                        //            NvrId = _entity.NvrId,
                        //            SiteId = _entity.SiteId.HasValue ? _entity.SiteId.Value : 0,
                        //            ActiveAlert = _entity.ActiveAlert,
                        //            InterfaceId = _entity.InterfaceId.HasValue ? _entity.InterfaceId.Value : 0,
                        //            IsMovable = _entity.IsMovable,
                        //            Name = _entity.Name
                        //        };

                        //        result.Add(_deviceDto);
                        //    }
                        //    catch (Exception es)
                        //    {
                        //        InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection()Exception 1: " + es.Message);
                        //    }
                        //}
                    }
                    InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection() Count : " + resultsCollection.Count());
                    _logger.Info("  items count: {0}", resultsCollection.Count());
                    _logger.Info("------------------------------------");
                    ClearMemory();
                    return result;

                }
            }
            catch (SecurityException ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection() SecurityException : " + ex.Message);
                _logger.Info("ControllerServiceImpl GetDevicesCollectionImpl() Exception:" + ex.Message);
                _logger.Error(ex);
            }
            finally
            {
                ClearMemory();
            }
            //

            return null;
        }

        public void CreateXamlFile(IEnumerable<DeviceDto> _deviceCollection)
        {
            try
            {
                if (!Directory.Exists(Storage.DeviceListPath))
                    Directory.CreateDirectory(Storage.DeviceListPath);

                foreach (var Dev in _deviceCollection)
                {
                    if (Dev is NvrCameraDto)
                    {
                        var _cam = Dev as NvrCameraDto;
                        string Fpath = Storage.DeviceListPath + "\\" + _cam.DeviceId + ".xaml";
                        Fpath = Fpath.Replace("\r", string.Empty);
                        Fpath = Fpath.Replace("\n", string.Empty);
                        try
                        {
                            if (File.Exists(Fpath))
                            {
                                File.Delete(Fpath);
                            }
                            //File.Create(Fpath);
                            using (var writer = new System.IO.StreamWriter(Fpath))
                            {
                                var serializer = new XmlSerializer(_cam.GetType());
                                serializer.Serialize(writer, _cam);
                                writer.Flush();
                            }
                        }
                        catch (Exception ex)
                        { _logger.Info("BrokerService CreateXamlFile() Exception:" + ex.Message); }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("BrokerService CreateXamlFile() Exception:" + ex.Message);
            }
        }


        public void ClearMemory()
        {
            try
            {
                long bytes1 = GC.GetTotalMemory(false); // Get memory in bytes
                //Console.WriteLine("Alert Service Memory Before Collect " + bytes1);
                _logger.Info("Alert Service Memory Before Collect " + bytes1);
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                long bytes3 = GC.GetTotalMemory(true); // Get memory
                // Console.WriteLine("Alert Service Memory After garbage collection " + bytes3);
                _logger.Info("Alert Service Memory After garbage collection " + bytes3);
            }
            catch (Exception ex)
            {
            }
        }
       
        public void StartCameraStatusTimer()
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("CameraStatus Thread Started "); // jatin 27112018

                //  CreateDeviceListFile(); jatin 07022019
                UpdateCameraStatus();

                try
                {
                    CameraStatusThread = new Thread(new ThreadStart(UpdateCameraStatusTimer));
                    CameraStatusThread.IsBackground = true;
                    CameraStatusThread.Start();
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("CameraStatusService StartCameraStatusTimer() Thread Initialization Exception" + ex.Message); // jatin 27112018
                }
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService StartCameraStatusTimer() Exception" + ex.Message);
                InsertBrokerOperationLog.AddProcessLog("CameraStatusService StartCameraStatusTimer() Exception" + ex.Message); // jatin 27112018
            }

        }        
        
        public void UpdateCameraStatusTimer()
        {
            while (true)
            {
                try
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera Status Timer Started");
                    //  CreateDeviceListFile();  jatin 07022019
                    UpdateCameraStatus();
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Camera Status Timer Exception:" + ex.Message);
                }

                var _camStatusTimeInterval = Storage.CameraStatusTimeSec;
                if (_camStatusTimeInterval < 60)
                {
                    _camStatusTimeInterval = 60;
                }
                new ManualResetEvent(false).WaitOne(_camStatusTimeInterval * 1000);//10 sec // ACSThreadWaitTime
            }

        }             


        public void UpdateCameraStatus()
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("In CameraStatusService UpdateCameraStatus():"); // jatin 27112018

               // string[] fileEntries = Directory.GetFiles(Storage.DeviceListPath);

                foreach (var deviceDto in DeviceCollection)// jatin 07022019 file creation omit
                {
                    #region jatin 07022019 file creation omit
                    //NvrCameraDto deviceDto = null; jatin 07022019 file creation omit
                    //XmlSerializer ser = new XmlSerializer(typeof(NvrCameraDto)); 

                    //using (XmlReader reader = XmlReader.Create(Filename))
                    //{
                    //    deviceDto = (NvrCameraDto)ser.Deserialize(reader);
                    //}
                    #endregion

                    if (deviceDto is NvrCameraDto)
                    {
                        try
                        {

                            var nvrCamera = deviceDto as NvrCameraDto;
                            if (nvrCamera.CameraIp != null && nvrCamera.CameraIp != "")
                            {
                                int nPort = 554;
                                if (nvrCamera.CameraPort != null && nvrCamera.CameraPort != "")
                                {
                                    nPort = int.Parse(nvrCamera.CameraPort);
                                }
                               UpdateStatus(deviceDto, nPort);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("CameraStatusService UpdateCameraStatus() Exception" + ex.Message);
                            InsertBrokerOperationLog.AddProcessLog("CameraStatusService UpdateCameraStatus() Exception" + ex.Message); // jatin 27112018
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService UpdateCameraStatus() Exception" + ex.Message);
                InsertBrokerOperationLog.AddProcessLog("CameraStatusService UpdateCameraStatus() Exception" + ex.Message); // jatin 27112018
            }
        }


        public bool checkTelnetSocket(string ip, int port)
        {

            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            try
            {

                var result = clientSocket.ConnectAsync(ip, port).Wait(3000);

                try
                {
                    //clientSocket.EndConnect(result);
                    clientSocket.Close();
                    clientSocket = null;
                }
                catch (Exception ex)
                {
                }

                return result;
            }
            catch (Exception ex)
            {
                try
                {
                    _logger.Info("CameraStatusService checkTelnetSocket() Exception for IP " + ex.Message + " IP " + ip + " Port " + port);
                    string Message = "CameraStatusService checkTelnetSocket() Exception" + ex.Message;
                    InsertBrokerOperationLog.AddProcessLog(Message);
                    //clientSocket.EndConnect(result);   

                    clientSocket.Close();
                    clientSocket = null;
                }
                catch (Exception exr)
                {
                }
                return false;
            }
            return false;
        }

        public void UpdateStatus(DeviceDto _deviceDto, int nPort)
        {
            try
            {
                //amit 14112016
                if (Storage.IsLogEnable == "1")
                {
                    string Message = "Camera Status Service UpdateStatus():DeviceID" + _deviceDto.DeviceId + "--Port:" + nPort;
                    InsertBrokerOperationLog.AddProcessLog(Message);
                }
                var nvrCamera = _deviceDto as NvrCameraDto;
             //   bool camStatus = IsDeviceAlive(nvrCamera.CameraIp, nPort);

                Task t = Task.Factory.StartNew(delegate
                {
                    try
                    {
                        bool camStatus = false;
                        //bool camStatus = IsDeviceAlive(nvrCamera.CameraIp, nPort);

                        camStatus = checkTelnetSocket(nvrCamera.CameraIp, nPort);
                        //new ManualResetEvent(false).WaitOne(3000);

                        try
                        {
                            // bool camStatus = MyResult.Result;
                            if (camStatus != null)
                            {
                                using (var ctx = new CentralDBEntities())
                                {
                                    var nDeviceEntry = ctx.tblCameraStatus.FirstOrDefault(x => x.DeviceID == nvrCamera.DeviceId);
                                    if (nDeviceEntry != null)//Entry exist
                                    {
                                        if (nvrCamera.Name == null)
                                        {
                                        }

                                        if (nvrCamera.CameraIp == null)
                                        {
                                        }
                                        if (nvrCamera.CameraIp != "" && nvrCamera.CameraIp != null)//&& nvrCamera.CameraIp!="NULL")
                                        {
                                            try
                                            {
                                                nDeviceEntry.Status = camStatus;
                                                nDeviceEntry.LastUpdatedTime = DateTime.Now;                                                
                                                ctx.Entry(nDeviceEntry).State = System.Data.EntityState.Modified; // jatin 07022019 file creation omit
                                                ctx.SaveChanges();
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                            try
                                            {
                                                var AnprDevice = ctx.tblANPRMaster.FirstOrDefault(x => x.DeviceID == nvrCamera.DeviceId);
                                                if (AnprDevice != null)
                                                {
                                                    int _deviceID = int.Parse(nvrCamera.DeviceId.ToString());
                                                    if (camStatus == false)
                                                    {

                                                        if (_CameraStatusDtoCollection != null)
                                                        {
                                                            var IsAnprDevStatusAlreadyUpdate = _CameraStatusDtoCollection.Where(x => x.Key == _deviceID && x.Value == "OFF"); //check if same status for Lpu already there then do nothing 

                                                            if (IsAnprDevStatusAlreadyUpdate.Count() == 0)
                                                            {
                                                                DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                                var alrtcnt = ctx.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == nvrCamera.DeviceId);
                                                                if (alrtcnt > 0)
                                                                {
                                                                }
                                                                else
                                                                {
                                                                    Task.Run(() => CreateAlert(nvrCamera.Name, "OFF"));
                                                                }

                                                            }

                                                            var _camstatus = _CameraStatusDtoCollection.FirstOrDefault(x => x.Key == _deviceID).Value;
                                                            if (_camstatus != null)
                                                            {
                                                                _camstatus = "OFF";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                            var alrtcnt = ctx.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == nvrCamera.DeviceId);
                                                            if (alrtcnt > 0)
                                                            {
                                                            }
                                                            else
                                                            {
                                                                Task.Run(() => CreateAlert(nvrCamera.Name, "OFF"));
                                                            }

                                                            _CameraStatusDtoCollection.Add(_deviceID, "OFF");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (_CameraStatusDtoCollection == null)
                                                        {
                                                            _CameraStatusDtoCollection.Add(_deviceID, "ON"); //update camera status
                                                        }
                                                        else
                                                        {
                                                            var _camstatus = _CameraStatusDtoCollection.FirstOrDefault(x => x.Key == _deviceID).Value;
                                                            if (_camstatus != null)
                                                            {
                                                                _camstatus = "ON";
                                                            }
                                                        }
                                                    }

                                                    try //if it is ANPR Camera then update status in anpr master table
                                                    {
                                                        if (camStatus == true)
                                                            AnprDevice.Status = "ON";

                                                        else
                                                            AnprDevice.Status = "OFF";

                                                        ctx.tblANPRMaster.Add(AnprDevice);
                                                        ctx.SaveChanges();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        InsertBrokerOperationLog.AddProcessLog("CameraStatusService UpdateAnprStatus() Exception" + ex.Message + "\n Exception stack: " + ex.StackTrace + "\n Exception string: " + ex.ToString());
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                string Message = "CameraStatusService UpdateAnprStatus() Exception" + ex.Message + "\n Exception stack: " + ex.StackTrace + "\n Exception string: " + ex.ToString();
                                                InsertBrokerOperationLog.AddProcessLog(Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (nvrCamera.CameraIp != "" && nvrCamera.CameraIp != null)
                                        {
                                            int camID = Int32.Parse(_deviceDto.DeviceId.ToString());
                                            var cameraStatus = new AMS.Broker.DataStore.tblCameraStatus();

                                            cameraStatus.Status = camStatus;
                                            cameraStatus.DeviceID = camID;
                                            cameraStatus.CameraIp = nvrCamera.CameraIp;// jatin 24092018
                                            cameraStatus.CameraName = nvrCamera.Name;// jatin 24092018
                                            cameraStatus.LastUpdatedTime = DateTime.Now; // jatin 07032019
                                            ctx.tblCameraStatus.Add(cameraStatus);
                                            ctx.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        //return camStatus;
                    }
                    catch (Exception ex)
                    {
                    }
                    return false;

                });
			
                //TestFile(nvrCamera);

            }
            catch (Exception ex)
            {
                //amit 14112016
                if (Storage.IsLogEnable == "1")
                {
                    string Message = "CameraStatusService UpdateStatus() Exception" + ex.Message;
                    InsertBrokerOperationLog.AddProcessLog(Message);
                }
                _logger.Info("CameraStatusService UpdateStatus() Exception" + ex.Message);
            }
        }

        public void CreateAlert(string DeviceName, string DeviceStaus)
        {
            try
            {
                string Message3 = "CameraStatusService service CreateAlert start DeviceName:" + DeviceName;
                InsertBrokerOperationLog.AddProcessLog(Message3);

                DeviceDto cameraDevice = new DeviceDto();
                EventTemplateDto evtdto = null;
                using (var context = new CentralDBEntities())
                {
                    var devicetemplates = from dc in context.Device
                                          where dc.Name == DeviceName
                                          select dc;
                    var devicetemplate = devicetemplates.FirstOrDefault();
                    int count = devicetemplates.Count();
                    if (count > 0)
                    {
                        //cameraDevice = Mapper.Map<DeviceDto>(devicetemplate);
                        //amit 06102016 manual mapping                                                
                        if (devicetemplate is NvrCamera)
                        {
                            var _entity1 = devicetemplate as NvrCamera;
                            cameraDevice = new NvrCameraDto()
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
                                IsMovable = _entity1.IsMovable,
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

                        }
                        else
                        {
                            cameraDevice = new DeviceDto
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
                        }
                        //
                    }
                }
                if (cameraDevice.DeviceId > 0)
                {
                    using (var contextErrorCode = new CentralDBEntities())
                    {
                        var errorCodetemplates = from dc in contextErrorCode.EventCode
                                                 where dc.EventAssociated == "ANPR Alert"
                                                 select dc;
                        var errorctemplate = errorCodetemplates.FirstOrDefault();

                        if (errorctemplate != null)
                        {

                            int nQualifire = Int32.Parse("1");


                            var alerttemplates = from tc in contextErrorCode.EventTemplate
                                                 where tc.EventCodeId == errorctemplate.EventCode1//nEvtCode
                                                 where tc.EventQualifierId == nQualifire
                                                 where tc.EventTypeTeplateId == 1
                                                 select tc;//EventTemplateId
                            var alerttemplate = alerttemplates.FirstOrDefault();
                            int count = alerttemplates.Count();
                            if (count > 0)
                            {
                                //evtdto = Mapper.Map<EventTemplateDto>(alerttemplate);
                                evtdto = new EventTemplateDto();
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

                    if (evtdto != null)
                    {
                        var alert = new AlertDTO
                        {
                            DeviceId = cameraDevice.DeviceId,
                            Sender = "Device-" + cameraDevice.DeviceId,      //// Device-DeviceID                    
                            Source = cameraDevice.Name,  ////InterfaceId from deviceDTO   ////Should be Name of the Interface
                            //SentAsString = DateTime.Now.ToString(), ////EventDto event datetime
                            Sent = DateTime.Now,
                            Identifier = Guid.NewGuid().ToString(),
                            StatusId = (AMS.Broker.Contracts.DTO.Status)Enum.Parse(typeof(AMS.Broker.Contracts.DTO.Status), (string)evtdto.Status),////Status FROM EventTemplateDto
                            MessageTypeId = Contracts.DTO.MessageType.Alert,////////MessageType FROM EventTemplateDto
                            ScopeId = (Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), (string)evtdto.Scope),////Scope FROM EventTemplateDto
                            Code = cameraDevice.Name + ":" + DeviceStaus, //evtdto.Headline,//eventDB.EventCode,/////EventDto Eeventcode
                            Addresses = cameraDevice.Name,//(string)wcfEvent.Payload["Address"],////site address from site table
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
                                                                                SiteId =long.Parse(cameraDevice.SiteId.ToString()),
                                                                                Latitude = Convert.ToDouble(cameraDevice.Lat),
                                                                                Longitude = Convert.ToDouble(cameraDevice.Long),
                                                                                Altitude =  Convert.ToDouble(cameraDevice.Altitude)
                                                                            }
                                                                    }
                                                            }
                                                    }
                        };

                        try
                        {
                            long ALertId = SubmitAnprDeviceStatusAlert(alert);
                        }
                        catch (Exception es)
                        {
                            _logger.Info("CameraStatusService service CreateAlert() Exception" + es.Message);

                            string Message = "CameraStatusService service Service CreateAlert Exception:" + es.Message;
                            InsertBrokerOperationLog.AddProcessLog(Message);
                        }
                    }
                    else
                    {
                        _logger.Info("CameraStatusService service CreateAlert() Event Template Not Found ANPR");
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service CreateAlert() Event Template Not Found ANPR");
                    }
                }
                else
                {
                    _logger.Info("CameraStatusService service CreateAlert() Device Not Found");
                    InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service CreateAlert() Device Not Found");
                }
            }
            catch (Exception ex)
            {
                string Message = "CameraStatusService Service CreateAlert Exception 1:" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }
        }

        public static long SubmitAnprDeviceStatusAlert(AMS.Broker.Contracts.DTO.Alert alert)
        {
            long nVerAlertid = 0;
            try
            {
                long result = 0;
                Guid parsedGuid;
                if (alert.Identifier == null || !Guid.TryParse(alert.Identifier, out parsedGuid)) alert.Identifier = Guid.NewGuid().ToString();
                using (var context = new CentralDBEntities())
                {
                    try
                    {
                        alert.Severity = alert.InfoCollection[0].SeverityId;
                        alert.Urgency = alert.InfoCollection[0].UrgencyId;
                        alert.ReceivedDateTime = DateTime.Now;
                        //amit 22092016
                        AMS.Broker.DataStore.Alert alertDb = new AMS.Broker.DataStore.Alert
                        {
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
                            InsertBrokerOperationLog.AddProcessLog("CameraStatusService Service SubmitAnprDeviceStatusAlert() Exception for save changes:" + ex.Message);
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
                            InsertBrokerOperationLog.AddProcessLog("CameraStatusService Service SubmitAnprDeviceStatusAlert() Exception() after save changes:" + ex.Message);
                        }
                        //
                        if (AlertPushMode == "1")
                        {
                            Task.Run(() => InformAboutRaisedAlertsNew(alert));
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.Info("CameraStatusService Service SubmitAnprDeviceStatusAlert() Exception:" + ex.Message);

                        InsertBrokerOperationLog.AddProcessLog("AnprDeviceStatus Service SubmitAnprDeviceStatusAlert():" + ex.Message);
                    }


                }

                //_logger.Info("------------------------------------");
                _logger.Info("CameraStatusService Service SubmitAnprDeviceStatusAlert() AlertID: " + nVerAlertid.ToString()); //alertDb.AlertId;
                string Message1 = "CameraStatusService Service SubmitAnprDeviceStatusAlert():-AlertID: " + nVerAlertid.ToString() + "--!--Headline " + alert.Code;
                InsertBrokerOperationLog.AddProcessLog(Message1);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService Service SubmitAnprDeviceStatusAlert() Exception:" + ex.Message);

                string Message = "CameraStatusService Service SubmitAnprDeviceStatusAlert() -- Exception = " + ex.Message;
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
                _logger.Info("CameraStatusService Service SubmitAnprDeviceStatusAlert() InformAboutRaisedAlertsNew() Exception:" + ex.Message);
                //InsertTransactionLog.InsertLog("FFTTransaction Service InformAboutRaisedAlertsNew() Exception:" + ex.Message);//jatin

            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService Service SubmitAnprDeviceStatusAlert() InformAboutRaisedAlertsNew() Exception 1:" + ex.Message);
                // InsertTransactionLog.InsertLog("FFTTransaction Service InformAboutRaisedAlertsNew() Exception 1:" + ex.Message);//jatin
                Console.WriteLine(ex.Message);
            }
            if (_serVice != null)
            {
                _serVice.Close();
                _serVice = null;
            }
        }
               
        public static bool IsDeviceAlive(string strIP, int strPort)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            try
            {
                // Uri uri = new Uri(strUrl);               
                var result = clientSocket.BeginConnect(strIP, strPort, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

                if (!success)
                {
                    try
                    {
                        clientSocket.Close();
                       // clientSocket.EndConnect(result);
                        clientSocket = null;
                    }
                    catch (Exception ex)
                    {
                    }
                    return false;
                }
                // we have connected
               // clientSocket.EndConnect(result);
                try
                {
                    clientSocket.Close();
                    // clientSocket.EndConnect(result);
                    clientSocket = null;
                }
                catch (Exception ex)
                {
                }
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    clientSocket.Close();                   
                    clientSocket = null;
                }
                catch (Exception esd)
                {
                }

                _logger.Info("CameraStatusService IsDeviceAlive() Exception" + ex.Message);
                string Message = "CameraStatusService IsDeviceAlive() Exception" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }
            return false;
        }
    }
}

