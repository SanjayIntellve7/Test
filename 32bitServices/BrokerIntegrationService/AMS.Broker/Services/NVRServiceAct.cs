//using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using NLog;
using QL.Communication.Authentication;
using QL.Communication.Messaging;
using QL.Communication.Network;
using QL.Communication.Server;
using QL.ComponentsModel.ComponentsManagement;
using QL.Configuration;
using QL.VideoBrowser.Controllers;
using QL.VideoBrowser.Controllers.CamerasManagement;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsFileCache;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsProviders;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsServices;
using QL.VideoBrowser.Controllers.ThumbnailsCache;
using QL.VideoBrowser.Controllers.ThumbnailsProviders;
using QL.VideoBrowser.Controllers.ThumbnailsServices;
using QL.VideoBrowser.Controllers.VideoServersManagement;
using QL.VideoBrowser.Controls;
using QL.VideoBrowser.Controls.Media;
using VideoServerEntity = QL.Communication.Server.VideoServerEntity;
using QL.VideoBrowser.Controllers.MediaExport;
using QL.VideoBrowser.Controllers.CamerasManagement.MediaExport;
using System.Collections.Generic;
using System;

namespace AMS.Broker.IntegrationService.Services
{
    public class NVRServiceAct
    {
        private readonly IConfigurationManager _configurationManager;
        private ICamerasManager _camerasManager;
        private IComponentsManager _componentsManager;
        private IRecordingThumbnailsProviderFactory _recordingThumbnailsProviderFactory;
        private IServerController _serverController;
        private IVideoServersManager _videoServersManager;
        private IVideoServersModel _videoServersModel;
        private readonly IList<MediaElement> _players = new List<MediaElement>();
        private readonly IDictionary<string, Guid> _servers = new Dictionary<string, Guid>();
        /*private IRecordingThumbnailsService _thumbnailsService;
        private IRecordingThumbnailsService _thumbnailsCacheService;*/

        private IDataPartsSavingService exportDataPartSer;

        private IMediaExportService exportService;
        private string exportDir;
        private long MinFreeSpaceForVisualWarning = 314572800;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public NVRServiceAct()
        {
            try
            {
                DispatcherHelper.Initialize();
                _configurationManager = new ConfigurationManager();
                RegisterApplicationComponents();
                ResolveApplicationComponents();
            }
            catch (Exception e)
            {
                _logger.Info("NVRServiceAct NVRServiceAct() Exception:" + e.Message);
            }
        }

        public IList<MediaElement> Players
        {
            get { return _players; }
        }

        public MediaElement GetVideoPlayer()
        {
            if (Players.Count == 0)
            {
                return new MediaElement(_videoServersManager, _camerasManager);
            }
            else
            {
                var player = Players[0];
                Players.Remove(player);
                return player;
            }
        }

        public ILivePlayer GetLivePlayer()
        {
            return _componentsManager.Resolve<ILivePlayer>();
        }

        public IPlaybackPlayer GetPlayBackPlayer()
        {
            return _componentsManager.Resolve<IPlaybackPlayer>();
        }

        private void ResolveApplicationComponents()
        {
            _videoServersModel = _componentsManager.Resolve<IVideoServersModel>();
            _camerasManager = _componentsManager.Resolve<ICamerasManager>();
            _videoServersManager = _componentsManager.Resolve<IVideoServersManager>();
        }

        private void RegisterApplicationComponents()
        {
            try
            {
                _componentsManager = new ComponentsManager(_configurationManager, null, null);
                _componentsManager.Run();
                RegisterComponents();
            }
            catch (Exception ex)
            {
                _logger.Info("NVRServiceAct RegisterApplicationComponents() Exception:" + ex.Message);
                //LogManager.GetCurrentClassLogger().ErrorException(ex.Message, ex);
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
                Register<IServerControllerFactory>(new ServerControllerFactory(_componentsManager,
                                                                               TimeSpan.FromMinutes(1)));
                Register<IVideoServersModel, VideoServersModel>(null, true);
                Register<IVideoServersManager, VideoServersManager>(null, true);
                Register<ICamerasManager, CamerasManager>();

                _videoServersManager = _componentsManager.Resolve<IVideoServersManager>();
                _camerasManager = _componentsManager.Resolve<ICamerasManager>();
                _componentsManager.Resolve<IVideoServersModel>();

                // Initializing the directory for thumbnails cache.
                var thumbnailsCasheDir = Path.Combine(Path.GetTempPath(), "ThumbnailsCache");
                if (Directory.Exists(thumbnailsCasheDir) == false)
                {
                    Directory.CreateDirectory(thumbnailsCasheDir);
                }

                string strPathTemp = Storage.VideoRepository;//System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];//amit 26062017
                this.exportDir = strPathTemp + "\\Temp";
                this.exportService = new MediaExportService(_videoServersManager, new DataPartsSavingService(this.exportDir, MinFreeSpaceForVisualWarning));

                /* _thumbnailsService = new RecordingThumbnailsService(_videoServersManager);
                 _thumbnailsCacheService = new RecordingThumbnailsCacheService(thumbnailsCasheDir, 1*100);

                 _recordingThumbnailsProviderFactory = new RecordingThumbnailsProviderFactory(_thumbnailsService,
                                                                                              _thumbnailsCacheService);*/
            }
            catch (Exception ex)
            {
                _logger.Info("NVRServiceAct RegisterComponents() Exception:" + ex.Message);
                // LogManager.GetCurrentClassLogger().ErrorException(ex.Message, ex);
            }
        }

