using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.Services;
using NLog;
using AMS.Broker.Contracts.DTO;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using ResourceDTO = AMS.Broker.Contracts.DTO.Resource;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using EventDTO = AMS.Broker.Contracts.DTO.Event;
using System.Runtime.Serialization.Json;
using System.IO;
using AMS.Broker.IntegrationService.DataStore;
using AutoMapper;
using System.Net.Sockets;


namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public sealed class ACSIntegrationService : IWcfACSIntegrationService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        

        public ACSIntegrationService()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService constructor Exception" + ex.Message);
            }
           
        }

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
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
            }
        }

        internal static ACSIntegrationService Initialise()
        {
            try
            {
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting ACS Integration service");

                var service = new ACSIntegrationService();

                var controllerHost = new ServiceHost(service);

                foreach (var endpoint in controllerHost.Description.Endpoints)
                {
                    if (endpoint.Binding is WSHttpBinding)
                    {
                        (endpoint.Binding as WSHttpBinding).MaxReceivedMessageSize = Int32.MaxValue;
                        (endpoint.Binding as WSHttpBinding).MaxBufferPoolSize = Int32.MaxValue;
                    }
                }
                controllerHost.Open();

                //
                //ACSIntegrationClass ObjAcs = new ACSIntegrationClass();
                //ObjAcs.StartUDPServer();
                //

                _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                _logger.Info("------------------------------------");

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016 

                return service;


            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService start Exception" + ex.Message);
                string Message = "ACSIntegrationService--start Exception  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            Logger.Info("ACSIntegrationService   Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            string Message = "ACSIntegrationService--Unhandled UI Exception  = " + (e.ExceptionObject as Exception).Message;
            //InsertBrokerOperationLog.AddProcessLog(Message);
            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin

        }

        public string TestMethod(string Username, string Passward)
        {

            _logger.Info("");
            _logger.Info("------------------------------------");
            _logger.Info("starting ACS Integration Method ");
            ClearMemory();
            return Username;
        }

       

        public static string SerializeObject(IEnumerable<AlertDTO> graph)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<AlertDTO>));
                string jsonCode;

                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, graph);
                    jsonCode = Encoding.Default.GetString(ms.ToArray());
                }               
                return jsonCode;
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService SerializeObject Exception" + ex.Message);
                string Message = "ACSIntegrationService--SerializeObject Exception  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }
        private static IEnumerable<AlertDTO> DeserializeAlerts(string alerts)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<AlertDTO>));
                IEnumerable<AlertDTO> alertDto = null;
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(alerts)))
                {
                    alertDto = serializer.ReadObject(stream) as IEnumerable<AlertDTO>;
                }
              
                return alertDto;
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService DeserializeAlerts Exception" + ex.Message);

                string Message = "ACSIntegrationService--DeserializeAlerts Exception  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }

        public string TCP(string IP, string port, string command, string ResponceTime)
        {
            // int slaveid = Convert.ToInt32(slave);
            try
            {
                string ss = "";
                try
                {

                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.ReceiveTimeout = Convert.ToInt32(ResponceTime);
                    tcpclnt.SendTimeout = 500;
                    IAsyncResult syncResult = tcpclnt.BeginConnect(IP, int.Parse(port), null, null);
                    bool connectionStatus = syncResult.AsyncWaitHandle.WaitOne(1000, true);
                    if (!connectionStatus)
                    {
                        tcpclnt.Close();
                        tcpclnt = null;
                        // throw new ApplicationException("Connection timeout for controller");
                    }
                    tcpclnt.ReceiveBufferSize = 256;
                    tcpclnt.SendBufferSize = 256;
                    NetworkStream stm = tcpclnt.GetStream();
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] CRC = new byte[2];
                    byte[] ba = System.Text.Encoding.Default.GetBytes(command); //asen.GetBytes(command);             
                    byte[] msg = new byte[ba.Length + 2];
                    for (int i = 0; i < ba.Length; i++)
                    {
                        msg[i] = ba[i];

                    }
                    //GetCRC(msg, ref CRC);
                    //msg[msg.Length - 2] = CRC[0];
                    //msg[msg.Length - 1] = CRC[1];
                    stm.Write(msg, 0, msg.Length);
                    stm.Flush();
                    byte[] bb = new byte[5000];
                    System.Threading.Thread.Sleep(500);
                    int k = stm.Read(bb, 0, 5000);
                    //ss = Encoding.ASCII.GetString(bb, 0, k);
                    StringBuilder s = new StringBuilder();
                    s.Append(System.Text.Encoding.Default.GetString(bb));
                    //for (int m = 0; m < k - 1; m++)
                    //{
                    //    s.Append(GetChar(bb[m].ToString()));
                    //}
                    // ss = Encoding.ASCII.GetString(bb, 0, k);
                    ss = s.ToString();
                    s.Clear();
                    tcpclnt.Close();
                    tcpclnt = null;
                   
                    return ss;
                }
                catch (Exception ex)
                {                
                    return "#Fail";
                }               
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService TCP() Function Exception" + ex.Message);
                string Message = "ACSIntegrationService--TCP() Function Exception  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;

        }
        [WebGet(UriTemplate = "DoorOpen/{strCmd}/{CntrIp}/{CntrPort}")]
        public string DoorOpen(string strCmd, string CntrIp, string CntrPort)
        {
            try
            {
                try
                {
                    int nChannel = Int32.Parse(strCmd);
                    string strCmdNew = "lO,1," + nChannel.ToString() + ",36,";
                    string strCommand = GetCommand(strCmdNew);
                    string result = TCP(CntrIp, CntrPort, strCommand, "1000");                    
                    return "Suc";
                }
                catch (Exception ex)
                {
                    Logger.Info("ACSIntegrationService DoorOpen() Exception" + ex.Message);
                    string Message = "ACSIntegrationService--DoorOpen() Function Exception  = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                }

            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService DoorOpen() Exception" + ex.Message);
                string Message = "ACSIntegrationService--DoorOpen() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return "Fail";
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
                Logger.Info("ACSIntegrationService GetCRCCheksum() Exception" + ex.Message);

                string Message = "ACSIntegrationService--GetCRCCheksum() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                return string.Empty;
            }
            finally
            {
                ClearMemoryStatic();
            }
        }

        public static string CharValue(string a)
        {
            //char value = (char)(Convert.ToInt32(a) + 48);
            //return value.ToString(); 
            try
            {
                string value = "";
                value = Convert.ToChar((Convert.ToInt32(a) + 48)).ToString();
              
                return value.ToString();
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService CharValue() Exception" + ex.Message);
                string Message = "ACSIntegrationService--CharValue() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }
        public string GetCommand(string strCmd)
        {
            try
            {
                string CHECKSUM = GetCRCCheksum("$" + CharValue("1") + strCmd);
                strCmd = "$" + CharValue("1") + strCmd + CHECKSUM + "\r\n";

                string strInPut = strCmd;// +strCmd;                 
                return strInPut;
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService GetCommand() Exception" + ex.Message);
                string Message = "ACSIntegrationService--GetCommand() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return "";
        }

        [WebGet(UriTemplate = "DoorClose/{strCmd}/{CntrIp}/{CntrPort}")]
        public string DoorClose(string strCmd, string CntrIp, string CntrPort)
        {
            try
            {
                int nChannel = Int32.Parse(strCmd);
                string strCmdNew = "lO,2," + nChannel.ToString() + ",36,";
                string strCommand = GetCommand(strCmdNew);
                string result = TCP(CntrIp, CntrPort, strCommand, "1000");
               
                return "Suc";
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService DoorClose() Exception" + ex.Message);
                string Message = "ACSIntegrationService--DoorClose() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return "Fail";
        }

        public string SelectEvent(int EventCode)
        {
            try
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
            }
            catch (Exception ex)
            {
                Logger.Info("ACSIntegrationService SelectEvent() Exception" + ex.Message);
                string Message = "ACSIntegrationService--SelectEvent() Function Exception 1  = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
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
