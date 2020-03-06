using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using AMS.Broker.Contracts.Services;
using NLog;
using System.DirectoryServices;
using System.ServiceModel.Activation;
using System.Security.Principal;
using AMS.Broker.AutherizationService.DataStore;
using System.DirectoryServices.AccountManagement;
using AMS.Broker.AutherizationService.Helpers;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using System.Threading;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.StaticFactory;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace AMS.Broker.AutherizationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal sealed class AuthService : IAuthService
    {
        IAuthService authServiceImpl;

        public AuthService()
        {
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            authServiceImpl = BrokerService.Container.Resolve<IAuthService>();
        }

        bool ValidateAuthToken(string authToken)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(endpoint.Address);
                System.Net.IPAddress _reqIp = ConverttoIP(authToken);

                if (ip.ToString() == _reqIp.ToString())
                {
                    return true;
                }
                else
                { return true; }//this for class A ip komal 16112017

            }
            catch (Exception ex)
            { }

            return true;//this for class A ip 
        }

        private System.Net.IPAddress ConverttoIP(string AuthToken)
        {
            try
            {
                var _firstPair = AuthToken.Substring(24, 3);
                var _secondPair = AuthToken.Substring(27, 3);
                var _thirdPair = AuthToken.Substring(30, 3);
                var _fourthPair = AuthToken.Substring(33, 3);

                string IPaddr = _firstPair + "." + _secondPair + "." + _thirdPair + "." + _fourthPair;
                var convertaddress = System.Text.RegularExpressions.Regex.Replace(IPaddr, "0*([0-9]+)", "${1}");
                var address = System.Net.IPAddress.Parse(convertaddress);
                return address;
            }
            catch (Exception ex)
            {
                _logger.Info("------------------------------------");
                //_logger.Info("ConverttoIP exception AuthToken" + AuthToken);
                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                InsertAuthLog.AddProcessLogAuth("ConverttoIP exception AuthToken" + AuthToken);//jatin
                return null;
            }
        }


        internal static IAuthService Initialise()
        {
            try
            {
                _logger.Info("------------------------------------");
                _logger.Info("starting Authentication service");
                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                InsertAuthLog.AddProcessLogAuth("starting Authentication service");//jatin

                IAuthService service = new AuthService();
                var controllerHost = new ServiceHost(service);

                controllerHost.Open();

                _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                _logger.Info("------------------------------------");
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016   
                return service;
            }
            catch (Exception e)
            {
                _logger.Info("AuthService Initialise() Exception" + e.Message);
                InsertAuthLog.AddProcessLogAuth("AuthService Initialise() Exception" + e.Message);//jatin
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("Auth Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);

        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="systemId">
        /// </param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component, string FCMToken = null)
        {
            var session = "";
            try
            {
                return authServiceImpl.CreateSession(identifier, systemId, username, password, identifierIP, component, FCMToken);

               //  session = strRet;

                /*if (AuthenticationHelper.IsValid(username, password))
                {
                    _logger.Info("  Authenticated, checking authorization");
                    using (var context = new CentralDBEntities())
                    {
                        var sid = AuthenticationHelper.GetUsersSID(username);
                        _logger.Info("  sid: {0}", sid);
                        if (!String.IsNullOrWhiteSpace(sid))
                        {
                            session = context.LoadAuthTokenFromDatastore(sid, identifier).ToString();
                            if (String.IsNullOrWhiteSpace(session))
                                session = context.LogInUser(sid, identifier).ToString();
                        }
                        _logger.Info("  login created: {0}", context.SaveChanges() > 0);

                        //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(x => StationsService.InformAboutUserLoggedIn(x as UserDTO)), new UserDTO { Identifier = identifier, AuthToken = Guid.Parse(session), ActiveFrom = DateTime.Now, SecurityUserId = systemId });
                    }
                  }
                else
                {
                    _logger.Info("  -> user name/password not valid");
                }*/

            }
            catch (Exception ex)
            {
                _logger.Info("AuthService CreateSession() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthService CreateSession() Exception" + ex.Message);//jatin
            }

            return session;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string GetServerConfigIpAddress(string authToken)
        {
            if (ValidateAuthToken(authToken) == false)
            {
                return null;
            }

            return authServiceImpl.GetServerConfigIpAddress(authToken);

        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public String CreateWeakSession(string identifier, string systemId, string username)
        {
            return authServiceImpl.CreateWeakSession(identifier, systemId, username);
        }
        

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public bool CloseSession(string authToken, string identifier)
        {
            return authServiceImpl.CloseSession(authToken, identifier);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]  //amit 07122016
        public bool LogoutConfig(string authToken, string identifier)
        {
            return authServiceImpl.LogoutConfig(authToken, identifier);
        }

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
