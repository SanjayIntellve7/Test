using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AutoMapper;
using CacheAspect;
using CacheAspect.Attributes;
using Microsoft.Practices.Unity;
using NLog;

using EventDTO = AMS.Broker.Contracts.DTO.Event;
using GroupDTO = AMS.Broker.Contracts.DTO.Group;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using IncidentReportDto = AMS.Broker.Contracts.DTO.IncidentReport;
using StationDTO = AMS.Broker.Contracts.DTO.Station;
using Alert = AMS.Broker.Contracts.DTO.Alert;
using ValuesLookUpDTO = AMS.Broker.Contracts.DTO.ValuesLookUp;
using IncidentReportDTO = AMS.Broker.Contracts.DTO.IncidentReport;
using System.Security;

namespace AMS.Broker.AutherizationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MobileAppCommunicationService : IMobileAppCommunicationService
    {
        IMobileAppCommunicationService _mobileAppCommunicationService;
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public MobileAppCommunicationService()
        {
            _mobileAppCommunicationService = BrokerService.Container.Resolve<IMobileAppCommunicationService>();

        }

        internal static IMobileAppCommunicationService Initialise()
        {
            try
            {
                _logger.Info("");
                _logger.Info("------------------------------------");
                _logger.Info("starting MobileAppCommunication Service.");

                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                InsertAuthLog.AddProcessLogAuth("starting MobileAppCommunication Service.");//jatin

                var service = new MobileAppCommunicationService();//alertservice
                var controllerHost = new ServiceHost(service);
                controllerHost.Open();

                /*service.GetContactsCollection(string.Empty);*/
                /*service.GetAccountsCollection(string.Empty);*/

                _logger.Info(string.Format("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri));
                _logger.Info("------------------------------------");
                _logger.Info("");
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016       
                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService Initialise() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService Initialise() Exception" + ex.Message); // jatin
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public int ChangePasswordNew(string username, string oldPassword, string newPassword) //amit 27102017// for web client and mobile app only 
        {
            return _mobileAppCommunicationService.ChangePasswordNew(username, oldPassword, newPassword);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionMobSiteId(string authToken, long siteId)
        {
            return _mobileAppCommunicationService.GetDevicesCollectionMobSiteId(authToken, siteId);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionMob(string authToken)
        {
            return _mobileAppCommunicationService.GetDevicesCollectionMob(authToken);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionWeb(string authToken)
        {
            return _mobileAppCommunicationService.GetDevicesCollectionWeb(authToken);
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<AlertMobDto> GetMobileSingleAlert(string authToken, int alertID)
        {
            return _mobileAppCommunicationService.GetMobileSingleAlert(authToken, alertID);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<SiteDto> GetAllSites(string authToken)
        {
            return _mobileAppCommunicationService.GetAllSites(authToken);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string GetRepositoryConfiguration(string authToken)
        {
            return _mobileAppCommunicationService.GetRepositoryConfiguration(authToken);
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken)
        {
            return _mobileAppCommunicationService.GetMobCurrentOpenAlerts(authToken);
        }

        [WebInvoke(Method = "GET")]
        public string GetMobCurrentOpenAlertsCount(string authToken)
        {
            return _mobileAppCommunicationService.GetMobCurrentOpenAlertsCount(authToken); ;
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<Alert> GetCurrentOpenAlerts(string authToken)
        {
            return _mobileAppCommunicationService.GetCurrentOpenAlerts(authToken);
        }

        [WebInvoke(Method = "GET")]
        public bool AcknowledgeAlertsMobile(string authToken, string alerts)
        {
            var acknowledgeIds = _mobileAppCommunicationService.AcknowledgeAlertsMobile(authToken, alerts);
            return acknowledgeIds;
        }

        [WebInvoke(Method = "GET")]
        public bool CancelAlertsMobile(string alerts)
        {
            var canceledAlarms = _mobileAppCommunicationService.CancelAlertsMobile(alerts);
            return canceledAlarms;
        }

        [WebInvoke(Method = "GET")]
        public bool CreateDummySimulatorAlerts(string alertcode)
        {
            return _mobileAppCommunicationService.CreateDummySimulatorAlerts(alertcode);
        }

        [WebInvoke(Method = "GET")]
        public bool AnimateMapPin()
        {
            _mobileAppCommunicationService.AnimateMapPin();
            return false;
        }

        [WebInvoke(Method = "GET")]
        public bool CreateMobileAlert(string urgency, string severity, string certainty, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No)
        {
            return _mobileAppCommunicationService.CreateMobileAlert(urgency, severity, certainty, note, lattitude, longitude, retPath, retVoicenotePath, retVideoPath, Imei_No);
        }

        // saurabh changes for mobile app 16112017
        [WebInvoke(Method = "GET")]
        public DeviceDto GetDeviceById(string authToken, long deviceId)//saurabh 13112017
        {
            return _mobileAppCommunicationService.GetDeviceById(authToken, deviceId);
        }


        [WebInvoke(Method = "POST")]
        public string UpdloadMediaPic(Stream strData)//amit 10/10/2017//saurabh 13112017
        {
            try
            {
                return _mobileAppCommunicationService.UpdloadMediaPic(strData);
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        [WebInvoke(Method = "POST")]
        public string UpdloadMediaAudio(Stream strData)//amit 10/10/2017 //saurabh 13112017
        {
            try
            {
                return _mobileAppCommunicationService.UpdloadMediaAudio(strData);
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        [WebInvoke(Method = "POST")]
        public string UpdloadMediaVideo(Stream strData)//amit 10/10/2017 //saurabh 13112017
        {
            try
            {
                return _mobileAppCommunicationService.UpdloadMediaVideo(strData);
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        //end saurabh changes

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("Controller Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            InsertAuthLog.AddProcessLogAuth("Controller Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);//jatin
        }

        [WebInvoke(Method = "GET")]
        public bool UpdateMobileAlert(string alertId, string retPath, string retVoicenotePath, string retVideoPath)
        {
            return _mobileAppCommunicationService.UpdateMobileAlert(alertId, retPath, retVoicenotePath, retVideoPath);
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool RegisterStation(string authToken, string identifier, string type, string description, string metadata, string longitued = null, string latitude = null)
        {
            return _mobileAppCommunicationService.RegisterStation(authToken, identifier, type, description, metadata, longitued = null, latitude = null);
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public Station ActivateStation(string authToken, string identifier)
        {
            return _mobileAppCommunicationService.ActivateStation(authToken, identifier);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public Station ActivateWebClient(string authToken, string identifier)
        {
            return _mobileAppCommunicationService.ActivateWebClient(authToken, identifier);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void DeactivateStation(string authToken, string identifier)
        {
            _mobileAppCommunicationService.DeactivateStation(authToken, identifier);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _mobileAppCommunicationService.ChangePassword(username, oldPassword, newPassword);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDTO> GetIncidentReportByIDWeb(string authToken, int IncidentReportId)
        {
            try
            {
                return _mobileAppCommunicationService.GetIncidentReportByIDWeb(authToken, IncidentReportId);//.Select(i => i.Report).ToList();
            }
            catch (Exception ex)
            {
                _logger.Info("IncidentReportServiceWeb GetIncidentReportByIDWeb() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("IncidentReportServiceWeb GetIncidentReportByIDWeb() Exception" + ex.Message);//jatin
            }
            return null;
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDTO> GetIncidentReportsByOwnerWeb(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName)
        {
            try
            {
                var nRetVal = _mobileAppCommunicationService.GetIncidentReportsByOwnerWeb(userName, authToken, startCreateDate, endCreateDate, ownerUserName);
                //List<IncidentReportDTO> _newlist = new List<IncidentReportDTO>();
               // _newlist.Add(new IncidentReportDTO());
                return nRetVal;
            }
            catch (Exception ex)
            {
                _logger.Info("IncidentReportServiceWeb GetIncidentReportsByOwnerWeb() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("IncidentReportServiceWeb GetIncidentReportsByOwnerWeb() Exception" + ex.Message);//jatin
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDTO> GetIncidentReportsByOwnerWebMob(string authToken)//, string startCreateDate, string endCreateDate, string ownerUserName
        {
            try
            {
                var nRetVal = _mobileAppCommunicationService.GetIncidentReportsByOwnerWebMob(authToken);//, string startCreateDate, string endCreateDate, string ownerUserName
                //List<IncidentReportDTO> _newlist = new List<IncidentReportDTO>();
                //  _newlist.Add(new IncidentReportDTO());

                var irlist = nRetVal.ToList();
                return irlist;
            }
            catch (Exception ex)
            {
                _logger.Info("IncidentReportServiceWeb GetIncidentReportsByOwnerWebMob() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("IncidentReportServiceWeb GetIncidentReportsByOwnerWebMob() Exception" + ex.Message);
            }
            return null;
        }
    }
}
