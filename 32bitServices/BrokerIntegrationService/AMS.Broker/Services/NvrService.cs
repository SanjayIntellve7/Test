using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Interfaces;
using NLog;
using QL.Communication.Authentication;
using QL.Communication.Messaging;
using QL.Communication.Messaging.Messages;
using QL.Communication.Network;
using QL.Communication.Server;
using QL.ComponentsModel.ComponentsManagement;
using QL.Configuration;
using QL.VideoBrowser.Controllers;
using QL.VideoBrowser.Controllers.CamerasManagement;
using QL.VideoBrowser.Controllers.VideoServersManagement;
using QL.VideoBrowser.Utils;
using QL.VideoBrowser.Controllers.MediaExport;
using QL.VideoBrowser.Controllers.CamerasManagement.MediaExport;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsFileCache;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsProviders;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsServices;
using QL.VideoBrowser.Controllers.ThumbnailsCache;
using QL.VideoBrowser.Controllers.ThumbnailsProviders;
using QL.VideoBrowser.Controllers.ThumbnailsServices;

namespace AMS.Broker.IntegrationService.Services
{
    public class NvrService : INvrCamerasProvider, INvrAlarmProvider
    {
        #region Private Variables

        private IVideoServersModel _videoServersModel;
        private IComponentsManager _componentsManager;
        private IConfigurationManager _configurationManager;
        private IVideoServersManager _videoServersManager;
        private ICamerasManager _camerasManager;
        private ICamerasManager camerasManager;

        private IRecordingThumbnailsProviderFactory _recordingThumbnailsProviderFactory;
        private IServerController _serverController;

        private readonly IList<QL.VideoBrowser.Controls.Media.MediaElement> _players = new List<QL.VideoBrowser.Controls.Media.MediaElement>();
        private readonly IDictionary<string, Guid> _servers = new Dictionary<string, Guid>();

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private IDataPartsSavingService exportDataPartSer;

        private IMediaExportService exportService;
        private string exportDir;
        private long MinFreeSpaceForVisualWarning = 314572800;

        #endregion

        #region Public Methods

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "NvrService-ClearMemory -- Exception = " + ex.Message;
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
                string Message = "NvrService-ClearMemoryStatic -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        public NvrService()
        {
            try
            {
                // _configurationManager = new ConfigurationManager();
            }
            catch (Exception x)
            { }
        }
        public void Initialize()
        {

            RegisterApplicationComponents();
            ResolveApplicationComponents();
        }
        public VideoServerEntity GetServer(string ip)
        {
            ClearMemory();
            return _videoServersModel.GetServers().First(s => s.Address == ip);
        }
        public IServerController GetServerController()
        {
            ClearMemory();
            return _serverController;
        }
        public IVideoServersManager GetServerManager()
        {
            ClearMemory();
            return _videoServersManager;
        }

