using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts;
using AMS.Broker.Contracts.Services;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.ServiceModel.Channels;
using NLog;
using AMS.Broker.Contracts.DTO;
using System.Diagnostics;
using System.Globalization;
using AMS.Broker.IntegrationService.DataStore;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CamTcpListenerService : ICamTcpListenerService
    {
        public static bool Listen=true;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
       // public static IList<CamDeviceInfo> _devInfolst = new List<CamDeviceInfo>();

        public static IList<CamDeviceInfo> _devInfolst = new List<CamDeviceInfo>();

        public static void CreateDeviceInfoColletion()
        {
            try
            {
                Logger.Info("Started creating list : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",CultureInfo.InvariantCulture)); 
                /*int FirstDigit=1;
                int SecondDigit=0;
                for (int i = 1; i <= 20000; i++)
                {
                    
                    string strIp="192.168."+SecondDigit.ToString() +"." + FirstDigit.ToString();
                    CamDeviceInfo _CamDeviceInfo = new CamDeviceInfo
                    {
                        DeviceID=i,
                        DeviceName="Test"+i.ToString(),
                        DeviceIp = strIp
                    };
                    try
                    {
                        _devInfolst.Add(_CamDeviceInfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    FirstDigit++;
                    if (FirstDigit >= 254)
                    {
                        FirstDigit = 1;
                        SecondDigit++;
                    }
                }*/

                using (var context = new CentralDBEntities())
                {
                    Logger.Info("");
                    Logger.Info("CamTcpListenerService: CreateDeviceInfoColletion");

                    var resultsCollection = context.Device.Where(x => x.Type == "NvrCamera").ToList();

                    Logger.Info("  items count: {0}", resultsCollection.Count());
                    Logger.Info("------------------------------------");

                   
                    if (resultsCollection.Count() > 0)
                    {
                        foreach (var _device in resultsCollection)
                        {                            
                            var entity = _device as NvrCamera;
                            CamDeviceInfo _CamDeviceInfo = new CamDeviceInfo
                            {
                                DeviceID =Int32.Parse(entity.DeviceId.ToString()),
                                DeviceName = entity.Name,
                                DeviceIp = entity.CameraIp,
                                DeviceUsername = entity.CamUser,
                                DevicePassword = entity.CamPassword,
                                DeviceUrl = entity.CameraUrl,
                                siteID =Int32.Parse(entity.SiteId.ToString())
                            
                            };
                            try
                            {
                                _devInfolst.Add(_CamDeviceInfo);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
            }
            Logger.Info("Finish creating list : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)); 
        }
        public void ProcessData(string strData,DateTime dt,string camIp)
        {
            try
            {
                Logger.Info("Received ProcessData start : " + strData.ToString() + " from : " + camIp + " StartTime " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
                var _devInfo = _devInfolst.FirstOrDefault(x => x.DeviceIp == camIp);
                Logger.Info("Received ProcessData get device info finish : " + _devInfo.DeviceName.ToString() + " from : " + _devInfo.DeviceID + " finishTime " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
                var childSocketThread = new Thread(() =>
                            {
                                try
                                {
                                    StartProcessing();
                                }
                                catch (Exception ex)
                                {
                                    Debug.Print("ProcessData: " + ex.ToString());                                    
                                }
                            });
                            childSocketThread.Start();  
            }
            catch (Exception ex)
            { 
            }
        }
        public void StartProcessing()
        {
            try
            {

            }
            catch (Exception ex)
            { }
        }

        public void StartListner()
        {
            try
            {
                byte[] receiveBuffer = new byte[10025];

              //  IPAddress ipAddress = IPAddress.Parse("192.168.0.230");

                string hostName = Dns.GetHostName(); // Retrive the Name of HOST                
                string strIpAddress = Dns.GetHostByName(hostName).AddressList[0].ToString(); // Get the IP

                IPAddress ipAddress = IPAddress.Parse(strIpAddress);

                Console.WriteLine("Starting TCP listener...");

                TcpListener listener = new TcpListener(ipAddress, 23);

                listener.Start();

                while (Listen)
                {
                    using (var tcpClient = listener.AcceptTcpClient())
                    {
                        Debug.Print(" >> Accepted connection from client");

                        using (var networkStream = tcpClient.GetStream())
                        {
                            string dataFromClient = "";
                            var bytesRead = networkStream.Read(receiveBuffer, 0, (int)tcpClient.ReceiveBufferSize);
                            if (bytesRead == 0)
                            {
                                // Read returns 0 if the client closes the connection
                            }
                            else
                            {
                                dataFromClient = System.Text.Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
                                string _ipAddress=((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                ProcessData(dataFromClient, DateTime.Now, _ipAddress);
                            }
                        }
                        Debug.Print(" >> stopped read loop");
                    }
                }

                listener.Stop();
                listener = null;

            }
            catch (Exception x)
            {
            }
        }
        internal static ICamTcpListenerService Initialise()
        {
            try
            {
                Logger.Info("");
                Logger.Info("------------------------------------");
                Logger.Info("starting CamTcpListenerService service");

                try
                {
                    var service = new CamTcpListenerService();

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
                            Logger.Info("CamTcpListenerService Initialise() Exception:" + ex.Message);
                            string Message = "CamTcpListenerService-Initialise -- Exception = " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message);
                            InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                        }
                    }
                    controllerHost.Open();
                    CreateDeviceInfoColletion();
                   // StartListner();
                    Logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                    Logger.Info("------------------------------------");                                       

                    return service;
                }
                catch (Exception ex)
                {
                    Logger.Info("CamTcpListenerService Initialise() Exception:" + ex.Message);
                    string Message = "CamTcpListenerService-Initialise -- Exception1 = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message);
                    InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
                }

                //_myThread = new Thread(ThreadProc);

                return null;
            }
            catch (Exception ex)
            {
                Logger.Info("CamTcpListenerService Initialise() Exception:" + ex.Message);
                string Message = "CamTcpListenerService-Initialise -- Exception2 = " + ex.Message;
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
        public static void ClearMemoryStatic()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "CamTcpListenerService-ClearMemoryStatic -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }
        public void ConsumeEvent(string strData)
        {
            try
            {
                
            }
            catch (Exception)
            { }
        }
    }

    public class CamDeviceInfo
    {
        public string DeviceName { get; set; }
        public int DeviceID { get; set; }
        public string DeviceIp { get; set; }
        public string DeviceUsername { get; set; }
        public string DevicePassword { get; set; }
        public int siteID { get; set; }
        public string DeviceUrl { get; set; }
    }
}
