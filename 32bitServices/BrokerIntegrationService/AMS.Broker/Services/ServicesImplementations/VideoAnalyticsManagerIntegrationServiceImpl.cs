using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;

using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using Status = AMS.Broker.Contracts.DTO.Status;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using AMS.Broker.IntegrationService.RihnoSecurity.Membership;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using AMS.Broker.IntegrationService.DataStore;
using NLog;
using AutoMapper;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace AMS.Broker.IntegrationService.Services.ServicesImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class VideoAnalyticsManagerIntegrationServiceImpl : ServiceBaseImpl, IVideoAnalyticsManagerIntegrationService
    {
       
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        private IDictionary<string, VideoAanalyticsEventDTO> _events = new Dictionary<string, VideoAanalyticsEventDTO>();        

        public int nAlertCount;
        public IEnumerable<DeviceDto> DeviceCollection = null;

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-ClearMemory -- Exception = "+ex.Message;
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
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-ClearMemoryStatic -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        public VideoAnalyticsManagerIntegrationServiceImpl()
        {
            try
            {
                DeviceCollection = GetDevicesCollectionImpl();
            }
            catch (Exception ex)
            { 
                _logger.Info("VideoAnalyticsManagerServiceImpl VideoAnalyticsManagerServiceImpl() Exception:" + ex.Message);
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }           
          
        }


        private IEnumerable<DeviceDto> GetDevicesCollectionImpl()
        {
            try
            {
                    using (var context = new CentralDBEntities())
                    {
                        IList<DeviceDto> result = new List<DeviceDto>();
                        _logger.Info("");
                        _logger.Info("controller: GetDevicesCollection");                        

                        var resultsCollection = context.Device;
                        /*  .AuthorizeCollection(authToken,
                                               x => SecurityPriviliges.AccessDeviceByNvr + x.NvrId,
                                               x => SecurityPriviliges.AccessDeviceAll)
                          .AuthorizeCollection(authToken,
                                               x => SecurityPriviliges.AccessDeviceById + x.NvrId,
                                               x => SecurityPriviliges.AccessDeviceAll);*/

                        var result2 = resultsCollection.Select(x => x).ToList();

                        foreach (var _entity in result2)
                        {
                            if (_entity is NvrCamera)
                            {
                                try
                                {
                                    var _entity1 = _entity as NvrCamera;

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
                                        //  HasPvAnalytics = _entity1.HasPvAnalytics,
                                        //  HasSzAnalytics = _entity1.HasSzAnalytics,
                                        //   HasAbAnalytics = _entity1.HasAbAnalytics,
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
                                catch (Exception ex)
                                {
                                    //amit 25062017
                                    string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetDevicesCollectionImpl  _deviceDto Exception = " + ex.Message;
                                    //InsertBrokerOperationLog.AddProcessLog(Message);
                                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
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
                                        //HasPvAnalytics = _entity.HasPvAnalytics,
                                        // HasSzAnalytics = _entity.HasSzAnalytics,
                                        // HasAbAnalytics = _entity.HasAbAnalytics,
                                        InterfaceId = _entity.InterfaceId.HasValue ? _entity.InterfaceId.Value : 0,
                                        IsMovable = _entity.IsMovable,
                                        Name = _entity.Name
                                    };

                                    result.Add(_deviceDto);
                                }
                                catch (Exception es)
                                {
                                    //amit 25062017
                                    string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetDevicesCollectionImpl  _deviceDto 1 Exception = " + es.Message;
                                    //InsertBrokerOperationLog.AddProcessLog(Message);
                                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                                }
                            }
                        }

                        _logger.Info("  items count: {0}", resultsCollection.Count());
                        _logger.Info("------------------------------------");
                        return result;
                    }
                
            }
            catch (System.Security.SecurityException ex)
            {
                _logger.Info("ControllerServiceImpl GetDevicesCollectionImpl() Exception:" + ex.Message);

                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetDevicesCollectionImpl  Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                _logger.Error(ex);
            }
            finally
            {
                ClearMemory();
            }
            //

            return null;
        }        

        public IEnumerable<string> GetCapabilities(Guid cameraId)
        {
            throw new NotImplementedException(); //Todo
        }

        public bool StartAnalytics(int cameraId, string version, string authToken)
        {
            ClearMemory();
            return true;
        }

        public bool StopAnalytics(int cameraId, string version, string authToken)
        {
            ClearMemory();
            return true;
        }

        public string GetStatus(int cameraId, string version, string authToken)
        {
            try
            {
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetDevicesCollectionImpl  GetStatus: cameraId = " + cameraId + "-!- authToken:" + authToken;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                //1. Get device and parameters
                var device = GetDeviceById(cameraId);    //trupti to change calling of service because of broker distribution
                if (device.NvrId == null) throw new Exception("Not camera CustomException");
                var nvr = GetNvrById("", device.NvrId.Value);   //trupti to change calling of service because of broker distribution
                var nvrCamera = device as NvrCameraDto;


                //2. Call get status for nvr
                //if exception hapens throw new Exception("...... CustomException"); 
               
                return "";
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerServiceImpl GetStatus() Exception:" + ex.Message);
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl -- GetStatus() -- Exception = " + ex.Message;
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

        public DeviceDto GetDeviceById(int deviceId)
        {
            try
            {
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl- GetDeviceById: deviceId = " + deviceId;
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
                    {
                        string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetDeviceById: Exception = " + ex.Message;
                        //InsertBrokerOperationLog.AddProcessLog(Message);
                        InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                    }
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
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetDeviceById  : Exception 1 = " + ex.Message;
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
                //amit 25062017
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetAssociatedDevice  : deviceId = " + deviceId;
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
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetAssociatedDevice  : Exception 1 = " + ex.Message;
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
        public NvrDto GetNvrById(string authToken, long nvrId)
        {
            string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetNvrById  : authToken = " + authToken;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            //if (!AuthenticationHelper.CanAccess(authToken, SecurityPriviliges.GetNvrById + nvrId))
            //{
            //    _logger.Info(string.Format("Access not allowed. {0}", authToken.GetUserNameByToken()));
            //    return null;
            //}


            NvrDto result = null;
            try
            {
                using (var ctx = new CentralDBEntities())
                {
                    var resultDb = (from nvr in ctx.NVR
                                    where nvr.NvrId == nvrId
                                    select nvr).First();
                    // NvrDto nvrDto =  Mapper.Map<NvrDto>(resultDb);

                    //amit 22092016 manual mapping
                    if (resultDb != null)
                    {
                        result = new NvrDto()
                        {
                            Description = resultDb.Description,
                            InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                            IPAddress = resultDb.IPAddress,
                            NvrId = resultDb.NvrId,
                            NvrUrl = resultDb.NvrUrl,
                            Password = resultDb.Password,
                            Port = int.Parse(resultDb.Port.ToString()),
                            Username = resultDb.Username
                        };
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Info("ControllerServiceImpl GetNvrById() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetNvrById  : Exception 1 = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                _logger.Error(ex);
                return result;
            }
            finally
            {
                ClearMemory();
            }

            return result;
        }

        private static List<VideoAanalyticsEventDTO> GetVideoAanalyticsEvents(string result)
        {
            try
            {
                string sreResult = result;
                sreResult = sreResult.Substring(sreResult.IndexOf("ALG"));
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
                                if (strTemp.Equals("3"))
                                {
                                    vaEvent.AlgorithmName = "PC";//AB
                                }

                                break;
                            case "CID":
                                string strGuid = line.Substring(line.IndexOf(':', 0) + 1).ToString();
                                vaEvent.CameraGuid = new Guid(strGuid);
                                break;
                            case "OID":
                                vaEvent.ObjectId = line.Substring(line.IndexOf(':', 0) + 1);
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
                                /*string pattern = "ddd MMM dd HH:mm:ss yyyy";
                                DateTime resultParsetTime;
                                DateTime.TryParseExact(line.Substring(line.IndexOf(':', 0) + 1)
                                        , pattern, null,
                                        DateTimeStyles.None, out resultParsetTime);
                                vaEvent.SentTime = resultParsetTime;*/

                                break;
                            case "LVL":
                                vaEvent.AlarmLevel =
                                    int.Parse(line.Substring(line.IndexOf(':', 0) + 1));
                                resultList.Add(vaEvent);
                                vaEvent = new VideoAanalyticsEventDTO();
                                break;

                            case "PPC":

                                resultList.Add(vaEvent);
                                vaEvent = new VideoAanalyticsEventDTO();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.GetCurrentClassLogger().DebugException(ex.Message, ex);
                    _logger.Info("VideoAnalyticsManagerServiceImpl GetVideoAanalyticsEvents() Exception:" + ex.Message);
                    string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetVideoAanalyticsEvents  : Exception 1 = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                }
              
                return resultList;
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerServiceImpl GetVideoAanalyticsEvents() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetVideoAanalyticsEvents  : Exception 2 = " + ex.Message;
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

        public AnalyticsEventTemplateDto GetAnalyticsEventTemplate(int analyticsEventTemplateId)
        {
            try
            {
                string Message = "VideoAnalyticsManagerIntegrationServiceImpl-GetAnalyticsEventTemplate  : analyticsEventTemplateId = " + analyticsEventTemplateId;
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
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-GetAnalyticsEventTemplate  : Exception 1 = " + ex.Message;
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

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        public int ConsumeEvent(string message)
        {
            try
            {
                //throw new NotImplementedException();
                int nRetVal = 0;

                try
                {
                    if (message != null)
                    {
                        try
                        {
                            string Message = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : Start ";
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                            List<VideoAanalyticsEventDTO> _mList = GetVideoAanalyticsEvents(message);
                            VideoAanalyticsEventDTO Obj = (VideoAanalyticsEventDTO)_mList[0];

                            ///////Save data to buffer
                            //WriteAlertEventBuffer(message);

                            ///////Send Event to Stations  // Generate Alart

                            DeviceDto cameraDevice = new DeviceDto();//= _controllerService.GetCameraDeviceByGuid(Obj.CameraGuid);

                            cameraDevice = DeviceCollection.SingleOrDefault(it => it.CameraGUID == Obj.CameraGuid.ToString());   //trupti to change calling of service because of broker distribution

                            DeviceDto deviceDto = cameraDevice;

                            if (Obj.AlgorithmName.Equals("PC"))
                            {
                                //insert into database
                                using (var contextpc = new CentralDBEntities())
                                {

                                    var peopleCounter = new tbpeoplecounter
                                    {
                                        DeviceID = deviceDto.DeviceId,
                                        EventDate = Obj.SentTime,
                                        EventCount = Int32.Parse(Obj.ObjectId)

                                    };

                                    contextpc.tbpeoplecounter.Add(peopleCounter);
                                    contextpc.SaveChanges();
                                    nRetVal = 1;
                                    goto exitToNext;
                                }

                            }

                            if (_events.ContainsKey(Obj.ObjectId))
                            {                               
                                return 1;
                            }
                            _events.Add(Obj.ObjectId, Obj);

                            NvrCameraDto nvrCameraDto = cameraDevice as NvrCameraDto;
                            int enevtTmplateID = nvrCameraDto.AnalyticsEventTemplateId.HasValue ? nvrCameraDto.AnalyticsEventTemplateId.Value : 0;
                            AnalyticsEventTemplateDto analyticsEventTemplateDto =
                                GetAnalyticsEventTemplate(enevtTmplateID);//AnalyticAlgorithmTypeId

                            if (analyticsEventTemplateDto.AnalyticAlgorithmTypeId > 0)
                            {
                                string strEventDesc = "";

                                if (analyticsEventTemplateDto.AnalyticAlgorithmTypeId == 2)
                                {
                                    strEventDesc = "Zone Violation – Parked Vehicle.";
                                }
                                if (analyticsEventTemplateDto.AnalyticAlgorithmTypeId == 3)
                                {
                                    strEventDesc = "Zone Violation – Abandoned Object.";
                                }
                                if (analyticsEventTemplateDto.AnalyticAlgorithmTypeId == 4)
                                {
                                    strEventDesc = "Zone Violation – People.";
                                }


                                string strAlertGuid = Guid.NewGuid().ToString();

                                ///////Now Alert found......Process for database in Alert , Info and Area Table....
                                var alert = new AlertDTO
                                {
                                    DeviceId = deviceDto.DeviceId,
                                    Sender = "Device-" + deviceDto.DeviceId,      //// Device-DeviceID
                                    Source = deviceDto.InterfaceId.ToString(),  ////InterfaceId from deviceDTO   ////Should be Name of the Interface
                                    //SentAsString = Obj.SentTime.ToString(), ////EventDto event datetime
                                    Sent = DateTime.Now,
                                    Identifier = strAlertGuid,
                                    StatusId = (Status)Enum.Parse(typeof(Status), (string)analyticsEventTemplateDto.Status),////Status FROM EventTemplateDto
                                    MessageTypeId = Contracts.DTO.MessageType.Alert,////////MessageType FROM EventTemplateDto
                                    ScopeId = (Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), (string)analyticsEventTemplateDto.Scope),////Scope FROM EventTemplateDto
                                    Code = strEventDesc,//eventDB.EventCode,/////EventDto Eeventcode
                                    Addresses = deviceDto.Name,//(string)wcfEvent.Payload["Address"],////site address from site table
                                    InfoCollection = new List<InfoDTO>()
                                                    {
                                                        new InfoDTO
                                                            {
                                                                Headline = analyticsEventTemplateDto.Headline,
                                                                Description =  (string)analyticsEventTemplateDto.Description,////Description FROM EventTemplateDto
                                                                Instruction =  (string)analyticsEventTemplateDto.Instruction,////Instruction FROM EventTemplateDto
                                                                Contact = "",//(string)wcfEvent.Payload["Contact"],////Contactid get from account id get from site id
                                                                UrgencyId = (Contracts.DTO.Urgency)Enum.Parse(typeof(Contracts.DTO.Urgency), (string)analyticsEventTemplateDto.Urgency),
                                                                SeverityId = (Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), (string)analyticsEventTemplateDto.Severity),
                                                                CertaintyId = (Contracts.DTO.Certainty)Enum.Parse(typeof(Contracts.DTO.Certainty), (string)analyticsEventTemplateDto.Certainty),
                                                                Event = strEventDesc,//eventDB.EventCode,////Actual event code from event
                                                                AreasCollection = new List<AreaDTO>()
                                                                    {
                                                                        new AreaDTO
                                                                            {
                                                                                SiteId = deviceDto.SiteId,
                                                                                Latitude = Convert.ToDouble(deviceDto.Lat),
                                                                                Longitude = Convert.ToDouble(deviceDto.Long),
                                                                                Altitude =  Convert.ToDouble(deviceDto.Altitude)
                                                                            }
                                                                    }
                                                            }
                                                    }
                                };

                                //By Yogesh
                            alert.VideoAanalyticsEvent = new List<VideoAanalyticsEventDTO>()
                            {
                                new VideoAanalyticsEventDTO 
                                {
                                     CameraGuid = Obj.CameraGuid,
                                     ObjectId = Obj.ObjectId,
                                     Height = Obj.Height,
                                     Width = Obj.Width,
                                     CenterX = Obj.CenterX,
                                     CenterY = Obj.CenterY,
                                     SentTime = Obj.SentTime,
                                     IsInZone = Obj.IsInZone,
                                     AlarmLevel = Obj.AlarmLevel,
                                     AlgorithmName = Obj.AlgorithmName
                                }
                            };

                            bool IsTrue = false;//_alertCreationService.SubmitNewAlert(alert);

                            try
                            {
                                string _strUrl = "https://localhost:6530/soap/AlertsCreationService";
                                System.ServiceModel.EndpointAddress ar = new System.ServiceModel.EndpointAddress(_strUrl);
                                AlertsCreationServiceRef.AlertsCreationServiceClient _serVice = new AlertsCreationServiceRef.AlertsCreationServiceClient("WSHttpBinding_IAlertsCreationService", ar.ToString());
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

                                IsTrue = _serVice.SubmitNewAlertDto(alert);
                                _serVice.Close();
                            }
                            catch (OutOfMemoryException ex)
                            {
                                _logger.Info("StationsServiceImpl ConsumeEvent() Exception:" + ex.Message);
                                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : OutOfMemoryException = " + ex.Message;
                                //InsertBrokerOperationLog.AddProcessLog(Message);
                                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                            }
                            catch (Exception ex)
                            {
                                _logger.Info("StationsServiceImpl ConsumeEvent() Exception:" + ex.Message);
                                Console.WriteLine(ex.Message);
                                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : Exception = " + ex.Message;
                                //InsertBrokerOperationLog.AddProcessLog(Message);
                                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                            }
                            finally
                            {

                            }

                                if (IsTrue == true)
                                {
                                    ////get alert ID FOR Identifire strAlertGuid
                                    using (var context = new CentralDBEntities())
                                    {
                                        var templates = from t in context.Alert
                                                        where t.Identifier == strAlertGuid
                                                        select t;
                                        var template = templates.FirstOrDefault();
                                        Obj.AlertId = template.AlertId;

                                      //  var videoAnalyticseventDB = Mapper.Map<AMS.Broker.IntegrationService.DataStore.VideoAanalyticsEvent>(Obj);
                                        //amit 30092016 manual mapping
                                        AMS.Broker.IntegrationService.DataStore.VideoAanalyticsEvent videoAnalyticseventDB= new AMS.Broker.IntegrationService.DataStore.VideoAanalyticsEvent();
                                        videoAnalyticseventDB.AlarmLevel = Obj.AlarmLevel;
                                        videoAnalyticseventDB.AlertId = Obj.AlertId;
                                        videoAnalyticseventDB.AlgorithmName = Obj.AlgorithmName;
                                        videoAnalyticseventDB.CameraGuid = Obj.CameraGuid;
                                        videoAnalyticseventDB.CenterX = Obj.CenterX;
                                        videoAnalyticseventDB.CenterY = Obj.CenterY;
                                        videoAnalyticseventDB.Height = Obj.Height;
                                        videoAnalyticseventDB.IsInZone = Obj.IsInZone;
                                        videoAnalyticseventDB.ObjectId = Obj.ObjectId;
                                        videoAnalyticseventDB.SentTime = Obj.SentTime;
                                        videoAnalyticseventDB.VideoAanalyticsEventId = Obj.VideoAanalyticsEventId;
                                        videoAnalyticseventDB.Width = Obj.Width;

                                        context.VideoAanalyticsEvent.Add(videoAnalyticseventDB);

                                        bool result = context.SaveChanges() > 0;
                                        ////Finally
                                        if (result)
                                            nRetVal = 1;
                                    }

                                }

                            }

                            //nRetVal = 1;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            nRetVal = 1;
                            _logger.Info("VideoAnalyticsManagerServiceImpl ConsumeEvent() Exception:" + ex.Message);
                            string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : Exception 1 = " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    nRetVal = 1;
                    _logger.Info("VideoAnalyticsManagerServiceImpl ConsumeEvent() Exception:" + ex.Message);
                    string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : Exception 2 = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                }

            exitToNext:
                               
                return nRetVal;
            }
            catch (Exception ex)
            {
                _logger.Info("VideoAnalyticsManagerServiceImpl ConsumeEvent() Exception:" + ex.Message);
                string Message1 = "VideoAnalyticsManagerIntegrationServiceImpl-ConsumeEvent  : Exception 3= " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                return 0;
            }
            finally
            {
                ClearMemory();
            }
            return 0;
        }

        public IEnumerable<VideoAnalyticsParameters> GetVideoAnalyticsCollection(string strNvr)
        {
            throw new NotImplementedException();
        }

        public string GetTest(int cameraId)
        {
            throw new NotImplementedException();
        }
        
       /* [DataContract]
        public class VideoAnalyticsParametersNew
        {
            [DataMember]
            public string VideoPath { get; set; }

            [DataMember]
            public string Version { get; set; }

            [DataMember]
            public int MaxBlobSize { get; set; }

            [DataMember]
            public int MinBlobSize { get; set; }

            [DataMember]
            public int AlarmDelay { get; set; }

            [DataMember]
            public float UpdateRate { get; set; }

            [DataMember]
            public string NvrUser { get; set; }

            [DataMember]
            public string NvrPassword { get; set; }

            [DataMember]
            public Guid CameraGuid { get; set; }

            [DataMember]
            public int Width { get; set; }

            [DataMember]
            public int Height { get; set; }

            [DataMember]
            public int FPS { get; set; }

            [DataMember]
            public int ZoneRows { get; set; }

            [DataMember]
            public int ZoneColumns { get; set; }

            [DataMember]
            public byte[] ZoneData { get; set; }
        }*/
    }
}
