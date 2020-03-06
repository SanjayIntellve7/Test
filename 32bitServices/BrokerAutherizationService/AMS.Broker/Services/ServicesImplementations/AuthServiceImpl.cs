using System;
using AMS.Broker.Contracts.Services;
using NLog;
using AMS.Broker.AutherizationService.DataStore;
using AMS.Broker.AutherizationService.Helpers;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using System.Threading;
using System.Web;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.AutherizationService.Services.ServicesImplementations
{
    internal sealed class AuthServiceImpl : ServiceBaseImpl, IAuthService
    {
        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="systemId">
        /// </param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public String CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component,string FCMToken)
        {
          
            try
            {
               // InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateSession() Start: identifier-" + identifier + " :systemId-" + systemId + " :username-" + username + " :password-" + password + " :identifierIP-" + identifierIP + " :component-" + component);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateSession() Start: identifier-" + identifier + " :systemId-" + systemId + " :username-" + username + " :password-" + password + " :identifierIP-" + identifierIP + " :component-" + component); // jatin 09102017
                var session = "";

                if (AuthenticationHelper.IsValid(username, password))
                {
                    _logger.Info("  Authenticated, checking authorization");
                   // InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateSession() :user name and password is valid");
                    InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateSession() :user name and password is valid"); // jatin 09102017

                    //get mac id
                    string result = string.Empty;
                    string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (!string.IsNullOrEmpty(ip))
                    {
                        string[] ipRange = ip.Split(',');
                        int le = ipRange.Length - 1;
                        result = ipRange[0];
                    }
                    else
                    {
                        result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }

                    //



                    using (var context = new CentralDBEntities())
                    {
                        var sid = AuthenticationHelper.GetUsersSID(username);
                        _logger.Info("  sid: {0}", sid);
                        if (!String.IsNullOrWhiteSpace(sid))
                        {
                            session = context.LoadAuthTokenFromDatastore(sid, identifier).ToString();
                            if (String.IsNullOrWhiteSpace(session))
                                session = context.LogInUser(sid, identifier,identifierIP,component).ToString();
                        }
                        _logger.Info("  login created: {0}", context.SaveChanges() > 0);

                        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(x => InformAboutUserLoggedIn(x as UserDTO)), new UserDTO { Identifier = identifier, AuthToken = Guid.Parse(session), ActiveFrom = DateTime.Now, SecurityUserId = systemId });
                    }
                }
                else
                {
                    //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateSession() :user name/password not valid");
                    InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateSession() :user name/password not valid"); // jatin 09102017
                    _logger.Info("  -> user name/password not valid");
                }

                return session;
            }
            catch (Exception ex)
            {
                _logger.Info("AuthServiceImpl CreateSession() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateSession() : Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateSession() : Exception:" + ex.Message);// jatin 09102017
            }
            return null;
        }

        public string GetServerConfigIpAddress(string authToken)
        {
            return null;
        }

        public bool LogoutConfig(string authToken, string identifier)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl LogoutConfig() : Start:");
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl LogoutConfig() : Start:"); // jatin 09102017
                using (var context = new CentralDBEntities())
                {
                    AuthenticationHelper.Logout(context, authToken, identifier);
                }
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl LogoutConfig() : Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl LogoutConfig() : Exception:" + ex.Message); // jatin 09102017
            }
            return false;
        }

        public String CreateWeakSession(string identifier, string systemId, string username)
        {
            try
            {
               // InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateWeakSession() : Start:");
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateWeakSession() : Start:");// jatin 09102017
                var session = "";

                if (AuthenticationHelper.IsValid(username, out session))
                {
                    _logger.Info("  Authenticated, checking authorization");
                    //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateWeakSession() : Valid UserName");
                    InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateWeakSession() : Valid UserName"); // jatin 09102017
                    using (var context = new CentralDBEntities())
                    {
                        var sid = session; //AuthenticationHelper.GetUsersSID(username);
                        _logger.Info("  sid: {0}", sid);
                        if (!String.IsNullOrWhiteSpace(sid))
                        {
                            session = context.LoadAuthTokenFromDatastore(sid, identifier).ToString();
                            if (String.IsNullOrWhiteSpace(session))
                                session = context.LogInUser(sid, identifier,null,null).ToString();
                        }
                        _logger.Info("  login created: {0}", context.SaveChanges() > 0);
                        ThreadPool.QueueUserWorkItem(
                            new WaitCallback(x => InformAboutUserLoggedIn(x as UserDTO)),
                            new UserDTO
                            {
                                Identifier = identifier,
                                AuthToken = Guid.Parse(session),
                                ActiveFrom = DateTime.Now,
                                SecurityUserId = systemId
                            }
                        );
                    }
                }
                else
                {
                    _logger.Info("  -> user name/password not valid");
                    //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateWeakSession() : user name/password not valid");
                    InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateWeakSession() : user name/password not valid"); // jatin 09102017
                }

                return session;
            }
            catch (Exception ex)
            {
                _logger.Info("AuthServiceImpl CreateWeakSession() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CreateWeakSession() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CreateWeakSession() Exception: " + ex.Message); // jatin 09102017
                _logger.Error(ex);
            }
            return null;
        }
        
        public bool CloseSession(string authToken, string identifier)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CloseSession(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CloseSession(): Start"); // jatin 09102017
                using (var context = new CentralDBEntities())
                {
                    context.Logout(authToken, identifier);
                    context.SaveChanges();

                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(x => InformAboutUserLoggedOut(x as UserDTO)), new UserDTO { Identifier = identifier, AuthToken = Guid.Parse(authToken), ActiveTill = DateTime.Now });
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("AuthServiceImpl CloseSession() Exception:" + ex.Message); 
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl CloseSession() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl CloseSession() Exception: " + ex.Message); // jatin
                _logger.Error(ex);
            }
            return false;
        }
        public void InformAboutUserLoggedIn(UserDTO _user)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedIn(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedIn(): Start"); // jatin
                string _strUrl = "https://"+Storage.StationServiceEnpoint+":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
               // InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedIn() _strUrl : " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedIn() _strUrl : " + _strUrl); // jatin 09102017
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
                _serVice.InformAboutUserLoggedIn(_user);
                _serVice.Close();
            }
            catch (OutOfMemoryException ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedIn() OutOfMemoryException:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedIn() OutOfMemoryException:" + ex.Message); // jatin
                _logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedIn() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedIn() Exception:" + ex.Message);//jatin
                _logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
            }

        }

        public void InformAboutUserLoggedOut(UserDTO _user)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedOut() Start : ");
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedOut() Start : "); // jatin
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedOut() _strUrl : " + _strUrl);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedOut() _strUrl : " + _strUrl); // jatin
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
                _serVice.InformAboutUserLoggedOut(_user);
                _serVice.Close();
            }
            catch (OutOfMemoryException ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedOut() OutOfMemoryException : " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedOut() OutOfMemoryException : " + ex.Message); // jatin 
                _logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceImpl InformAboutUserLoggedOut() Exception : " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceImpl InformAboutUserLoggedOut() Exception : " + ex.Message); // jatin
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }

        }
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
