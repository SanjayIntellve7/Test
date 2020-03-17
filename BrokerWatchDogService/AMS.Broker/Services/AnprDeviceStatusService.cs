using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.Services;
using NLog;
using AMS.Broker.WatchDogService;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.WatchDogService.DataStore;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using AMS.Broker.DataStore;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace AMS.Broker.WatchDogService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class AnprDeviceStatusService : IAnprDeviceStatusService
    {
        readonly IAnprDeviceStatusService _AnprDeviceStatusService;
        private static IAnprDeviceStatusService _serviceInstance = new AnprDeviceStatusService();
        public static IAnprDeviceStatusService ServiceInstance { get { return _serviceInstance; } }
        readonly IDeviceTimeSyncService _DeviceTimeSyncService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public string IsAnprDeviceStatusEnable = Storage.AnprDeviceStatusEnable;
        public string TimeInterval = Storage.AnprDeviceStatusInterval;
        public System.Threading.Thread testSyncThread;
        public int nCount = 0;
        public int waitTime = 10 * 60 * 1000;
        public  List<AlarmPanelDTO> _alarmPanleDtoList = new List<AlarmPanelDTO>();
        public List<AnprStatusDto> _AnprStatusDtoColection = new List<AnprStatusDto>();

        int AnprStatAlertTime = Int32.Parse(Storage.AnprDeviceStatusAlertTime);
        public AnprDeviceStatusService()
        {
            try
            { 
                if (IsAnprDeviceStatusEnable == "1")
                {
                    try
                    {
                      var IntervalTime=Int32.Parse(TimeInterval);

                      if (IntervalTime < 20)
                          IntervalTime = 20;

                          waitTime = IntervalTime * 60 * 1000;                         
                    }
                    catch (Exception EX)
                    {
                    }
                    GetANPRInterfaceCollection();
                    GetAnprDeviceStatuslist();
                    StartAnprDeviceStatusThread();
                }
            }
            catch (Exception ex)
            { 
            }
        }

        public void GetANPRInterfaceCollection()
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    var AlarmPanel = context.AlarmPanelTypeMaster.FirstOrDefault(x => x.Name == "Konnet ANPR");

                    if (AlarmPanel != null)
                    {
                        var interfaceColl = context.alarmPanel.Where(x => x.AlarmPanelTypeId == AlarmPanel.AlarmPanelTypeId);
                        if (interfaceColl.Count() > 0)
                        {
                            _alarmPanleDtoList = new List<AlarmPanelDTO>();
                            foreach (var _interfaceDate in interfaceColl)
                            {
                                //if (_interfaceDate.InterfaceDeviceIP == "192.168.0.169")
                                //{
                                    AlarmPanelDTO _AlarmPanelDTO = new AlarmPanelDTO();
                                    _AlarmPanelDTO.InterfaceDeviceIP = _interfaceDate.InterfaceDeviceIP;
                                    _AlarmPanelDTO.InterfaceDevicePort = _interfaceDate.InterfaceDevicePort;
                                    _AlarmPanelDTO.AlarmPanelId = (int)_interfaceDate.AlarmPanelTypeId;

                                    if (_alarmPanleDtoList.FirstOrDefault(x => x.InterfaceDeviceIP == _interfaceDate.InterfaceDeviceIP) == null && _interfaceDate.InterfaceDeviceIP != null && _interfaceDate.InterfaceDeviceIP != "NULL")
                                        _alarmPanleDtoList.Add(_AlarmPanelDTO);
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception EX)
            {
            }
        }

        public void StartAnprDeviceStatusThread()
        {
            try
            {
                testSyncThread = new System.Threading.Thread(new System.Threading.ThreadStart(AnprDeviceStatusThread));               
                testSyncThread.Start();
            }
            catch (Exception ex)
            {
            }
        }

        public void AnprDeviceStatusThread()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        if (_alarmPanleDtoList.Count() > 0)
                        {
                            StartGetStatus(_alarmPanleDtoList);
                        }
                    }
                    catch (Exception ex)
                    {
                        InsertBrokerOperationLog.AddProcessLog("StartGetStatus Exception:" + ex.Message);
                    }
                    new ManualResetEvent(false).WaitOne(waitTime);   
                }                
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("AnprDeviceStatusThread Exception:" + ex.Message);
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<AnprStatusDto> GetAnprDeviceStatusCollection(string authToken)
        {
            try
            {
                return _AnprStatusDtoColection;
            }
            catch (Exception ex)
            { 
            }
            return null;
        }

        
        public List<AnprStatusDto> GetAnprDeviceStatuslist()
        {
            try
            {              
                using (var context = new CentralDBEntities())
                {                                   
                    //join query to get two table data 
                    var innerJoin = from D in context.tblANPRMaster                                  
                                    join L in context.tblANPRLPDetails on D.appkey equals L.UID                                  
                                    select new
                                   {
                                       LPID = L.UID,
                                       LPUName = L.DeviceName,
                                       LPUStatus = L.Status,
                                       ANprDeviceID = D.ANPRDeviceID,
                                       DeviceStatus = D.Status,
                                       DeviceID=D.DeviceID,
                                       AnprDevName=D.Camusername
                                   };
                    foreach (var data in innerJoin)
                    {
                        AnprStatusDto _AnprStatusDto = new AnprStatusDto();
                        _AnprStatusDto.ANprDeviceID = data.ANprDeviceID;
                        _AnprStatusDto.DeviceID = data.DeviceID.ToString();
                        _AnprStatusDto.DeviceStatus = data.DeviceStatus;
                        _AnprStatusDto.LPID = data.LPID;
                        _AnprStatusDto.LPUName = data.LPUName;
                        _AnprStatusDto.LPUStatus = data.LPUStatus;
                        _AnprStatusDto.AnprDevName = data.AnprDevName;
                        _AnprStatusDtoColection.Add(_AnprStatusDto);
                    }
                  
                }

                return _AnprStatusDtoColection;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public void StartGetStatus(List<AlarmPanelDTO> _alarmPanleDtoList)
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("StartGetStatus() StartGetStatus Start: ");
                foreach (var _anprServer in _alarmPanleDtoList)
                {
                    // var AlarmPanel = _interface as AlarmPanelDTO;
                    string _AnprUrl = "http://" + _anprServer.InterfaceDeviceIP + ":" + _anprServer.InterfaceDevicePort + "/alpr/process/anprMaster/";

                    string _LpuUrl = "http://" + _anprServer.InterfaceDeviceIP + ":" + _anprServer.InterfaceDevicePort + "/alpr/process/lpDetails/";

                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() ..InterfaceDeviceIP:" + _anprServer.InterfaceDeviceIP + "---InterfaceDevicePort--" + _anprServer.InterfaceDevicePort);

                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() .._AnprMasterUrl:" + _AnprUrl + ".._LpuUrl:" + _LpuUrl);

                    try
                    {                        

                        //string _url = @"http://192.168.0.169:8000/alpr/process/lpDetails/";
                        string LpuRespData = string.Empty;
                        var request = (HttpWebRequest)WebRequest.Create(_LpuUrl);
                        request.Timeout = 9;
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            LpuRespData = reader.ReadToEnd();
                        }
                        if (LpuRespData != null)
                        {
                            var ANPRLPInfo = JsonConvert.DeserializeObject<List<LpuMasterObject>>(LpuRespData);

                            if (ANPRLPInfo != null && ANPRLPInfo.Count() > 0)
                            {
                                using (var ctx = new CentralDBEntities())
                                {
                                   // var PresentANPRLPList = ctx.tblANPRLPDetails.Where(x => x.UID != "").ToList();
                                    foreach (var Item in ANPRLPInfo)
                                    {
                                        InsertBrokerOperationLog.AddProcessLog("StartGetStatus() LPID: " + Item.uid + "--!--LPDeviceStatus: " + Item.status + "--!--LPUName:" + Item.device_name);
                                        //check LpDevice status if offline create alert
                                        if (Item.status == "OFF")
                                        {
                                            //get device name  from db
                                            using (var context = new CentralDBEntities())
                                            {
                                                //context.tblANPRMaster
                                                try
                                                {
                                                    var IsLpuStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.LPID == Item.uid && x.LPUStatus == Item.status); //check if same status for Lpu already there then do nothing 

                                                    if (IsLpuStatusAlreadyUpdate.Count() == 0)
                                                    {
                                                        InsertBrokerOperationLog.AddProcessLog("StartGetStatus() IsLpuStatusAlreadyUpdate: 0");

                                                        var LpDevice = context.Device.FirstOrDefault(x => x.ExternalId == Item.uid);
                                                        if (LpDevice != null)
                                                        {
                                                            //AnprStatAlertTime
                                                            DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                            var alrtcnt = context.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == LpDevice.DeviceId);
                                                            if (alrtcnt > 0)
                                                            {
                                                            }
                                                            else
                                                            {
                                                                Task.Run(() => CreateAlert(LpDevice.Name, Item.status));
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                            }
                                        }

                                        using (var context = new CentralDBEntities())
                                        {
                                            var COntainData = context.tblANPRLPDetails.Where(x => x.UID == Item.uid).FirstOrDefault();
                                            if (COntainData != null)
                                            {
                                                try
                                                {
                                                    if (COntainData.Status != Item.status)
                                                    {
                                                        COntainData.Status = Item.status;
                                                        context.SaveChanges();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 2:" + ex.Message);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                           //this is for ANPR Master

                        try
                        {
                            string AnprMasterRespData = string.Empty;
                            var anprrequest = (HttpWebRequest)WebRequest.Create(_AnprUrl);
                            anprrequest.Timeout = 9;

                            using (HttpWebResponse response = (HttpWebResponse)anprrequest.GetResponse())
                            using (Stream stream = response.GetResponseStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                AnprMasterRespData = reader.ReadToEnd();
                            }
                            if (AnprMasterRespData != null)
                            {

                                var ANPRMasterInfo = JsonConvert.DeserializeObject<List<AnprDeviceMasterObject>>(AnprMasterRespData);

                                if (ANPRMasterInfo != null && ANPRMasterInfo.Count() > 0)
                                {
                                    using (var ctx = new CentralDBEntities())
                                    {
                                        //var PresentANPRLPList = ctx.tblANPRMaster.ToList();
                                        foreach (var Item in ANPRMasterInfo)
                                        {
                                            InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Cam name: " + Item.anpr_camera_name + "--!--CamStatus: " + Item.status + "--!--UID :" + Item.app_key);
                                            //check LpDevice status if offline create alert
                                            if (Item.status == "True" || Item.status.ToLower() == "on")
                                                Item.status = "ON";

                                            if (Item.status == "False" || Item.status.ToLower() == "off")
                                                Item.status = "OFF";

                                            if (Item.status == "OFF")
                                            {
                                                //get device name  from db
                                                using (var context = new CentralDBEntities())
                                                {
                                                    try
                                                    {
                                                        var IsLpuStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.AnprDevName == Item.anpr_camera_name && x.DeviceStatus == Item.status); //check if same status for Lpu already there then do nothing 

                                                        if (IsLpuStatusAlreadyUpdate.Count() == 0)
                                                        {
                                                            InsertBrokerOperationLog.AddProcessLog("StartGetStatus() IsLpuStatusAlreadyUpdate: 0");

                                                            var AnprCamDevice = context.Device.FirstOrDefault(x => x.Name == Item.anpr_camera_name);
                                                            if (AnprCamDevice != null)
                                                            {
                                                                //AnprStatAlertTime
                                                                DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                                var alrtcnt = context.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == AnprCamDevice.DeviceId);
                                                                if (alrtcnt > 0)
                                                                {
                                                                }
                                                                else
                                                                {
                                                                    Task.Run(() => CreateAlert(AnprCamDevice.Name, Item.status));
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                    }
                                                }
                                            }

                                            //update status in Anpt master Table

                                            using (var context = new CentralDBEntities())
                                            {
                                                var COntainData = context.tblANPRMaster.Where(x => x.ANPRCameraName == Item.anpr_camera_name).FirstOrDefault();
                                                if (COntainData != null)
                                                {
                                                    try
                                                    {
                                                        if (COntainData.Status != Item.status)
                                                        {
                                                            COntainData.Status = Item.status;
                                                            context.SaveChanges();
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        InsertBrokerOperationLog.AddProcessLog("update camstatus in tblANPRMaster Exception 2:" + ex.Message);
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
                        }
                        //

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("update camstatus in tblANPRMaster Final Exception :" + ex.Message);
            }
        }

        public async void StartGetStatusOld(List<AlarmPanelDTO> _alarmPanleDtoList)
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("StartGetStatus() StartGetStatus Start: ");
                foreach (var _anprServer in _alarmPanleDtoList)
                {
                    string _url = "http://" + _anprServer.InterfaceDeviceIP + ":" + _anprServer.InterfaceDevicePort + "/api/Device/GetDeviceStatus?DevID=All";

                    List<RootObject> ANPRLPInfo = new List<RootObject>();

                    using (var client = new HttpClient())
                    {

                        try
                        {
                            Task t = Task.Run(async()=>
                            {
                                client.BaseAddress = new Uri(_url);
                                client.DefaultRequestHeaders.Accept.Clear();
                                //Define request data format  
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                //Sending request to find web api REST service resource Get ANPR Data using HttpClient      
                                HttpResponseMessage Res = await client.GetAsync(_url);
                                return Res;

                            })
                            .ContinueWith((MyResult) =>
                            {
                                var Res = MyResult.Result;
                                //If response is successful decrypt the out     
                                if (Res.IsSuccessStatusCode)
                                {
                                    //Storing the response details received from web api    
                                    string ANPRResponse = Res.Content.ReadAsStringAsync().Result;

                                    //The response has \\ added that needs to be removed    
                                    ANPRResponse = ANPRResponse.Replace("\\", string.Empty); ANPRResponse = ANPRResponse.Trim('"');

                                    //Decrypt Response Data   

                                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() ANPRResponse: " + ANPRResponse);

                                    string strDrcData = Decrypt(ANPRResponse);

                                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() strDrcData: " + strDrcData);

                                    ANPRLPInfo = JsonConvert.DeserializeObject<List<RootObject>>(strDrcData);

                                    if (ANPRLPInfo != null && ANPRLPInfo.Count() > 0)
                                    {
                                        foreach (var _ANPRLPInfo in ANPRLPInfo)
                                        {
                                            if (_ANPRLPInfo.strDeviceUID != null)
                                            {
                                                InsertBrokerOperationLog.AddProcessLog("StartGetStatus() LPID: " + _ANPRLPInfo.strDeviceUID + "--!--LPDeviceStatus: " + _ANPRLPInfo.strDeviceStatus + "--!--cameraID:" + _ANPRLPInfo.strCamId + "--!--cameraStatus:" + _ANPRLPInfo.strAppStatus);
                                                //check LpDevice status if offline create alert
                                                if (_ANPRLPInfo.strDeviceStatus == "OFF")
                                                {
                                                    //get device name  from db
                                                    using (var context = new CentralDBEntities())
                                                    {
                                                        //context.tblANPRMaster
                                                        try
                                                        {
                                                            var IsLpuStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.LPID == _ANPRLPInfo.strDeviceUID && x.LPUStatus == _ANPRLPInfo.strDeviceStatus); //check if same status for Lpu already there then do nothing 

                                                            if (IsLpuStatusAlreadyUpdate.Count() == 0)
                                                            {
                                                                InsertBrokerOperationLog.AddProcessLog("StartGetStatus() IsLpuStatusAlreadyUpdate: 0");

                                                                var LpDevice = context.Device.FirstOrDefault(x => x.ExternalId == _ANPRLPInfo.strDeviceUID);
                                                                if (LpDevice != null)
                                                                {
                                                                    //AnprStatAlertTime
                                                                    DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                                    var alrtcnt = context.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == LpDevice.DeviceId);
                                                                    if (alrtcnt > 0)
                                                                    {
                                                                    }
                                                                    else
                                                                    {
                                                                        Task.Run(() => CreateAlert(LpDevice.Name, _ANPRLPInfo.strDeviceStatus));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                        }
                                                    }
                                                }
                                                /* else
                                                 {
                                                     if (_ANPRLPInfo.strDeviceStatus == "ON")
                                                     {
                                                         using (var context = new CentralDBEntities())
                                                         {
                                                             //AnprStatAlertTime
                                                             var AnprDevice = context.tblANPRMaster.FirstOrDefault(x => x.ANPRDeviceID == _ANPRLPInfo.strCamId);
                                                             if (AnprDevice != null)
                                                             {
                                                                 try
                                                                 {
                                                                     if (_ANPRLPInfo.strAppStatus == "OFF")
                                                                     {
                                                                         var IsAnprDevStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.ANprDeviceID == _ANPRLPInfo.strCamId && x.DeviceStatus == _ANPRLPInfo.strAppStatus); //check if same status for Lpu already there then do nothing 

                                                                         if (IsAnprDevStatusAlreadyUpdate.Count() == 0)
                                                                         {
                                                                             var _Device = context.Device.FirstOrDefault(x => x.DeviceId == AnprDevice.DeviceID);
                                                                             if (_Device != null)
                                                                             {
                                                                                 DateTime currentdate = DateTime.Now.AddMinutes(-AnprStatAlertTime);
                                                                                 var alrtcnt = context.Alert.Count(x => x.Sent >= currentdate && x.DeviceId == _Device.DeviceId);
                                                                                 if (alrtcnt > 0)
                                                                                 {
                                                                                 }
                                                                                 else
                                                                                 {
                                                                                     Task.Run(() => CreateAlert(_Device.Name, _ANPRLPInfo.strAppStatus));
                                                                                 }
                                                                             }
                                                                         }
                                                                     }
                                                                 }
                                                                 catch (Exception ex)
                                                                 {
                                                                     InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception :" + ex.Message);
                                                                 }
                                                             }
                                                         }
                                                     }
                                                 }*/
                                                //update status in tblanprLpdetails table and tblanprmastertable

                                                try
                                                {
                                                    var IsLpuStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.LPID == _ANPRLPInfo.strDeviceUID && x.LPUStatus == _ANPRLPInfo.strDeviceStatus); //check if same status for Lpu already there then do nothing 

                                                    if (IsLpuStatusAlreadyUpdate.Count() == 0)
                                                    {
                                                        try
                                                        {
                                                            var LPUdata = _AnprStatusDtoColection.Where(x => x.LPID == _ANPRLPInfo.strDeviceUID);
                                                            if (LPUdata != null)
                                                            {
                                                                if (LPUdata.Count() > 0)
                                                                {
                                                                    foreach (var LPU in LPUdata)
                                                                    {
                                                                        LPU.LPUStatus = _ANPRLPInfo.strDeviceStatus;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 1:" + ex.Message);
                                                        }

                                                        using (var context = new CentralDBEntities())
                                                        {
                                                            var COntainData = context.tblANPRLPDetails.Where(x => x.UID == _ANPRLPInfo.strDeviceUID).FirstOrDefault();
                                                            if (COntainData != null)
                                                            {
                                                                try
                                                                {
                                                                    if (COntainData.Status != _ANPRLPInfo.strDeviceStatus)
                                                                    {
                                                                        COntainData.Status = _ANPRLPInfo.strDeviceStatus;
                                                                        context.SaveChanges();
                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 2:" + ex.Message);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    /* var IsAnprDevStatusAlreadyUpdate = _AnprStatusDtoColection.Where(x => x.ANprDeviceID == _ANPRLPInfo.strCamId && x.DeviceStatus == _ANPRLPInfo.strAppStatus); //check if same status for Lpu already there then do nothing 

                                                     if (IsAnprDevStatusAlreadyUpdate.Count() == 0)
                                                     {
                                                         try
                                                         {
                                                             var AnprMasterdata = _AnprStatusDtoColection.FirstOrDefault(x => x.ANprDeviceID == _ANPRLPInfo.strCamId);
                                                             if (AnprMasterdata != null)
                                                             {
                                                                 AnprMasterdata.DeviceStatus = _ANPRLPInfo.strAppStatus;
                                                             }
                                                         }
                                                         catch (Exception ex)
                                                         {
                                                             InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 3:" + ex.Message);
                                                         }

                                                         try
                                                         {
                                                             using (var context = new CentralDBEntities())
                                                             {
                                                                 var COntainMasterData = context.tblANPRMaster.Where(x => x.ANPRDeviceID == _ANPRLPInfo.strCamId).FirstOrDefault();
                                                                 if (COntainMasterData != null)
                                                                 {
                                                                     if (COntainMasterData.Status != _ANPRLPInfo.strAppStatus)
                                                                     {
                                                                         COntainMasterData.Status = _ANPRLPInfo.strAppStatus;
                                                                         context.SaveChanges();
                                                                     }
                                                                 }
                                                             }
                                                         }
                                                         catch (Exception ex)
                                                         {
                                                             InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 4:" + ex.Message);
                                                         }
                                                     }*/
                                                }
                                                catch (Exception ex)
                                                {
                                                    InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception 5:" + ex.Message);
                                                }
                                                // }
                                            }
                                        }
                                    }
                                }
                            }, TaskScheduler.FromCurrentSynchronizationContext());                          
                           
                        }
                        catch (Exception ex)
                        {
                            InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Api call Exception :" + ex.Message);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("StartGetStatus() Exception final:" + ex.Message);
            }
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "Konnet_ViAn_Pvt_Ltd_ANPRAPIV1";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText); using (System.Security.Cryptography.Aes encryptor = System.Security.Cryptography.Aes.Create())
            {
                System.Security.Cryptography.Rfc2898DeriveBytes pdb = new System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32); encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, encryptor.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length); cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
      

        public void Test()
        {
            try
            {
            }
            catch (Exception ex)
            { 
            }
        }
        internal static IAnprDeviceStatusService Initialise()
        {
            try
            {
                _logger.Info(" ");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting AnprDeviceStatus Service");

                Uri httpUrl = new Uri("https://localhost:6530/AnprDeviceStatusService");
                //Create ServiceHost
                WebServiceHost host
                = new WebServiceHost(typeof(AnprDeviceStatusService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IAnprDeviceStatusService)
                , new WebHttpBinding(WebHttpSecurityMode.Transport), "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };
                host.Description.Behaviors.Add(throttleBehavior);
                host.Open();               
                _logger.Info("AnprDeviceStatus Service started successfully");
                return null;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("AnprDeviceStatus Service Initialise() Exception" + ex.Message);
            }
            return null;
        }

        public void CreateAlert(string DeviceName,string DeviceStaus)
        {
            try
            {
                string Message3 = "AnprDeviceStatus service CreateAlert start DeviceName:" + DeviceName;
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
                            Code =cameraDevice.Name+":"+DeviceStaus, //evtdto.Headline,//eventDB.EventCode,/////EventDto Eeventcode
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
                            _logger.Info("AnprDeviceStatus service CreateAlert() Exception" + es.Message);

                            string Message = "AnprDeviceStatus service Service CreateAlert Exception:" + es.Message;
                            InsertBrokerOperationLog.AddProcessLog(Message);
                        }
                    }
                    else
                    {
                        _logger.Info("AnprDeviceStatus service CreateAlert() Event Template Not Found ANPR");
                        InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service CreateAlert() Event Template Not Found ANPR");
                    }
                }
                else
                {
                    _logger.Info("AnprDeviceStatus service CreateAlert() Device Not Found");
                    InsertBrokerOperationLog.AddProcessLog("ServerClientCommunication service CreateAlert() Device Not Found");
                }
            }
            catch (Exception ex)
            {
                string Message = "AnprDeviceStatus Service CreateAlert Exception 1:" + ex.Message;
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
                            InsertBrokerOperationLog.AddProcessLog("AnprDeviceStatus Service SubmitSystemAlert() Exception for save changes:" + ex.Message);
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
                            InsertBrokerOperationLog.AddProcessLog("AnprDeviceStatus Service SubmitSystemAlert() Exception() after save changes:" + ex.Message);
                        }
                        //
                        if (AlertPushMode == "1")
                        {
                            Task.Run(() => InformAboutRaisedAlertsNew(alert));
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.Info("AnprDeviceStatus Service SubmitSystemAlert() Exception:" + ex.Message);

                        InsertBrokerOperationLog.AddProcessLog("AnprDeviceStatus Service SubmitSystemAlert():" + ex.Message);
                    }


                }

                //_logger.Info("------------------------------------");
                _logger.Info("AnprDeviceStatus Service SubmitSystemAlert() AlertID: " + nVerAlertid.ToString()); //alertDb.AlertId;
                string Message1 = "AnprDeviceStatus Service SubmitSystemAlert():-AlertID: " + nVerAlertid.ToString() + "--!--Headline " + alert.Code;
                InsertBrokerOperationLog.AddProcessLog(Message1);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("AnprDeviceStatus Service SubmitSystemAlert() Exception:" + ex.Message);

                string Message = "AnprDeviceStatus Service SubmitSystemAlert() -- Exception = " + ex.Message;
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
    }

    public class RootObject
    {
        public string strDeviceUID { get; set; } //lpUdevice
        public string strDeviceStatus { get; set; } 
        public string strCamId { get; set; } //cam device
        public string strAppStatus { get; set; }
    }
}
