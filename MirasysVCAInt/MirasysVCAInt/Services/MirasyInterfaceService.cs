using AMS.Broker.Contracts.DTO;
using MirasysVCAInt.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MirasysVCAInt.Services
{   
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MirasyInterfaceService : IMirasyInterfaceService
    {
       
        public static MirasysVaInterface MirasysVaInterface = null;

        internal static IMirasyInterfaceService Initialise(MirasysVaInterface _MirasysVaInterface)
        {

            InsertLog.AddLog("MirasyInterfaceService Initialise()");
            MirasysVaInterface = _MirasysVaInterface;
            var service = new MirasyInterfaceService();
            Uri httpUrl = new Uri("https://localhost:6530/MirasyInterfaceService");

            WebServiceHost controllerHost
            = new WebServiceHost(typeof(MirasyInterfaceService), httpUrl);

            WebHttpBinding _webhttpbis = new WebHttpBinding(WebHttpSecurityMode.Transport);

            _webhttpbis.ReceiveTimeout = TimeSpan.Parse("00:10:00");
            _webhttpbis.CloseTimeout = TimeSpan.Parse("00:10:00");
            _webhttpbis.OpenTimeout = TimeSpan.Parse("00:10:00");
            _webhttpbis.SendTimeout = TimeSpan.Parse("00:10:00");
            _webhttpbis.MaxBufferPoolSize = 2147483647;//524288;
            _webhttpbis.MaxBufferSize = 2147483647;
            _webhttpbis.MaxReceivedMessageSize = 2147483647;//1073741823;
            _webhttpbis.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;


            var endpoint = controllerHost.AddServiceEndpoint(typeof(IMirasyInterfaceService), _webhttpbis, "");//WSHttpBinding

            ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
            {
                MaxConcurrentCalls = 500,
                MaxConcurrentInstances = 500,
                MaxConcurrentSessions = 500,
            };

            controllerHost.Description.Behaviors.Add(throttleBehavior);

            var _ServiceMetadataBehavior = controllerHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (_ServiceMetadataBehavior == null)
            {
                _ServiceMetadataBehavior = new ServiceMetadataBehavior();
                controllerHost.Description.Behaviors.Add(_ServiceMetadataBehavior);
            }

            _ServiceMetadataBehavior.HttpGetEnabled = true;
            _ServiceMetadataBehavior.HttpsGetEnabled = true;

            var _ServiceDebugBehavior = controllerHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            if (_ServiceDebugBehavior == null)
            {
                _ServiceDebugBehavior = new ServiceDebugBehavior();
                controllerHost.Description.Behaviors.Add(_ServiceDebugBehavior);
            }
            _ServiceDebugBehavior.IncludeExceptionDetailInFaults = true;

            var serviceCredential = controllerHost.Description.Behaviors.Find<ServiceCredentials>();
            if (serviceCredential == null)
            {
                serviceCredential = new ServiceCredentials();
                controllerHost.Description.Behaviors.Add(serviceCredential);
            }

            serviceCredential.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
               StoreName.My,
               X509FindType.FindByThumbprint,
               "f55bf424542522c6a6d833f933431a31baaf43de");
            controllerHost.Open();
            InsertLog.AddLog("MirasyInterfaceService Started Successfully");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016   

            return null;
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {

        }
        public string Test()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return "";
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IList<MirasysDeviceDetails> GetMirasysCamDeviceList(string MirasysNvrIP, string MirasysNvrPort, string MirasysUserName, string MirasysPassword)
        {
            try
            {
                InsertLog.AddLog("MirasyInterfaceService GetMirasysCamDeviceList() DevList MirasysNvrIP:" + MirasysNvrIP + "--!--MirasysNvrPort:" + MirasysNvrPort + "--!--MirasysUserName:" + MirasysUserName + "--!--MirasysNvrPort:" + MirasysPassword);
             var DevList= MirasysVaInterface.getCamDeviceList();

             InsertLog.AddLog("MirasyInterfaceService GetMirasysCamDeviceList() DevList Count:" + DevList.Count());

             return DevList;
            }
            catch (Exception ex)
            {
                InsertLog.AddLog("MirasyInterfaceService GetMirasysCamDeviceList() Exception:"+ex.Message);
            }
            return null;
        }
     

    }
}