        public IEnumerable<DeviceDto> GetCameras(NvrDto nvrDto)
        {
            try
            {
                // Requesting the cameras list from the server.
                /*var server = InitializeServer(nvrDto);
                this.camerasManager.GetCamerasAsObservable(server.ServerUniqueId).Subscribe(
                cameras =>
                {
                    // Looking for a camera with name specified in configuration
                     var camerasResult = cameras.Cameras.Select(camera =>
                            {
                                var device = new NvrCameraDto()
                                    {
                                        CameraGUID = camera.Id.ToString(),
                                        Description = camera.Name,
                                        IPAddress = camera.Address,
                                        Lat = camera.LocationLatitude,
                                        Long = camera.LocationLongitude,
                                        Type = "NVRCamera",
                                        LocationDescription = string.Empty,
                                        Metadata =
                                            string.Format("<metadata><camera-id>{0}</camera-id></metadata>", camera.Id),
                                        Width = camera.Width,
                                        Height = camera.Height,
                                        FPS = (int)camera.RecordingFrameRate,
                                        ZoneColumns = camera.Width,
                                        ZoneRows = camera.Height,
                                        UpdateRate = (decimal?)0.0001

                                    };
                                return device;
                            }).ToList();
                    var camera = cameras.Cameras.FirstOrDefault(c => c.Name == this.cameraName);
                    if (camera != null)
                    {
                        var source = new Source(this.server.Id, camera.Id, false) { Framerate = 25 };
                        //If playing video and loading thumbnails are requested during handling a response to a cameras request from the CamerasManager
                        // - it has to be done in separate thread in order to avoid problems with deadlock of CamerasManager.
                        ThreadPool.QueueUserWorkItem(_ =>
                        {
                            // Setting the source to player in order to start playing the video
                            this.player.Source = source;
                            this.player.Play();

                            // Setting the source to ThumbnailsSlider in order to load thumbnails for this specific camera
                            this.slider.Source = source;
                        });
                    }
                    else
                    {
                        // Such camera not found
                    }
                },
                error =>
                {
                    // An error occurred when receiving the cameras list
                     exception => _logger.Error("Failed to get cameras for server. Error information:\r\n{0}", exception));
                     return cameras.EmptyIfNull();
                });*/

                var camerasInfoRequestMessage = new AdditionalCameraInfoRequest();
                var cameras = ExecuteRequest<AdditionalCameraInfoResponse, IEnumerable<DeviceDto>>(nvrDto, camerasInfoRequestMessage,
                    result =>
                    {
                        var camerasResult = result.CamerasInfoCollection.Select(camera =>
                        {
                            var device = new NvrCameraDto()
                            {
                                CameraGUID = camera.Id.ToString(),
                                Description = camera.Name,
                                IPAddress = camera.Address,
                                Lat = camera.LocationLatitude,
                                Long = camera.LocationLongitude,
                                Type = "NVRCamera",
                                IsPtz = false,
                                IsMovable = false,
                                LocationDescription = string.Empty,
                                Metadata =
                                    string.Format("<metadata><camera-id>{0}</camera-id></metadata>", camera.Id),
                                Width = camera.Width,
                                Height = camera.Height,
                                FPS = (int)camera.RecordingFrameRate,
                                ZoneColumns = camera.Width,
                                ZoneRows = camera.Height,
                                UpdateRate = (decimal?)0.0001

                            };

                            return device;
                        }).ToList();

                        return camerasResult;
                    },
                    exception => _logger.Error("Failed to get cameras for server. Error information:\r\n{0}", exception));

                return cameras.EmptyIfNull();
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService GetCameras() Exception:" + ex.Message);
                string Message = "NvrService-GetCameras -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        public IEnumerable<VideoAlarmEvent> GetVideoAlarms(NvrDto nvr, IEnumerable<DeviceDto> nvrDevices)
        {
            try
            {
                var devices =
                    nvrDevices.EmptyIfNull()
                              .Where(dto => dto.InterfaceId == nvr.InterfaceId)
                              .Select(device => Guid.Parse(device.CameraGUID));

                return GetVideoAlarms(nvr, devices);
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService GetVideoAlarms() Exception:" + ex.Message);
                string Message = "NvrService-GetVideoAlarms -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        public IMediaExportService InitExportService()
        {
            /* string strPathTemp = System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
             this.exportDir = strPathTemp;
             return new MediaExportService(_videoServersManager, new DataPartsSavingService(this.exportDir, MinFreeSpaceForVisualWarning));*/
            ClearMemory();
            return this.exportService;
        }

        public IEnumerable<VideoAlarmEvent> GetVideoAlarms(NvrDto nvr, IEnumerable<Guid> sources)
        {
            try
            {
                var alarmRequest = new AlarmsEventsRequestMessageExtended
                {
                    StartDate = DateTime.Now.ToUniversalTime().AddDays(-1),
                    EndDate = DateTime.Now,
                    MaxTransaction = 100,
                    PosModeEnabled = false,
                    Sources = sources,
                    SearchString = string.Empty
                };

                var alarmsEventsResult = ExecuteRequest<AlarmsEventsResponseMessageExtended, IEnumerable<VideoAlarmEvent>>(nvr, alarmRequest,
                    result =>
                    {
                        var alarmEvents = result.Events.Select(alarmEvent => new VideoAlarmEvent
                        {
                            AlarmId = alarmEvent.AlarmId,
                            AlarmName = alarmEvent.AlarmName,
                            Cameras = alarmEvent.Cameras,
                            Date = alarmEvent.Date,
                            Deactivated = alarmEvent.Deactivated,
                            Description = alarmEvent.Description,
                            EventId = alarmEvent.EventId,
                            Priority = alarmEvent.Priority
                        }).ToList();
                        return alarmEvents;
                    },
                    exception => _logger.Error("Failed to get video alarms for server. Error information:\r\n{0}", exception));

                return alarmsEventsResult.EmptyIfNull();
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService GetVideoAlarms() Exception:" + ex.Message);
                string Message = "NvrService-GetVideoAlarms -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }


        public void AddServer(string ip, int port, string user, string password, string domain)
        {
            if (_servers.ContainsKey(ip))
            {
                _serverController = _videoServersManager.GetServer(_servers[ip]);
            }
            else
            {
                var server = new VideoServerEntity
                {
                    Address = ip,
                    Id = Guid.NewGuid(),
                    Name = "My server",
                    Port = port,
                    UserName = user,
                    UserPassword = password,
                    UserDomain = string.Empty
                };//2020IMAGING
                _videoServersModel.AddServer(server);
                _servers.Add(ip, server.Id);
                _serverController = _videoServersManager.GetServer(server.Id);
            }
            _serverController.Timeout = new TimeSpan(0, 0, 10);
        }

        public IEnumerable<object> GetCameraAdditionalInfo(NvrDto nvr)
        {
            try
            {
                var cameraInfoRequest = new AdditionalCameraInfoRequest();

                var camerasInfoCollection = ExecuteRequest<AdditionalCameraInfoResponse, IEnumerable<Object>>(nvr, cameraInfoRequest,
                    result =>
                    {
                        var camerasInfos = result.CamerasInfoCollection;
                        return camerasInfos;
                    },
                    exception => _logger.Error("Failed to get camera info collection from server. Error information:\r\n{0}", exception));

                return camerasInfoCollection.EmptyIfNull();
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService GetCameraAdditionalInfo() Exception:" + ex.Message);
                string Message = "NvrService-GetCameraAdditionalInfo -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        #endregion

        #region Helper Methods

        // Make it service locator like
        private IServerController InitializeServer(NvrDto nvrDto)
        {
            try
            {
                var videoServerEntity = new VideoServerEntity
                {
                    Address = nvrDto.IPAddress,
                    Id = Guid.NewGuid(),
                    Name = nvrDto.Description,
                    Port = nvrDto.Port,
                    UserName = nvrDto.Username,
                    UserPassword = nvrDto.Password,
                    UserDomain = string.Empty
                };

                _videoServersModel.AddServer(videoServerEntity);
                var serverController = _videoServersManager.GetServer(videoServerEntity.Id);
                serverController.ServerControllerError += (s, e) =>
                {
                    _logger.Error("Server error: {0}", e.Error);
                };

                return serverController;


            }
            catch (Exception ex)
            {
                _logger.Info("NvrService InitializeServer() Exception:" + ex.Message);
                string Message = "NvrService-InitializeServer -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        //TODO: review when working on alarms
        private TResult ExecuteRequest<TResponse, TResult>(NvrDto nvrDto, MessageBase request, Func<TResponse, TResult> onSuccess, Action<Exception> onError)
            where TResponse : MessageBase
        {

            var tcs = new TaskCompletionSource<TResult>();
            var server = InitializeServer(nvrDto);
            Action serverCall = () => server.SendAndGetResponseAsObservable<TResponse>(request)
                           .Subscribe<TResponse>(response =>
                           {
                               var result = onSuccess(response);
                               tcs.TrySetResult(result);
                           }, error =>
                           {
                               onError(error);
                               tcs.TrySetResult(default(TResult));
                           });
            if (server.State == ServerControllerState.Connected)
            {
                serverCall();
            }
            else
            {
                server.Connected += (s, e) => serverCall();
            }
            ClearMemory();
            return tcs.Task.Result;

        }

        #region Initialization to be moved in another place

        private void ResolveApplicationComponents()
        {
            try
            {
                _videoServersModel = _componentsManager.Resolve<IVideoServersModel>();
                _componentsManager.Resolve<ICamerasManager>();
                this.camerasManager = this._componentsManager.Resolve<ICamerasManager>();
                // camerasManager.Resolve<ICamerasManager>();
                _videoServersManager = _componentsManager.Resolve<IVideoServersManager>();
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService ResolveApplicationComponents() Exception:" + ex.Message);
                string Message = "NvrService-ResolveApplicationComponents -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

        }

        private void RegisterApplicationComponents()
        {
            try
            {
                _configurationManager = new ConfigurationManagerStub();
                _componentsManager = new ComponentsManager(_configurationManager, null, null);
                _componentsManager.Run();
                RegisterComponents();
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService RegisterApplicationComponents() Exception:" + ex.Message);
                string Message = "NvrService-RegisterApplicationComponents -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

        }

        private void RegisterComponents()
        {
            try
            {
                Register<IConfigurationManager>(_configurationManager);
                Register<IMessageDispatcherFactory, DefaultMessageDispatcherFactory>();
                Register<IConnection, TcpConnection>(ConnectionProtocol.Tcp.ToString());
                Register<IPropertyBagSerializer, PropertyBagBinarySerializer>(MessageFormat.Binary.ToString());
                Register<IPropertyBagFactory, MemoryPropertyBagFactory>();
                Register<IAuthenticatorFactory, NtlmAuthenticatorFactory>(AuthenticationProtocol.Ntlm.ToString());
                Register<IServerController, ServerController>();
                Register<IServerControllerFactory>(new ServerControllerFactory(_componentsManager, TimeSpan.FromMinutes(1)));
                Register<IVideoServersModel, VideoServersModel>(null, true);
                Register<IVideoServersManager, VideoServersManager>(null, true);
                Register<ICamerasManager, CamerasManager>();

                _videoServersModel = _componentsManager.Resolve<IVideoServersModel>();
                _camerasManager = _componentsManager.Resolve<ICamerasManager>();
                _videoServersManager = _componentsManager.Resolve<IVideoServersManager>();

                string strPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                this.exportDir = strPathTemp + "\\Temp";
                this.exportService = new MediaExportService(_videoServersManager, new DataPartsSavingService(this.exportDir, MinFreeSpaceForVisualWarning));

                /* _thumbnailsService = new RecordingThumbnailsService(_videoServersManager);
                 _thumbnailsCacheService = new RecordingThumbnailsCacheService(thumbnailsCasheDir, 1*100);

                 _recordingThumbnailsProviderFactory = new RecordingThumbnailsProviderFactory(_thumbnailsService,
                                                                                              _thumbnailsCacheService);*/
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService RegisterComponents() Exception:" + ex.Message);
                string Message = "NvrService-RegisterComponents -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

            // Register<IShell, Shell>();
        }

        private void Register<T1, T2>(string name = null, bool singlethon = false)
        {
            try
            {
                _componentsManager.RegisterType(typeof(T1), typeof(T2), name, singlethon);
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService Register() Exception:" + ex.Message);
                string Message = "NvrService-NvrService Register-- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

        }

        private void Register<T>(object instance, string name = null)
        {
            try
            {
                _componentsManager.RegisterInstance(typeof(T), name, instance);
            }
            catch (Exception ex)
            {
                _logger.Info("NvrService Register() Exception:" + ex.Message);
                string Message = "NvrService-NvrService Register -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

        }

        #endregion

        #endregion
    }
}

