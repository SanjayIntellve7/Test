using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.AutherizationService.DataStore;
using AMS.Broker.AutherizationService.Helpers;
using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using UserDTO = AMS.Broker.Contracts.DTO.User;

namespace AMS.Broker.AutherizationService.Services.ServicesImplementations
{
    internal sealed class AuthServiceMembershipImpl : ServiceBaseImpl, IAuthService
    {
       /* public string CreateSession(string identifier, string systemId, string username, string password)
        {
            var session = "";

            try
            {
                if (Membership.ValidateUser(username, password))
                {
                    _logger.Info("  Authenticated, creating session");
                    using (var context = new CentralDBEntities())
                    {
                        var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                        _logger.Info("  sid: {0}", usr.UserSid);
                        if (!String.IsNullOrWhiteSpace(usr.UserSid))
                        {
                            session = context.LoadAuthTokenFromDatastore(usr.UserSid, identifier).ToString();
                            if (String.IsNullOrWhiteSpace(session))
                                session = context.LogInUser(usr.UserSid, identifier).ToString();
                        }
                        _logger.Info("  login created: {0}", context.SaveChanges() > 0);

                        System.Threading.ThreadPool.QueueUserWorkItem(
                            new System.Threading.WaitCallback(x => StationsService.InformAboutUserLoggedIn(x as UserDTO)),
                            new UserDTO
                                {
                                    Identifier = identifier,
                                    AuthToken = Guid.Parse(session),
                                    ActiveFrom = DateTime.Now,
                                    SecurityUserId = systemId
                                });
                    }
                }
                else
                {
                    _logger.Info("  -> user name/password not valid");
                }
            }
            catch (Exception e)
            {

            }

            return session;
        }*/
        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl ClearMemory()  Exception() :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl ClearMemory()  Exception() :" + ex.Message); // jatin
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
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl ClearMemoryStatic()  Exception() :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl ClearMemoryStatic()  Exception() :" + ex.Message); // jatin
            }
        }
        public string CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component, string FCMToken = null)
        {
          
            var session = "";

            ///////check if user already logged in if yes then return message Already LoggedIn otherwise allow login
            bool IsAllreadyLoggedIn = false;
            try
            {

              /*  bool IsWebClient = identifier.Contains("Webclient");
                if (IsWebClient)
                {
                    var props = OperationContext.Current.IncomingMessageProperties;
                    var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    if (endpointProperty != null)
                    {
                        var ip = endpointProperty.Address;
                        identifier = identifier + "_" + ip;
                    }
                }*/

                if (identifier.Contains("Mobile") || identifier.Contains("Webclient") || identifier.Contains("DashBoard"))
                {                   
                    return CreateSessionClient(identifier, systemId, username, password,identifierIP,component,FCMToken);
                }
                if (identifier == "BrokerEngine" || identifier == "MosaicEngine")
                {
                    try
                    {
                        if (Membership.ValidateUser(username, password))
                        {
                            string strIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();//amit 15112016 version 1.4.1

                            using (var context = new CentralDBEntities())
                            {
                                var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                                if (!String.IsNullOrWhiteSpace(usr.UserSid))
                                {
                                    session = context.LoadAuthTokenFromDatastore(usr.UserSid, identifier).ToString();
                                    if (String.IsNullOrWhiteSpace(session))
                                        session = context.LogInUser(usr.UserSid, identifier, strIp, component).ToString();
                                }

                                context.SaveChanges();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("AuthServiceMembershipImpl CreateSession() Exception:" + ex.Message);
                        //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() Exception :" + ex.Message);
                        InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() Exception :" + ex.Message); // jatin 
                    }                   
                    return session;
                }               

                using (var cxtLogin = new CentralDBEntities())
                {
                    var sid = AuthenticationHelper.GetUsersSID(username);
                    if (sid == "23")//jatin 19012018
                    {
                        return "23";
                    }
                    if (!String.IsNullOrWhiteSpace(sid))
                    {
                        using (var cxtLoginchk = new CentralDBEntities())
                        {
                            var signedUserlist = cxtLoginchk.Login
                                    .Where(x => x.SecurityUserId.Equals(sid, StringComparison.OrdinalIgnoreCase))
                                    .Where((x => !x.LogoutDate.HasValue));
                                   // .FirstOrDefault(x => !x.LogoutDate.HasValue);
                            // .FirstOrDefault(x => x.Identifier.Equals(identifier, StringComparison.OrdinalIgnoreCase));
                           
                            var authToken = String.Empty;
                            foreach (var signedUser in signedUserlist)
                            {
                                if (signedUser != null)
                                {
                                    if (signedUser.Identifier == "BrokerEngine")
                                    {
                                        goto skipbroker;
                                    }

                                    ////Check if any other user logged into the station
                                    bool DoNotChk = false;
                                    using (var cxtUserchk = new CentralDBEntities())
                                    {
                                        var OtherUser = cxtUserchk.Login
                                                .Where(x => !x.SecurityUserId.Equals(sid, StringComparison.OrdinalIgnoreCase))
                                                .Where(x => x.Identifier == identifier)
                                                .Where(x => !x.LogoutDate.HasValue).ToList();
                                        // .FirstOrDefault(x => !x.LogoutDate.HasValue);
                                        if (OtherUser != null && OtherUser.Count > 0)
                                        {
                                            bool IsSuc = false;
                                            foreach (var users in OtherUser)
                                            {
                                                users.LogoutDate = DateTime.Now;
                                                IsSuc = true;
                                                //DoNotChk = true;
                                            }
                                            if (IsSuc)
                                                cxtUserchk.SaveChanges();
                                        }

                                    }

                                    if (DoNotChk == false)
                                    {
                                        ///////Ping Station ...if yes then do not allow user to login....and if no then reset the logout date and move forword
                                        using (var cxtstation = new CentralDBEntities())
                                        {
                                            try
                                            {                                              

                                                var fromStation = cxtstation.Station.Where(it => it.Identifier.Equals(signedUser.Identifier));
                                                //var result = fromStation.Select(Mapper.Map<AMS.Broker.Contracts.DTO.Station>).ToArray();   //trupti270916 for removing mapper
                                                IList<AMS.Broker.Contracts.DTO.Station> result = null;
                                                if (fromStation.Count() > 0)
                                                {
                                                    try
                                                    {
                                                        result = new List<AMS.Broker.Contracts.DTO.Station>();
                                                        foreach (var stn in fromStation)
                                                        {
                                                            AMS.Broker.Contracts.DTO.Station StnDto = new AMS.Broker.Contracts.DTO.Station();
                                                            StnDto.Altitude = stn.Altitude;
                                                            StnDto.Description = stn.Description;
                                                            StnDto.Identifier = stn.Identifier;
                                                            StnDto.IsActive = stn.IsActive;
                                                            //StnDto.IsBlocked = stn.IsBlocked;
                                                            StnDto.Lat = stn.Lat;
                                                            StnDto.Long = stn.Long;
                                                            StnDto.LocationDescription = stn.LocationDescription;
                                                            StnDto.Metadata = stn.Metadata;
                                                            //StnDto.NumberOfMonitors = stn.NumberOfMonitors;
                                                            StnDto.StationId = stn.StationId;
                                                            //StnDto.Type = stn.Type;
                                                            StnDto.ActivationDate = DateTime.Parse(stn.ActivationDate.ToString());
                                                            result.Add(StnDto);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() StationDto Exception :" + ex.Message);
                                                        InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() StationDto Exception :" + ex.Message);// jatin
                                                    }

                                                }
                                                //
                                                if (result != null)
                                                {
                                                    if (result.Count() == 0)
                                                    {
                                                        using (var cxtsLoginUpd = new CentralDBEntities())
                                                        {
                                                            var signedUserUpd = cxtsLoginUpd.Login
                                                                                           .Where(x => x.SecurityUserId.Equals(sid, StringComparison.OrdinalIgnoreCase))
                                                                                           .Where((x => !x.LogoutDate.HasValue))
                                                                                           .FirstOrDefault((x => x.Identifier == signedUser.Identifier));
                                                            signedUserUpd.LogoutDate = DateTime.Now;
                                                            cxtsLoginUpd.SaveChanges();
                                                        }
                                                    }

                                                    foreach (var actstation in result)
                                                    {
                                                        string strIp = actstation.LocationDescription;
                                                        if (!actstation.Identifier.Contains("_mosaic") && !actstation.Identifier.Contains("Webclient") && !actstation.Identifier.Contains("DashBoard"))
                                                        {
                                                            //////form a Url and send request                         

                                                            if (strIp != "")
                                                            {
                                                                try
                                                                {
                                                                    //  string _strUrl = "http://" + strIp + ":4532/soap/ControllerCallBackCommService";
                                                                    // AMS.Broker.AutherizationService.ControllerCallBackCommServiceRef.ControllerCallBackCommServiceClient _serVice = new AMS.Broker.AutherizationService.ControllerCallBackCommServiceRef.ControllerCallBackCommServiceClient("WSHttpBinding_IControllerCallBackCommService", ar.ToString());
                                                                    string _strUrl = "https://" + strIp + ":6532/soap/LoginStatusService";  //trupti250116 for https
                                                                    EndpointAddress ar = new EndpointAddress(_strUrl);

                                                                    AMS.Broker.AutherizationService.LoginStatusServiceRef.LoginStatusClient _serVice = new AMS.Broker.AutherizationService.LoginStatusServiceRef.LoginStatusClient("WSHttpBinding_ILoginStatus", ar.ToString()); //WSHttpBinding_ILoginStatus
                                                                    _serVice.Endpoint.Binding.OpenTimeout = TimeSpan.FromSeconds(3);
                                                                    _serVice.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(3);
                                                                    int nRetVal = _serVice.CheckStatus();

                                                                    _serVice.Close();
                                                                    if (nRetVal < 1)
                                                                    {

                                                                        actstation.IsActive = false;
                                                                        cxtstation.SaveChanges();

                                                                        signedUser.LogoutDate = DateTime.Now;
                                                                        cxtLoginchk.SaveChanges();
                                                                    }
                                                                    else if (nRetVal == 2)
                                                                    {
                                                                        IsAllreadyLoggedIn = true;
                                                                        session = "200";
                                                                    }
                                                                    else
                                                                    {
                                                                        IsAllreadyLoggedIn = true;
                                                                        session = "200";
                                                                    }

                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    var station = cxtstation.Station.FirstOrDefault(x => x.StationId == actstation.StationId);
                                                                    station.IsActive = false;
                                                                    cxtstation.SaveChanges();
                                                                    Console.WriteLine(ex.Message);
                                                                    using (var cxtsLoginUpd = new CentralDBEntities())
                                                                    {
                                                                        var signedUserUpd = cxtsLoginUpd.Login
                                                                                                       .Where(x => x.SecurityUserId.Equals(sid, StringComparison.OrdinalIgnoreCase))
                                                                                                       .Where((x => !x.LogoutDate.HasValue))
                                                                                                       .FirstOrDefault((x => x.Identifier == signedUser.Identifier));
                                                                        signedUserUpd.LogoutDate = DateTime.Now;
                                                                        cxtsLoginUpd.SaveChanges();
                                                                    }
                                                                    IsAllreadyLoggedIn = false;
                                                                    //signedUser.LogoutDate = DateTime.Now;
                                                                    //cxtLoginchk.SaveChanges();
                                                                }
                                                            }

                                                        }

                                                    }
                                                }
                                                //

                                            }
                                            catch (Exception ex)
                                            {
                                                _logger.Info("AuthServiceMembershipImpl CreateSession() Exception:" + ex.Message); 
                                                _logger.ErrorException("RequestMessage - Fault Exception", ex);
                                                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() Exception 1 :" + ex.Message);
                                                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() Exception 1 :" + ex.Message); // jatin
                                            }

                                        }
                                        //
                                    }
                                    else
                                    {
                                        IsAllreadyLoggedIn = false;
                                    }
                                //goto next
                                skipbroker: ;
                                }
                            }
                        }

                    }//
                    else
                    {
                        session = "4";
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Info("AuthServiceMembershipImpl CreateSession() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() Exception 2:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() Exception 2:" + ex.Message); // jatin 
            }

            if (IsAllreadyLoggedIn == false)
            {
                try
                {
                    //amit 26092017
                    if (component == "TouchConfig" || component == "TouchControl" || component == "ThinClient")
                    {
                        using (var context = new CentralDBEntities())
                        {
                            var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

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
                                    session = "passwordExpired";
                                    if (username.ToLower() == "admin")//for admin user password could not be expired
                                    {
                                        MemUser.PasswordValidity = validity;
                                        context.SaveChanges();
                                    }
                                    else
                                    {
                                        return session;
                                    }
                                }
                            }
                        }
                    }

                    if (Membership.ValidateUser(username, password))
                    {
                        _logger.Info("  Authenticated, creating session");
                        using (var context = new CentralDBEntities())
                        {
                            var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                            if (component == "TouchConfig")
                            {
                                if (usr.UserType.UserTypeName == "Super User" || usr.UserType.UserTypeName == "System Administrator")
                                {
                                    _logger.Info("  sid: {0}", usr.UserSid);
                                    //InsertBrokerOperationLog.AddProcessLog("  sid: " + usr.UserSid); // jatin 2408
                                    InsertAuthLog.AddProcessLogAuth("  sid: " + usr.UserSid); // jatin 
                                    if (!String.IsNullOrWhiteSpace(usr.UserSid))
                                    {
                                        session = context.LoadAuthTokenFromDatastore(usr.UserSid, identifier).ToString();
                                        if (String.IsNullOrWhiteSpace(session))
                                            session = context.LogInUser(usr.UserSid, identifier, identifierIP, component).ToString();

                                    }
                                    _logger.Info("  login created: {0}", context.SaveChanges() > 0);
                                   // InsertBrokerOperationLog.AddProcessLog("  login created: " + (context.SaveChanges() > 0).ToString()); // jatin 2408
                                    InsertAuthLog.AddProcessLogAuth("  login created: " + (context.SaveChanges() > 0).ToString()); // jatin 2408

                                    System.Threading.ThreadPool.QueueUserWorkItem(
                                        new System.Threading.WaitCallback(x =>

                                            InformAboutUserLoggedIn(x as UserDTO)
                                            ),
                                        new UserDTO
                                        {
                                            Identifier = identifier,
                                            AuthToken = Guid.Parse(session),
                                            ActiveFrom = DateTime.Now,
                                            SecurityUserId = systemId
                                        });
                                }
                                else //if not super user and system admin dont allow to login
                                {
                                    return "404";
                                }
                            }
                            else
                            {
                                _logger.Info("  sid: {0}", usr.UserSid);
                                if (!String.IsNullOrWhiteSpace(usr.UserSid))
                                {
                                    session = context.LoadAuthTokenFromDatastore(usr.UserSid, identifier).ToString();
                                    if (String.IsNullOrWhiteSpace(session))
                                        session = context.LogInUser(usr.UserSid, identifier, identifierIP, component).ToString();

                                }
                                _logger.Info("  login created: {0}", context.SaveChanges() > 0);

                                System.Threading.ThreadPool.QueueUserWorkItem(
                                    new System.Threading.WaitCallback(x =>

                                        InformAboutUserLoggedIn(x as UserDTO)
                                        ),
                                    new UserDTO
                                    {
                                        Identifier = identifier,
                                        AuthToken = Guid.Parse(session),
                                        ActiveFrom = DateTime.Now,
                                        SecurityUserId = systemId
                                    });
                            }
                            //
                        }
                    }
                    else
                    {
                        using (var cxtsLoginUpd = new CentralDBEntities())
                        {
                             var memUserid = AuthenticationHelper.GetMemUserID(username);

                            Guid memid=new Guid(memUserid);
                            var signedUserUpd = cxtsLoginUpd.aspnet_Membership.Where(x => x.UserId == memid).FirstOrDefault();
                            if (signedUserUpd.IsLockedOut == true)
                            {
                                session = "lock";
                            }
                            else 
                            {
                                if (signedUserUpd.FailedPasswordAttemptCount == 1)
                                {
                                    session = "Attempt1";

                                    if (username.ToLower() == "admin")  //for admin user wrong password komal08112017
                                    {
                                        signedUserUpd.FailedPasswordAttemptCount = 0;
                                        signedUserUpd.IsLockedOut = false;
                                        cxtsLoginUpd.SaveChanges();
                                        session = "Invalid Password";
                                    }
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 2)
                                {
                                    session = "Attempt2";
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 3)
                                {
                                    session = "Attempt3";
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 4)
                                {
                                    session = "Attempt4";
                                }   
                                _logger.Info("  -> user name/password not valid");
                                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() user name/password not valid ");
                                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() user name/password not valid "); // jatin
                            }
                        }
                     
                    }
                }
                catch (Exception ex)
                {
                    _logger.Info("AuthServiceMembershipImpl CreateSession() Exception:" + ex.Message);
                    //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() Exception 3:" + ex.Message);
                    InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() Exception 3:" + ex.Message); // jatin 
                }
                finally
                {
                    ClearMemory();
                }
            }
            else
            {
                try
                {
                    if (Membership.ValidateUser(username, password))
                    {
                        _logger.Info("  Authenticated, creating session");
                        _logger.Info("AuthServiceMembershipImpl Authenticated , creating session:");
                        using (var context = new CentralDBEntities())
                        {
                            var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                            _logger.Info("  sid: {0}", usr.UserSid);
                            if (!String.IsNullOrWhiteSpace(usr.UserSid))
                            {
                                if (identifier.Contains("WebClient") || identifier.Contains("Mobile"))
                                {
                                    session = context.LogInUser(usr.UserSid, identifier,identifierIP, component).ToString();
                                }                               
                            }
                            _logger.Info("  login created: {0}", context.SaveChanges() > 0);

                            System.Threading.ThreadPool.QueueUserWorkItem(
                                new System.Threading.WaitCallback(x => InformAboutUserLoggedIn(x as UserDTO)),
                                new UserDTO
                                {
                                    Identifier = identifier,
                                    AuthToken = Guid.Parse(session),
                                    ActiveFrom = DateTime.Now,
                                    SecurityUserId = systemId
                                });
                        }
                    }
                    else
                    {
                        using (var cxtsLoginUpd = new CentralDBEntities())
                        {
                            var memUserid = AuthenticationHelper.GetMemUserID(username);

                            Guid memid = new Guid(memUserid);
                            var signedUserUpd = cxtsLoginUpd.aspnet_Membership.Where(x => x.UserId == memid).FirstOrDefault();
                            if (signedUserUpd.IsLockedOut == true)
                            {
                                session = "lock";
                            }
                            else 
                            {
                                if (signedUserUpd.FailedPasswordAttemptCount == 1)
                                {
                                    session = "Attempt1";
                                    if (username.ToLower() == "admin")  //for admin user wrong password komal08112017
                                    {
                                        signedUserUpd.FailedPasswordAttemptCount = 0;
                                        signedUserUpd.IsLockedOut = false;
                                        cxtsLoginUpd.SaveChanges();
                                        session = "Invalid Password";
                                    }
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 2)
                                {
                                    session = "Attempt2";
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 3)
                                {
                                    session = "Attempt3";
                                }
                                if (signedUserUpd.FailedPasswordAttemptCount == 4)
                                {
                                    session = "Attempt4";
                                }   
                                _logger.Info("  -> user name/password not valid");
                                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() session 4 user name/password not valid ");
                                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() session 4 user name/password not valid "); // jatin
                            }
                        }
                      
                    }
                }
                catch (Exception ex)
                {
                    _logger.Info("AuthServiceMembershipImpl CreateSession() Exception:" + ex.Message);
                    //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSession() Exception 4:" + ex.Message);
                    InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() Exception 4:" + ex.Message);// jatin 

                }
                finally
                {
                    ClearMemory();
                }
            }
          
            return session;
        }

        public string GetServerConfigIpAddress(string authToken)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl GetServerConfigIpAddress(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl GetServerConfigIpAddress(): Start"); // jatin 
                string OutputString = Storage.WatchdogServiceEndpoint + "," + Storage.StationServiceEnpoint + "," + Storage.SetOperationServiceEndpoint + "," + Storage.GetOperationServiceEndpoint + "," + Storage.TransactionServiceEndpoint + "," + Storage.IntegrationServiceEndpoint + "," + Storage.SecondaryWatchdogServiceEndpoint + "," + Storage.SecondaryStationServiceEnpoint + "," + Storage.SecondarySetOperationServiceEndpoint + "," + Storage.SecondaryGetOperationServiceEndpoint + "," + Storage.SecondaryTransactionServiceEndpoint + "," + Storage.SecondaryIntegrationServiceEndpoint;
                return OutputString;
            }
            catch (Exception ex)
            { 
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl GetServerConfigIpAddress(): Exception"+ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl GetServerConfigIpAddress(): Exception" + ex.Message); //jatin

            }
            return null;
        }

        public bool LogoutConfig(string authToken, string identifier)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl LogoutConfig(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl LogoutConfig(): Start"); // jatin 


                using (var context = new CentralDBEntities())
                {
                    AuthenticationHelper.Logout(context, authToken, identifier);
                }
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl LogoutConfig(): Exception " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl LogoutConfig(): Exception " + ex.Message); // jatin 
            }
            return false;
        }

        public void InformAboutUserLoggedIn(UserDTO _user)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedIn(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedIn(): Start"); // jatin 
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedIn(): _strUrl" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedIn(): _strUrl" + _strUrl); // jatin 
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
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedIn(): OutOfMemoryException: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedIn(): OutOfMemoryException: " + ex.Message); // jatin 
                _logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedIn(): Exception :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedIn(): Exception :" + ex.Message);//jatin 
                _logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ClearMemory();
            }

        }

        public void InformAboutUserLoggedOut(UserDTO _user)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedOut(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedOut(): Start"); // jatin 
                string _strUrl = "https://" + Storage.StationServiceEnpoint + ":6530/soap/StationsService";
                EndpointAddress ar = new EndpointAddress(_strUrl);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedOut(): _strUrl" + _strUrl);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedOut(): _strUrl" + _strUrl);//jatin
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
                _logger.Info("StationsServiceImpl ActivateStationInform() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedOut() OutOfMemoryException: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedOut() OutOfMemoryException: " + ex.Message); // jatin 
            }
            catch (Exception ex)
            {
                _logger.Info("StationsServiceImpl UpdateRegistionInfoStationInformTask() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl InformAboutUserLoggedOut() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl InformAboutUserLoggedOut() Exception: " + ex.Message); // jatin 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ClearMemory();
            }
        }

        public string CreateSessionClient(string identifier, string systemId, string username, string password,string identifierIP, string component,string FCMToken=null)
        {
            var session = "";
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSessionClient(): Start");
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSessionClient(): Start");//jatin 

                using (var context = new CentralDBEntities())
                {
                    var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

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
                            session = "passwordExpired";
                            if (username.ToLower() == "admin")//for admin user password could not be expired
                            {
                                MemUser.PasswordValidity = validity;
                                context.SaveChanges();
                            }
                            else
                            {
                                return session;
                            }
                        }
                    }
                }

                if (Membership.ValidateUser(username, password))
                {
                    using (var context = new CentralDBEntities())
                    {
                        var usr = context.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                        if (!String.IsNullOrWhiteSpace(usr.UserSid))
                        {
                            session = context.LoadAuthTokenFromDatastore(usr.UserSid, identifier).ToString();
                            if (String.IsNullOrWhiteSpace(session))
                                session = context.LogInUser(usr.UserSid, identifier, identifierIP, component).ToString();

                            if (identifier.Contains("Mobile"))
                            {
                                if (usr != null)
                                {
                                    var userRole = context.UserType.Single(user1 => user1.UserTypeId == usr.UserTypeId);
                                    //var role= userRole.UserTypeName.ToString();
                                    //session = session + "_" + role;
                                }
                            }
                        }  
                        context.SaveChanges();
                        _logger.Info("  login created: {0}", "true");
                    }

                    try
                    {
                        if (identifier.Contains("Mobile"))
                        {
                            if (FCMToken != "" && FCMToken != null)
                            {
                                using (var ctx = new CentralDBEntities())
                                {
                                    try
                                    {
                                        var tokenCheck = ctx.tblDeviceFCMToken.Where(x => x.FCMToken == FCMToken).FirstOrDefault();
                                        if (tokenCheck != null)
                                        {
                                            //if fcm token present than do nothing
                                        }
                                        else
                                        {
                                            //Check if device is present
                                            if (tokenCheck == null)
                                            {
                                                var identifierCheck = ctx.tblDeviceFCMToken.Where(x => x.Device_ID == identifier).FirstOrDefault();
                                                if (identifierCheck != null)
                                                {
                                                    //Entry is already present then update 
                                                    identifierCheck.FCMToken = FCMToken;
                                                    ctx.tblDeviceFCMToken.Attach(identifierCheck);
                                                    ctx.Entry(identifierCheck).State = System.Data.EntityState.Modified;
                                                    ctx.SaveChanges();
                                                }
                                                else
                                                {
                                                    tblDeviceFCMToken tbl = new tblDeviceFCMToken()
                                                    {
                                                        Device_ID = identifier,
                                                        FCMToken = FCMToken
                                                    };
                                                    ctx.tblDeviceFCMToken.Add(tbl);
                                                    ctx.SaveChanges();
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSessionClient() Exception:"+ex.Message);//jatin
                                    }
                                }
                            }
                        }
                        //
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    using (var cxtsLoginUpd = new CentralDBEntities())
                    {
                        var memUserid = AuthenticationHelper.GetMemUserID(username);

                        Guid memid = new Guid(memUserid);
                        var signedUserUpd = cxtsLoginUpd.aspnet_Membership.Where(x => x.UserId == memid).FirstOrDefault();
                        if (signedUserUpd.IsLockedOut == true)
                        {
                            session = "lock";
                        }
                        else
                        {
                            if (signedUserUpd.FailedPasswordAttemptCount == 1)
                            {
                                session = "Attempt1";
                                if (username.ToLower() == "admin")  //for admin user wrong password komal08112017
                                {
                                    signedUserUpd.FailedPasswordAttemptCount = 0;
                                    signedUserUpd.IsLockedOut = false;
                                    cxtsLoginUpd.SaveChanges();
                                    session = "Invalid Password";
                                }
                            }
                            if (signedUserUpd.FailedPasswordAttemptCount == 2)
                            {
                                session = "Attempt2";
                            }
                            if (signedUserUpd.FailedPasswordAttemptCount == 3)
                            {
                                session = "Attempt3";
                            }
                            if (signedUserUpd.FailedPasswordAttemptCount == 4)
                            {
                                session = "Attempt4";
                            }
                            _logger.Info("  -> password not valid");
                            InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSession() user name/password not valid ");
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CreateSessionClient() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CreateSessionClient() Exception: " + ex.Message); // jatin 
            }
            finally
            {
                ClearMemory();
            }
            return session;
        }

        public string CreateWeakSession(string identifier, string systemId, string username)
        {
            throw new NotImplementedException();
        }

        public bool CloseSession(string authToken, string identifier)
        {
            try
            {
                using (var context = new CentralDBEntities())
                {
                    context.Logout(authToken, identifier);
                    context.SaveChanges();

                    System.Threading.ThreadPool.QueueUserWorkItem(
                        new System.Threading.WaitCallback(x => InformAboutUserLoggedOut(x as UserDTO)),
                        new UserDTO
                            {
                                Identifier = identifier,
                                AuthToken = Guid.Parse(authToken),
                                ActiveTill = DateTime.Now
                            });
                }              
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("AuthServiceMembershipImpl CloseSession() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("AuthServiceMembershipImpl CloseSession() Exception: " + ex.Message);
                InsertAuthLog.AddProcessLogAuth("AuthServiceMembershipImpl CloseSession() Exception: " + ex.Message); // jatin 
                _logger.Error(ex);
            }
            finally
            {
                ClearMemory();
            }
            return false;
        }

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
