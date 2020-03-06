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


namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class CameraStatusService : ICameraStatusService
    {

        readonly ICameraStatusService _CameraStatusService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // private static Timer _timer;
        public int CamerastatusTimer = Storage.CameraStatusTimeSec * 1000;
        static bool exitFlag = false;
        private Timer _timer = new System.Timers.Timer();
        public bool IsFirstTimeCameraStatus = true;




        private static ICameraStatusService _serviceInstance = new CameraStatusService();

        public static ICameraStatusService ServiceInstance { get { return _serviceInstance; } }

        public CameraStatusService()
        {
            // StartCameraStatusTimer();
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

                _logger.Info("Camera Status service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService Initialise() Exception" + ex.Message);
            }
            return null;
        }

        public void CreateDeviceListFile()
        {
            IEnumerable<DeviceDto> DeviceCollection = GetDevicesCollection();

            CreateXamlFile(DeviceCollection);



        }
        public void ProcessStatusData(long deviceID, string strDatetime, string msg, string machineIP, string machineIdentifier, string deviceName, string deviceIP, string siteId)
        {
            try
            {               
                //deviceIp devicename,branchname 
                string siteName = "";
                DateTime _dt = DateTime.Parse(strDatetime);
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
                }
                catch (SqlException ex)
                {
                }
                catch (Exception ex)
                {
                }
                
                // 
            }
            catch (Exception ex)
            { 
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void InformToServerAboutCameraOffline(long deviceID, string strDatetime, string msg, string machineIP, string machineIdentifier, string deviceName, string deviceIP, string siteId)
        {
            try
            {
                Task.Run(() => ProcessStatusData(deviceID, strDatetime, msg, machineIP, machineIdentifier, deviceName, deviceIP, siteId));
               
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


                    var resultsCollection = context.Device;

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
                        else
                        {
                            try
                            {
                                var _deviceDto = new DeviceDto
                                {
                                    DeviceId = _entity.DeviceId,
                                    ExternalId = _entity.ExternalId,
                                    Description = _entity.Description,
                                    Metadata = _entity.Metadata,
                                    Type = _entity.Type,
                                    Lat = _entity.Lat,
                                    Long = _entity.Long,
                                    Altitude = _entity.Altitude,
                                    LocationDescription = _entity.LocationDescription,
                                    CameraGUID = _entity.CameraGuid,
                                    NvrId = _entity.NvrId,
                                    SiteId = _entity.SiteId.HasValue ? _entity.SiteId.Value : 0,
                                    ActiveAlert = _entity.ActiveAlert,
                                    InterfaceId = _entity.InterfaceId.HasValue ? _entity.InterfaceId.Value : 0,
                                    IsMovable = _entity.IsMovable,
                                    Name = _entity.Name
                                };

                                result.Add(_deviceDto);
                            }
                            catch (Exception es)
                            {
                                InsertBrokerOperationLog.AddProcessLog("Camera status service GetDevicesCollection()Exception 1: " + es.Message);
                            }
                        }
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
                        string Fpath = Storage.DeviceListPath + "\\" + _cam.CameraGUID + ".xaml";
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
                CreateDeviceListFile();
                _timer.Elapsed += (sender, e) => UpdateCameraStatusTimer(sender, e);
                _timer.Interval = CamerastatusTimer;
                _timer.Start();
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService StartCameraStatusTimer() Exception" + ex.Message);
            }

        }

        public void UpdateCameraStatusTimer(object sender, ElapsedEventArgs e)
        {
            _logger.Info("Camera Status Timer Started");
            _timer.Stop();
            //timer start for 5 sec
            //stop timer after 15 min
            //Task.Run(() => UpdateCameraStatus());
            UpdateCameraStatus();
            _timer.Start();
        }

        public void UpdateCameraStatus()
        {
            try
            {
                _logger.Info("CameraStatus: GetNVRCameraCollection");
                string[] fileEntries = Directory.GetFiles(Storage.DeviceListPath);
                int FileCOunt = fileEntries.Count();
                if (FileCOunt > 0)
                {
                    var _timerInterval = FileCOunt / 3.33;
                    int _timerTime = Convert.ToInt32(_timerInterval);
                    if (Storage.CameraStatusTimeSec < _timerTime)
                    {
                        _timer.Interval = (_timerTime + 10) * 1000;
                        //return;
                    }
                }

                if (IsFirstTimeCameraStatus == true)
                {
                    IsFirstTimeCameraStatus = false;
                    return;
                }

                foreach (var Filename in fileEntries)
                {
                    NvrCameraDto deviceDto = null;
                    XmlSerializer ser = new XmlSerializer(typeof(NvrCameraDto));

                    using (XmlReader reader = XmlReader.Create(Filename))
                    {
                        deviceDto = (NvrCameraDto)ser.Deserialize(reader);
                    }
                    if (deviceDto is NvrCameraDto)
                    {
                        try
                        {
                            //create rtsp url 
                            var nvrCamera = deviceDto as NvrCameraDto;
                            if (nvrCamera.CameraIp != null && nvrCamera.CameraIp != "")
                            {
                                int nPort = 554;
                                if (nvrCamera.CameraPort != null || nvrCamera.CameraPort != "")
                                {
                                    nPort = int.Parse(nvrCamera.CameraPort);
                                }
                                Task.Run(() => UpdateStatus(deviceDto, nPort));
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("CameraStatusService UpdateCameraStatus() Exception" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService UpdateCameraStatus() Exception" + ex.Message);
            }
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
                bool camStatus = IsDeviceAlive(nvrCamera.CameraIp, nPort);


                if (camStatus != null)
                {
                    using (var ctx = new CentralDBEntities())
                    {
                        var nDeviceEntry = ctx.tblCameraStatus.FirstOrDefault(x => x.DeviceID == nvrCamera.DeviceId);
                        if (nDeviceEntry != null)//Entry exist
                        {
                            nDeviceEntry.Status = camStatus;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            int camID = Int32.Parse(_deviceDto.DeviceId.ToString());
                            var cameraStatus = new AMS.Broker.DataStore.tblCameraStatus
                            {
                                Status = camStatus,
                                DeviceID = camID
                            };
                            ctx.tblCameraStatus.Add(cameraStatus);
                            ctx.SaveChanges();
                        }
                    }
                }//
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
        public void UpdateCameraStatusold()
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    // _logger.Info("");
                    _logger.Info("CameraStatus: GetNVRCameraCollection");

                    var resultsCollection = context.Device;

                    var result2 = resultsCollection.Select(x => x).ToArray();

                    //  var result = resultsCollection.Select(DeviceDto,resultsCollection).ToArray();

                    var result = result2.Select(Mapper.Map<DeviceDto>).ToArray();

                    foreach (var deviceDto in result)
                    {
                        if (deviceDto is NvrCameraDto)
                        {
                            try
                            {
                                //create rtsp url 
                                var nvrCamera = deviceDto as NvrCameraDto;

                                if (nvrCamera.CameraIp != null && nvrCamera.CameraIp != "")
                                {
                                    int nPort = 554;
                                    if (nvrCamera.CameraPort != null || nvrCamera.CameraPort != "")
                                    {
                                        nPort = int.Parse(nvrCamera.CameraPort);
                                    }
                                    //string camUrl = "rtsp://admin:12345@" + nvrCamera.CameraIp + ":554/Streaming/Channels/2";

                                    //check status of camera
                                    bool camStatus = IsDeviceAlive(nvrCamera.CameraIp, nPort);
                                    //check the entry in tblCameraStatus
                                    /*if (nvrCamera.DeviceId == 331)
                                    {
 
                                    }*/

                                    if (camStatus != null)
                                    {
                                        using (var ctx = new CentralDBEntities())
                                        {
                                            var nDeviceEntry = ctx.tblCameraStatus.FirstOrDefault(x => x.DeviceID == nvrCamera.DeviceId);
                                            if (nDeviceEntry != null)//Entry exist
                                            {
                                                nDeviceEntry.Status = camStatus;
                                                ctx.SaveChanges();
                                            }
                                            else
                                            {
                                                int camID = Int32.Parse(deviceDto.DeviceId.ToString());
                                                var cameraStatus = new AMS.Broker.DataStore.tblCameraStatus
                                                {
                                                    Status = camStatus,
                                                    DeviceID = camID
                                                };
                                                ctx.tblCameraStatus.Add(cameraStatus);
                                                ctx.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.Info("CameraStatusService UpdateCameraStatusold() Exception" + ex.Message);
                                string Message = "CameraStatusService UpdateCameraStatusold() Exception" + ex.Message;
                                InsertBrokerOperationLog.AddProcessLog(Message);
                            }
                            /*var camCollection = context.tblCameraStatus.Where(x => x.DeviceID == deviceDto.DeviceId);

                            var results = camCollection.Select(x => x).ToArray();

                            var resultCam = results.Select(Mapper.Map<tblCameraStatusDto>).ToArray();

                            int camID = Int32.Parse(deviceDto.DeviceId.ToString());

                            if (resultCam.Count() == 0)
                            {
                                //insert
                                var cameraStatus = new tblCameraStatus
                                {
                                    Status = camStatus,
                                    DeviceID = camID
                                };
                                context.tblCameraStatus.Add(cameraStatus);
                                context.SaveChanges();
                            }
                            else
                            {
                                //update 
                                AMS.Broker.DataStore.tblCameraStatus camsta = (from x in context.tblCameraStatus where x.DeviceID == camID select x).First();
                                camsta.Status = camStatus;
                                context.SaveChanges(); 
                            }
                            */
                            //update into db
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService UpdateCameraStatusold() Exception" + ex.Message);
                string Message = "CameraStatusService UpdateCameraStatusold() Exception1" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }
        }



        private IEnumerable<DeviceDto> GetNVRCameraCollection(string authToken)
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    _logger.Info("");
                    _logger.Info("CameraStatus: GetNVRCameraCollection");
                    _logger.Info("  authToken: {0}", authToken);

                    var NVRCameraList = (from NVRCamera in context.NvrCamera
                                         select NVRCamera);
                }
            }
            catch (SecurityException ex)
            {
                _logger.Error(ex);
                _logger.Info("CameraStatusService GetNVRCameraCollection() Exception" + ex.Message);
                string Message = "CameraStatusService GetNVRCameraCollection() Exception" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }

            return null;
        }


        public static bool IsDeviceAlive(string strIP, int strPort)
        {
            try
            {
                // Uri uri = new Uri(strUrl);
                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                var result = clientSocket.BeginConnect(strIP, strPort, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

                if (!success)
                {
                    return false;
                }
                // we have connected
                clientSocket.EndConnect(result);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("CameraStatusService IsDeviceAlive() Exception" + ex.Message);
                string Message = "CameraStatusService IsDeviceAlive() Exception" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }
            return false;
        }
    }
}