        private void Register<T1, T2>(string name = null, bool singlethon = false)
        {
            _componentsManager.RegisterType(typeof(T1), typeof(T2), name, singlethon);
        }

        private void Register<T>(object instance, string name = null)
        {
            _componentsManager.RegisterInstance(typeof(T), name, instance);
        }


        public VideoServerEntity GetServer(string ip)
        {
            return _videoServersModel.GetServers().First(s => s.Address == ip);
        }

        public IRecordingThumbnailsCacheService GetCameraThumbnailServiceCache(Guid sourceId)
        {
            /*if (_thumbnailsCacheService == null)
            {
                var thumbnailsCasheDir = Path.Combine(Path.GetTempPath(), "ThumbnailsCache");
                if (Directory.Exists(thumbnailsCasheDir) == false)
                {
                    Directory.CreateDirectory(thumbnailsCasheDir);
                }
                _thumbnailsCacheService = new RecordingThumbnailsCacheService(thumbnailsCasheDir, 1*100);
            }
            return _thumbnailsCacheService;*/

            var thumbnailsCasheDir = Path.Combine(Path.GetTempPath(), "ThumbnailsCache");
            if (Directory.Exists(thumbnailsCasheDir) == false)
            {
                Directory.CreateDirectory(thumbnailsCasheDir);
            }

            return new RecordingThumbnailsCacheService(thumbnailsCasheDir, 1 * 100, sourceId);
        }

        public IRecordingThumbnailsService GetCameraThumbnailService(Source source, DateTime startDate)
        {
            /*if (_thumbnailsService == null)
            {
                string thumbnailsCasheDir = Path.Combine(Path.GetTempPath(), "ThumbnailsCache");
                if (Directory.Exists(thumbnailsCasheDir) == false)
                {
                    Directory.CreateDirectory(thumbnailsCasheDir);
                }

                _thumbnailsService = new RecordingThumbnailsService(_videoServersManager);
            }
            return _thumbnailsService;*/

            return new RecordingThumbnailsService(_serverController, source, startDate);
        }

        public IVideoServersManager GetServerManager()
        {
            return _videoServersManager;
        }

        public IMediaExportService InitExportService()
        {
            /* string strPathTemp = System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
             this.exportDir = strPathTemp;
             return new MediaExportService(_videoServersManager, new DataPartsSavingService(this.exportDir, MinFreeSpaceForVisualWarning));*/

            return this.exportService;
        }

        public IServerController GetServerController()
        {
            return _serverController;
        }

        public ICamerasManager GetCamerasManager()
        {
            return _camerasManager;
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
                    UserName = user,// "administrator",
                    UserPassword = password,// "abc@123",
                    UserDomain = ""
                };//2020IMAGING
                _videoServersModel.AddServer(server);
                _servers.Add(ip, server.Id);
                _serverController = _videoServersManager.GetServer(server.Id);
                _serverController.ServerControllerError += (s, e) =>
                {
                    var strerror = e.Error;
                };
                _logger.Info("Server Id:" + server.Id + "," + "Server IP :" + ip.ToString());
            }
            _serverController.Timeout = new TimeSpan(0, 3, 0);
        }

        public void Dispose()
        {
            /*throw new NotImplementedException();*/
        }

        public IRecordingThumbnailsProviderFactory GetThumbnailProviderFactory()
        {
            var thumbnailsCasheDir = Path.Combine(Path.GetTempPath(), "ThumbnailsCache");
            if (Directory.Exists(thumbnailsCasheDir) == false)
            {
                Directory.CreateDirectory(thumbnailsCasheDir);
            }

            return new RecordingThumbnailsProviderFactory(GetServerManager(), thumbnailsCasheDir, 1 * 100);
        }
    }
}
