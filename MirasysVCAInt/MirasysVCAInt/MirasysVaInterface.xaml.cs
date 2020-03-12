using AMS.Broker.Contracts.DTO;
using Mirasys.Clients.Gateway.SDK.Core;
using Mirasys.Clients.Gateway.SDK.Events;
using Mirasys.Clients.Gateway.SDK.Recorder.Alarm;
using Mirasys.Clients.Gateway.SDK.Recorder.Profile;
using Mirasys.Clients.Gateway.SDK.Recorder.RecorderEvent;
using Mirasys.Clients.Gateway.SDK.Recorder.Streaming;
using Mirasys.Clients.Gateway.SDK.Utils;
using MirasysVCAInt.Helpers;
using MirasysVCAInt.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MirasysVCAInt
{
    /// <summary>
    /// Interaction logic for MirasysVaInterface.xaml
    /// </summary>
    public partial class MirasysVaInterface : UserControl,IDisposable
    {
        private static  string TestSDKApplicationCode ="";
        private static  string MirasysHostIP = "";
        private static  string MirasysHostPort = "";
        private static  string MirasysHostUserName = "";
        private static  string MirasysHostPassword = "";

        private static string PublicApiUrl = "";
        private static string LicenseKey = "";

        private Dictionary<System.Windows.Forms.CheckBox, RecorderEventType> _recorderEventMap;
        private System.Windows.Forms.CheckBox _boxCameraStateEvent;
        private System.Windows.Forms.CheckBox _boxIoStateEvent;
        private System.Windows.Forms.CheckBox _boxVideoMotionEvent;
        private System.Windows.Forms.CheckBox _boxAlarmEvent;
        private System.Windows.Forms.ComboBox _comboBoxProfileNames;

        public SessionContext session = null;
        private GatewayConnection _connection;
        public AlarmService _aAlarmService = null;
        public MainWindow MainWindow = null;

        HttpClient _httpClient;

        public MirasysVaInterface(string _TestSDKApplicationCode, string _MirasysHostIP, string _MirasysHostPort, string _MirasysHostUserName, string _MirasysHostPassword,string _PublicApiUrl,string _LicenseKey, MainWindow _MainWindow)
        {
            InitializeComponent();

            TestSDKApplicationCode = _TestSDKApplicationCode;
            MirasysHostIP = _MirasysHostIP;
            MirasysHostPort = _MirasysHostPort;
            MirasysHostUserName = _MirasysHostUserName;
            MirasysHostPassword = _MirasysHostPassword;
            PublicApiUrl = _PublicApiUrl;
            LicenseKey = _LicenseKey;

            MainWindow = _MainWindow;
            try
            {
                _recorderEventMap = new Dictionary<System.Windows.Forms.CheckBox, RecorderEventType>();
                _boxCameraStateEvent = new System.Windows.Forms.CheckBox();
                _boxCameraStateEvent.Checked = true;
                _recorderEventMap[_boxCameraStateEvent] = RecorderEventType.CameraState;
                _boxIoStateEvent = new System.Windows.Forms.CheckBox();
                _boxIoStateEvent.Checked = true;
                _recorderEventMap[_boxIoStateEvent] = RecorderEventType.IOState;
                _boxAlarmEvent = new System.Windows.Forms.CheckBox();
                _boxAlarmEvent.Checked = true;
                _recorderEventMap[_boxAlarmEvent] = RecorderEventType.Alarm;
                _boxVideoMotionEvent = new System.Windows.Forms.CheckBox();
                _boxVideoMotionEvent.Checked = true;
                _recorderEventMap[_boxVideoMotionEvent] = RecorderEventType.VideoMotion;

                _comboBoxProfileNames = new System.Windows.Forms.ComboBox();
                _comboBoxProfileNames.SelectedIndexChanged += _comboBoxProfileNames_SelectedIndexChanged;
                myhost.Child = _comboBoxProfileNames;
                this.Loaded += MirasysVaInterface_Loaded;

                MirasyInterfaceService.Initialise(this);
               
            }
            catch (Exception ex)
            { 
            }
        }

        void MirasysVaInterface_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SSLValidator.OverrideValidation();
                Connect();


                //  DateTime _datetime = DateTime.Parse(strAlarmDateTime);

                //string strDateTime = DateTime.Now.AddMinutes(-5).ToUniversalTime().ToString("O");

                //var _img = GetImage("b42d6cf5-313d-4ff8-b49d-74c2e91124cd", strDateTime);

                //byte[] jpegBytes = Convert.FromBase64String(_img);

                //CreateVaAlert("Reception_222", "linecross", "", jpegBytes);
            }
            catch (Exception ex)
            {
            }
        }

        public void Connect()
        {
            try
            {

                InsertLog.AddLog("MirasysVCAInterfaceService Connect(): Start");

                if (_connection != null)
                {
                    _connection.ConnectionEvent -= new EventHandler<ConnectionEventArgs>(OnConnectionEvent);       
                    _connection.Dispose();
                    _connection = null;
                }
                _connection = new GatewayConnection(MirasysHostIP, Convert.ToInt32(MirasysHostPort), MirasysHostUserName, MirasysHostPassword, TestSDKApplicationCode);
                _connection.ConnectionEvent += new EventHandler<ConnectionEventArgs>(OnConnectionEvent);
                session = _connection.SessionContext;
                session.ErrorHandler.SessionExceptionThrown += new EventHandler<Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs>(OnExceptionThrown); ;//ErrorHandler_SessionExceptionThrown;
                session.RequestValidation += new EventHandler<RequestValidationEventArgs>(OnRequestValidation);
                session.ProfileService.ProfileEventReceived += new EventHandler<ProfileEventArgs>(OnProfileEventReceived);
                session.ProfileService.UserStatusChanged += new EventHandler<AuthenticationEventArgs>(OnUserStatusChanged);

                //session.RecorderEventService.RecorderEventReceived += new EventHandler<RecorderEventArgs>(OnRecorderEventReceived);


                _connection.Connect();

            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysVCAInterfaceService Connect(): Exception " + ex.Message);
            }
        }


        private void OnUserStatusChanged(System.Object aSource, AuthenticationEventArgs aArgs)
        {
            ExecuteSecure(() =>
            {
                ProfileService profileService = (ProfileService)aSource;
                /*ConsoleWriteLine("User status changed: " + profileService.UserStatus.ToString() + " (" + aArgs.AuthenticationStatus.ToString() + ")");
                foreach (IApplicationState control in ApplicationControls)
                {
                    control.OnUserStatusEvent(profileService.UserStatus);
                }*/
                if (profileService.UserStatus == UserStatus.LoggedIn)
                {
                    StreamingService streamingService = _connection.SessionContext.StreamingService;

                    //session.ProfileService.GetProfile("Service");

                    //_toolStripLabelMaximumRealtimeStreams.Text = "Maximum real-time streams: " + streamingService.MaximumRealtimeDataStreams.ToString();
                    //_toolStripLabelMaximumPlaybackStreams.Text = "Maximum playback streams: " + streamingService.MaximumPlaybackDataStreams.ToString();
                    _connection.SessionContext.RecorderEventService.SubscribeRecorderEvents(RecorderEventsOn);
                }
                else
                {
                    var strtest = aArgs.AuthenticationStatus.ToString();
                    //Program.ShowErrorMessageBox(this, "You have been logged out - " + aArgs.AuthenticationStatus.ToString(), "Session terminated by host");
                    InsertLog.AddLog("MirasysVCAInterfaceService OnUserStatusChanged(): logged out : " + strtest);

                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                       {
                           new ManualResetEvent(false).WaitOne(5000);

                           Disconnect();
                           Connect();
                          
                       }));

                    InsertLog.AddLog("MirasysVCAInterfaceService OnUserStatusChanged():After Connect");
                }
            });
        }

        public IList<RecorderEventType> RecorderEventsOn
        {
            get
            {
                IList<RecorderEventType> recorderEventsOn = new List<RecorderEventType>(4);
                foreach (KeyValuePair<System.Windows.Forms.CheckBox, RecorderEventType> recorderEvent in _recorderEventMap)
                {
                    // The check box corresponding to a recorder event should be checked to be subscribed to
                    if (recorderEvent.Key.Checked)
                    {
                        recorderEventsOn.Add(recorderEvent.Value);
                    }
                }
                return recorderEventsOn;
            }
        }

        private void ExecuteSecure(Action aAction)
        {

            /*if (InvokeRequired)
            {
                BeginInvoke(aAction);
            }
            else
            {*/
            aAction();
            //}
        }

        public void CameraStateChangeEventListen()
        {
            try
            {
                ProfileNode _aProfileNode = session.ProfileService.CurrentProfile;
                var _SiteNode = (SiteNode)_aProfileNode;

                if (_SiteNode != null)
                {
                    var _Count = _SiteNode.Children.Count();
                    if (_Count > 0)
                    {

                        var _CamerasNodelist = _SiteNode.Children.Where(X => X.Name == "Cameras" || X.Name.Contains("Recorder"));// NodeType.Camera || X.NodeType == NodeType.PtzCamera);//"Cameras"
                        foreach (var _CamerasNoderecval in _CamerasNodelist)
                        {
                            var _CamerasNoderec = (SiteNode)_CamerasNoderecval;
                            foreach (var _CamerasNodelocval in _CamerasNoderec.Children)
                            {
                                //var _CamerasNodeloc = (SiteNode)_CamerasNodelocval;
                                // foreach (var _CamerasNode in _CamerasNodeloc.Children)
                                //{

                                InsertLog.AddLog("MirasysInterface getCamDeviceList() Location name:  " + _CamerasNodelocval.Name);

                                var _SiteNodeCameras = (SiteNode)_CamerasNodelocval;
                                if (_SiteNodeCameras.Children.Count() == 0)
                                {

                                }
                                else
                                {
                                    var streamingService = _connection.SessionContext.StreamingService;
                                    var playbackGroup = streamingService.CreatePlaybackStreamingGroup();
                                    var RealtimeGroup = session.StreamingService.CreateRealtimeStreamingGroup();

                                    foreach (var _DeviceNode in _SiteNodeCameras.Children)
                                    {
                                        try
                                        {
                                            CameraNode aCamera = _DeviceNode as CameraNode;
                                          
                                            aCamera.StateChanged += aCamera_StateChanged;

                                        }
                                        catch (Exception ex)
                                        {
                                            InsertLog.AddLog("MirasysInterface getCamDeviceList() Exception:" + ex.ToString());
                                        }
                                    }
                                }
                                //    }
                            }
                        }

                        //var _CamerasNodelist = _SiteNode.Children.Where(X => X.Name == "Cameras" || X.Name.Contains("Recorder"));// NodeType.Camera || X.NodeType == NodeType.PtzCamera);//"Cameras"
                        //foreach (var _CamerasNoderecval in _CamerasNodelist)
                        //{
                        //    var _CamerasNoderec = (SiteNode)_CamerasNoderecval;
                        //    foreach (var _CamerasNodelocval in _CamerasNoderec.Children)
                        //    {
                        //        //at office
                        //        try
                        //        {
                        //            CameraNode aCamera = _CamerasNodelocval as CameraNode;
                        //            aCamera.StateChanged += aCamera_StateChanged;

                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            InsertLog.AddLog("MirasysInterface getCamDeviceList() Exception:" + ex.ToString());
                        //        }                              
                               
                        //    }
                        //}
                        //
                    }
                }
                //
            }
            catch (Exception ex)
            {
            }
        }

        void aCamera_StateChanged(object sender, EventArgs e)
        {
            try
            {
                var DeviceNode = sender as DeviceNode;
                if (DeviceNode != null)
                {
                    if (DeviceNode.State != DeviceStatus.NotConfigured)
                    {
                        if (DeviceNode.State == DeviceStatus.Disconnected || DeviceNode.State == DeviceStatus.NoSignal || DeviceNode.State == DeviceStatus.Off || DeviceNode.State == DeviceStatus.Unknown)
                        {

                            //offline call broker method to update 
                            var strStatus = "Offline"; //DeviceNode.State.ToString();     
                            string DeviceName = DeviceNode.Name;
                            string StrGuid = DeviceNode.ProfileId;

                            Task t = Task.Factory.StartNew(delegate
                            {
                                InsertLog.AddLog("MirasysInterface aCamera_StateChanged() DeviceName:" + DeviceName + "--!--StrGuid:" + StrGuid + "--!--strStatus:" + DeviceNode.State.ToString());

                                var json = JsonServicesHelper.GetJsonResponse("ControllerSetOperation", "UpdateMiracysDeviceStatus", "DeviceName=" + DeviceName, "StrGuid=" + StrGuid, "Status=" + strStatus);

                            })
                            .ContinueWith((MyResult) =>
                            {

                            });                           

                        }
                        if (DeviceNode.State == DeviceStatus.OK || DeviceNode.State == DeviceStatus.On)
                        {
                            //online
                            var strStatus = "Online";
                            string DeviceName = DeviceNode.Name;
                            string StrGuid = DeviceNode.ProfileId;

                            Task t = Task.Factory.StartNew(delegate
                            {
                                InsertLog.AddLog("MirasysInterface aCamera_StateChanged() DeviceName:" + DeviceName + "--!--StrGuid:" + StrGuid + "--!--strStatus:" + DeviceNode.State.ToString());

                                var json = JsonServicesHelper.GetJsonResponse("ControllerSetOperation", "UpdateMiracysDeviceStatus", "DeviceName=" + DeviceName, "StrGuid=" + StrGuid, "Status=" + strStatus);

                            })
                            .ContinueWith((MyResult) =>
                            {

                            });   
               
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysInterface aCamera_StateChanged() Exception:" + ex.Message);

            }
        }

        public void AlarmEventListen(AlarmService aAlarmService)
        {
            try
            {
                //lock (_eventLock)
                //{
                _aAlarmService = aAlarmService;// _connection.SessionContext.AlarmService;//_connection.SessionContext.AlarmService;
                _aAlarmService.AlarmEventReceived += new EventHandler<AlarmEventArgs>(OnAlarmEventReceived);
                _aAlarmService.AlarmException += new EventHandler<Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs>(OnAlarmException);
                //}
            }
            catch (Exception ex)
            {
            }
        }


        public string GetImage(string _caemraGuid, string strDateTime)
        {
            string strImg = "";
            try
            {
                //Login
                LoginDetails loginDetails = new LoginDetails()
                {
                    PublicApiUrl = PublicApiUrl,
                    Username = MirasysHostUserName,
                    Password = MirasysHostPassword,
                    LicenseKey = LicenseKey
                };

                var Result = Login(loginDetails).GetAwaiter().GetResult();

                if (Result == true)
                {
                    Uri uri = new Uri(loginDetails.PublicApiUrl + @"/api/v1/cameras/playbackimage/" + _caemraGuid + "?utcTime=" + strDateTime + "&direction=backward&requestedsize=medium&includemetadata=true");

                    HttpResponseMessage response = _httpClient.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        SnapshotImage snapshot = JsonConvert.DeserializeObject<SnapshotImage>(jsonResponse);

                        return snapshot.LatestCameraImageJpegBase64;
                    }
                    else
                    {
                        //Not able to take Image
                    }

                    Uri urilogout = new Uri(loginDetails.PublicApiUrl + @"/api/v1/logon/logout");
                    StringContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    HttpResponseMessage responselogout = _httpClient.PostAsync(urilogout, content).Result;
                }
                else
                {
                    //Unable to login
                }


            }
            catch (Exception ex)
            {
            }

            return strImg;
        }
        public async Task<bool> Login(LoginDetails loginDetails)
        {
            try
            {
                // create a data object to be posted as JSON to the API
                LogonRequest loginData = new LogonRequest()
                {
                    Username = loginDetails.Username,
                    Password = loginDetails.Password,
                    License = loginDetails.LicenseKey
                };
                string json = JsonConvert.SerializeObject(loginData);

                Uri uri = new Uri(loginDetails.PublicApiUrl + @"/api/v1/logon");

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
               
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }
                HttpResponseMessage response = _httpClient.PostAsync(uri, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return false;
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                LogonResponse logon = JsonConvert.DeserializeObject<LogonResponse>(jsonResponse);
                if (logon.Success)
                {
                    GetClient(logon.Authorization.AccessToken);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                string error = "Exception {ex.GetType().Name}: {ex.Message}";
                if (ex.InnerException != null)
                {
                    error += " " + ex.InnerException.Message;
                }

                return false;
            }
        }

        public HttpClient GetClient(string aToken)
        {
            try
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }

                AuthenticationHeaderValue authorization = new AuthenticationHeaderValue("Bearer", aToken);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorization.Scheme, authorization.Parameter);
                return _httpClient;
            }
            catch (Exception ex)
            { 
            }
            return null;
        }

        private void OnAlarmEventReceived(System.Object aSource, AlarmEventArgs aAlarmEventArgs)
        {
            try
            {
                //UpdateAlarmEventRow(aAlarmEventArgs.AlarmEvent);
                AlarmNode alarmProfile = _aAlarmService.GetAlarmProfile(aAlarmEventArgs.AlarmEvent.AlarmProfileId);
                if (alarmProfile != null)
                {
                    String strEventCode = "";
                    String strAlarmDateTime = "";
                    String strDevName = "";
                    String CamGuid= "b42d6cf5-313d-4ff8-b49d-74c2e91124cd";
                    string strEventTemp = alarmProfile.Name;
                    
                    strDevName = aAlarmEventArgs.AlarmEvent.AlarmConfiguration.AlarmTrigger.ChannelName;

                     InsertLog.AddLog("MirasysVCAInterfaceService CamGuid ProfileId:"+alarmProfile.ProfileId);

                    if(alarmProfile.ProfileId!=null && alarmProfile.ProfileId!="")
                    CamGuid=alarmProfile.ProfileId;


                    if (strEventTemp.Contains(strDevName))
                    {
                        strEventTemp = strEventTemp.Replace("_" + strDevName, "");
                    }

                    strEventCode = strEventTemp;// aAlarmEventArgs.AlarmEvent.AlarmConfiguration.AlarmTrigger.EventName;

                    strAlarmDateTime = Helper.ToLocalDateTime(aAlarmEventArgs.AlarmEvent.StartTime).ToString();                    

                    DateTime _datetime = DateTime.Parse(strAlarmDateTime);
                    string strDateTime = _datetime.ToUniversalTime().ToString("O");
                    var _img = GetImage(CamGuid, strDateTime);
                    byte[] jpegBytes = Convert.FromBase64String(_img);

                    InsertLog.AddLog("MirasysVCAInterfaceService Connect() before CreateVaAlert: strDevName " + strDevName + "--!--strEventCode:" + strEventCode + "--!--strAlarmDateTime:" + strAlarmDateTime + "--!--strDateTime:" + strDateTime);


                    CreateVaAlert(strDevName, strEventCode, strAlarmDateTime, jpegBytes);

                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        string strResult = strDevName + "   " + strEventCode + "    " + strAlarmDateTime;
                        MainWindow.txtResult.AppendText(strResult + "\n");
                        if (MainWindow.txtResult.LineCount > 20)
                            MainWindow.txtResult.Clear();
                    }));
                }
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysVCAInterfaceService Connect() before CreateVaAlert:Exception -- "+ex.ToString());
            }
        }

        public void CreateVaAlert(string strDevName, string strEventCode, string strAlarmDateTime, byte[] image)
        {
            try
            {
                //create alert here on channael name 
                Task t = Task.Factory.StartNew(delegate
                {
                    InsertLog.AddLog("MirasysInterface CreateVaAlert() DeviceName:" + strDevName + "--!--strEventCode:" + strEventCode + "--!--strAlarmDateTime:" + strAlarmDateTime.ToString());

                   // var json = JsonServicesHelper.GetJsonResponse("MirasysVideoAnalyticsService", "ConsumVideoAnalytics", "strDevName=" + strDevName, "strEventCode=" + strEventCode, "strAlarmDateTime=" + strAlarmDateTime);
                    MirasysAlertData _MirasysAlertData = new MirasysAlertData();
                    _MirasysAlertData.AlertDateTime = strAlarmDateTime;
                    _MirasysAlertData.DeviceName = strDevName;
                    _MirasysAlertData.Eventcode = strEventCode;
                    _MirasysAlertData.Imagedata = image;


                    var json = JsonServicesHelper.GetJsonResponsePost("MirasysVideoAnalyticsService", "ConsumVideoAnalytics", _MirasysAlertData);

                   // var json = JsonServicesHelper.GetJsonResponsePost("MirasysVideoAnalyticsService", "ConsumVideoAnalytics", "strDevName=" + strDevName, "strEventCode=" + strEventCode, "strAlarmDateTime=" + strAlarmDateTime);
                   

                    if (json == null)
                        return false;
                    else
                        return true;

                })
                .ContinueWith((MyResult) =>
                {

                });                  
                
            }
            catch (Exception ex)
            {
            }
            return ;
        }

        private void OnAlarmException(System.Object aSource, Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs aException)
        {
            try
            {
                String errorMessage =
                    aException.Exception != null ?
                    aException.Exception.Message :
                    String.Format("{0}: {1}", aException.ErrorName, aException.ErrorMessage);
            }
            catch (Exception ex)
            {
            }
        }

        public IList<MirasysDeviceDetails> getCamDeviceList()
        {
            string strResponce = "";

            InsertLog.AddLog("MirasysInterface getCamDeviceList() Start:");

            List<MirasysDeviceDetails> MirasysDeviceDetailsList = new List<MirasysDeviceDetails>();
            try
            {            
                ProfileNode _aProfileNode = session.ProfileService.CurrentProfile;
                var _SiteNode = (SiteNode)_aProfileNode;

                if (_SiteNode != null)
                {
                    var _Count = _SiteNode.Children.Count();
                    if (_Count > 0)
                    {
                        var _CamerasNodelist = _SiteNode.Children.Where(X => X.Name == "Cameras" || X.Name.Contains("Recorder"));// NodeType.Camera || X.NodeType == NodeType.PtzCamera);//"Cameras"
                        foreach (var _CamerasNoderecval in _CamerasNodelist)
                        {
                            var _CamerasNoderec = (SiteNode)_CamerasNoderecval;
                            foreach (var _CamerasNodelocval in _CamerasNoderec.Children)
                            {
                                //var _CamerasNodeloc = (SiteNode)_CamerasNodelocval;
                               // foreach (var _CamerasNode in _CamerasNodeloc.Children)
                                //{

                                InsertLog.AddLog("MirasysInterface getCamDeviceList() Location name:  " + _CamerasNodelocval.Name);

                                var _SiteNodeCameras = (SiteNode)_CamerasNodelocval;
                                    if (_SiteNodeCameras.Children.Count() == 0)
                                    {
                                        
                                    }
                                    else
                                    {
                                        var streamingService = _connection.SessionContext.StreamingService;
                                        var playbackGroup = streamingService.CreatePlaybackStreamingGroup();
                                        var RealtimeGroup = session.StreamingService.CreateRealtimeStreamingGroup();

                                        foreach (var _DeviceNode in _SiteNodeCameras.Children)
                                        {
                                            try
                                            {
                                                CameraNode aCamera = _DeviceNode as CameraNode;
                                                if (aCamera.State != DeviceStatus.NotConfigured)
                                                {
                                                    MirasysDeviceDetails _MirasysDeviceDetails = new MirasysDeviceDetails();
                                                    string strCmName = "";
                                                    string strCamGuid = "";
                                                    string strCamType = "";//1- camera 2- PTZ Camera
                                                    string strCamChannelNumber = "";
                                                    string strCamIp = "";
                                                    string strCamUserName = "";
                                                    string strCamPass = "";
                                                    string strCamPortNum = "";
                                                    string strCamWidth = "";
                                                    string strCamHeight = "";

                                                    //
                                                    InsertLog.AddLog("MirasysInterface getCamDeviceList() Camera name:  " + aCamera.Name);

                                                    strCmName = aCamera.Name;
                                                    strCamGuid = aCamera.ProfileId;
                                                    strCamType = aCamera.NodeType.ToString();//1- camera 2- PTZ Camera

                                                    strCamChannelNumber = "";
                                                    strCamIp = "";
                                                    strCamUserName = "";
                                                    strCamPass = "";
                                                    strCamPortNum = "";
                                                    strCamWidth = "";
                                                    strCamHeight = "";

                                                    if (strCmName != "" && _MirasysDeviceDetails != null)
                                                        _MirasysDeviceDetails.CameraName = strCmName;

                                                    if (strCamGuid != "" && strCamGuid != null)
                                                        _MirasysDeviceDetails.CameraGuid = strCamGuid;

                                                    if (strCamType != "" && strCamType != null)
                                                        _MirasysDeviceDetails.CameraType = strCamType;

                                                    MirasysDeviceDetailsList.Add(_MirasysDeviceDetails);

                                                    //
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                InsertLog.AddLog("MirasysInterface getCamDeviceList() Exception:" + ex.ToString());
                                            }
                                        }
                                    }
                            //    }
                            }
                        }
                        //
                    }
                }
                //
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysInterface getCamDeviceList() Exception Final:" + ex.ToString());
            }
            return MirasysDeviceDetailsList;
        }

        private void OnProfileEventReceived(System.Object aSource, ProfileEventArgs aArgs)
        {
            ExecuteSecure(() =>
            {
                //ConsoleWriteLine("Profile event received: " + aArgs.EventType.ToString());

                if (aArgs.EventType == ProfileEventType.ProfileNamesReceived && aArgs.ProfileUpdated)
                {
                    //Program.ShowInfoMessageBox(this, "Profile has been updated", "The application will close all features that are no longer authorized");
                }
                else if (aArgs.EventType == ProfileEventType.ProfileReceived)
                {
                    // Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    //{
                    //MakeBtnEnable();
                    try
                    {
                       //getCamDeviceList();
                       CameraStateChangeEventListen();
                       AlarmEventListen(_connection.SessionContext.AlarmService);
                        // btnStatrlisten.IsEnabled = false;
                    }
                    catch (Exception ex)
                    {
                    }
                    //}));
                }

                if (aArgs.EventType == ProfileEventType.ProfileNamesReceived)
                {
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {

                        try
                        {
                            var _test = session.ProfileService.CurrentProfile;
                            IList<string> profileNames = session.ProfileService.ProfileNames;
                            _comboBoxProfileNames.DataSource = profileNames;
                            if (profileNames.Count > 0)
                            {
                                _comboBoxProfileNames.SelectedIndex = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }));

                }
                else if (aArgs.EventType == ProfileEventType.ProfileReceived)
                {
                    //BuildProfileTree(SessionContext.ProfileService.CurrentProfile);
                }

            });

        }
        private void OnExceptionThrown(System.Object aSource, Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs aArgs)
        {
            //ConsoleWriteLine("Session exception: " + aArgs.Exception.Message);
            InsertLog.AddLog("MirasysVCAInterfaceService OnExceptionThrown() : " + aArgs.Exception.Message);
        }
        private void OnRequestValidation(System.Object aSource, RequestValidationEventArgs aArgs)
        {
            string requestCommand = aArgs.RequestCommand;
            string statusCode = aArgs.StatusCode;
            string details = aArgs.Details;
            // ConsoleWriteLine("Request validation: " + requestCommand + ":" + statusCode + " - " + details);
        }
        void _comboBoxProfileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_comboBoxProfileNames.Items.Count > 0)
                {
                    string selectedProfile = ((System.Windows.Forms.ComboBox)sender).Text;
                    session.ProfileService.GetProfile(selectedProfile);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void OnConnectionEvent(System.Object aSource, ConnectionEventArgs aArgs)
        {
            try
            {
                InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): start");

                GatewayConnection connection = (GatewayConnection)aSource;
                // ConsoleWriteLine("Connection event: " + connection.Status.ToString());

                var connStatus = connection.Status;

                if (connection.Status == ConnectionStatus.Connected)
                {
                    //Log Connected
                    try
                    {
                        InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): Connected ");
                        System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            string strResult = "Connected";
                            MainWindow.txtResult.AppendText(strResult + "\n");
                            if (MainWindow.txtResult.LineCount > 20)
                                MainWindow.txtResult.Clear();
                        }));
                        //_connection.SessionContext.AlarmService
                        //_AlarmEvents = new AlarmEvents(_connection.SessionContext.AlarmService);
                        InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): Connected 1 ");// + _connection.SessionContext.);
                    }
                    catch (Exception ex)
                    {
                        InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): Exception " + ex.Message);
                    }
                }
                else
                {
                    if (connection.Status == ConnectionStatus.ConnectionFailed)
                    {
                        InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): ConnectionFailed ");
                        System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            string strResult = "ConnectionFailed";
                            MainWindow.txtResult.AppendText(strResult + "\n");
                            if (MainWindow.txtResult.LineCount > 20)
                                MainWindow.txtResult.Clear();
                        }));
                        //Program.ShowErrorMessageBox(this, "Error occured when connection to Gateway was attempted.", "Connection failed");
                    }
                }
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysVCAInterfaceService OnConnectionEvent(): Exception 1 " + ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                InsertLog.AddLog("MirasysVCAInterfaceService Disconnect(): start ");

                if (_connection != null)
                {
                    _connection.ConnectionEvent -= new EventHandler<ConnectionEventArgs>(OnConnectionEvent);
                    _connection.Disconnect();
                    _connection.Dispose();
                    _connection = null;
                }
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasysVCAInterfaceService Disconnect(): Exception " + ex.Message);
            }
        }
        public void Dispose()
        {
            try
            {
                Disconnect();
                InsertLog.AddLog("MirasysVCAInterfaceService Dispose()");

                try
                {
                    if (_comboBoxProfileNames != null)
                    {
                        myhost.Child = null;
                        _comboBoxProfileNames.Dispose();
                        myhost.Dispose();
                        myhost = null;
                    }

                    _boxCameraStateEvent.Dispose();
                    _boxCameraStateEvent = null;

                    _boxIoStateEvent.Dispose();
                    _boxIoStateEvent = null;

                    _boxVideoMotionEvent.Dispose();
                    _boxVideoMotionEvent = null;

                    _boxAlarmEvent.Dispose();
                    _boxAlarmEvent = null;
                }
                catch (Exception ex)
                {
                }
                // NativeMethods.FreeConsole();
                //if(ControlFactory.Instance!=null)

                //ControlFactory.Instance.Dispose();
                if (_connection != null)
                {
                    _connection.Dispose();
                }

                session.ErrorHandler.SessionExceptionThrown -= new EventHandler<Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs>(OnExceptionThrown);
                session.ProfileService.ProfileEventReceived -= new EventHandler<ProfileEventArgs>(OnProfileEventReceived);
                session.ProfileService.UserStatusChanged -= new EventHandler<AuthenticationEventArgs>(OnUserStatusChanged);

                _aAlarmService.AlarmEventReceived -= new EventHandler<AlarmEventArgs>(OnAlarmEventReceived);
                _aAlarmService.AlarmException -= new EventHandler<Mirasys.Clients.Gateway.SDK.Events.ExceptionEventArgs>(OnAlarmException);
                //base.Dispose(disposing);
            }
            catch (Exception ex)
            {
            }   
        }
    }

    public static class SSLValidator
    {

        private static System.Net.Security.RemoteCertificateValidationCallback _orgCallback;

        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool result = false;

            if (certificate.Subject.Contains("2020ImagingLtd") || certificate.Subject.Contains("cloudinary.com") || certificate.Subject.Contains("smtp.gmail.com") || certificate.Subject.Contains("outlook.com") || certificate.Subject.Contains("2020imaging.com") || certificate.Subject.Contains("pparke.in") || certificate.Subject.Contains("*.googleapis.com, O=Google Inc, L=Mountain View, S=California, C=US") || certificate.Subject.Contains("*.googleapis.com, O=Google LLC, L=Mountain View, S=California, C=US"))
            {
                return true;
            }
            else
            {
                InsertLog.AddLog("MirasysVCAInterfaceService OnValidateCertificate() new certificate.Subject :" + certificate.Subject);//jatin
                return true;
                // MessageBox.Show("Kindly install valid certificate from 2020Imaging!");
                // Environment.Exit(1);
            }
            return result;
        }

        public static void OverrideValidation()
        {
            _orgCallback = ServicePointManager.ServerCertificateValidationCallback;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidateCertificate);
            ServicePointManager.Expect100Continue = true;
        }


        public static void RestoreValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = _orgCallback;
        }
    }


    public class LoginDetails
    {
        //public LoginDetails();

        public string LicenseKey { get; set; }
        public string Password { get; set; }
        public string PublicApiUrl { get; set; }
        public string Username { get; set; }
    }
    public class LogonRequest
    {
        //public LoginDetails();

        public string License { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
    //LogonRequest
    public class LogonResponse
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public LogonTokens Authorization { get; set; }
    }
    public class LogonTokens
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }
    }
    public class SnapshotImage
    {
        public string LatestCameraImageJpegBase64 { get; set; }

        public DateTime ImageLocalTime { get; set; }
    }
}
