using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.IntegrationService.DataStore;
using AutoMapper;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using ResourceDTO = AMS.Broker.Contracts.DTO.Resource;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using EventDTO = AMS.Broker.Contracts.DTO.Event;
using AMS.Broker.Contracts.Services;
using NLog;
using System.ServiceModel;

namespace AMS.Broker.IntegrationService.Services
{
    class ACSIntegrationClass
    {
        string strUDPPort = Storage.UDPListenPort;//System.Configuration.ConfigurationManager.AppSettings["UDPListenPort"];
        Thread background;
        Socket mListener;
        EndPoint Remote;
        bool IsStarted = true;
        byte[] buff = new byte[1024];

       

        public ACSIntegrationClass()
        {
            
        }

        ~ACSIntegrationClass()
        {
            IsStarted = false;
            if (background != null)
                background.Abort();
            background = null;

            if (mListener != null)
                mListener.Close();
            mListener = null;
        }

        /*public void doJob()
        {
            int recv;
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Convert.ToInt32(strUDPPort));
            mListener = new Socket(AddressFamily.InterNetwork,
                           SocketType.Dgram, ProtocolType.Udp);
            mListener.Bind(ipep);

            IPEndPoint senderUser = new IPEndPoint(IPAddress.Any, Convert.ToInt32(strUDPPort));
            Remote = (EndPoint)(senderUser);

            //StartReceive();   

            while (true)
            {
                try
                {
                    data = new byte[1024];
                    recv = mListener.ReceiveFrom(data, ref Remote);
                    string strData = Encoding.Default.GetString(data, 0, recv);
                    if(strData.Contains(","))
                    {
                        Task.Run(() => ProcessData(strData.ToString(), ((IPEndPoint)Remote).Address.ToString()));
                    }
                }
                catch (Exception es)
                {
                    Logger.Info("ACSIntegrationClass Exception" + es.Message);
                }
                finally
                {

                }
            }

        }*/

