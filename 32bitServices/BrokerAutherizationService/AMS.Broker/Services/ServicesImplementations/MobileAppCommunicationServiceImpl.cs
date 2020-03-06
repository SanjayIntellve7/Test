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
using NLog;
using EventDTO = AMS.Broker.Contracts.DTO.Event;
using GroupDTO = AMS.Broker.Contracts.DTO.Group;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using StationDTO = AMS.Broker.Contracts.DTO.Station;
using IncidentReportDto = AMS.Broker.Contracts.DTO.IncidentReport;
using Alert = AMS.Broker.Contracts.DTO.Alert;
using ValuesLookUpDTO = AMS.Broker.Contracts.DTO.ValuesLookUp;
using System.Drawing;
using System.Net.Sockets;
using System.Security;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AMS.Broker.AutherizationService.DataStore;
using System.Web;
using System.Threading;
using System.Net.Mail;
using System.Collections.ObjectModel;

namespace AMS.Broker.AutherizationService.Services.ServicesImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MobileAppCommunicationServiceImpl : ServiceBaseImpl, IMobileAppCommunicationService
    {
        // IAlertsGetOperationService _alertsService;
        public AMS.Broker.Contracts.Services.INvrCamerasService nvrCamerasService;

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        private static object _lock = new object();

        public MobileAppCommunicationServiceImpl()
        {
            //_alertsService = alertsService;
        }
        public void ClearMemory()
        {
            try
            {
                long bytes1 = GC.GetTotalMemory(false); // Get memory in bytes           
                _logger.Info("Controller Memory Before Collect " + bytes1);
                InsertAuthLog.AddProcessLogAuth("Controller Memory Before Collect " + bytes1);// jatin 
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                long bytes3 = GC.GetTotalMemory(true); // Get memory               
                _logger.Info("Controller Memory After garbage collection " + bytes3);
                InsertAuthLog.AddProcessLogAuth("Controller Memory After garbage collection " + bytes3);//jatin
            }
            catch (Exception ex)
            {
            }
        }
        public static void ClearMemoryStatic()
        {
            try
            {
                long bytes1 = GC.GetTotalMemory(false); // Get memory in bytes               
                _logger.Info("Controller Memory Before Collect " + bytes1);
                InsertAuthLog.AddProcessLogAuth("Controller Memory Before Collect " + bytes1);//jatin
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                long bytes3 = GC.GetTotalMemory(true); // Get memory               
                _logger.Info("Controller Memory After garbage collection " + bytes3);
                InsertAuthLog.AddProcessLogAuth("Controller Memory After garbage collection " + bytes3);// jatin
            }
            catch (Exception ex)
            {
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionMob(string authToken)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMob():Start");//jatin
                // InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionMob():Start");
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                string _strUrl = "https://" + Storage.GetOperationServiceEndpoint + ":6530/soap/ControllerGetOperation";
                EndpointAddress ar = new EndpointAddress(_strUrl);

                ControllerGetOperationRef.ControllerGetOperationServiceClient _serVice = new ControllerGetOperationRef.ControllerGetOperationServiceClient("WSHttpBinding_IControllerGetOperationService", ar.ToString());
                // StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                var result = _serVice.GetDevicesCollectionMob(authToken);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetDevicesCollectionMob() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionMob():Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMob() Exception:" + ex.Message);// jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }

            return null;
        }

        //
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ChangePassword():Start");
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ChangePassword():Start");//jatin
                var mUser = System.Web.Security.Membership.GetUser(username);
                return mUser.ChangePassword(oldPassword, newPassword);
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService ChangePassword() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ChangePassword():Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ChangePassword():Exception:" + ex.Message);// jatin 
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;

        }

        //07112017komal
        public bool checkUserIslock(string userName)
        {
            try
            {
                var session = "";
                using (var cxtsLoginUpd = new CentralDBEntities())
                {
                    var usr = cxtsLoginUpd.User.Single(user => user.MembershipUser.LoweredUserName == userName.ToLower());

                    var MemUser = cxtsLoginUpd.aspnet_Membership.Single(u => u.UserId == usr.MembershipUserId);
                    if (MemUser != null)
                    {
                        var signedUserUpd = MemUser;
                        if (signedUserUpd.IsLockedOut == true)
                        {
                            //locked user
                            session = "lock";
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string Message1 = "SecuritySetOperationServiceImpl checkUserIslock() Exception:" + ex.Message;
                InsertAuthLog.AddProcessLogAuth(Message1);
            }

            return false;
        }

        public bool checkPasswordIsExpired(string userName)
        {
            //komal 27102017 for password expired
            try
            {
                var session = "";
                using (var context = new CentralDBEntities())
                {
                    var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == userName.ToLower());

                    var MemUser = context.aspnet_Membership.Single(u => u.UserId == usr.MembershipUserId);
                    if (MemUser != null)
                    {
                        DateTime passChangeDate = MemUser.LastPasswordChangedDate;
                        int validity = Int32.Parse(MemUser.PasswordValidity.ToString());
                        DateTime CurrentDate = DateTime.Now;
                        DateTime passValidityDate = passChangeDate.AddDays(validity);
                        if (CurrentDate > passValidityDate) //
                        {
                            //validity expired
                            // session = "passwordExpired";

                            if (userName.ToLower() == "admin")//for admin user password could not be expired
                            {
                                MemUser.PasswordValidity = validity;
                                context.SaveChanges();
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                            // return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string Message1 = "SecuritySetOperationServiceImpl ChangePasswordNew() passwordExpired! Exception:" + ex.Message;
                InsertAuthLog.AddProcessLogAuth(Message1);
            }
            return false;
            //         
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public int ChangePasswordNew(string username, string oldPassword, string newPassword) //amit 27092017// jatin 06012017
        {
            try
            {
                string Message = "MobileAppCommunicationService ChangePasswordNew()  username:" + username + "--!--oldPassword:" + oldPassword + "--!--oldPassword:" + newPassword;
                InsertAuthLog.AddProcessLogAuth(Message);

                //check if user is lock
                if (checkUserIslock(username))
                    return 7;
                //check password expiry
                if (checkPasswordIsExpired(username))
                    return 8;
                //Get the password
                var mUserChk = System.Web.Security.Membership.GetUser(username);
                if (mUserChk != null)
                {
                    //
                    if (mUserChk.ChangePassword(oldPassword, newPassword) == true)
                    {
                        using (var ctx = new CentralDBEntities())
                        {
                            var user = ctx.MembershipUser.Single(user1 => user1.UserName == username);
                            var membershipUser = ctx.aspnet_Membership.Single(user1 => user1.UserId == user.UserId);
                            // membershipUser.PasswordValidity = 30; //jatin 08112017
                            ctx.SaveChanges();
                        }
                        return 1;
                    }
                    else
                    {
                        //return invalid old password
                        using (var cxtsLoginUpd = new CentralDBEntities())
                        {
                            var usr = cxtsLoginUpd.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                            var MemUser = cxtsLoginUpd.aspnet_Membership.Single(u => u.UserId == usr.MembershipUserId);
                            if (MemUser != null)
                            {
                                var signedUserUpd = MemUser;
                                if (signedUserUpd.FailedPasswordAttemptCount == 1)
                                {
                                    var retVal = 3;
                                    if (username.ToLower() == "admin")  //for admin user wrong password komal08112017
                                    {
                                        signedUserUpd.FailedPasswordAttemptCount = 0;
                                        signedUserUpd.IsLockedOut = false;
                                        cxtsLoginUpd.SaveChanges();
                                        retVal = 11;//"Invalid Password";
                                    }
                                    return retVal;

                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 2)
                                {
                                    // session = "Attempt2";
                                    return 4;
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 3)
                                {
                                    // session = "Attempt3";
                                    return 5;
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 4)
                                {
                                    // session = "Attempt4";
                                    return 6;
                                }
                                //
                                if (signedUserUpd.IsLockedOut == true)
                                {
                                    // session = "Attempt4";
                                    return 7;       //for if locked user
                                }
                                //
                                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ChangePasswordNew(): user name/password not valid ");
                            }
                        }
                        // return 3;
                    }
                }
                else
                {
                    //Return Invalid user name
                    return 2;
                }
            }
            catch (Exception ex)
            {
                //Logger.Info("SecurityServiceImpl ChangePasswordNew() Exception:" + ex.Message);
                string Message = "MobileAppCommunicationService ChangePasswordNew()   Exception:" + ex.Message;
                InsertAuthLog.AddProcessLogAuth(Message);
                return 0;
            }
            finally
            {
                ClearMemory();
            }
            return 0;

        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionWeb(string authToken)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionWeb():Start");
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionWeb():Start");//jatin
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                string _strUrl = "https://" + Storage.GetOperationServiceEndpoint + ":6530/soap/ControllerGetOperation";
                EndpointAddress ar = new EndpointAddress(_strUrl);

                ControllerGetOperationRef.ControllerGetOperationServiceClient _serVice = new ControllerGetOperationRef.ControllerGetOperationServiceClient("WSHttpBinding_IControllerGetOperationService", ar.ToString());
                // StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                var result = _serVice.GetDevicesCollectionWeb(authToken);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetDevicesCollectionMob() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionWeb():Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionWeb():Exception:" + ex.Message);//jatin

                return null;
            }
            finally
            {
                ClearMemory();
            }

            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetDevicesCollectionMobSiteId(string authToken, long siteId)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionMobSiteId(): Start");
                /* InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMobSiteId(): Start");//jatin 
                 //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                 string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/ControllerGetOperation";
                 EndpointAddress ar = new EndpointAddress(_strUrl);

                 ControllerGetOperationRef.ControllerGetOperationServiceClient _serVice = new ControllerGetOperationRef.ControllerGetOperationServiceClient("WSHttpBinding_IControllerGetOperationService", ar.ToString());
                 // StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                 var result = _serVice.GetDevicesCollectionMobSiteId(authToken, siteId);
                 _serVice.Close();*/
                var result = GetDevicesCollectionMobSiteIdJson(authToken, siteId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetDevicesCollectionMobSiteId() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionMobSiteId():Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMobSiteId():Exception:" + ex.Message); // jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }

            return null;
        }


        public IEnumerable<DeviceDto> GetDevicesCollectionMobSiteIdJson(string authToken, long siteId)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMobSiteIdJson():Start:authToken" + authToken);
                var DevCollection = new ObservableCollectionEx<DeviceDto>(JsonServicesHelper.GetObjectsCollection<DeviceDto>("ControllerGetOperation", "GetDevicesCollectionMobSiteId", "authToken=" + authToken, "siteId=" + siteId));
                return DevCollection;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDevicesCollectionMobSiteIdJson():Exception:" + ex.Message);
            }
            return null;
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<AlertMobDto> GetMobileSingleAlert(string authToken, int alertID)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobileSingleAlert(): Start");
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobileSingleAlert(): Start");//jatin
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                /*  string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsGetOperationService";
                  EndpointAddress ar = new EndpointAddress(_strUrl);

                  AlertsGetOperationServiceRef.AlertsGetOperationServiceClient _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());

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
                  var alertResult = _serVice.GetMobileSingleAlert(authToken, alertID);
                  _serVice.Close();*/
                var alertResult = GetMobileSingleAlertJson(authToken, alertID);
                return alertResult;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetMobileSingleAlert() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobileSingleAlert(): Exception" + ex.Message);//jatin 
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobileSingleAlert(): Exception" + ex.Message);
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }
        public IEnumerable<AlertMobDto> GetMobileSingleAlertJson(string authToken, int alertID)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobileSingleAlertJson():Start:authToken" + authToken);
                var mobAlerts = new ObservableCollectionEx<AlertMobDto>(JsonServicesHelper.GetObjectsCollection<AlertMobDto>("AlertsGetOperationService", "GetMobileSingleAlert", "authToken=" + authToken, "alertID=" + alertID));
                return mobAlerts;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobileSingleAlertJson():Exception:" + ex.Message);
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<SiteDto> GetAllSites(string authToken)
        {
            try
            {
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/ZoneGetOperation";

                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetAllSites():Start  URL" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetAllSites():Start  URL" + _strUrl);//jatin

                EndpointAddress ar = new EndpointAddress(_strUrl);
                ZoneGetOperationRef.ZonesGetOperationServiceClient _serVice = new ZoneGetOperationRef.ZonesGetOperationServiceClient("WSHttpBinding_IZonesGetOperationService", ar.ToString());
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
                var siteResult = _serVice.GetAllSites(authToken);
                _serVice.Close();
                return siteResult;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetAllSites() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetAllSites(): Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetAllSites() Exception:" + ex.Message);//jatin 
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string GetRepositoryConfiguration(string authToken)
        {
            try
            {
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                /*string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/ControllerGetOperationDummy";
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetRepositoryConfiguration():Start  URL" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetRepositoryConfiguration():Start  URL" + _strUrl);//jatin
                EndpointAddress ar = new EndpointAddress(_strUrl);

                ControllerGetOperationRef.ControllerGetOperationServiceClient _serVice = new ControllerGetOperationRef.ControllerGetOperationServiceClient("WSHttpBinding_IControllerGetOperationService", ar.ToString());
                // StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                var result = _serVice.GetRepositoryConfiguration(authToken);
                _serVice.Close();*/

                return GetRepositoryConfigurationJson(authToken);
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetRepositoryConfiguration() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetRepositoryConfiguration():Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetRepositoryConfiguration():Exception" + ex.Message);// jatin 
                return null;
            }
            finally
            {
                ClearMemory();
            }

            return null;
        }

        public string GetRepositoryConfigurationJson(string authToken)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("ControllersService GetDevicesCollection() :Start:");
                string RepositoryPath = "";
                //foreach (var DataVal in AuthenticationService.ServerIpConfigurationList)
                //{
                if (authToken != "" && authToken != null)
                {
                    var json = JsonServicesHelper.GetJsonResponse("ControllerGetOperation", "GetRepositoryConfiguration", "authToken=" + authToken);
                    if (json == null)
                        return null;
                    json = JsonServicesHelper.RemoveJsonpSyntax(json);
                    RepositoryPath = JsonServicesHelper.Deserialize<string>(json);// new JsonServicesHelper.Deserialize<IEnumerable<string>>(json);

                    //DeviceCollection = new ObservableCollectionEx<DeviceDto>(DataCollectionLst);
                    //}
                }
                return RepositoryPath;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("ControllersService GetDevicesCollection() :" + ex.Message);
            }
            return null;
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken)
        {
            try
            {
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                /* string _strUrl = "https://" + Storage.GetOperationServiceEndpoint + ":6530/soap/AlertsGetOperationService";
                 //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobCurrentOpenAlerts() Start : URL" + _strUrl);
                 InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobCurrentOpenAlerts() Start : URL" + _strUrl);//jatin
                 EndpointAddress ar = new EndpointAddress(_strUrl);

                 AlertsGetOperationServiceRef.AlertsGetOperationServiceClient _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());

                 if (Storage.IsCloudServer == "1")
                 {
                     _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(30);
                     _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(30);
                 }
                 else
                 {
                     _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(8);
                     _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(8);
                 }
                 var result = _serVice.GetMobCurrentOpenAlerts(authToken);
                 _serVice.Close();*/
                return GetMobiCurrentOpenAlertsJson(new Guid(authToken));
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetMobCurrentOpenAlerts() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobCurrentOpenAlerts() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobCurrentOpenAlerts() Exception: " + ex.Message);//jatin 
                return null;
            }
            finally
            {
                ClearMemory();
            }
        }

        public static IEnumerable<AlertMobDto> GetMobiCurrentOpenAlertsJson(Guid authToken)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("Alert service GetMobiCurrentOpenAlerts():Start:authToken" + authToken);
                var mobAlerts = new ObservableCollectionEx<AlertMobDto>(JsonServicesHelper.GetObjectsCollection<AlertMobDto>("AlertsGetOperationService", "GetMobCurrentOpenAlerts", "authToken=" + authToken));
                return mobAlerts;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("Alert service GetMobiCurrentOpenAlerts():Exception:" + ex.Message);
            }
            return null;
        }


        [WebInvoke(Method = "GET")]
        public string GetMobCurrentOpenAlertsCount(string authToken)
        {
            try
            {
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsGetOperationService";
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobCurrentOpenAlertsCount() Start : URL" + _strUrl);//jatin
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobCurrentOpenAlertsCount() Start : URL" + _strUrl);
                EndpointAddress ar = new EndpointAddress(_strUrl);

                AlertsGetOperationServiceRef.AlertsGetOperationServiceClient _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());

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
                var result = _serVice.GetMobCurrentOpenAlertsCount(authToken);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobCurrentOpenAlertsCount() Count :" + result.Count());
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobCurrentOpenAlertsCount() Count :" + result.Count());//jatin
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetMobCurrentOpenAlertsCount() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetMobCurrentOpenAlertsCount()  Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobCurrentOpenAlertsCount()  Exception: " + ex.Message);//jatin

                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        [WebInvoke(Method = "GET")]
        public IEnumerable<Alert> GetCurrentOpenAlerts(string authToken)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetCurrentOpenAlerts() Start : authToken" + authToken);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetCurrentOpenAlerts() Start : authToken" + authToken);//jatin
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsGetOperationService";
                EndpointAddress ar = new EndpointAddress(_strUrl);

                AlertsGetOperationServiceRef.AlertsGetOperationServiceClient _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());

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
                var result = _serVice.GetCurrentOpenAlerts(authToken);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetCurrentOpenAlerts() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetCurrentOpenAlerts() Exception:" + ex.Message);//jatin
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetCurrentOpenAlerts() Exception: " + ex.Message);
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        [WebInvoke(Method = "GET")]
        public bool AcknowledgeAlertsMobile(string authToken, string alerts)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService AcknowledgeAlertsMobile() Start:authToken " + authToken);
                //InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService AcknowledgeAlertsMobile() Start:authToken " + authToken);//jatin
                //string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsSetOperationService";
                //EndpointAddress ar = new EndpointAddress(_strUrl);
                //AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());

                //if (Storage.IsCloudServer == "1")
                //{
                //    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(30);
                //    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(30);
                //}
                //else
                //{
                //    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(5);
                //    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(5);
                //}
                //var result = _serVice.AcknowledgeAlertsMobile(authToken, alerts);

                var result = AcknowledgeAlertsMobileJson(authToken, alerts);
                //_serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService AcknowledgeAlertsMobile() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService AcknowledgeAlertsMobile() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService AcknowledgeAlertsMobile() Exception: " + ex.Message); // jatin
                return false;
            }
            finally
            {
                // ClearMemory();
            }
            return false;
        }

        [WebInvoke(Method = "GET")]
        public bool AcknowledgeAlertsMobileJson(string authToken, string alerts)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("ControllersService AcknowledgeAlertsMobileJson() :Start:");
                bool result = false;
                //foreach (var DataVal in AuthenticationService.ServerIpConfigurationList)
                //{
                if (authToken != "" && authToken != null)
                {
                    var json = JsonServicesHelper.GetJsonResponse("AlertsSetOperationService", "AcknowledgeAlertsMobile", "authToken=" + authToken, "alerts=" + alerts);
                    if (json == null)
                        return false;
                    json = JsonServicesHelper.RemoveJsonpSyntax(json);
                    result = JsonServicesHelper.Deserialize<bool>(json);// new JsonServicesHelper.Deserialize<IEnumerable<string>>(json);

                    //DeviceCollection = new ObservableCollectionEx<DeviceDto>(DataCollectionLst);
                    //}
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("ControllersService AcknowledgeAlertsMobileJson() :" + ex.Message);
            }
            return false;
        }

        [WebInvoke(Method = "GET")]
        public bool CancelAlertsMobile(string alerts)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CancelAlertsMobile() Start: ");
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CancelAlertsMobile() Start: ");//jatin
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsSetOperationService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());

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
                var result = _serVice.CancelAlertsMobile(alerts);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService CancelAlertsMobile() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CancelAlertsMobile() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CancelAlertsMobile() Exception:" + ex.Message); // jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }


        [WebInvoke(Method = "GET")]
        public bool AnimateMapPin()
        {
            try
            {
                string _strUrl = "https://" + Storage.TransactionServiceEndpoint + ":6530/soap/AlertsCreationService";
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService AnimateMapPin() Start:_strUrl" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService AnimateMapPin() Start:_strUrl" + _strUrl);//jatin 
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());
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
                var result = _serVice.AnimateMapPin();
                _serVice.Close();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService CreateMobileAlert() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CreateMobileAlert() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CreateMobileAlert() Exception:" + ex.Message); // jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }

        [WebInvoke(Method = "GET")]
        public bool CreateDummySimulatorAlerts(string alertcode)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CreateDummySimulatorAlerts() Start : alertcode" + alertcode);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CreateDummySimulatorAlerts() Start : alertcode" + alertcode);//jatin

                string _strUrl = "https://" + Storage.TransactionServiceEndpoint + ":6530/soap/AlertsCreationService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());
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
                var result = _serVice.CreateDummySimulatorAlerts(alertcode);
                _serVice.Close();
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService CreateDummySimulatorAlerts() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CreateDummySimulatorAlerts() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CreateDummySimulatorAlerts() Exception:" + ex.Message);//jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;

        }

        [WebInvoke(Method = "GET")]
        public bool CreateMobileAlert(string urgency, string severity, string certainty, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No)
        {
            try
            {
                string _strUrl = "https://" + Storage.TransactionServiceEndpoint + ":6530/soap/AlertsCreationService";

                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CreateMobileAlert() Start : _strUrl " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CreateMobileAlert() Start : _strUrl " + _strUrl);//jatin

                EndpointAddress ar = new EndpointAddress(_strUrl);
                //AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());
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
                var result = _serVice.CreateMobileAlertNormal(urgency, severity, certainty, note, lattitude, longitude, retPath, retVoicenotePath, retVideoPath, Imei_No);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService CreateMobileAlert() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService CreateMobileAlert() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService CreateMobileAlert() Exception: " + ex.Message); // jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("Controller Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            InsertAuthLog.AddProcessLogAuth("Controller Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message); // jatin
        }


        // saurabh changes for mobile app 16112017
        [WebInvoke(Method = "GET")]
        public DeviceDto GetDeviceById(string authToken, long deviceId) //Saurabh 13112017
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetDevicesCollectionMobSiteId(): Start");
                //return GetDevicesCollectionMobSiteIdImpl(authToken, siteId);
                /* string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/ControllerGetOperation";
                 EndpointAddress ar = new EndpointAddress(_strUrl);

                 ControllerGetOperationRef.ControllerGetOperationServiceClient _serVice = new ControllerGetOperationRef.ControllerGetOperationServiceClient("WSHttpBinding_IControllerGetOperationService", ar.ToString());
                 // StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                 var result = _serVice.GetDeviceById(authToken, deviceId);
                 _serVice.Close();*/

                var result = GetDeviceByIdJson(authToken, deviceId);
                return result;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public DeviceDto GetDeviceByIdJson(string authToken, long deviceId)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetDeviceById():Start:authToken" + authToken);
                var singleDevice = JsonServicesHelper.GetJsonResponse("ControllerGetOperation", "GetDeviceById", "authToken=" + authToken, "deviceId=" + deviceId);
                if (singleDevice == null)
                    return null;
                singleDevice = JsonServicesHelper.RemoveJsonpSyntax(singleDevice);
                var result = JsonServicesHelper.Deserialize<DeviceDto>(singleDevice);
                return result;
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetMobiCurrentOpenAlerts():Exception:" + ex.Message);
            }
            return null;
        }


        //Saurabh changes for mobile app 16112017
        public string UpdloadMediaPic(Stream strData)
        {
            try
            {
                string strFile = "";
                strFile = Path.GetTempFileName();
                byte[] bytearray = null;

                MultipartParser parser = new MultipartParser(strData);
                if (parser.Success)
                {
                    // Save the file
                    bytearray = parser.FileContents;
                    File.WriteAllBytes(strFile, bytearray);
                    //SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
                }

                return strFile;
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        public string UpdloadMediaAudio(Stream strData)
        {
            try
            {
                string strFile = "";
                strFile = Path.GetTempFileName();
                byte[] bytearray = null;

                MultipartParser parser = new MultipartParser(strData);
                if (parser.Success)
                {
                    // Save the file
                    bytearray = parser.FileContents;
                    File.WriteAllBytes(strFile, bytearray);
                    //SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
                }

                return strFile;
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        public string UpdloadMediaVideo(Stream strData)
        {
            try
            {
                string strFile = "";
                strFile = Path.GetTempFileName();
                byte[] bytearray = null;

                MultipartParser parser = new MultipartParser(strData);
                if (parser.Success)
                {
                    // Save the file
                    bytearray = parser.FileContents;
                    File.WriteAllBytes(strFile, bytearray);
                    //SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
                }

                return strFile;
            }
            catch (Exception ex)
            {
            }

            return "";
        }
        //


        [WebInvoke(Method = "GET")]
        public bool UpdateMobileAlert(string alertId, string retPath, string retVoicenotePath, string retVideoPath)
        {
            try
            {
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/AlertsSetOperationService";
                // InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService UpdateMobileAlert() Start : _strUrl " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService UpdateMobileAlert() Start : _strUrl " + _strUrl);//jatin

                EndpointAddress ar = new EndpointAddress(_strUrl);
                AlertsSetOperationServiceRef.AlertsSetOperationServiceClient _serVice = new AlertsSetOperationServiceRef.AlertsSetOperationServiceClient("WSHttpBinding_IAlertsSetOperationService", ar.ToString());

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
                var result = _serVice.UpdateMobileAlert(alertId, retPath, retVoicenotePath, retVideoPath);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService UpdateMobileAlert() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService UpdateMobileAlert() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService UpdateMobileAlert() Exception: " + ex.Message);//jatin
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool RegisterStation(string authToken, string identifier, string type, string description, string metadata, string longitued = null, string latitude = null)
        {
            try
            {
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService RegisterStation() Start: " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService RegisterStation() Start: " + _strUrl); // jatin 
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
                var result = _serVice.RegisterStation(authToken, identifier, type, description, metadata, longitued, latitude);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService RegisterStation() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService RegisterStation() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService RegisterStation() Exception: " + ex.Message); // jatin 
                return false;
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }
        //
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public StationDTO ActivateStation(string authToken, string identifier)
        {
            try
            {
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                // InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ActivateStation() Start: " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ActivateStation() Start: " + _strUrl);//jatin
                StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());

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
                var result = _serVice.ActivateStation(authToken, identifier);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetAllSites() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ActivateStation() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ActivateStation() Exception:" + ex.Message); // jatin 
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public StationDTO ActivateWebClient(string authToken, string identifier)
        {
            try
            {
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ActivateWebClient() Start:URL =" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ActivateWebClient() Start:URL =" + _strUrl);//jatin
                StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());
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
                var result = _serVice.ActivateStation(authToken, identifier);
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService ActivateWebClient() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService ActivateWebClient() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService ActivateWebClient() Exception:" + ex.Message);//jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void DeactivateStation(string authToken, string identifier)
        {
            try
            {

                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService DeactivateStation() Start: URL=" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService DeactivateStation() Start: URL=" + _strUrl);//jatin
                StationsServiceRef.StationsServiceClient _serVice = new StationsServiceRef.StationsServiceClient("WSHttpBinding_IStationsService", ar.ToString());
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
                _serVice.DeactivateStation(authToken, identifier);
                _serVice.Close();

            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService DeactivateStation() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService DeactivateStation() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService DeactivateStation() Exception:" + ex.Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDto> GetIncidentReportByIDWeb(string authToken, int IncidentReportId)
        {
            try
            {
                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/IncidentReportGetOperationServiceWeb";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetIncidentReportByIDWeb() Start: _strUrl=" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportByIDWeb() Start: _strUrl=" + _strUrl);//jatin
                // _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());
                IncidentReportGetOperationServiceWebRef.IncidentReportGetOperationServiceWebClient _serVice = new IncidentReportGetOperationServiceWebRef.IncidentReportGetOperationServiceWebClient("WSHttpBinding_IIncidentReportGetOperationServiceWeb", ar.ToString());
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
                var result = _serVice.GetIncidentReportByIDWeb(authToken, IncidentReportId).ToList(); //need to add reference
                _serVice.Close();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetIncidentReportByIDWeb() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetCurrentOpenAlerts() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportByIDWeb() Exception:" + ex.Message);//jatin
                return null;
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDto> GetIncidentReportsByOwnerWeb(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName)
        {
            try
            {
                var user = new UserDTO()
                {
                    SecurityUserId = userName,
                    AuthToken = Guid.Parse(authToken)
                };

                string _strUrl = "https://" + Storage.MobileOperationServiceEndpoint + ":6530/soap/IncidentReportGetOperationServiceWeb";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetIncidentReportsByOwnerWeb() Start:URL=" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportsByOwnerWeb() Start:URL=" + _strUrl);//jatin
                // _serVice = new AlertsGetOperationServiceRef.AlertsGetOperationServiceClient("WSHttpBinding_IAlertsGetOperationService", ar.ToString());
                IncidentReportGetOperationServiceWebRef.IncidentReportGetOperationServiceWebClient _serVice = new IncidentReportGetOperationServiceWebRef.IncidentReportGetOperationServiceWebClient("WSHttpBinding_IIncidentReportGetOperationServiceWeb", ar.ToString());
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
                var result = _serVice.GetIncidentReportsByOwnerWeb(userName, authToken, startCreateDate, endCreateDate, ownerUserName).ToList(); //need to add reference
                _serVice.Close();

                return result; //GetIncidentReportsByOwnerJson(userName, authToken, startCreateDate, endCreateDate, ownerUserName);//
                // return GetIncidentReportsByOwner(user, DateTime.Parse(startCreateDate), DateTime.Parse(endCreateDate), ownerUserName).Select(i => i.Report).ToList();      

            }
            catch (Exception ex)
            {
                _logger.Info("MobileAppCommunicationService GetIncidentReportsByOwnerWeb() Exception:" + ex.Message);
                // InsertBrokerOperationLog.AddProcessLog("MobileAppCommunicationService GetIncidentReportsByOwnerWeb() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportsByOwnerWeb() Exception:" + ex.Message);//jatin
                return null;
            }

            return null;
        }
       

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public List<IncidentReportDto> GetIncidentReportsByOwnerWebMob(string authToken)//, string startCreateDate, string endCreateDate, string ownerUserName
        {      
             
                //return _incidentReportService.GetIncidentReportsByOwner(user, DateTime.Parse(startCreateDate), DateTime.Parse(endCreateDate), ownerUserName).Select(i => i.Report).ToList();
              try
              {
                  Guid authtoken = Guid.Parse(authToken);
                  DateTime startDate = DateTime.Now;
                  var resultlist = new List<IncidentReportWrapper>();
                  // DateTime  EndCreateDate = endCreateDate.AddHours(1);
                  _logger.Info("");
                  _logger.Info("------------------------------------");
                  _logger.Info("IncidentReportServiceWeb: GetIncidentReportsByOwnerWeb");
                  _logger.Info("  authToken: {0}", authToken);

                  string Message = "IncidentReportServiceWeb GetIncidentReportsByOwnerWeb () AuthToken" + authToken;
                  //InsertBrokerOperationLog.AddProcessLog(Message);
                  InsertAuthLog.AddProcessLogAuth(Message);//jatin

                  Contracts.DTO.IncidentReport mapped = null;

                  //List<IncidentReportDTO> IrList = new List<IncidentReportDTO>();
                  using (var context = new CentralDBEntities())
                  {

                      try
                      {
                          var AuthToken = new SqlParameter
                          {
                              ParameterName = "AuthToken",
                              Value = authtoken
                          };

                          var IncidentReportResult =context.Database.SqlQuery<SP_GetIncidentReport_Result>(
                         "exec SP_GetIncidentReport @AuthToken", AuthToken).ToList<SP_GetIncidentReport_Result>();
                          if (IncidentReportResult != null)
                          {
                              foreach (var Ir in IncidentReportResult)
                              {
                                  IncidentReportWrapper Irwrapresult = new IncidentReportWrapper();

                                  mapped = new Contracts.DTO.IncidentReport();
                                  try
                                  {
                                      // mapped.Comments = Ir.Comments;
                                      mapped.CreationDate = Ir.CreateDate;
                                      mapped.CreationDateAsString = Ir.CreateDate.ToString();
                                      mapped.Id = Ir.IIncidentReportId;
                                      mapped.Owner = Ir.Owner;
                                      //mapped.Comments = "saurabh";
                                   //   List<AMS.Broker.Contracts.DTO.Alert> _iAlertList = new List<AMS.Broker.Contracts.DTO.Alert>();
                                   //   _iAlertList.Add(new AMS.Broker.Contracts.DTO.Alert { AlertId = Ir.AlertID, Code = Ir.Code, DeviceDto = new DeviceDto { SiteId = Ir.SiteId } });
                                   // mapped.Alerts = _iAlertList;

                                  }
                                  catch (Exception ex)
                                  {

                                  }
                                  try
                                  {
                                      Irwrapresult.Report = mapped;
                                      Irwrapresult.SystemId = authtoken;
                                      resultlist.Add(Irwrapresult);
                                  }
                                  catch (Exception ex)
                                  {
                                  }

                              }
                          }
                      }

                      catch (Exception ex)
                      {
                          Message = "IncidentReportGetOperationService GetIncidentReportsByOwnerWeb () Exception" + authtoken;
                          //InsertBrokerOperationLog.AddProcessLog(Message);
                          InsertAuthLog.AddProcessLogAuth(Message);
                      }
                  }

                  DateTime endDate2 = DateTime.Now;
                  TimeSpan span2 = endDate2.Subtract(startDate);
                  Message = "IncidentReportGetOperationService GetIncidentReportsByOwnerWeb ()" + authtoken;
                  InsertAuthLog.AddProcessLogAuth(Message);
                  _logger.Info("GetIncidentReportsByOwnerWeb before return:" + span2.TotalMilliseconds);
                  if (resultlist != null)
                  {
                      if (resultlist[0].Report != null)
                      {
                          return resultlist.Select(i => i.Report).ToList();
                      }
                  }
              }
              catch (Exception ex)
              { 
              }


            return null;
        }

        public static IEnumerable<IncidentReportDto>  GetIncidentReportsByOwnerWebMobJason(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName)
        {
            try
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportsByOwnerWebMobJason():Start:authToken" + authToken);
                var mobAlerts = new ObservableCollectionEx<IncidentReportDto>(JsonServicesHelper.GetObjectsCollection<IncidentReportDto>("IncidentReportGetOperationServiceWeb", "GetIncidentReportsByOwnerWeb", "userName=" + userName, "authToken=" + authToken, "startCreateDate=" + startCreateDate, "endCreateDate=" + endCreateDate, "ownerUserName=" + ownerUserName));
                return mobAlerts.ToList();
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("MobileAppCommunicationService GetIncidentReportsByOwnerWebMobJason():Exception:" + ex.Message);
            }
            return null;
        }
    }

    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public ObservableCollectionEx()
        {
        }
        public ObservableCollectionEx(List<T> list)
            : base(list)
        {
        }
        // Override the event so this class can access it
        public ObservableCollectionEx(IEnumerable<T> collection)
            : base(collection)
        {
        }
        public void RaiseCollectionChanged(IList<object> newItems, IList<object> oldItems)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Replace, newItems, oldItems));
            }
        }
        public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Be nice - use BlockReentrancy like MSDN said
            using (BlockReentrancy())
            {
                System.Collections.Specialized.NotifyCollectionChangedEventHandler eventHandler = CollectionChanged;
                if (eventHandler == null)
                    return;

                Delegate[] delegates = eventHandler.GetInvocationList();
                // Walk thru invocation list
                foreach (System.Collections.Specialized.NotifyCollectionChangedEventHandler handler in delegates)
                {
                    var dispatcherObject = handler.Target as System.Windows.Threading.DispatcherObject;
                    // If the subscriber is a DispatcherObject and different thread
                    if (dispatcherObject != null && dispatcherObject.CheckAccess() == false)
                    {
                        // Invoke handler in the target dispatcher's thread
                        dispatcherObject.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.DataBind, handler, this, e);
                    }
                    else // Execute handler as is
                        handler(this, e);
                }
            }
        }
    }
}
