using AMS.Broker.Contracts.DTO;
using AMS.Broker.TwTwFFTAdapterService.Interfaces;
using NLog;
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
using System.Xml;

namespace AMS.Broker.TwTwFFTAdapterService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FFTAdapterService : IFFTAdapterService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static Cams3SdkUser cams3SdkUser = null;

        internal static IFFTAdapterService Initialise()
        {
            try
            {
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting FFTAdapterService Service");

                InsertFFTAdapterOperationLog.AddProcessLogFFTAdapterOperation("");
                InsertFFTAdapterOperationLog.AddProcessLogFFTAdapterOperation("------------------------------------");
                InsertFFTAdapterOperationLog.AddProcessLogFFTAdapterOperation("starting FFTAdapterService Service");

                var service = new FFTAdapterService();
                Uri httpUrl = new Uri("https://localhost:6530/FFTAdapterService");

                WebServiceHost controllerHost
                = new WebServiceHost(typeof(FFTAdapterService), httpUrl);
                
                WebHttpBinding _webhttpbis = new WebHttpBinding(WebHttpSecurityMode.Transport);
                // WSHttpBinding _webhttpbis = new WSHttpBinding(SecurityMode.Transport);
               
                _webhttpbis.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.CloseTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.OpenTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.SendTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.MaxBufferPoolSize = 2147483647;//524288;
                _webhttpbis.MaxBufferSize = 2147483647;
                _webhttpbis.MaxReceivedMessageSize = 2147483647;//1073741823;
                _webhttpbis.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

                XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
                myReaderQuotas.MaxStringContentLength = 2147483647;
                myReaderQuotas.MaxArrayLength = 2147483647;
                myReaderQuotas.MaxBytesPerRead = 2147483647;
                myReaderQuotas.MaxDepth = 2147483647;
                myReaderQuotas.MaxNameTableCharCount = 2147483647;

                _webhttpbis.GetType().GetProperty("ReaderQuotas").SetValue(_webhttpbis, myReaderQuotas, null);
                //_webhttpbis.CrossDomainScriptAccessEnabled = true;
                var endpoint = controllerHost.AddServiceEndpoint(typeof(IFFTAdapterService), _webhttpbis, "");//WSHttpBinding

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

                _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                _logger.Info("------------------------------------");
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016   

                if (cams3SdkUser == null)
                {
                    cams3SdkUser = new Cams3SdkUser();                  
                }

                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("FFTAdapterService Initialise() Exception" + ex.Message);
                InsertFFTAdapterOperationLog.AddProcessLogFFTAdapterOperation("FFTAdapterService Initialise() Exception" + ex.Message);
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("FFTAdapterService service  Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            InsertFFTAdapterOperationLog.AddProcessLogFFTAdapterOperation("FFTAdapterService service  Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
        }

        public FFTAdapterService()
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)] 
        public List<SdkCtrlDataDto> GetController()
        {
            try
            {
                List<SdkCtrlDataDto> camsGetControllerlist = new List<SdkCtrlDataDto>();
                if (cams3SdkUser != null)
                {
                    var camsGetController = cams3SdkUser.GetControllers();
                    if (camsGetController != null)
                    {
                        foreach (var cntr in camsGetController)
                        {
                            SdkCtrlDataDto _SdkCtrlDataDto = new SdkCtrlDataDto { 
                                Connected=cntr.Connected,
                                Description = cntr.Description,
                                HostName = cntr.HostName,
                                Id = cntr.Id,
                                IpAddress = cntr.IpAddress,
                                Locator = cntr.Locator,
                                Name = cntr.Name,
                                Port = cntr.Port
                            };
                            camsGetControllerlist.Add(_SdkCtrlDataDto);
                        }

                        return camsGetControllerlist;
                    }
                }
            }
            catch (Exception ex)
            { 
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<SdkZoneDataDTO> GetFFTZones()
        {
            try
            {              
                List<SdkZoneDataDTO> camsGetFFTZonelist = new List<SdkZoneDataDTO>();

                if (cams3SdkUser != null)
                {
                    var camsGetFFTZone = cams3SdkUser.GetZones();
                    if (camsGetFFTZone != null)
                    {
                        foreach (var cntr in camsGetFFTZone)
                        {
                           
                            List<SensorSectionDto> _SensorSections = new List<SensorSectionDto>();

                            foreach (var __SensorSections in cntr.SensorSections)
                            {
                                 List<CoordinateDto> Points = new List<CoordinateDto>();
                                 foreach (var _cord in __SensorSections.Points)
                                 {
                                     CoordinateDto _CoordinateDto = new CoordinateDto { 
                                         Alt = _cord .Alt,
                                         IsEmpty=_cord.IsEmpty,
                                         Lat=_cord.Lat,
                                         Long=_cord.Long
                                     };

                                     Points.Add(_CoordinateDto);
                                 }
                                SensorSectionDto _SensorSectionDto = new SensorSectionDto {
                                 CableEnd=__SensorSections.CableEnd,
                                 CableStart=__SensorSections.CableStart,
                                 Opposite=__SensorSections.Opposite,
                                 PerimeterEnd=__SensorSections.PerimeterEnd,
                                 PerimeterStart=__SensorSections.PerimeterStart,
                                 Points=Points,
                                 Reversed=__SensorSections.Reversed,
                                 SectionId=__SensorSections.SectionId,
                                 SensorEndIdx=__SensorSections.SensorEndIdx,
                                 SensorId=__SensorSections.SensorId,
                                 SensorStartIdx=__SensorSections.SensorStartIdx,
                                 ServerId=__SensorSections.ServerId                                 
                                };

                                _SensorSections.Add(_SensorSectionDto);
                            }
                            SdkZoneDataDTO _SdkZoneDataDTO = new SdkZoneDataDTO
                            {
                                Isolated = cntr.Isolated,
                                Description = cntr.Description,
                                Id = cntr.Id,
                                Name = cntr.Name,
                                SensorSections = _SensorSections
                            };
                            camsGetFFTZonelist.Add(_SdkZoneDataDTO);
                        }

                        return camsGetFFTZonelist;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<SdkSensorDataDto> GetFFTSensor()
        {
            try
            {               
                //List<Fft.Cams.Sdk.SdkSensorData> sensors = cams3SdkUser.GetSensors();
                List<SdkSensorDataDto> camsGetFFTSensorlist = new List<SdkSensorDataDto>();
                if (cams3SdkUser != null)
                {
                    var camsGetFFTSensor = cams3SdkUser.GetSensors();
                    if (camsGetFFTSensor != null)
                    {
                        foreach (var _sensor in camsGetFFTSensor)
                        {
                            List<CoordinateDto> _DrawingPoints = new List<CoordinateDto>();
                            foreach (var _cor in _sensor.DrawingPoints)
                            {
                                CoordinateDto _CoordinateDto = new CoordinateDto
                                {
                                    Alt = _cor.Alt,
                                    IsEmpty = _cor.IsEmpty,
                                    Lat = _cor.Lat,
                                    Long = _cor.Long
                                };
                                _DrawingPoints.Add(_CoordinateDto);
                            }
                            List<SensorPointDto> _SensorPoints = new List<SensorPointDto>();
                            foreach (var _cor in _sensor.SensorPoints)
                            {
                                CoordinateDto _CoordinateDto = new CoordinateDto
                                {
                                    Alt = _cor.coordinate.Alt,
                                    IsEmpty = _cor.coordinate.IsEmpty,
                                    Lat = _cor.coordinate.Lat,
                                    Long = _cor.coordinate.Long
                                };
                                SensorPointDto _SensorPointDto = new SensorPointDto
                                {
                                    cableDistance = _cor.cableDistance,
                                    calibrationPoint = _cor.calibrationPoint,
                                    calibrationPointName = _cor.calibrationPointName,
                                    coordinate = _CoordinateDto,
                                    id = _cor.id,
                                    perimeterDistance = _cor.perimeterDistance,
                                    seq = _cor.seq
                                };
                                _SensorPoints.Add(_SensorPointDto);
                            }
                            SdkSensorDataDto _SdkSensorDataDto = new SdkSensorDataDto
                            {
                                ControllerId = _sensor.ControllerId,
                                DrawingPoints = _DrawingPoints,
                                Id = _sensor.Id,
                                Name = _sensor.Name,
                                Number = _sensor.Number,
                                SensorPoints = _SensorPoints
                            };
                            camsGetFFTSensorlist.Add(_SdkSensorDataDto);
                        }

                        return camsGetFFTSensorlist;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string Test()
        {
            return "Hello World";
        }
    }
}