       /* public void ProcessData(string data, string strIp)
        {
            string strData = data;// "#1U,002,001,002,3782706324,162806,261114,000023,000048,002,002,00000,4B,\r";
            try
            {
                var strDa = strData.Split(',');
                if (strDa == null)
                    return;

                string strCheck = strDa[3];
                if (strCheck == "002" || strCheck == "002" || strCheck == "004" || strCheck == "005" || strCheck == "006" || strCheck == "007" || strCheck == "008"
                    || strCheck == "012" || strCheck == "015" || strCheck == "017" || strCheck == "020" || strCheck == "024" || strCheck == "036" || strCheck == "038"
                    || strCheck == "039" || strCheck == "040" || strCheck == "041" || strCheck == "042" || strCheck == "043" || strCheck == "062")
                { }
                else
                    return;
                string deviceId = Int32.Parse(strDa[2]).ToString();
                string strCardNo = strDa[4];
                string errorCode = "ACS Alert " + strCardNo + "-" + SelectEvent(Int32.Parse(strDa[3]));
                string errorCode1 = "ACS Alert " + strCardNo + "-" + SelectEvent(Int32.Parse(strDa[3]));
                string strTemp1 = strDa[5];
                string strTemp2 = strDa[6];

                string dateTime = DateTime.Now.ToString();//"20" + strTemp2.Substring(4, 2) + "-" + strTemp2.Substring(2, 2) + "-" + strTemp2.Substring(0, 2) + " " + strTemp1.Substring(0, 2) + ":" + strTemp1.Substring(2, 2) + ":" + strTemp1.Substring(4, 2);

                string strExtId = deviceId + "-" + strIp;
                //amit 14112016
                if (Storage.IsLogEnable == "1")
                {
                    string Message = "Acs integration Service--ProcessData -- DevicID = " + deviceId + "-- DevicExtID = " + strExtId;
                    InsertBrokerOperationLog.AddProcessLog(Message);
                }
                DeviceDto deviceDto = new DeviceDto();
                using (var devicecontext = new CentralDBEntities())
                {
                    var devicetemplates = from dc in devicecontext.Device
                                          where dc.ExternalId == strExtId
                                          select dc;
                    var devicetemplate = devicetemplates.FirstOrDefault();
                    int count = devicetemplates.Count();
                    if (count > 0)
                    {
                        //deviceDto = Mapper.Map<DeviceDto>(devicetemplate); ;// Mapper.Map<DeviceDto>(alerttemplate);

                        try
                        {
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
                                    //   HasPvAnalytics = _entity1.HasPvAnalytics,
                                    //   HasSzAnalytics = _entity1.HasSzAnalytics,
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
                                deviceDto = DevDto;
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
                                    //  HasPvAnalytics = _data.Device.HasPvAnalytics,
                                    //  HasSzAnalytics = _data.Device.HasSzAnalytics,
                                    //  HasAbAnalytics = _data.Device.HasAbAnalytics,
                                    InterfaceId = devicetemplate.InterfaceId.HasValue ? devicetemplate.InterfaceId.Value : 0,
                                    IsMovable = devicetemplate.IsMovable,
                                    Name = devicetemplate.Name
                                };
                                deviceDto = DevDto;
                            }
                        }
                        catch (Exception ex)
                        {
 
                        }
                    }
                }

                if (deviceDto.DeviceId == 0)
                    return;
                var alert = new AlertDTO
                {
                    DeviceId = Convert.ToInt64(Convert.ToDecimal(deviceDto.DeviceId)),//long.Parse(wcfEvent.Payload["DeviceId"].ToString()),
                    Sender = "Device-" + deviceDto.DeviceId.ToString(),//(string)wcfEvent.Payload["Sender"],
                    Source = deviceDto.Description,//(string)wcfEvent.Payload["Address"],
                    //SentAsString = dateTime, //wcfEvent.StartTime.ToString(),
                    Sent=DateTime.Now,
                    Identifier = Guid.NewGuid().ToString(),
                    StatusId = (AMS.Broker.Contracts.DTO.Status)Enum.Parse(typeof(AMS.Broker.Contracts.DTO.Status), Enum.GetName(typeof(AMS.Broker.Contracts.DTO.Status), AMS.Broker.Contracts.DTO.Status.Actual)),//(Status)Enum.Parse(typeof(Status), (string)wcfEvent.Payload["StatusId"]),
                    MessageTypeId = Contracts.DTO.MessageType.Alert,
                    ScopeId = (Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), AMS.Broker.Contracts.DTO.Scope.Private.ToString()), //(Contracts.DTO.Scope)Enum.Parse(typeof(Contracts.DTO.Scope), (string)wcfEvent.Payload["ScopeId"]),
                    Code = errorCode,
                    Addresses = deviceDto.Name, //(string)wcfEvent.Payload["Address"],
                    Severity = (Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), Contracts.DTO.Severity.Extreme.ToString()), //(Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), (string)wcfEvent.Payload["SeverityId"]),
                    InfoCollection = new List<InfoDTO>()
                                    {
                                        new InfoDTO
                                            {   SenderName=deviceId,//(string)wcfEvent.Payload["AdapterName"],
                                                Headline = "ACS Alert",//"ACS Alert",//(string)wcfEvent.Payload["Headline"],
                                                Description =errorCode,//"ACS Alert",//(string)wcfEvent.Payload["Description"],
                                                Instruction ="",//(string)wcfEvent.Payload["Instruction"],
                                                Contact ="", //(string)wcfEvent.Payload["Contact"], 
                                                UrgencyId = (Contracts.DTO.Urgency)Enum.Parse(typeof(Contracts.DTO.Urgency),Contracts.DTO.Urgency.Immediate.ToString()),//(Contracts.DTO.Urgency)Enum.Parse(typeof(Contracts.DTO.Urgency), (string)wcfEvent.Payload["UrgencyId"]),
                                                SeverityId = (Contracts.DTO.Severity)Enum.Parse(typeof(Contracts.DTO.Severity), Contracts.DTO.Severity.Extreme.ToString()),
                                                CertaintyId = (Contracts.DTO.Certainty)Enum.Parse(typeof(Contracts.DTO.Certainty),  Contracts.DTO.Certainty.Possible.ToString()),
                                                Event = errorCode,
                                                AreasCollection = new List<AreaDTO>()
                                                    {
                                                        new AreaDTO
                                                            {
                                                                SiteId = deviceDto.SiteId,
                                                                Latitude = Convert.ToDouble(deviceDto.Lat),
                                                                Longitude = Convert.ToDouble(deviceDto.Long),
                                                                Altitude =Convert.ToDouble(deviceDto.Altitude)
                                                            }
                                                    }
                                            }
                                    }
                };

                try
                {
                   // alert.DeviceDto = deviceDto; //amit 24102016
                    //_alertCreationService.SubmitNewAlert(alert);    //trupti to change calling of service because of broker distribution  
                    try
                    {
                        string _strUrl = "https://localhost:6530/soap/AlertsCreationService";
                        EndpointAddress ar = new EndpointAddress(_strUrl);
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
                        string _alert = SerializeAlertObject(alert);
                        _serVice.SubmitNewAlert(_alert);
                        _serVice.Close();
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {

                    }
                }
                catch (Exception es)
                {
                    Logger.Info("ACSIntegrationClass process data Exception" + es.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationClass process data Exception" + ex.Message);
            }

        }*/

