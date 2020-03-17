using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.Services.CPPlusDahua;
using AMS.Broker.Services.HIK;
using AMS.Broker.WatchDogService.DataStore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMS.Broker.Services;

namespace AMS.Broker.WatchDogService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class DeviceTimeSyncService : IDeviceTimeSyncService
    {
        readonly IDeviceTimeSyncService _DeviceTimeSyncService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
         private static IDeviceTimeSyncService _serviceInstance = new DeviceTimeSyncService();
        public static IDeviceTimeSyncService ServiceInstance { get { return _serviceInstance; } }
        public IList<NvrDto> _NvrCollection = new List<NvrDto>();

        public IList<tblTimeSyncinfoDto> _tblTimeSyncinfoDtoCollection = new List<tblTimeSyncinfoDto>();

        public IList<DeviceDto> _DeviceCollection = new List<DeviceDto>();
        public IList<DvrNvrTypeMasterDTO> _DvrNvrCollection = new List<DvrNvrTypeMasterDTO>();
        public Dictionary<int, DeviceDto> DeviceCollectionDictionary = new Dictionary<int, DeviceDto>();

        public string DeviceTimeSyncInterval = Storage.DeviceTimeSyncInterval;
        public string ConcurrDeviceSyncCount = Storage.ConcurrDeviceSyncCount;
        public string ConnectionTimeOut = Storage.ConnectionTimeOut;
        public string HikConnectTime = Storage.HikConnectTime;

        public string IsDeviceTimeSyncEnable = Storage.DeviceTimeSyncEnable; 

        public System.Threading.Thread testSyncThread;
        public int nCount = 0;

        public static BrokerService _BrokerInstance = null;

        public DeviceTimeSyncService()
        {
            try
            {              

                // StartCameraStatusTimer();           
               // GetNVRCollection();
              
                if (IsDeviceTimeSyncEnable == "1")
                {
                    CHCNetSDK.NET_DVR_Init();//
                    CPPlusDahuaSDK.CLIENT_Init(null, IntPtr.Zero);

                    GetTimeSyncinfoCollection();
                    GetDvrNvrTypeMaster();
                    GetDevicesCollection();
                    SyncDeviceTime();
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSyncService DeviceTimeSyncService() Exception" + ex.Message);
            }
        }
                       

        public void SyncDeviceTime()
        {
            try
            {
                testSyncThread = new System.Threading.Thread(new System.Threading.ThreadStart(TestThreads));               
                testSyncThread.Start();
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSyncService SyncDeviceTime() Exception" + ex.Message);
            }
        }

        public void TestThreads()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        InsertBrokerOperationLog.AddProcessLog("Process Started ..." + nCount.ToString());
                        
                        //t2.Start();
                        int nCo = 1;
                        int batchDeviceCnt = 1000;

                        try
                        {
                            batchDeviceCnt = Int32.Parse(ConcurrDeviceSyncCount);//take from config file
                        }
                        catch (Exception ex)
                        { 
                        }

                        int interval = DeviceCollectionDictionary.Count() / batchDeviceCnt;

                        //if (interval < 1)
                        //{
                        //    interval = 1;
                        //}
                        for (int i = 0; i <= interval; i++)
                        {
                            foreach (var device in DeviceCollectionDictionary.Where(x => (x.Key > (batchDeviceCnt*i) && x.Key <= (batchDeviceCnt*(i+1)))))
                            {
                                var nvrcam = device.Value as NvrCameraDto;
                                if (nvrcam != null)
                                {
                                    if (nvrcam.InterafaceType != null)
                                    {
                                        if (nvrcam.InterafaceType.Contains("HikVision"))
                                        {
                                            try
                                            {
                                                HIKInterface _OBJ5 = new HIKInterface(nvrcam.CameraIp, Int32.Parse(nvrcam.CameraPort), nvrcam.CamUser, nvrcam.CamPassword, Int32.Parse(device.Value.DeviceId.ToString()));//, nCount, nCo);
                                                _OBJ5.SyncDeviceTime();
                                            }
                                            catch (Exception ex)
                                            {
                                                InsertBrokerOperationLog.AddProcessLog("TestThread.HikVision..Exception:" + ex.Message);
                                            }
                                        }

                                        if (nvrcam.InterafaceType.Contains("CPPlus") || nvrcam.InterafaceType.Contains("Dahua"))
                                        {
                                            try
                                            {
                                                CPPlusDahuaInterface _OBJ5 = new CPPlusDahuaInterface(nvrcam.CameraIp, Int32.Parse(nvrcam.CameraPort), nvrcam.CamUser, nvrcam.CamPassword);//, nCount, nCo);
                                                _OBJ5.SyncDeviceTime();
                                            }
                                            catch (Exception ex)
                                            {
                                                InsertBrokerOperationLog.AddProcessLog("TestThread.CPPlus or Dahua..Exception:" + ex.Message);
                                            }

                                        }
                                    }
                                }
                            }

                        }

                      //  HIKInterface _OBJ5 = new HIKInterface("192.168.0.201", 8000, "admin", "12345");// new HIKInterface("192.168.0.216", 8000, "admin", "12345", nCount, this,nCo);
                     //   _OBJ5.SyncDeviceTime();

                        
                        //for (int i = 1; i < 100000; i++)
                        //{
                        //    HIKInterface _OBJ5 = new HIKInterface("192.168.0.216", 8000, "admin", "12345", nCount,nCo);
                        //    _OBJ5.SyncDeviceTime();
                        //    nCo++;
                        //}
                        //HIKInterface _OBJ = new HIKInterface("192.168.0.217", 8000, "admin", "12345", nCount, this);
                        //_OBJ.SyncDeviceTime();

                        //HIKInterface _OBJ2 = new HIKInterface("192.168.0.218", 8000, "admin", "12345", nCount,this);
                        //_OBJ2.SyncDeviceTime();

                        //HIKInterface _OBJ3 = new HIKInterface("192.168.0.219", 8000, "admin", "12345", nCount, this);
                        //_OBJ3.SyncDeviceTime();

                        //HIKInterface _OBJ4 = new HIKInterface("192.168.0.220", 8000, "admin", "12345", nCount, this);
                        //_OBJ4.SyncDeviceTime();

                        InsertBrokerOperationLog.AddProcessLog("Process of creation of threads End ...");//+ nCount.ToString()

                    }
                    catch (Exception ex)
                    {
                        InsertBrokerOperationLog.AddProcessLog("Error  Test Threads While Loop Exception..." + ex.Message);
                    }

                    InsertBrokerOperationLog.AddProcessLog("Process Wait Time Start ..." + nCount.ToString());
                    //Thread.Sleep(20000);
                    int waitTime = 90000;
                    try
                    {
                        waitTime = Int32.Parse(DeviceTimeSyncInterval) * 60 * 1000;
                    }
                    catch (Exception EX)
                    { 
                    }

                    new ManualResetEvent(false).WaitOne(waitTime);
                    //new AutoResetEvent(false).WaitOne(20000);
                    InsertBrokerOperationLog.AddProcessLog("Process Wait Time End ..." + nCount.ToString());

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                  //  nCount = nCount + 1;

                    //if (nCount > 2)
                    //    break;
                }
            }
            catch (Exception ex)
            {               
                InsertBrokerOperationLog.AddProcessLog("Error  Test Threads Exception..." + ex.Message);
            }

            InsertBrokerOperationLog.AddProcessLog("Operation Complete...");
        }

        internal static IDeviceTimeSyncService Initialise(BrokerService _BrokerService)
        {
            try
            {
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("startingDeviceTimeSync Service");

                _BrokerInstance = _BrokerService;

                Uri httpUrl = new Uri("https://localhost:6530/DeviceTimeSyncService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(DeviceTimeSyncService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IDeviceTimeSyncService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();

                _logger.Info("DeviceTimeSync Service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("DeviceTimeSync Service Initialise() Exception" + ex.Message);

                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service Initialise() Exception" + ex.Message);
                _BrokerInstance.isInitialiseFail = true;
            }
            return null;
        }

        public void StartThread()
        {
            try
            {
            }
            catch (Exception ex)
            { 
            }
        }

        private IEnumerable<tblTimeSyncinfoDto> GetTimeSyncinfoCollection()
        {
            InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetTimeSyncinfoCollection(): Start");
            try
            {
                using (var context = new CentralDBEntities())
                {

                    var resultsCollection = context.tblTimeSyncinfo;

                    var result2 = resultsCollection.Select(x => x).ToList();

                    foreach (var _entity in result2)
                    {
                        tblTimeSyncinfoDto _tblTimeSyncinfoDto = new tblTimeSyncinfoDto()
                        {
                            ID = _entity.ID,
                            DeviceID =(int) _entity.DeviceID,
                            DVRNVRTypeID = (int)_entity.DVRNVRTypeID,
                            DateTimeSyncStatus = (int)_entity.DateTimeSyncStatus
                        };

                        _tblTimeSyncinfoDtoCollection.Add(_tblTimeSyncinfoDto);
                    }
                    return _tblTimeSyncinfoDtoCollection;
                }

            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetTimeSyncinfoCollection(): Exception:" + ex.Message);
            }
            return null;

        }

        private IEnumerable<NvrDto> GetNVRCollection()
        {
            InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetInterfaceCollection(): Start");
            try
            {
                using (var context = new CentralDBEntities())
                {
                  
                    var resultsCollection = context.NVR;

                       var result2 = resultsCollection.Select(x => x).ToList();

                       foreach (var _entity in result2)
                       {
                          NvrDto _NvrDto = new NvrDto()
                           {
                               Description = _entity.Description,
                               InterfaceId = int.Parse(_entity.InterfaceId.ToString()),
                               IPAddress = _entity.IPAddress,
                               NvrId = _entity.NvrId,
                               NvrUrl = _entity.NvrUrl,
                               Password = _entity.Password,
                               Port = int.Parse(_entity.Port.ToString()),
                               Username = _entity.Username,
                               DvrNvrTypeId =int.Parse(_entity.DvrNvrTypeId.ToString()),
                           };

                          _NvrCollection.Add(_NvrDto);
                       }
                       return _NvrCollection;
                }
               
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetNVRCollection(): Exception:" + ex.Message);
            }
            return null;
        }

        private IEnumerable<DvrNvrTypeMasterDTO> GetDvrNvrTypeMaster()
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    _DvrNvrCollection = new List<DvrNvrTypeMasterDTO>();
                   var resultsCollection = context.DvrNvrType;

                    var result2 = resultsCollection.Select(x => x).ToList();

                    foreach (var _entity in result2)
                    {
                        DvrNvrTypeMasterDTO _dvrNvrTypeMasterDTO = new DvrNvrTypeMasterDTO()
                        {
                          Name = _entity.Name,
                          DvrNvrTypeId = _entity.DvrNvrTypeId,
                          Description = _entity.Description
                        };
                        _DvrNvrCollection.Add(_dvrNvrTypeMasterDTO);
                    }
                    return _DvrNvrCollection;
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetDvrNvrTypeMaster(): Exception:" + ex.Message);
            }
            return null;
        }

        private IEnumerable<DeviceDto> GetDevicesCollection()
        {

            InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service GetDevicesCollection(): Start");
            try
            {
                int cnt = 0;
                using (var context = new CentralDBEntities())
                {
                    _DeviceCollection = new List<DeviceDto>();


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

                               // using (var contextNvr = new CentralDBEntities())
                                //{
                                try
                                {
                                   // var nvr = _NvrCollection.FirstOrDefault(x => x.InterfaceId == _deviceDto.InterfaceId);

                                    var DvrNvrDeviceID = _tblTimeSyncinfoDtoCollection.FirstOrDefault(x => x.DeviceID == _deviceDto.DeviceId);

                                    if (DvrNvrDeviceID != null)
                                    {
                                        var dvrNvrType = _DvrNvrCollection.FirstOrDefault(x => x.DvrNvrTypeId == DvrNvrDeviceID.DVRNVRTypeID);
                                        if (dvrNvrType != null)
                                            _deviceDto.InterafaceType = dvrNvrType.Name;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync service GetDvrNvrType Exception : " + ex.Message);
                                }
                                //}
                                cnt++;
                                DeviceCollectionDictionary.Add(cnt, _deviceDto);
                               // _DeviceCollection.Add(_deviceDto);
                            }
                            catch (Exception ES)
                            {
                                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync service GetDevicesCollection()Exception : " + ES.Message);
                            }
                        }
                      
                    }
                    InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync service GetDevicesCollection() Count : " + resultsCollection.Count());
                    _logger.Info("  items count: {0}", resultsCollection.Count());
                    _logger.Info("------------------------------------");
                    ClearMemory();
                    return _DeviceCollection;

                }
            }
            catch (SecurityException ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync service GetDevicesCollection() SecurityException : " + ex.Message);
                _logger.Info("DeviceTimeSync service GetDevicesCollectionImpl() Exception:" + ex.Message);
                _logger.Error(ex);
            }
            finally
            {
                ClearMemory();
            }
            //

            return null;
        }

        public void ClearMemory()
        {
            try
            {
                long bytes1 = GC.GetTotalMemory(false);
                _logger.Info("DeviceTimeSync Service Memory Before Collect " + bytes1);
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                long bytes3 = GC.GetTotalMemory(true); // Get memory               
                _logger.Info("DeviceTimeSync Service Memory After garbage collection " + bytes3);
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("DeviceTimeSync Service ClearMemory() Exception" + ex.Message);
            }
        }
    }
}
