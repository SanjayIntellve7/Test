using NLog;

using System.Reactive.Linq;
using QL.Communication.Server;
using QL.ComponentsModel.ComponentsManagement;
using QL.Configuration;
using QL.Logging;
using QL.VideoBrowser.Controllers;
using QL.VideoBrowser.Controllers.CamerasManagement;
using QL.VideoBrowser.Controllers.CamerasManagement.MediaExport;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsProviders;
using QL.VideoBrowser.Controllers.MediaExport;
using QL.VideoBrowser.Controls.Media;

using System;
//using System.Windows.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using QL.Communication.Authentication;
using QL.Communication.Messaging;
using QL.Communication.Messaging.Messages;
using QL.Communication.Network;
using QL.Communication.Server;

using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;
using QL.VideoBrowser.Controllers.CamerasManagement.ThumbnailsServices;
using QL.VideoBrowser.Controllers.VideoServersManagement;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.IntegrationService.Services
{
    class AlertMediaintegration
    {
        private static object _lock = new object();
        public NVRServiceAct _nvrServices;
        private readonly IConfigurationManager _configurationManager;
        private ICamerasManager _camerasManager;
        private IComponentsManager _componentsManager;
        private IVideoServersModel _serversModel;
        private IVideoServersManager _videoServersManager;
        private IVideoServersModel _videoServersModel;
        private IServerController _serverId;
        private byte[] _playBackThumb;
        private long _streamId;

        private IDataPartsSavingService exportDataSer;
        private IMediaExportService exportService;
        private string exportDir;
        private long MinFreeSpaceForVisualWarning = 314572800;
        private DateTime exportStartTime;
        private DateTime exportStopTime;
        private Guid cameraId;
        private Guid serverId;
        public bool IsCompleted;
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        //private readonly DispatcherTimer _thumbTimer;

        public AlertMediaintegration(NVRServiceAct nvrService)
        {
            _nvrServices = nvrService;
            string strPathTemp = Storage.VideoRepository;  // System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];

            this.exportService = _nvrServices.InitExportService();

            IsCompleted = false;
        }

        private void RegisterApplicationComponents(IConfigurationManager configurationManager)
        {
            try
            {
                _componentsManager = new ComponentsManager(_configurationManager, null, null);
                _componentsManager.Run();
                RegisterComponents();
            }
            catch (Exception ex)
            {
                _logger.Info("AlertMediaintegration RegisterApplicationComponents() Exception" + ex.Message);
                string Message = "AlertMediaintegration-RegisterApplicationComponents -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                string tmp;
                tmp = ex.Message;
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

        private void RegisterComponents()
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

            this._videoServersManager = _componentsManager.Resolve<IVideoServersManager>();
            _camerasManager = _componentsManager.Resolve<ICamerasManager>();
            _serversModel = _componentsManager.Resolve<IVideoServersModel>();

            // Initializing the directory for thumbnails cache.
            string thumbnailsCasheDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                     "ThumbnailsCache");
            if (Directory.Exists(thumbnailsCasheDir) == false)
            {
                Directory.CreateDirectory(thumbnailsCasheDir);
            }

            this.exportService = new MediaExportService(this._videoServersManager, new DataPartsSavingService(this.exportDir, MinFreeSpaceForVisualWarning));

        }
        private void ResolveApplicationComponents()
        {
            _videoServersModel = _componentsManager.Resolve<IVideoServersModel>();
            //_camerasManager = _componentsManager.Resolve<ICamerasManager>();
            //_videoServersManager = _componentsManager.Resolve<IVideoServersManager>();
        }

        //
        private void Export(string strfileName,string sAlertID)
        {
            // To cancel export, just invoke "Dispose" method on exportSubscription.
            string Message = "AlertMediaintegration-Export -- start -- strfileName= " + strfileName + "-!-sAlertID:" + sAlertID;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            string strExPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
            strExPathTemp = strExPathTemp + "\\Temp";
            IDisposable exportSubscription = this.exportService.Export(serverId, this.cameraId, this.exportStartTime, this.exportStopTime, strExPathTemp)
                //.ObserveOn(new DispatcherSynchronizationContext())                
                .Subscribe(
                ok =>
                {                    
                    string stageDescription = ok.Stage == MediaExportProgressStage.ExportProgress ? "preparing data" : "saving results";
                    string progress = ok.Progress != null ? ok.Progress : string.Empty;                   
                },
                error =>
                {
                    this.HandleExportError(error);
                    _logger.Info("Server Error:" + error);
                    IsCompleted = true;
                },
                () =>
                {                     
                    // If we are here, export process was successfully finished.
                    //Rename Files and move    asf File                    
                    string strPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                    string strVideoFile = strPathTemp + "\\Temp";
                    string strSearchParam = "*.asf";
                    string[] files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                    int numFiles = files.Length;
                    for (int i = 0; i < numFiles; i++)
                    {
                        string file = files[i].ToString();
                        try
                        {
                            string strDestVideoFile=  strPathTemp + "\\AlertPlayBack_"+ sAlertID + ".asf";
                            if (File.Exists(strDestVideoFile))
                            {
                                File.Delete(strDestVideoFile);
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                            else
                            {
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.Info("AlertMediaintegration Export() Exception" + e.Message);
                            string Messagea = "AlertMediaintegration-Export -- Exception = " + e.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Messagea);//jatin
                        }
                    }

                    //.p7m                    
                    strVideoFile = strPathTemp + "\\Temp";
                    strSearchParam = "*.p7m";
                    files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                    numFiles = files.Length;
                    for (int i = 0; i < numFiles; i++)
                    {
                        string file = files[i].ToString();
                        try
                        {
                            string strDestVideoFile = strPathTemp + "\\AlertPlayBack_" + sAlertID + ".p7m";
                            if (File.Exists(strDestVideoFile))
                            {
                                File.Delete(strDestVideoFile);
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                            else
                            {
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.Info("AlertMediaintegration Export() Exception" + e.Message);
                            string Messagea = "AlertMediaintegration-Export -- Exception 1= " + e.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Messagea);//jatin
                        }
                    }
                    //
                    strVideoFile = strPathTemp + "\\Temp";
                    strSearchParam = "*.smi";
                    files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                    numFiles = files.Length;
                    for (int i = 0; i < numFiles; i++)
                    {
                        string file = files[i].ToString();
                        try
                        {
                            string strDestVideoFile = strPathTemp + "\\AlertPlayBack_" + sAlertID + ".smi";
                            if (File.Exists(strDestVideoFile))
                            {
                                File.Delete(strDestVideoFile);
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                            else
                            {
                                System.IO.File.Move(file, strDestVideoFile);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("AlertMediaintegration Export() Exception" + ex.Message);
                            string Messagea = "AlertMediaintegration-Export -- Exception 2 = " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Messagea);//jatin
                        }
                    }
                    //Delete Ticket here
                    ////Archive File here
                    string strDest = "";
                    string strFileName = "";
                    strDest = strfileName.Substring(0, strfileName.LastIndexOf("\\"));
                    strFileName = strfileName.Substring(strfileName.LastIndexOf("\\"));
                    strDest = strDest + "\\ArchiveTickets" + strFileName;
                    //check file exist ,if Yyes delete the new one
                    if (File.Exists(strDest))
                    {
                        File.Delete(strDest);
                        System.IO.File.Move(strfileName, strDest);
                    }
                    else
                    {
                        System.IO.File.Move(strfileName, strDest);                       
                    }

                    IsCompleted = true;
                });
        }

        ////Get IR Export
        private void ExportIRVideo(string strfileName, string sIRIdID, string sTblId)
        {
            try
            {
                string Message = "AlertMediaintegration-ExportIRVideo -- start -- strfileName= " + strfileName + "-!-sIRIdID:" + sIRIdID;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                string strExPathTemp = Storage.VideoRepository; //System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                strExPathTemp = strExPathTemp + "\\Temp";
                // To cancel export, just invoke "Dispose" method on exportSubscription.
                IDisposable exportSubscription = this.exportService.Export(serverId, this.cameraId, this.exportStartTime, this.exportStopTime, strExPathTemp)
                    //.ObserveOn(new DispatcherSynchronizationContext())                
                    .Subscribe(
                    ok =>
                    {
                        string stageDescription = ok.Stage == MediaExportProgressStage.ExportProgress ? "preparing data" : "saving results";
                        string progress = ok.Progress != null ? ok.Progress : string.Empty;
                    },
                    error =>
                    {
                        this.HandleExportError(error);
                        _logger.Info("Server Error:" + error);
                        IsCompleted = true;
                    },
                    () =>
                    {
                        // If we are here, export process was successfully finished.
                        //Rename Files and move    asf File                    
                        string strPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                        string strVideoFile = strPathTemp + "\\Temp";
                        string strSearchParam = "*.asf";
                        string[] files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        int numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\IRPlayBack_" + sTblId + "_" + sIRIdID + ".asf";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration ExportIRVideo() Exception" + e.Message);
                            }
                        }

                        //.p7m                    
                        strVideoFile = strPathTemp + "\\Temp";
                        strSearchParam = "*.p7m";
                        files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\IRPlayBack_" + sTblId + "_" + sIRIdID + ".p7m";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration ExportIRVideo() Exception" + e.Message);
                            }
                        }
                        //
                        strVideoFile = strPathTemp + "\\Temp";
                        strSearchParam = "*.smi";
                        files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\IRPlayBack_" + sTblId + "_" + sIRIdID + ".smi";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration ExportIRVideo() Exception" + e.Message);
                            }
                        }
                        //Delete Ticket here
                        ////Archive File here
                        string strDest = "";
                        string strFileName = "";
                        strDest = strfileName.Substring(0, strfileName.LastIndexOf("\\"));
                        strFileName = strfileName.Substring(strfileName.LastIndexOf("\\"));
                        strDest = strDest + "\\ArchiveTickets" + strFileName;
                        //check file exist ,if Yyes delete the new one
                        if (File.Exists(strDest))
                        {
                            File.Delete(strDest);
                            System.IO.File.Move(strfileName, strDest);
                        }
                        else
                        {
                            System.IO.File.Move(strfileName, strDest);
                        }

                        IsCompleted = true;
                    });
            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration ExportIRVideo() Exception" + e.Message);
                string Message = "AlertMediaintegration ExportIRVideo() -- Exception = " + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        ////Get Bookmark Export
        private void ExportBookmarkVideo(string strfileName, string sBkID, string sTblId)
        {
            try
            {
                string Message = "AlertMediaintegration-ExportIRVideo -- start -- strfileName= " + strfileName + "-!-sBkID:" + sBkID;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                string strExPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                strExPathTemp = strExPathTemp + "\\Temp";
                // To cancel export, just invoke "Dispose" method on exportSubscription.
                IDisposable exportSubscription = this.exportService.Export(serverId, this.cameraId, this.exportStartTime, this.exportStopTime, strExPathTemp)
                    //.ObserveOn(new DispatcherSynchronizationContext())                
                    .Subscribe(
                    ok =>
                    {
                        string stageDescription = ok.Stage == MediaExportProgressStage.ExportProgress ? "preparing data" : "saving results";
                        string progress = ok.Progress != null ? ok.Progress : string.Empty;
                    },
                    error =>
                    {
                        this.HandleExportError(error);
                        _logger.Info("Server Error:" + error);
                        IsCompleted = true;
                    },
                    () =>
                    {
                        // If we are here, export process was successfully finished.
                        //Rename Files and move    asf File                    
                        string strPathTemp = Storage.VideoRepository;// System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
                        string strVideoFile = strPathTemp + "\\Temp";
                        string strSearchParam = "*.asf";
                        string[] files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        int numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\BookmarkPlayBack_" + sTblId + "_" + sBkID + ".asf";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration BookMarkVideo() Exception" + e.Message);
                            }
                        }

                        //.p7m                    
                        strVideoFile = strPathTemp + "\\Temp";
                        strSearchParam = "*.p7m";
                        files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\BookmarkPlayBack_" + sTblId + "_" + sBkID + ".p7m";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration BookMarkVideo() Exception" + e.Message);
                            }
                        }
                        //
                        strVideoFile = strPathTemp + "\\Temp";
                        strSearchParam = "*.smi";
                        files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
                        numFiles = files.Length;
                        for (int i = 0; i < numFiles; i++)
                        {
                            string file = files[i].ToString();
                            try
                            {
                                string strDestVideoFile = strPathTemp + "\\BookmarkPlayBack_" + sTblId + "_" + sBkID + ".smi";
                                if (File.Exists(strDestVideoFile))
                                {
                                    File.Delete(strDestVideoFile);
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                                else
                                {
                                    System.IO.File.Move(file, strDestVideoFile);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Info("AlertMediaintegration BookMarkVideo() Exception" + e.Message);
                            }
                        }
                        //Delete Ticket here
                        ////Archive File here
                        string strDest = "";
                        string strFileName = "";
                        strDest = strfileName.Substring(0, strfileName.LastIndexOf("\\"));
                        strFileName = strfileName.Substring(strfileName.LastIndexOf("\\"));
                        strDest = strDest + "\\ArchiveTickets" + strFileName;
                        //check file exist ,if Yyes delete the new one
                        if (File.Exists(strDest))
                        {
                            File.Delete(strDest);
                            System.IO.File.Move(strfileName, strDest);
                        }
                        else
                        {
                            System.IO.File.Move(strfileName, strDest);
                        }

                        IsCompleted = true;
                    });
            }
            catch (Exception ex)
            {
                string Message = "AlertMediaintegration-BookMarkVideo --Exception" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            }
        }


        private void HandleExportCheckError(Exception ex)
        {
            if (ex is ArgumentException)
            {
                //MessageBox.Show(ex.Message);
                return;
            }

            if (ex is MediaExportException)
            {
                MediaExportException exportEx = (MediaExportException)ex;
                Console.WriteLine(string.Format("Error occurred when validating export input data: {0}", exportEx.Error),
                    exportEx.InnerException != null ? exportEx.InnerException.ToString() : string.Empty);
            }
        }

        private void HandleExportError(Exception ex)
        {

            MediaExportException exportEx = (MediaExportException)ex;
            Console.WriteLine(string.Format("Error occurred when exporting data: {0}", exportEx.Error),
                exportEx.InnerException != null ? exportEx.InnerException.ToString() : string.Empty);
        }
        //
        private void ProceedExport(SavingPossibilityValidationResult validationResult, string strfileName,string sAlertID)
        {
            switch (validationResult.Result)
            {
                case FreeSpaceValidationResult.EnoughFreeSpace:
                    if (validationResult.SavingDataSize == 0)
                    {
                        IsCompleted = true;
                        //MessageBox.Show(string.Format("No video was found for the specified time interval."), string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    Export(strfileName, sAlertID);
                    break;
                case FreeSpaceValidationResult.NotEnoughFreeSpace:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Not enough free space at {0} for saving exported data.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.DestinationAccessError:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Failed access {0}.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.LessThanThresholdValue:
                    // If we are here, less than <see cref="MinFreeSpaceForVisualWarning"> amount of free disc space at the export dir partition will left.
                    string estimatedDataSize = (validationResult.SavingDataSize / 1048576f).ToString("#####.#");
                    string remainSize = validationResult.AdditionalData == null ?
                        string.Empty :
                        (((long)validationResult.AdditionalData) / 1048576f).ToString("#####.#");

                    //string message = string.Format("After saving {0} MB. export data, only {1} MB. will left at the partition of specified destination folder. Continue?", estimatedDataSize, remainSize);
                    //if (MessageBox.Show(message, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{
                    Export(strfileName, sAlertID);
                    //}

                    break;
            }
        }
        //Get IR Process
        private void ProceedIRExport(SavingPossibilityValidationResult validationResult, string strfileName, string sIRIdID, string sTblId)
        {
            switch (validationResult.Result)
            {
                case FreeSpaceValidationResult.EnoughFreeSpace:
                    if (validationResult.SavingDataSize == 0)
                    {
                        IsCompleted = true;
                        //MessageBox.Show(string.Format("No video was found for the specified time interval."), string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    ExportIRVideo(strfileName, sIRIdID,sTblId);
                    break;
                case FreeSpaceValidationResult.NotEnoughFreeSpace:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Not enough free space at {0} for saving exported data.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.DestinationAccessError:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Failed access {0}.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.LessThanThresholdValue:
                    // If we are here, less than <see cref="MinFreeSpaceForVisualWarning"> amount of free disc space at the export dir partition will left.
                    string estimatedDataSize = (validationResult.SavingDataSize / 1048576f).ToString("#####.#");
                    string remainSize = validationResult.AdditionalData == null ?
                        string.Empty :
                        (((long)validationResult.AdditionalData) / 1048576f).ToString("#####.#");

                    //string message = string.Format("After saving {0} MB. export data, only {1} MB. will left at the partition of specified destination folder. Continue?", estimatedDataSize, remainSize);
                    //if (MessageBox.Show(message, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{
                    ExportIRVideo(strfileName, sIRIdID, sTblId);
                    //}

                    break;
            }
        }

        //Get IR Process
        private void ProceedBookmarkExport(SavingPossibilityValidationResult validationResult, string strfileName, string sBkID, string sTblId)
        {
            switch (validationResult.Result)
            {
                case FreeSpaceValidationResult.EnoughFreeSpace:
                    if (validationResult.SavingDataSize == 0)
                    {
                        IsCompleted = true;
                        //MessageBox.Show(string.Format("No video was found for the specified time interval."), string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    ExportIRVideo(strfileName, sBkID, sTblId);
                    break;
                case FreeSpaceValidationResult.NotEnoughFreeSpace:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Not enough free space at {0} for saving exported data.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.DestinationAccessError:
                    IsCompleted = true;
                    //MessageBox.Show(string.Format("Failed access {0}.", this.exportDir), string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case FreeSpaceValidationResult.LessThanThresholdValue:
                    // If we are here, less than <see cref="MinFreeSpaceForVisualWarning"> amount of free disc space at the export dir partition will left.
                    string estimatedDataSize = (validationResult.SavingDataSize / 1048576f).ToString("#####.#");
                    string remainSize = validationResult.AdditionalData == null ?
                        string.Empty :
                        (((long)validationResult.AdditionalData) / 1048576f).ToString("#####.#");

                    //string message = string.Format("After saving {0} MB. export data, only {1} MB. will left at the partition of specified destination folder. Continue?", estimatedDataSize, remainSize);
                    //if (MessageBox.Show(message, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{
                    ExportBookmarkVideo(strfileName, sBkID, sTblId);
                    //}

                    break;
            }
        }
        //GetIR Playback
        public void GetIRPlayBack(string sIRId,string sTblId, string sWidth, string sHeight, string strNvrIp, string strUser, string strPass, string cameraGuid, string dt_dateTime, string strFileName)
        {
            try
            {
                this.IsCompleted = false;
                int nWidth = Int32.Parse(sWidth);
                int nHeight = Int32.Parse(sHeight);
                long nIRId = long.Parse(sIRId);
                long nTblId = long.Parse(sTblId);
                DateTime dt_Start = Convert.ToDateTime(dt_dateTime);
                dt_Start = dt_Start.AddSeconds(-30);
                DateTime dt_End = dt_Start.AddSeconds(30);

                this.exportStartTime = dt_Start;
                this.exportStopTime = dt_End;

                // _nvrServices = new NVRServices();

                _nvrServices.AddServer(
                    strNvrIp,
                    1518,
                    strUser,
                    strPass,
                    ""
                    );

                if (_nvrServices.GetServerController().State == ServerControllerState.Connected)
                {
                    GetIRPlayBackNow(sIRId,sTblId, dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, strFileName);
                }
                else
                {

                    _nvrServices.GetServerController().Connected += (sender, args) => GetIRPlayBackNow(sIRId, sTblId, dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, strFileName); ;
                    _nvrServices.GetServerController().ServerControllerError +=
                        (sender, args) =>
                        {
                            LogManager.GetCurrentClassLogger().Error(args.Error.Message);
                            _logger.Info("Server Id:" + args.ServerId);
                        };
                }

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetIRPlayback() Exception" + e.Message);
            }
        }

        //GetBookmark Playback
        public void GetBookmarkPlayBack(string sDevId, string sTblId, string sWidth, string sHeight, string strNvrIp, string strUser, string strPass, string cameraGuid, string dt_dateTime, string strFileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetBookmarkPlayBack -- start -- sDevId= " + sDevId + "-!-strFileName:" + strFileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                this.IsCompleted = false;
                int nWidth = Int32.Parse(sWidth);
                int nHeight = Int32.Parse(sHeight);
                long nIRId = long.Parse(sDevId);
                long nTblId = long.Parse(sTblId);
                DateTime dt_Start = Convert.ToDateTime(dt_dateTime);
                dt_Start = dt_Start.AddSeconds(-30);
                DateTime dt_End = dt_Start.AddMinutes(30);

                this.exportStartTime = dt_Start;
                this.exportStopTime = dt_End;

                // _nvrServices = new NVRServices();

                _nvrServices.AddServer(
                    strNvrIp,
                    1518,
                    strUser,
                    strPass,
                    ""
                    );

                if (_nvrServices.GetServerController().State == ServerControllerState.Connected)
                {
                    GetBookmarkPlayBackNow(sDevId, sTblId, dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, strFileName);
                }
                else
                {

                    _nvrServices.GetServerController().Connected += (sender, args) => GetBookmarkPlayBackNow(sDevId, sTblId, dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, strFileName); ;
                    _nvrServices.GetServerController().ServerControllerError +=
                        (sender, args) =>
                        {
                            LogManager.GetCurrentClassLogger().Error(args.Error.Message);
                            _logger.Info("Server Id:" + args.ServerId);
                        };
                }

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetBookmarkPlayback() Exception" + e.Message);

                string Message = "AlertMediaintegration-GetBookmarkPlayback -- sException" + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        //Get playback Video
        public void GetAlertPlayBack(string sAlertID, string sWidth, string sHeight, string strNvrIp, string strUser, string strPass, string cameraGuid, string dt_dateTime, string strFileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetAlertPlayBack -- start -- sAlertID= " + sAlertID + "-!-strFileName:" + strFileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                int nWidth = Int32.Parse(sWidth);
                int nHeight = Int32.Parse(sHeight);
                long nAlertID = long.Parse(sAlertID);
                DateTime dt_Start = Convert.ToDateTime(dt_dateTime);
                dt_Start = dt_Start.AddSeconds(-30);
                DateTime dt_End = dt_Start.AddSeconds(30);

                this.exportStartTime = dt_Start;
                this.exportStopTime = dt_End;

               // _nvrServices = new NVRServices();

                _nvrServices.AddServer(
                    strNvrIp,
                    1518,
                    strUser,
                    strPass,
                    ""
                    );

                if (_nvrServices.GetServerController().State == ServerControllerState.Connected)
                {
                    GetPlayBack( sAlertID,dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, nAlertID, strFileName);
                }
                else
                {

                    _nvrServices.GetServerController().Connected += (sender, args) => GetPlayBack(sAlertID, dt_Start, cameraGuid, strNvrIp, nWidth, nHeight, nAlertID, strFileName);
                    _nvrServices.GetServerController().ServerControllerError +=
                        (sender, args) =>
                        {
                            LogManager.GetCurrentClassLogger().Error(args.Error.Message);
                            _logger.Info("Server Id:" + args.ServerId);
                        };
                }

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetAlertPlayBack() Exception" + e.Message);
                string Message = "AlertMediaintegration-GetAlertPlayBack -- Exception" + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        ////
        public void GetPlayBack(string sAlertID,DateTime playbackFrom, string _sourceId, string strNvrIp, int nWidth, int nHeight, long _alertId, string strfileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetPlayBack -- start -- sAlertID= " + sAlertID + "-!-strfileName:" + strfileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                IsCompleted = false;

                cameraId =new Guid( _sourceId);

                var serverId = _nvrServices.GetServer(strNvrIp).Id;
                this.serverId = serverId;
                              
                // To cancel export possibility validation, just invoke "Dispose" method on exportCheckSubscription.
                //this.exportService.DefaultExportDestination
                IDisposable exportCheckSubscription = this.exportService.CheckExportPossibility(serverId, cameraId, this.exportStartTime, this.exportStopTime, this.exportDir)
                    //.ObserveOn(new DispatcherSynchronizationContext())                   
                    .Subscribe(
                    ok =>
                    {
                        this.ProceedExport(ok,strfileName,sAlertID);
                        
                    },
                    error =>
                    {
                        this.HandleExportCheckError(error);
                        IsCompleted = true;
                    });

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetPlayBack() Exception" + e.Message);
                string Message = "AlertMediaintegration-GetPlayBack -- Exception" + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        //Get IR Playback
        public void GetIRPlayBackNow(string sIRIdID, string sTblId, DateTime playbackFrom, string _sourceId, string strNvrIp, int nWidth, int nHeight, string strfileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetPlayBack -- start -- sIRIdID= " + sIRIdID + "-!-strfileName:" + strfileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                IsCompleted = false;

                cameraId = new Guid(_sourceId);

                var serverId = _nvrServices.GetServer(strNvrIp).Id;
                this.serverId = serverId;

                // To cancel export possibility validation, just invoke "Dispose" method on exportCheckSubscription.
                //this.exportService.DefaultExportDestination
                IDisposable exportCheckSubscription = this.exportService.CheckExportPossibility(serverId, cameraId, this.exportStartTime, this.exportStopTime, this.exportDir)
                    //.ObserveOn(new DispatcherSynchronizationContext())                   
                    .Subscribe(
                    ok =>
                    {
                        this.ProceedIRExport(ok, strfileName, sIRIdID,sTblId);

                    },
                    error =>
                    {
                        this.HandleExportCheckError(error);
                        IsCompleted = true;
                    });

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetIRPlayBackNow() Exception" + e.Message);
                string Message = "AlertMediaintegration-GetIRPlayBackNow -- Exception" + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        //Get IR Playback
        public void GetBookmarkPlayBackNow(string sBkID, string sTblId, DateTime playbackFrom, string _sourceId, string strNvrIp, int nWidth, int nHeight, string strfileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetBookmarkPlayBackNow -- start -- sBkID= " + sBkID + "-!-strfileName:" + strfileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                IsCompleted = false;

                cameraId = new Guid(_sourceId);

                var serverId = _nvrServices.GetServer(strNvrIp).Id;
                this.serverId = serverId;

                // To cancel export possibility validation, just invoke "Dispose" method on exportCheckSubscription.
                //this.exportService.DefaultExportDestination
                IDisposable exportCheckSubscription = this.exportService.CheckExportPossibility(serverId, cameraId, this.exportStartTime, this.exportStopTime, this.exportDir)
                    //.ObserveOn(new DispatcherSynchronizationContext())                   
                    .Subscribe(
                    ok =>
                    {
                        this.ProceedBookmarkExport(ok, strfileName, sBkID, sTblId);

                    },
                    error =>
                    {
                        this.HandleExportCheckError(error);
                        IsCompleted = true;
                    });

            }
            catch (Exception e)
            {
                _logger.Info("AlertMediaintegration GetBookmarkPlayBackNow() Exception" + e.Message);
                string Message = "AlertMediaintegration-GetBookmarkPlayBackNow -- Exception" + e.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        ////Get Images
        public void GetAlertImage(string sAlertID, string sWidth, string sHeight, string strNvrIp, string strUser, string strPass, string cameraGuid, string dt_dateTime, string strFileName)
        {
            try
            {
                string Message = "AlertMediaintegration-GetAlertImage -- start -- sAlertID= " + sAlertID + "-!-strFileName:" + strFileName;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

                DateTime _dtAlertTime = Convert.ToDateTime(dt_dateTime);//DateTime.Now.ToLocalTime().AddMinutes(-1);
                int nWidth = Int32.Parse(sWidth);
                int nHeight = Int32.Parse(sHeight);
                long nAlertID = long.Parse(sAlertID);
                /*string strNvrIp = "192.168.0.70";
                string strUser = "DellDesktop3";
                string strPass = "12345";
                string cameraGuid = "AD4F4692-007F-46A3-8D1A-E9FC9D0179F7";
                */

                _nvrServices.AddServer(
                    strNvrIp,
                    1518,
                    strUser,
                    strPass,
                    ""
                    );


                if (_nvrServices.GetServerController().State == ServerControllerState.Connected)
                {
                    GetPlaybackThumbnail(_dtAlertTime, new Guid(cameraGuid), strNvrIp, nWidth, nHeight, nAlertID, strFileName);
                }
                else
                {

                    _nvrServices.GetServerController().Connected += (sender, args) => GetPlaybackThumbnail(_dtAlertTime, new Guid(cameraGuid), strNvrIp, nWidth, nHeight, nAlertID, strFileName);
                    _nvrServices.GetServerController().ServerControllerError +=
                        (sender, args) =>
                            {
                            LogManager.GetCurrentClassLogger().Error(args.Error.Message);
                            _logger.Info("Server Id:"+args.ServerId);
                           

                            };


                }
            }
            catch (Exception ec)
            {

                _logger.Info("AlertMediaintegration GetAlertImage() Exception" + ec.Message);
                string Message = "AlertMediaintegration-GetAlertImage -- Exception" + ec.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        public void SaveImaeg(byte[] imgFrame, long nAlertID, string strfileName)
        {
            string Message = "AlertMediaintegration-SaveImaeg -- start -- nAlertID= " + nAlertID + "-!-strFileName:" + strfileName;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

            string strPathTemp = Storage.ImageRepository;//System.Configuration.ConfigurationManager.AppSettings["ImageRepository"]; //amit 26062017
            string modelImagePath = strPathTemp + "\\AlertTimeImage_" + nAlertID.ToString() + ".jpg";
            try
            {
                //save image to drive
                MemoryStream ms = new MemoryStream(imgFrame);
                System.Drawing.Image i = System.Drawing.Image.FromStream(ms);
                i.Save(modelImagePath);

                ////Archive File here
                string strDest = "";
                string strFileName = "";
                strDest = strfileName.Substring(0, strfileName.LastIndexOf("\\"));
                strFileName = strfileName.Substring(strfileName.LastIndexOf("\\"));
                strDest = strDest + "\\ArchiveTickets" + strFileName;
                //check file exist ,if Yyes delete the new one
                if (File.Exists(strDest))
                {
                    File.Delete(strDest);
                    System.IO.File.Move(strfileName, strDest);
                }
                else
                {
                    System.IO.File.Move(strfileName, strDest);
                }
            }
            catch (Exception ex)
            {
                _logger.Info("AlertMediaintegration SaveImaeg() Exception" + ex.Message);
                string Message1 = "AlertMediaintegration-SaveImaeg -- Exception" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
            }
        }

        private void GetPlaybackThumbnail(DateTime playbackFrom, Guid sourceId, string strNvrIp, int nWidth, int nHeight, long _alertId, string strfileName)
        {
            string Message = "AlertMediaintegration-GetPlaybackThumbnail -- start -- strNvrIp= " + strNvrIp + "-!-strFileName:" + strfileName;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            var createStreamRequest = new CreatePlaybackStreamRequest
            {
                StartTime = playbackFrom.ToUniversalTime().AddMinutes(-1),
                EndTime = playbackFrom.ToUniversalTime().AddMinutes(2),
                SourceId = sourceId
            };

            var serverId = _nvrServices.GetServer(strNvrIp).Id;
            var server =
                _nvrServices.GetServerManager().GetServer(serverId);

            var timestamps = new List<DateTime>
                {
                    playbackFrom.ToUniversalTime(),
                };

            var source = new Source(serverId, sourceId, false);
            var thumbService = new RecordingThumbnailsService(server, source, timestamps[0]);
            thumbService.GetRecordingThumbnails(nWidth, nHeight, timestamps).Subscribe(
                    thumbnail =>
                    {
                        // Will be executed per each thumbnail, i.e. 6 times in this case
                        if (thumbnail.Thumbnail != null)
                        {
                            SaveImaeg(thumbnail.Thumbnail, _alertId, strfileName);
                        }
                    },
                    completed =>
                    {
                        // All requested thumbnails are received

                        // Don't forget to dispose of the thumbService as soon as you know you won't need any other thumbnails for this source.
                        thumbService.Dispose();
                    });

            /*server.SendAndGetResponseAsObservable<CreatePlaybackStreamResponse>(createStreamRequest).Subscribe(
                stream =>
                {
                    _streamId = stream.StreamId;

                    var source = new Source(serverId, sourceId, false);
                    _nvrServices.GetCameraThumbnailService(source, createStreamRequest.StartTime)
                                .GetRecordingThumbnails(nWidth, nHeight, timestamps)
                                .Subscribe(
                                    thumbnail =>
                                    server.SendAndGetResponseAsObservable<EmptyMessage>(new ClosePlaybackStream
                                    {
                                        StreamId = _streamId
                                    }).Subscribe(
                                            success =>
                                            {
                                                if (thumbnail.Thumbnail != null)
                                                {
                                                    SaveImaeg(thumbnail.Thumbnail,_alertId,strfileName);
                                                }
                                            },
                                            error =>
                                            {
                                                int i = 0;
                                            }),
                                    completed =>
                                    {
                                        int u = 0;
                                    });
                },
                error =>
                {
                    int y = 0;
                });*/

        }

    }
}