        public static string SerializeAlertObject(AlertDTO _alert)
        {
            try
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(AlertDTO));
                string jsonCode;

                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, _alert);
                    jsonCode = Encoding.Default.GetString(ms.ToArray());
                }

                return jsonCode;
            }
            catch (Exception ex)
            { Logger.Info("StationsServiceImpl SerializeObject() Exception:" + ex.Message); }
            finally
            {

            }
            return null;
        }
        public static string GetCRCCheksum(string message)
        {
            try
            {
                int result = new int();
                string ResultChksum = string.Empty;
                int Len = message.Length;
                string[] hex = new string[Len];
                //======== Ascii conversion =========================================
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] ba = encoding.GetBytes(message);

                for (int i = 0; i <= ba.Length - 1; i++)
                {
                    hex[i] = String.Format("{0:X}", ba[i]);
                    if (i >= 1)
                    {
                        if (result == 0)
                            result = Convert.ToInt32(hex[0].ToString(), 16) ^ Convert.ToInt32(hex[i].ToString(), 16);
                        else
                            result = result ^ Convert.ToInt32(hex[i].ToString(), 16);
                    }
                }
                return result.ToString("X");
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationClass GetCRCCheksum Exception" + ex.Message);
                return string.Empty;
            }
        }

        public string GetCommand(string strCmd)
        {
            try
            {
                string strInPut = "$1IO,1," + strCmd;
                string strChk = GetCRCCheksum(strInPut);
                strInPut = strInPut + "," + strChk;// +"\n";
                return strInPut;
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationClass GetCommand Exception" + ex.Message);
            }
            return "";
        }

        public string DoorOpen(string strCmd, string CntrIp, string CntrPort)
        {
            try
            {
                string Message = "Acs integration class -DoorOpen()-- Command = " + strCmd + "-- CntrIp = " + CntrIp + "-- CntrPort = " + CntrPort;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin


                string strCommand = GetCommand(strCmd);

                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(CntrIp, Int32.Parse(CntrPort));
                NetworkStream networkStream = tcpClient.GetStream();
                StreamReader clientStreamReader = new StreamReader(networkStream);
                StreamWriter clientStreamWriter = new StreamWriter(networkStream);
                clientStreamWriter.Write(strCommand);

                char[] buf = new char[1024];
                while (true)
                {
                    clientStreamReader.Read(buf, 1, 5);
                    if (buf != null)
                        break;
                }

            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationClass DoorOpen Exception" + ex.Message);
                string Message = "Acs integration class -DoorOpen()-- Exception" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }

            return "Fail";
        }

        /*public string SelectEvent(int EventCode)
        {
            string EventDesc = "";

            switch (EventCode)
            {

                case 0:
                    EventDesc = "EVENT_FACLITY_ERR";
                    break;
                case 1:
                    EventDesc = "EVENT_VALID_CARD";
                    break;
                case 2:
                    EventDesc = "EVENT_CARD_NOT_FOUND";
                    break;
                case 3:
                    EventDesc = "EVENT_Card_Expired";
                    break;
                case 4:
                    EventDesc = "EVENT_TimeZone_Err";
                    break;
                case 5:
                    EventDesc = "EVENT_USER_RESTRICTED";
                    break;
                case 6:
                    EventDesc = "EVENT_FINGER_NOT_MATCH";
                    break;
                case 7:
                    EventDesc = "EVENT_HOLIDAY_NO_ACCESS";
                    break;
                case 8:
                    EventDesc = "EVENT_DOTL_ALARM";
                    break;
                case 10:
                    EventDesc = "EVENT_DOTL_ALARM_OFF";
                    break;
                case 12:
                    EventDesc = "EVENT_FORCE_ALARM";
                    break;
                case 14:
                    EventDesc = "EVENT_SYSTEM_RESET";
                    break;
                case 15:
                    EventDesc = "EVENT_APB_Err";
                    break;
                case 16:
                    EventDesc = "EVENT_PIN_VERIFICATION";
                    break;
                case 17:
                    EventDesc = "EVENT_INVALID_ACCESS";
                    break;
                case 20:
                    EventDesc = "EVENT_DUEL_USER_ACCESS_FAIL";
                    break;
                case 21:
                    EventDesc = "EVENT_DUEL_USER_2";
                    break;
                case 24:
                    EventDesc = "EVENT_INVALID_CARD";
                    break;
                case 25:
                    EventDesc = "EVENT_ADMIN_LOGIN";
                    break;
                case 26:
                    EventDesc = "EVENT_DOOR_OPEN_EGRESS";
                    break;
                case 27:
                    EventDesc = "EVENT_SYSTEM_INI";
                    break;
                case 28:
                    EventDesc = "EVENT_ESCORT_CARD";
                    break;
                case 29:
                    EventDesc = "DOOR_INTERLOCK";
                    break;
                case 30:
                    EventDesc = "EVENT_DOOR_NOT_OPEN";
                    break;
                case 31:
                    EventDesc = "EVENT_LAST_CARD_ERROR";
                    break;
                case 34:
                    EventDesc = "EVENT_DURESS_ACCESS";
                    break;
                case 35:
                    EventDesc = "EVENT_TIME_BASED_ACTION";
                    break;
                case 36:
                    EventDesc = "EVENT_DEAD_MAN_ZONE";
                    break;
                case 37:
                    EventDesc = "EVENT_OCCUPANCY_FULL";
                    break;
                case 38:
                    EventDesc = "EVENT_INTRUSION_ALARM_HIGH";
                    break;
                case 39:
                    EventDesc = "EVENT_INTRUSION_ALARM_LOW";
                    break;
                case 40:
                    EventDesc = "EVENT_FIRE_ALARM_HIGH";
                    break;
                case 41:
                    EventDesc = "EVENT_FIRE_ALARM_LOW";
                    break;
                case 42:
                    EventDesc = "EVENT_TAMPER_ALARM_HIGH";
                    break;
                case 43:
                    EventDesc = "EVENT_TAMPER_ALARM_LOW";
                    break;
                case 44:
                    EventDesc = "EVENT_SC_KEY_MISMATCH";
                    break;
                case 56:
                    EventDesc = "EVENT_INTRUSION_CARD";
                    break;
                case 57:
                    EventDesc = "EVENT_OCCUPANCY_CONTROL_CARD";
                    break;
                case 58:
                    EventDesc = "EVENT_OVERRIDE_ACCESS_CARD";
                    break;
                case 59:
                    EventDesc = "EVENT_FIRST_INUSER_CARD";
                    break;
                case 60:
                    EventDesc = "EVENT_EMERGENCY_CARD";
                    break;
                case 61:
                    EventDesc = "EVENT_DONOT_DISTURB_CARD";
                    break;
                case 62:
                    EventDesc = "EVENT_ALERT_CARD";
                    break;
                case 63:
                    EventDesc = "EVENT_NORMAL_CARD";
                    break;
                case 68:
                    EventDesc = "PHYSICALLY_DOOR_CLOSE";
                    break;
                case 69:
                    EventDesc = "PHYSICALLY_DOOR_OPEN";
                    break;
                case 70:
                    EventDesc = "EVENT_FIRST_INCARD_NOT_FOUND";
                    break;
                case 71:
                    EventDesc = "EVENT_DMZ_RESET_CARD";
                    break;
                case 72:
                    EventDesc = "EVENT_DONOT_DSTRB_MODE";
                    break;
                case 73:
                    EventDesc = "EVENT_DONOT_DISTURBZONE_CARD";
                    break;
                case 74:
                    EventDesc = "EVENT_LOGGING(apb error)";
                    break;
                case 75:
                    EventDesc = "EVENT_SPCL_CARD_NOT_FOUND";
                    break;
                case 76:
                    EventDesc = "EVENT_DR_PC_NORMAL";
                    break;
                case 77:
                    EventDesc = "EVENT_DR_PC_USER_OPEN";
                    break;
                case 78:
                    EventDesc = "EVENT_DR_PC_USER_CLOSE";
                    break;
                case 79:
                    EventDesc = "EVENT_UACC_ATT_TYPE";
                    break;
                case 80:
                    EventDesc = "EVENT_SERVER_CHECK_TIMEOUT";
                    break;

            }
            return EventDesc;

        }*/

        private void StartReceive()
        {
            byte[] buff = new byte[1024];
            // Here we use the Async Receive to allow
            // concurrent packets to be received.
            // for some reason the synchronous version
            // of this command throws concurrent 
            // packets away
            mListener.BeginReceive(buff, 0, buff.Length, SocketFlags.None,
                new AsyncCallback(DataReceived), buff);
        }

        private void DataReceived(IAsyncResult ar)
        {
            byte[] buff = (byte[])ar.AsyncState;
            if (buff != null)
            {
                /* AppCommand cmd = AppCommandTranslator.FromBinary(buff);
                 if (mCallBack != null)
                     mCallBack(cmd);*/
                StartReceive();
            }
        }

        

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    }
}
