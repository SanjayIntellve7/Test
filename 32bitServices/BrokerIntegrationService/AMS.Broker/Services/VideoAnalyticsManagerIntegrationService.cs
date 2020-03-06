using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using NLog;

using VideoAnalyticsEventDTO = AMS.Broker.Contracts.DTO.VideoAanalyticsEventDTO;
using System.Xml;
using System.Linq;
using System.Globalization;
using AMS.Broker.IntegrationService.DataStore;
using AutoMapper;

using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Security.Permissions;
using System.Text;

using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using Status = AMS.Broker.Contracts.DTO.Status;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using AMS.Broker.IntegrationService.RihnoSecurity.Membership;
using System.ServiceModel.Channels;
using AMS.Broker.IntegrationService.Services.ServicesImplementations;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class VideoAnalyticsManagerIntegrationService : IVideoAnalyticsManagerIntegrationService
    {
        readonly IVideoAnalyticsManagerIntegrationService _videoAnalyticsManagerService;        
        private Thread _myThread = null;        
        public int nAlertCount;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        StationsServiceRef.StationsServiceClient _stationSerVice = null;

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "VideoAnalyticsManagerIntegrationService-ClearMemory -- Exception = " + ex.Message;
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
                string Message = "VideoAnalyticsManagerIntegrationService-ClearMemoryStatic -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        public StationsServiceRef.StationsServiceClient sendMsgToStationSer()
        {
            StationsServiceRef.StationsServiceClient _serVice = null;
            try
            {
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
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
                return _serVice;
            }
            catch (OutOfMemoryException ex)
            {
                _logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
                InsertIntegrationLog.AddProcessLogIntegration("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);//jatin
            }
            catch (Exception ex)
            {
                _logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                InsertIntegrationLog.AddProcessLogIntegration("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);//jatin
                Console.WriteLine(ex.Message);
            }
            /*if (_serVice != null)
            {
                _serVice.Close();
                _serVice = null;
            }*/
            return null;
        }

        public VideoAnalyticsManagerIntegrationService()
        {
            try
            {
                _videoAnalyticsManagerService = new VideoAnalyticsManagerIntegrationServiceImpl();//BrokerService.Container.Resolve<IVideoAnalyticsManagerService>();
                nAlertCount = 0;
                _stationSerVice = sendMsgToStationSer();
                //_myThread = new Thread(ThreadProc); //TRUPTI09SEPT15
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService VideoAnalyticsManagerService() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationService-VideoAnalyticsManagerService -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
           

            //  DumpCOunt();
        }

        ~VideoAnalyticsManagerIntegrationService()
        {
            if (_myThread != null)
            {
                if (_myThread.IsAlive)
                {
                    _myThread.Abort();
                }
            }
        }

        private Binding CreateBindingWith_MaxPendingChannels_Set(Binding baseBinding)
        {
            try
            {
                BindingElementCollection elements = baseBinding.CreateBindingElements();
                ReliableSessionBindingElement reliableSessionElement =
                           elements.Find<ReliableSessionBindingElement>();
                if (reliableSessionElement != null)
                {
                    reliableSessionElement.MaxPendingChannels = 128;

                    CustomBinding newBinding = new CustomBinding(elements);

                    newBinding.CloseTimeout = baseBinding.CloseTimeout;
                    newBinding.OpenTimeout = baseBinding.OpenTimeout;
                    newBinding.ReceiveTimeout = baseBinding.ReceiveTimeout;
                    newBinding.SendTimeout = baseBinding.SendTimeout;
                    newBinding.Name = baseBinding.Name;
                    newBinding.Namespace = baseBinding.Namespace;
                    return newBinding;
                }
                else
                {
                    throw new Exception("the base binding does not " +
                                        "have ReliableSessionBindingElement");
                }
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService CreateBindingWith_MaxPendingChannels_Set() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationService-CreateBindingWith_MaxPendingChannels_Set -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                return null;
            }
            finally
            {
                ClearMemory();               
            }
            return null;
        }

        public void DumpCOunt()
        {
            try
            {
                DateTime st = new DateTime();
                st = Convert.ToDateTime("02-Mar-2014 18:00");

                for (int i = 600; i <= 4600; i++)
                {
                    try
                    {
                        using (var contextpc = new CentralDBEntities())
                        {
                            var peopleCounter = new tbpeoplecounter
                            {
                                DeviceID = 112,
                                EventDate = st,
                                EventCount = i

                            };
                            contextpc.tbpeoplecounter.Add(peopleCounter);
                            contextpc.SaveChanges();
                            ClearMemory();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService DumpCOunt() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationService-DumpCOunt -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            
        }

        internal static IVideoAnalyticsManagerIntegrationService Initialise()
        {
            try
            {
                Logger.Info("");
                Logger.Info("------------------------------------");
                Logger.Info("starting VideoAnalyticsManagerService service");

                try
                {
                    var service = new VideoAnalyticsManagerIntegrationService();

                    var controllerHost = new ServiceHost(service);

                    foreach (var endpoint in controllerHost.Description.Endpoints)
                    {
                        try
                        {
                            BindingElementCollection elements = endpoint.Binding.CreateBindingElements();
                            ReliableSessionBindingElement reliableSessionElement = elements.Find<ReliableSessionBindingElement>();
                            if (reliableSessionElement != null)
                            {
                                Console.WriteLine("Found ReliableSessionBindingElement");
                                reliableSessionElement.MaxPendingChannels = 128;
                                CustomBinding newBinding = new CustomBinding(elements);
                                // need to copy properties from existing binding to the new binding

                                // all other properties (e.g. security,encoder,transport) should be preserved and do not need to be copied
                                newBinding.CloseTimeout = endpoint.Binding.CloseTimeout;
                                newBinding.OpenTimeout = endpoint.Binding.OpenTimeout;
                                newBinding.ReceiveTimeout = endpoint.Binding.ReceiveTimeout;
                                newBinding.SendTimeout = endpoint.Binding.SendTimeout;
                                newBinding.Name = endpoint.Binding.Name;
                                newBinding.Namespace = endpoint.Binding.Namespace;
                                endpoint.Binding = newBinding;
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("VideoAnalyticsManagerService Initialise() Exception:" + ex.Message);
                            string Message = "VideoAnalyticsManagerIntegrationService-Initialise -- Exception = " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                        }
                    }
                    controllerHost.Open();

                    Logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                    Logger.Info("------------------------------------");

                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);  //amit 04112016 

                    return service;
                }
                catch (Exception ex)
                {
                    _logger.Info("VideoAnalyticsManagerService Initialise() Exception:" + ex.Message);
                    string Message = "VideoAnalyticsManagerIntegrationService-Initialise -- Exception1 = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                }

                //_myThread = new Thread(ThreadProc);

                return null;
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService Initialise() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationService-Initialise -- Exception2 = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                return null;
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("VideoAnalyticsManager Service  Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            string Message = "VideoAnalyticsManagerIntegrationService-Initialise -- Exception1 = " + (e.ExceptionObject as Exception).Message;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
        }

        public IEnumerable<string> GetCapabilities(Guid cameraId)
        {
            try
            {
                string Message = "VideoAnalyticsManagerIntegrationService-GetCapabilities -- cameraId = " + cameraId;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                //throw new NotImplementedException(); //Todo
                string _strIP = "";// device.IPAddress;
                /*  string _strIP = "";//"127.0.0.1";// GetNVRIP(cameraId);trupti23122014

                  if (Storage.IsAnalyticServer == "0")
                      _strIP = strIp;
                  else
                      _strIP = Storage.AnalyticServerIP;
                  //read from config*/

                string _strUrl = "";

                string[] _strRetVal = { "", "", "" };


                if (Storage.IsAnalyticServer == "0")
                    _strIP = "127.0.0.1";
                else
                    _strIP = Storage.AnalyticServerIP;

                try
                {
                    _strUrl = "https://" + _strIP + ":6532/soap/VideoAnalyticsService";

                    EndpointAddress ar = new EndpointAddress(_strIP);

                    AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsServiceClient _serVice = new AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsServiceClient("WSHttpBinding_IVideoAnalyticsService", ar.ToString());

                    _strRetVal = _serVice.GetCapabilities();
                    _serVice.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.Info("VideoAnalyticsManagerService GetCapabilities() Exception:" + ex.Message);
                    string Message1 = "VideoAnalyticsManagerIntegrationService-GetCapabilities -- Exception = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message1);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                }

                return _strRetVal;
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService GetCapabilities() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetCapabilities -- Exception 1 = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return null;
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET")]
        public bool StartAnalytics(int cameraId, string version, string authToken)
        {
            try
            {
                 
                string Message = "VideoAnalyticsManagerIntegrationService-GetCapabilities -- cameraId = " + cameraId + "--!--version:" + version + "--!--authToken:" + authToken;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                //2. Get device and parameters
                var device = GetDeviceById(cameraId);   //trupti to change calling of service because of broker distribution
                if (device.NvrId == null) throw new Exception("Not camera CustomException");

                //var nvr = _controllerService.GetNvrById("", device.NvrId.Value);
                string strUser = "";
                string strPass = "";
                string strIp = "";
                string strLaneVal = "";
                bool _RetVal = false;
                try
                {
                    using (var ctx = new CentralDBEntities())
                    {

                        var resultDb = (from nvr in ctx.NVR
                                        where nvr.NvrId == device.NvrId.Value
                                        select nvr).First();

                        if (resultDb != null)
                        {
                            //amit 03102016 manual mapping
                            NvrDto nvrDto = new NvrDto()
                            {
                                Description = resultDb.Description,
                                DvrNvrTypeId = int.Parse(resultDb.DvrNvrTypeId.ToString()),
                                InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                                IPAddress = resultDb.IPAddress,
                                NvrId = resultDb.NvrId,
                                NvrUrl = resultDb.NvrUrl,
                                Password = resultDb.Password,
                                Port = int.Parse(resultDb.Port.ToString()),
                                Username = resultDb.Username
                            };
                            //NvrDto nvrDto = Mapper.Map<NvrDto>(resultDb); //amit 03102016 manual mapping
                            strIp = nvrDto.IPAddress;
                            strUser = nvrDto.Username;
                            strPass = nvrDto.Password;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Info("VideoAnalyticsManagerService StartAnalytics() Exception:" + ex.Message);
                    string Message1 = "VideoAnalyticsManagerIntegrationService-StartAnalytics -- Exception = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message1);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                }
                var nvrCamera = device as NvrCameraDto;

                if (nvrCamera.CameraUrl == null || nvrCamera.CameraUrl == "")
                {
                    return false;
                }
                //3. Check if version is supported----GetCapabilitis
                //4. Set parameters
                AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters;

                if (device is NvrCameraDto)
                {
                    var nvrCameraDto = device as NvrCameraDto;
                    float fUpdateRate = float.Parse("0.008");

                    if (nvrCameraDto.Lane1 != null && nvrCameraDto.Lane1 != 0)
                    {
                        strLaneVal = nvrCameraDto.Lane1.ToString();
                    }
                    if (nvrCameraDto.Lane2 != null && nvrCameraDto.Lane2 != 0)
                    {
                        if (nvrCameraDto.Lane1 != null && nvrCameraDto.Lane1 != 0)
                            strLaneVal = strLaneVal + "," + nvrCameraDto.Lane2.ToString();
                        else
                            strLaneVal = nvrCameraDto.Lane2.ToString();
                    }
                    if (nvrCameraDto.Lane3 != null && nvrCameraDto.Lane3 != 0)
                    {
                        if (nvrCameraDto.Lane1 != null && nvrCameraDto.Lane1 != 0 && nvrCameraDto.Lane2 != null && nvrCameraDto.Lane2 != 0)
                            strLaneVal = strLaneVal + "," + nvrCameraDto.Lane3.ToString();
                        else
                            strLaneVal = nvrCameraDto.Lane2.ToString();
                    }

                    parameters = new NvrVideoAnalytics.VideoAnalyticsParameters
                    {
                        AlarmDelay = nvrCameraDto.AlarmDelay.HasValue ? nvrCameraDto.AlarmDelay.Value : 10,
                        CameraGuid = Guid.Parse(nvrCameraDto.CameraGUID),
                        Height = nvrCameraDto.Height.HasValue ? nvrCameraDto.Height.Value : 600,
                        Width = nvrCameraDto.Width.HasValue ? nvrCameraDto.Width.Value : 900,
                        MaxBlobSize = nvrCameraDto.MaxBlobSize.HasValue ? nvrCameraDto.MaxBlobSize.Value : 900,
                        Version = nvrCameraDto.AnalyticAlgorithmType.Name,// "Sterile Zone Version 2.0",
                        VideoPath = "",//////Video File Path...
                        MinBlobSize = nvrCameraDto.MinBlobSize.HasValue ? nvrCameraDto.MinBlobSize.Value : 900,
                        UpdateRate = (float)nvrCameraDto.UpdateRate,
                        NvrUser = strUser,//nvr.Username,
                        NvrPassword = strPass,//nvr.Password,
                        FPS = nvrCameraDto.FPS.HasValue ? nvrCameraDto.FPS.Value : 12,
                        ZoneRows = nvrCameraDto.ZoneRows.HasValue ? nvrCameraDto.ZoneRows.Value : 576,
                        ZoneColumns = nvrCameraDto.ZoneColumns.HasValue ? nvrCameraDto.ZoneColumns.Value : 720,
                        ZoneData = nvrCameraDto.ZoneData,
                        CamIp = nvrCameraDto.CameraIp,
                        CamUser = nvrCameraDto.CamUser,
                        CamPass = nvrCameraDto.CamPassword,
                        CamUrl = nvrCameraDto.CameraUrl,
                        TripWireDirectionFlag = nvrCameraDto.DirectionFlag.Value,
                        ResvOne = nvrCameraDto.MinBlobWidth.ToString() + "," + nvrCameraDto.MinBlobHeight + "," + nvrCameraDto.MaxBlobWidth + "," + nvrCameraDto.MaxBlobHeight,
                        ResvTwo = strLaneVal

                    };

                    try
                    {
                        using (var ctxNew = new CentralDBEntities())
                        {

                            var existingEntry = ctxNew.DeviceZoneData.Where(dev => dev.DeviceID == device.DeviceId).FirstOrDefault();

                            if (existingEntry != null)
                            {
                                parameters.ZoneData = existingEntry.ZoneData;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("VideoAnalyticsManagerService StartAnalytics() Exception:" + ex.Message);
                        string Message1 = "VideoAnalyticsManagerIntegrationService-StartAnalytics -- Exception 1 = " + ex.Message;
                        //InsertBrokerOperationLog.AddProcessLog(Message1);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                    }

                    //analytics server 0 as 
                    string _strIP = "";//"127.0.0.1";// GetNVRIP(cameraId);trupti23122014
                    if (nvrCamera.AnalyticsServerIp != null && nvrCamera.AnalyticsServerIp != string.Empty)
                    {
                        _strIP = nvrCamera.AnalyticsServerIp.ToString();
                    }
                    if (Storage.IsAnalyticServer == "0")
                        _strIP = _strIP;
                    else
                        _strIP = Storage.AnalyticServerIP;
                    //read from config

                    string _strUrl = "";
                    try
                    {
                        _strUrl = "https://" + _strIP + ":6532/soap/VideoAnalyticsService";

                        EndpointAddress ar = new EndpointAddress(_strUrl);

                        AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsServiceClient _serVice = new AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsServiceClient("WSHttpBinding_IVideoAnalyticsService", ar.ToString());

                        version = nvrCamera.AnalyticAlgorithmType.Name;
                        if (version.Contains("Vehicle Counter Version") || version.Contains("People") || version.Contains("Counter") || version.Contains("Trip Wire") || version.Contains("Block"))//trupti29122014 
                        {
                           _RetVal= _serVice.StartAnalytics2020(parameters, nvrCamera.CameraIp, version);
                           if (_RetVal == false)
                           {
                               _RetVal = _serVice.StartAnalytics2020(parameters, nvrCamera.CameraIp, version);
                               if (_RetVal == true)
                               {
                                   return true;
                               }
                           }
                           else
                           {
                               return true;
                           }
                        }
                        else
                        {
                            _RetVal= _serVice.SetupAnalytics(parameters);
                            if (_RetVal == false)
                            {
                                _RetVal = _serVice.SetupAnalytics(parameters);
                                if (_RetVal == true)
                                {
                                    _serVice.StartAnalytics(new Guid(device.CameraGUID), version);
                                    _RetVal= true;
                                }
                            }
                            else
                            {
                                //5.Start analytics                     
                                _serVice.StartAnalytics(new Guid(device.CameraGUID), version);
                                _RetVal= true;
                            }
                        }

                        _serVice.Close();
                        //if exception hapens throw new Exception("...... CustomException");

                        //inform stations that analytics was started.
                        if(_RetVal==true)
                         _stationSerVice.InformVideoAnalyticsStarted(device.CameraGUID);

                        return _RetVal;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        _logger.Info("VideoAnalyticsManagerService StartAnalytics() Exception:" + ex.Message);
                        string Message1 = "VideoAnalyticsManagerIntegrationService-StartAnalytics -- Exception 2 = " + ex.Message;
                        //InsertBrokerOperationLog.AddProcessLog(Message1);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService StartAnalytics() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-StartAnalytics -- Exception 3 = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message1);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //[RihnoPermission(Operation = "/Systems/View")]
        public IEnumerable<VideoAnalyticsParameters> GetVideoAnalyticsCollection(string strNvr)//IEnumerable //IList<VideoAnalyticsParameters> GetVideoAnalyticsCollection(string strNvr)
        {
            IList<VideoAnalyticsParameters> vaCamList = new List<VideoAnalyticsParameters>();
            VideoAnalyticsParameters parameters;

            try
            {
                long cNvrId = 0;
                string strUser = "";
                string strPass = "";
                string strIp = "";

                using (var ctx = new CentralDBEntities())
                {
                    var resultDb = (from nvr in ctx.NVR
                                    where nvr.IPAddress == strNvr
                                    select nvr).First();
                    //NvrDto nvrDto = Mapper.Map<NvrDto>(resultDb);//amit 03102016 manual mapping                    
                    //amit 03102016 manual mapping
                    if (resultDb != null)
                    {
                        NvrDto nvrDto = new NvrDto()
                        {
                            Description = resultDb.Description,
                            DvrNvrTypeId = int.Parse(resultDb.DvrNvrTypeId.ToString()),
                            InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                            IPAddress = resultDb.IPAddress,
                            NvrId = resultDb.NvrId,
                            NvrUrl = resultDb.NvrUrl,
                            Password = resultDb.Password,
                            Port = int.Parse(resultDb.Port.ToString()),
                            Username = resultDb.Username
                        };
                        cNvrId = nvrDto.NvrId;
                        strIp = nvrDto.IPAddress;
                        strUser = nvrDto.Username;
                        strPass = nvrDto.Password;
                    }
                }

                if (cNvrId != 0)
                {
                    using (var ctx1 = new CentralDBEntities())
                    {
                        var resultDb1 = (from dev in ctx1.Device
                                         where dev.NvrId == cNvrId
                                         select dev);
                        var result = resultDb1.Select(Mapper.Map<DeviceDto>).ToList();

                        // return result;

                        if (result != null)
                        {
                            foreach (var deviceDto in result)
                            {
                                if (deviceDto is NvrCameraDto)
                                {
                                    var dtDev = deviceDto as NvrCameraDto;
                                    if (dtDev.AnalyticAlgorithmTypeId > 1)
                                    {
                                        var device = deviceDto;

                                        if (device.NvrId != null)
                                        {
                                            if (device is NvrCameraDto)
                                            {
                                                var nvrCamera = device as NvrCameraDto;

                                                var nvrCameraDto = device as NvrCameraDto;
                                                float fUpdateRate = float.Parse("0.008");

                                                parameters = new VideoAnalyticsParameters
                                                {
                                                    AlarmDelay = nvrCameraDto.AlarmDelay.HasValue ? nvrCameraDto.AlarmDelay.Value : 10,
                                                    CameraGuid = Guid.Parse(nvrCameraDto.CameraGUID),
                                                    Height = nvrCameraDto.Height.HasValue ? nvrCameraDto.Height.Value : 600,
                                                    Width = nvrCameraDto.Width.HasValue ? nvrCameraDto.Width.Value : 900,
                                                    MaxBlobSize = nvrCameraDto.MaxBlobSize.HasValue ? nvrCameraDto.MaxBlobSize.Value : 900,
                                                    Version = nvrCameraDto.AnalyticAlgorithmType.Name,// "Sterile Zone Version 2.0",
                                                    VideoPath = "",//////Video File Path...
                                                    MinBlobSize = nvrCameraDto.MinBlobSize.HasValue ? nvrCameraDto.MinBlobSize.Value : 900,
                                                    UpdateRate = (float)nvrCameraDto.UpdateRate,
                                                    NvrUser = strUser,//nvr.Username,
                                                    NvrPassword = strPass,//nvr.Password,
                                                    FPS = nvrCameraDto.FPS.HasValue ? nvrCameraDto.FPS.Value : 12,
                                                    ZoneRows = nvrCameraDto.ZoneRows.HasValue ? nvrCameraDto.ZoneRows.Value : 576,
                                                    ZoneColumns = nvrCameraDto.ZoneColumns.HasValue ? nvrCameraDto.ZoneColumns.Value : 720,
                                                    ZoneData = nvrCameraDto.ZoneData
                                                };

                                                try
                                                {
                                                    using (var ctxNew = new CentralDBEntities())
                                                    {

                                                        var resultDb = ctxNew.DeviceZoneData.Where(dev => dev.DeviceID == device.DeviceId).FirstOrDefault();
                                                        if (resultDb == null)
                                                        {
                                                            parameters.ZoneData = resultDb.ZoneData;
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    _logger.Info("VideoAnalyticsManagerService GetVideoAnalyticsCollection() Exception:" + ex.Message);
                                                    string Message1 = "VideoAnalyticsManagerIntegrationService-StartAnalytics -- Exception = " + ex.Message;
                                                    //InsertBrokerOperationLog.AddProcessLog(Message);
                                                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                                                }

                                                vaCamList.Add(parameters);
                                                /////Add parameters object in list
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService GetVideoAnalyticsCollection() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetVideoAnalyticsCollection -- Exception 1 = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return vaCamList;
            }
            finally
            {
                ClearMemory();
            }
            return vaCamList;
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        public string GetTest(int cameraId)
        {
            return "Hi.......Pagoda";
        }

        public DeviceDto GetDeviceById(int deviceId)
        {
            try
            {
                string Message = "VideoAnalyticsManagerIntegrationService-GetDeviceById -- deviceId  = " + deviceId;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                DeviceDto device = null;
                using (var ctx = new CentralDBEntities())
                {
                    var entity = ctx.Device.Single(x => x.DeviceId == deviceId);
                    //device = Mapper.Map<DeviceDto>(entity);//amit 04102016 manual mapping
                    try
                    {
                        if (entity is NvrCamera)
                        {
                            var _entity1 = entity as NvrCamera;
                            device = new NvrCameraDto()
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
                                //HasPvAnalytics = _entity1.HasPvAnalytics,
                                //  HasSzAnalytics = _entity1.HasSzAnalytics,
                                //  HasAbAnalytics = _entity1.HasAbAnalytics,
                                InterfaceId = _entity1.InterfaceId.HasValue ? _entity1.InterfaceId.Value : 0,
                                IsMovable = _entity1.IsMovable,
                                Name = _entity1.Name,
                                AnalyticAlgorithmType = new AnalyticAlgorithmTypeDto()
                                {
                                    AnalyticAlgorithmId = _entity1.AnalyticAlgorithmType.AnalyticAlgorithmId,
                                    Name = _entity1.AnalyticAlgorithmType.Name
                                },
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
                            device = new DeviceDto()
                            {
                                ActiveAlert = entity.ActiveAlert,
                                Altitude = entity.Altitude,
                                CameraGUID = entity.CameraGuid,
                                Description = entity.Description,
                                DeviceId = entity.DeviceId,
                                ExternalId = entity.ExternalId,
                                InterfaceId = int.Parse(entity.InterfaceId.ToString()),
                                IsMovable = entity.IsMovable,
                                Lat = entity.Lat,
                                LocationDescription = entity.LocationDescription,
                                Long = entity.Long,
                                Metadata = entity.Metadata,
                                Name = entity.Name,
                                NvrId = entity.NvrId,
                                SiteId = int.Parse(entity.SiteId.ToString()),
                                Type = entity.Type,
                            };
                        }

                    }
                    catch (Exception ex)
                    { }
                }

                if (device.Type != "NvrCamera")
                {
                    device.AssociatedDeviceId = GetAssociatedDevice(deviceId);
                }
                return device;
            }
            catch (Exception ex)
            {
                _logger.Info("SystemServiceImpl GetDeviceById() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetDeviceById -- Exception  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }


        private int? GetAssociatedDevice(int deviceId)
        {
            try
            {
                string Message = "VideoAnalyticsManagerIntegrationService-GetAssociatedDevice -- deviceId  = " + deviceId;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                using (var associationRepository = new CentralDBEntities()) //amit 16062017
                {
                    var firstOrDefault = associationRepository.ObjectsAssociation.FirstOrDefault(x => x.Object1Identity == deviceId && x.ObjectTypeId == 1);//obj.FirstOrDefault(o => o.Object1Identity == deviceId && o.ObjectType.Name == "Device");
                    if (firstOrDefault != null)
                    {
                        var associatedDeviceId = firstOrDefault.Object2Identity;
                        return associatedDeviceId;
                    }
                }
               
               /* using (var associationRepository = new TwTw.DataLayer.Models.ObjectsAssociationRepository())
                {
                    var firstOrDefault = associationRepository.All.FirstOrDefault(o => o.Object1Identity == deviceId && o.ObjectType.Name == "Device");
                    if (firstOrDefault != null)
                    {
                        var associatedDeviceId =
                            firstOrDefault.Object2Identity;

                        return associatedDeviceId;
                    }
                }*/

                return default(int?);
            }
            catch (Exception ex)
            {
                _logger.Info("SystemServiceImpl GetAssociatedDevice() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationService-GetAssociatedDevice -- Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;

        }
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET")]
        public bool StopAnalytics(int cameraId, string version, string authToken)
        {

            string Message = "VideoAnalyticsManagerIntegrationService-StopAnalytics -- cameraId:" + cameraId + "--!--version:" + version + "--!--authToken:" + authToken;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            //Thread.Sleep(5000);
            //return true;

            //throw new NotImplementedException();
            //1. Get device and parameters
            var device = GetDeviceById(cameraId);  //trupti to change calling of service because of broker distribution
            if (device.NvrId == null) throw new Exception("Not camera CustomException");
            // var nvr = _controllerService.GetNvrById("", device.NvrId.Value);

            string strUser = "";
            string strPass = "";
            string strIp = "";

            try
            {
                using (var ctx = new CentralDBEntities())
                {
                    var resultDb = (from nvr in ctx.NVR
                                    where nvr.NvrId == device.NvrId.Value
                                    select nvr).First();
                   // NvrDto nvrDto = Mapper.Map<NvrDto>(resultDb);//amit 03102016
                    //amit 03102016 manual mapping
                    if (resultDb != null)
                    {
                        NvrDto nvrDto = new NvrDto()
                        {
                            Description = resultDb.Description,
                            DvrNvrTypeId = int.Parse(resultDb.DvrNvrTypeId.ToString()),
                            InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                            IPAddress = resultDb.IPAddress,
                            NvrId = resultDb.NvrId,
                            NvrUrl = resultDb.NvrUrl,
                            Password = resultDb.Password,
                            Port = int.Parse(resultDb.Port.ToString()),
                            Username = resultDb.Username
                        };
                        strIp = nvrDto.IPAddress;
                        strUser = nvrDto.Username;
                        strPass = nvrDto.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService StopAnalytics() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-StopAnalytics --Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
            }           
            var nvrCamera = device as NvrCameraDto;

            ////Stop Analytics

            string _strIP = "";//"127.0.0.1";// GetNVRIP(cameraId);

            if (nvrCamera.AnalyticsServerIp != null && nvrCamera.AnalyticsServerIp != string.Empty)
            {
                _strIP = nvrCamera.AnalyticsServerIp.ToString();
            }
            if (Storage.IsAnalyticServer == "0")
                _strIP = _strIP;
            else
                _strIP = Storage.AnalyticServerIP;
            //read from config

            string _strUrl = "";
            try
            {
                _strUrl = "https://" + _strIP + ":6532/soap/VideoAnalyticsService";

                EndpointAddress ar = new EndpointAddress(_strUrl);

                var _serVice = new
                    NvrVideoAnalytics.VideoAnalyticsServiceClient("WSHttpBinding_IVideoAnalyticsService", ar.ToString());

                version = nvrCamera.AnalyticAlgorithmType.Name;
                if (version.Contains("Vehicle Counter Version") || version.Contains("Trip Wire") || version.Contains("People") || version.Contains("Counter") || version.Contains("Block"))//trupti29122014
                {
                    _serVice.StopAnalytics2020(nvrCamera.CameraIp, version,new Guid(nvrCamera.CameraGUID));
                }
                else
                {
                    _serVice.StopAnalytics(new Guid(device.CameraGUID), version);
                }
                _serVice.Close();

                //inform stations that analytics was broked.
                _stationSerVice.InformVideoAnalyticsStopped(device.CameraGUID); //amit 09032018

                //if exception hapens throw new Exception("...... CustomException"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Info("VideoAnalyticsManagerService StopAnalytics() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-StopAnalytics --Exception 1:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                 InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return true;
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET")]
        public string GetStatus(int cameraId, string version, string authToken)
        {
            string Message = "VideoAnalyticsManagerIntegrationService-GetStatus -- cameraId:" + cameraId + "--!--version:" + version + "--!--authToken:" + authToken;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            string strResult = "";
            //throw new NotImplementedException();
            //1. Get device and parameters
            var device = GetDeviceById(cameraId);   //trupti to change calling of service because of broker distribution
            if (device.NvrId == null) throw new Exception("Not camera CustomException");

            //var nvr = _controllerService.GetNvrById("", device.NvrId.Value);
            string strUser = "";
            string strPass = "";
            string strIp = "";

            try
            {
                using (var ctx = new CentralDBEntities())
                {
                    var resultDb = (from nvr in ctx.NVR
                                    where nvr.NvrId == device.NvrId.Value
                                    select nvr).First();
                    // NvrDto nvrDto = Mapper.Map<NvrDto>(resultDb); //amit 03102016 manual mapping
                    //amit 03102016 manual mapping
                    if (resultDb != null)
                    {
                        NvrDto nvrDto = new NvrDto()
                        {
                            Description = resultDb.Description,
                            DvrNvrTypeId = int.Parse(resultDb.DvrNvrTypeId.ToString()),
                            InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                            IPAddress = resultDb.IPAddress,
                            NvrId = resultDb.NvrId,
                            NvrUrl = resultDb.NvrUrl,
                            Password = resultDb.Password,
                            Port = int.Parse(resultDb.Port.ToString()),
                            Username = resultDb.Username
                        };
                        strIp = nvrDto.IPAddress;
                        strUser = nvrDto.Username;
                        strPass = nvrDto.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerService GetStatus() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetStatus --Exception :" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
            }

            var nvrCamera = device as NvrCameraDto;

            if (nvrCamera.CameraUrl == null || nvrCamera.CameraUrl == "")
            {
                return "Camera Url Should Not Be Blank";
            }

            //2. Call get status for nvr
            //if exception hapens throw new Exception("...... CustomException");
            //string _strIP = "10.0.0.22";
            string _strIP = "";//"127.0.0.1";// GetNVRIP(cameraId);trupti23122014

            if (nvrCamera.AnalyticsServerIp != null && nvrCamera.AnalyticsServerIp != string.Empty)
            {
                _strIP = nvrCamera.AnalyticsServerIp.ToString();
            }
            if (Storage.IsAnalyticServer == "0")
                _strIP = _strIP;
            else
                _strIP = Storage.AnalyticServerIP;
            //read from config
            string _strUrl = "";
            try
            {
                _strUrl = "https://" + _strIP + ":6532/soap/VideoAnalyticsService";

                var ar = new EndpointAddress(_strUrl);

                var _serVice = new AMS.Broker.IntegrationService.NvrVideoAnalytics.VideoAnalyticsServiceClient("WSHttpBinding_IVideoAnalyticsService", ar.ToString());
                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(2);
                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(2);

                version = nvrCamera.AnalyticAlgorithmType.Name;
                if (version.Contains("Vehicle Counter Version") || version.Contains("Trip Wire") || version.Contains("People") || version.Contains("Counter") || version.Contains("Block"))//trupti29122014
                {
                    strResult = _serVice.GetStatus2020(nvrCamera.CameraIp, version, new Guid(nvrCamera.CameraGUID));
                }
                else
                {
                    strResult = _serVice.GetStatus(new Guid(device.CameraGUID), version);
                }
                _serVice.Close();

                //if exception hapens throw new Exception("...... CustomException"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Info("VideoAnalyticsManagerService GetStatus() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetStatus --Exception 1:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return strResult;
            }
            finally
            {
                ClearMemory();
            }
            return strResult;
        }

        private static List<VideoAanalyticsEventDTO> GetVideoAanalyticsEvents(string result)
        {
            bool IsIndiaAlgo = false;
            string sreResult = result;

            sreResult = sreResult.Substring(sreResult.IndexOf("ALG"));
            sreResult = sreResult.Replace("\r", "");
            var resultList = new List<VideoAanalyticsEventDTO>();
            try
            {
                var lines = sreResult.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var vaEvent = new VideoAanalyticsEventDTO();
                string strTemp = "";
                foreach (var line in lines)
                {
                    string steTmpn = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    steTmpn = steTmpn.TrimStart();
                    steTmpn = steTmpn.TrimEnd();
                    steTmpn = steTmpn.Trim();
                    steTmpn = steTmpn.Replace(" ", string.Empty);
                    switch (steTmpn)
                    {
                        case "ALG":
                            strTemp = line.Substring(line.IndexOf(':', 0) + 1);
                            if (strTemp.Equals("0"))
                            {
                                vaEvent.AlgorithmName = "Sterile Zone Version 3.0";//SZ
                            }
                            if (strTemp.Equals("1"))
                            {
                                vaEvent.AlgorithmName = "Parked Vehicle Version 3.0";//PV
                            }
                            if (strTemp.Equals("2"))
                            {
                                vaEvent.AlgorithmName = "Abandoned Baggage Version 3.0";//AB
                            }
                            if (strTemp.Equals("3") || strTemp.Equals("6") || strTemp.Equals("8"))//Trupti29122014
                            {
                                vaEvent.AlgorithmName = "PC";//AB
                            }
                            if (strTemp.Equals("4"))//amit01092015
                            {
                                vaEvent.AlgorithmName = "Missing Object Version 1.0";//MO                               
                            }
                            if (strTemp.Equals("5"))
                            {
                                vaEvent.AlgorithmName = "Trip Wire Version 1.0";//AB
                                IsIndiaAlgo = true;
                            }
                            if (strTemp.Equals("7"))//Trupti29122014
                            {
                                vaEvent.AlgorithmName = "Camera Block Version 1.0";//AB
                                IsIndiaAlgo = true;
                            }

                            if (strTemp.Equals("9"))//Trupti29122014
                            {
                                vaEvent.AlgorithmName = "Vehicle Counter Version 1.0";//AB
                                IsIndiaAlgo = true;
                            }

                            break;
                        case "CID":
                            /* string strGuid = line.Substring(line.IndexOf(':', 0) + 1).ToString();
                             if (IsIndiaAlgo == false)
                             {
                                 try
                                 {
                                     vaEvent.CameraGuid = new Guid(strGuid);
                                 }
                                 catch (Exception ex)
                                 {
                                     
                                 }
                             }*/

                            // else
                            // vaEvent.CamIp = strGuid.Substring(0, strGuid.IndexOf(':'));

                            break;
                        case "OID":
                            vaEvent.ObjectId = line.Substring(line.IndexOf(':', 0) + 1);
                            break;
                        case "GID":
                            string strGuid1 = line.Substring(line.IndexOf(':', 0) + 1).ToString();
                            vaEvent.CameraGuid = new Guid(strGuid1);
                            break;
                        case "HEI":
                            vaEvent.Height = int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;
                        case "WID":
                            vaEvent.Width = int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;
                        case "XPO":
                            vaEvent.CenterX =
                                int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;
                        case "YPO":
                            vaEvent.CenterY =
                                int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;
                        case "STM":

                            string pattern = "ddd MMM dd HH:mm:ss yyyy";
                            string strTmp = line.Substring(line.IndexOf(':', 0) + 1);
                            DateTime resultParsetTime;
                            resultParsetTime = DateTime.ParseExact(strTmp
                                    , pattern,
                                    System.Globalization.CultureInfo.InvariantCulture);
                            vaEvent.SentTime = resultParsetTime;

                            break;
                        case "LVL":
                            vaEvent.AlarmLevel =
                                int.Parse(line.Substring(line.IndexOf(':', 0) + 1));

                            //vaEvent = new VideoAanalyticsEventDTO();
                            break;

                        case "PPC":
                            vaEvent.ObjectId = line.Substring(line.IndexOf(':', 0) + 1);

                            break;

                        case "DIR":
                            vaEvent.DirectionFlg =
                               int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;

                        case "LNUM": //Lane Number
                            vaEvent.LaneNumber = int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;

                        case "VTYPE"://Vehicle Type
                            vaEvent.VehicleType = int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;

                        case "VCOUNT"://Vehicle count
                            vaEvent.VehicleCount = int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                            break;
                    }
                }
                resultList.Add(vaEvent);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().DebugException(ex.Message, ex);
                _logger.Info("VideoAnalyticsManagerService GetVideoAanalyticsEvents() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetVideoAanalyticsEvents --Exception :" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                 InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return resultList;
            }
            finally
            {
                ClearMemoryStatic();
            }
            return resultList;
        }

        public static void ThreadProc()
        {
            try
            {
                Console.WriteLine("ThreadProc: {0}");

            Startagain:

                Thread.Sleep(0);
                ////Search files 
                string[] _files = Directory.GetFiles(@"C:\\VideoAnalyticsEventDataBroker\\AlertEventData\", "*.*", SearchOption.AllDirectories);

                int _Flag = 0;
                byte[] bytes = null;

                if (_files.Length > 0)
                {

                    for (int i = 0; i < _files.Length; i++)
                    {
                        string _file = _files[i].ToString();
                        ////Open File
                        try
                        {
                            System.IO.StreamReader _TxnFile =
                            new System.IO.StreamReader(_file);
                            string _myString = _TxnFile.ReadToEnd();
                            // _myString = _myString.Substring(1);
                            // _myString = _myString.Replace(" ", string.Empty);
                            _myString = _myString.TrimStart();
                            _myString = _myString.TrimEnd();
                            int _strLength = _myString.Length;
                            _TxnFile.Close();

                            /* if (!(_myString.Equals("")))
                             {
                                 if (_strLength > 0)
                                 {
                                     //_Flag = _Instance.SendData(_myString);
                                     List<VideoAanalyticsEventDTO> _mList = GetVideoAanalyticsEvents(_myString);
                                     VideoAanalyticsEventDTO Obj = (VideoAanalyticsEventDTO)_mList[0];

                                     using (var context = new CentralDBEntities())
                                     {
                                         var videoAnalyticseventDB = Mapper.Map<AMS.Broker.IntegrationService.DataStore.VideoAanalyticsEvent>(Obj);

                                         context.VideoAanalyticsEvent.Add(videoAnalyticseventDB);

                                         bool result = context.SaveChanges() > 0;
                                         ////Finally
                                         if (result)
                                             _Flag = 1;
                                     }
                                 }
                             }*/

                        }
                        catch (FileNotFoundException ioEx)
                        {
                            Console.WriteLine(ioEx.Message);
                            _logger.Info("VideoAnalyticsManagerService ThreadProc() Exception:" + ioEx.Message);
                            string Message1 = "VideoAnalyticsManagerIntegrationService-ThreadProc --Exception :" + ioEx.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                             InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }

                        ////Delete File
                        if (_Flag == 1)
                            File.Delete(_file);
                    }

                    goto Startagain;
                    Thread.Sleep(0);
                }
            }
            catch (Exception ex)
            {
                /////Error Msg
                _logger.Info("VideoAnalyticsManagerService ThreadProc() Exception:" + ex.Message); 
            }
            finally
            {
                ClearMemoryStatic();
            }
        }

        public void WriteAlertEventBuffer(string strEvent)
        {
            var guid = Guid.NewGuid();

            string _strFileName = "C:\\VideoAnalyticsEventDataBroker\\AlertEventData\\VideoAnalyticsEvent" + DateTime.Now.ToString("MMddyyyy HHmmss ") + guid.ToString() + ".log";

            //BinaryWriter _Writer = null;

            StreamWriter _Writer = null;

            try
            {
                // Create a new stream to write to the file
                _Writer = new StreamWriter(_strFileName);
                // Writer raw data
                string _strData = strEvent;

                int i = _strData.Length;

                _Writer.Write(_strData);

                _Writer.Flush();

                _Writer.Close();

                if (!(_myThread.IsAlive))
                {
                    _myThread = new Thread(ThreadProc);

                    _myThread.Start();
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                _logger.Info("VideoAnalyticsManagerService WriteAlertEventBuffer() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-WriteAlertEventBuffer --Exception :" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
            }
            finally
            {
                ClearMemory();
            }
        }

        private IDictionary<string, VideoAanalyticsEventDTO> _events = new Dictionary<string, VideoAanalyticsEventDTO>();

             

        public AnalyticsEventTemplateDto GetAnalyticsEventTemplate(int analyticsEventTemplateId)
        {
            try
            {
                string Message = "VideoAnalyticsManagerIntegrationService-GetAnalyticsEventTemplate --analyticsEventTemplateId :" + analyticsEventTemplateId;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                using (var ctx = new CentralDBEntities())
                {
                    var templateEntity = ctx.AnalyticsEventTemplate.SingleOrDefault(it => it.AnalyticsEventTemplateId == analyticsEventTemplateId);

                    if (templateEntity != null)
                    {


                        AnalyticsEventTemplateDto analyticsEventTemplateDto = new AnalyticsEventTemplateDto();
                        analyticsEventTemplateDto.AnalyticAlgorithmTypeId = templateEntity.AnalyticAlgorithmTypeId;
                        analyticsEventTemplateDto.AnalyticsEventTemplateId = templateEntity.AnalyticsEventTemplateId;
                        analyticsEventTemplateDto.Category = templateEntity.Category;
                        analyticsEventTemplateDto.Certainty = templateEntity.Certainty;
                        analyticsEventTemplateDto.Description = templateEntity.Description;
                        analyticsEventTemplateDto.EventTypeTeplateId = templateEntity.EventTypeTeplateId;
                        analyticsEventTemplateDto.Headline = templateEntity.Headline;
                        analyticsEventTemplateDto.Instruction = templateEntity.Instruction;
                        analyticsEventTemplateDto.MessageType = templateEntity.MessageType;
                        analyticsEventTemplateDto.Name = templateEntity.Name;
                        analyticsEventTemplateDto.ResponseType = templateEntity.ResponseType;
                        analyticsEventTemplateDto.Scope = templateEntity.Scope;
                        analyticsEventTemplateDto.Severity = templateEntity.Severity;
                        analyticsEventTemplateDto.Status = templateEntity.Status;
                        analyticsEventTemplateDto.Urgency = templateEntity.Urgency;
                        analyticsEventTemplateDto.EventType = templateEntity.EventType;
                        return analyticsEventTemplateDto;//Mapper.Map<AnalyticsEventTemplateDto>(templateEntity);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.Info("SystemServiceImpl GetAnalyticsEventTemplate() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationService-GetAnalyticsEventTemplate --Exception :" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
