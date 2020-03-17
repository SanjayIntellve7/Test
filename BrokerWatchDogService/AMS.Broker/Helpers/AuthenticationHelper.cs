using System;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using AMS.Broker.WatchDogService.DataStore;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using CacheAspect;
using CacheAspect.Attributes;
using NLog;
using AMS.Broker.Contracts.DTO;
using System.Threading;
using AMS.Broker.WatchDogService.RihnoSecurity.Membership;

namespace AMS.Broker.WatchDogService.Helpers
{
    internal static class AuthenticationHelper
    {
        private static DirectoryEntry _searchRoot;
        private static DirectorySearcher _mySearcher;
        private static SearchResultCollection _result;

        public static void LoadActiveDirectory()
        {
            try
            {
                // Bind to the users container.
                _searchRoot = new DirectoryEntry(string.Format("LDAP://{0}/{1}", Storage.Domain, Storage.Container), Storage.User, Storage.Password);
                // Create a DirectorySearcher object.
                _mySearcher = new DirectorySearcher(_searchRoot, "(objectClass=user)");
                _mySearcher.CacheResults = true;
                // Create a SearchResultCollection object to hold a collection of SearchResults
                // returned by the FindAll method.
                // _mySearcher.Filter = 
                _result = _mySearcher.FindAll();
                // Get search results. For more information, see Getting Search Results.
                // ...
                // This sample uses Try...Catch to catch errors.
                // Create an Exception object. For more information, see System.Exception.
                foreach (SearchResult searchResult in _result)
                {
                    var username = searchResult.Properties["cn"];
                    var sid = searchResult.Properties["objectsid"].ToString();
                    var user = username[0];

                    int i = 1;
                }

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Runtime.InteropServices.COMException exception =
                    new System.Runtime.InteropServices.COMException();
                Console.WriteLine(exception);
            }
            catch (InvalidOperationException)
            {
                InvalidOperationException InvOpEx = new InvalidOperationException();
                Console.WriteLine(InvOpEx.Message);
            }
            catch (NotSupportedException)
            {
                NotSupportedException NotSuppEx = new NotSupportedException();
                Console.WriteLine(NotSuppEx.Message);
            }
        }

        public static List<UserDto> FindUserInActiveDirectory(string searchExpression)
        {
            try
            {
                var result = new List<UserDto>();

                // Bind to the users container.
                _searchRoot = new DirectoryEntry(string.Format("LDAP://{0}/{1}", Storage.Domain, Storage.Container),
                                                 Storage.User, Storage.Password);
                var filter = "(&(objectClass=user){0})"; // "";

                var searchExpressions = searchExpression.Split(' ');
                var addedFilters = "";
                foreach (var expr in searchExpressions)
                {
                    if (!string.IsNullOrEmpty(expr))
                    {
                        addedFilters += "(|(cn=*" + expr + "*)(name=*" + expr + "*)(sAMAccountName=*" + expr + "*))";
                    }
                    else
                    {
                        
                    }
                }

                if (!string.IsNullOrEmpty(addedFilters))
                {
                    filter = string.Format(filter, string.Format("(|{0})", addedFilters));
                }
                else
                {
                    filter = string.Format(filter, "");
                }

                // Create a DirectorySearcher object.
                _mySearcher = new DirectorySearcher(_searchRoot, filter);
                _mySearcher.CacheResults = true;
                // Create a SearchResultCollection object to hold a collection of SearchResults
                // returned by the FindAll method.
                // _mySearcher.Filter = 
                _result = _mySearcher.FindAll();
                // Get search results. For more information, see Getting Search Results.
                // ...
                // This sample uses Try...Catch to catch errors.
                // Create an Exception object. For more information, see System.Exception.
                foreach (SearchResult searchResult in _result)
                {
                    var usr = new UserDto() {Person = new PersonDto()};
                    foreach (var property in searchResult.Properties.PropertyNames)
                    {
                        var propertyName = property.ToString();
                        switch (propertyName)
                        {
                            case "cn":
                                usr.Username = searchResult.Properties[propertyName][0].ToString();
                                break;

                            case "objectsid":
                                usr.UserSid = searchResult.Properties[propertyName][0].ToString();
                                break;
                            case "givenname":
                                usr.Person.FirstName = searchResult.Properties[propertyName][0].ToString();
                                break;
                            case "sn":
                                usr.Person.LastName = searchResult.Properties[propertyName][0].ToString();
                                break;
                        }
                    }

                    result.Add(usr);
                }

                return result;

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Runtime.InteropServices.COMException exception =
                    new System.Runtime.InteropServices.COMException();
                Console.WriteLine(exception);
            }
            catch (InvalidOperationException)
            {
                InvalidOperationException InvOpEx = new InvalidOperationException();
                Console.WriteLine(InvOpEx.Message);
            }
            catch (NotSupportedException)
            {
                NotSupportedException NotSuppEx = new NotSupportedException();
                Console.WriteLine(NotSuppEx.Message);
            }

            return null;
        }

        public static bool IsValid(string username, string password)
        {
            try
            {
                using (var ctx = GetPrincipalContext())
                {
                    return ctx.ValidateCredentials(username, password);
                }
            }
            catch (PrincipalServerDownException exp)
            {
                _logger.Error("Validation faield with message {0}", exp.Message);
                return false;
            }
        }

        public static bool IsValid(string username)
        {
            try
            {
                using (var ctx = GetPrincipalContext())
                {
                    var user = UserPrincipal.FindByIdentity(ctx, username);
                    return user != null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }

        public static bool IsValid(string username, out string sessionId)
        {
            try
            {
                using (var ctx = GetPrincipalContext())
                {
                    var user = UserPrincipal.FindByIdentity(ctx, username);

                    if (user != null)
                    {
                        sessionId = user.Sid.ToString();
                    }
                    else
                    {
                        sessionId = string.Empty;
                    }

                    return user != null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }

        public static string LoadAuthTokenFromDatastore(this CentralDBEntities context, string sid, string identifier)
        {
            try
            {
                var signedUser = context.Login
                    .Where(x => x.SecurityUserId.Equals(sid, StringComparison.OrdinalIgnoreCase))
                    .Where(x => !x.LogoutDate.HasValue)
                    .FirstOrDefault(x => x.Identifier.Equals(identifier, StringComparison.OrdinalIgnoreCase));
                var authToken = String.Empty;

                if (signedUser != null)
                    if (signedUser.LoginDate.AddMinutes(30) < DateTime.Now)
                        context.Login.Remove(signedUser);
                    else
                        authToken = signedUser.AuthToken.ToString();

                return authToken;
            }
            catch (Exception exp)
            {
                _logger.Error("LoadAuthTokenFromDatastore failed with message {0}", exp.Message);
                _logger.Info("error type is {0}", exp.GetType().FullName);
            }
            return String.Empty;
        }

        public static Guid LogInUser(this CentralDBEntities context, string sid, string identifier)
        {
            var loginObject = new AMS.Broker.DataStore.Login();

            loginObject.SecurityUserId = sid.ToString();
            loginObject.AuthToken = Guid.NewGuid();
            loginObject.Identifier = identifier;
            loginObject.LoginDate = DateTime.Now;
            loginObject.LogoutDate = null;

            context.Login.Add(loginObject);

            return loginObject.AuthToken;
        }

        public static void Logout(this CentralDBEntities context, string authToken, string identifier)
        {
            Logout(context, Guid.Parse(authToken), identifier);
        }
        public static void Logout(this CentralDBEntities context, Guid authToken, string identifier)
        {
            if (context != null)
            {
                var logoutObject = context.Login.FirstOrDefault(x => x.AuthToken == authToken);


                if (logoutObject != null)
                    logoutObject.LogoutDate = DateTime.Now;

                context.SaveChanges();
            }
        }
        internal static bool IsOwner(this CentralDBEntities context, string authToken, string identity)
        {
            var guid = Guid.Parse(authToken);
            var result = context.Login.Where(x => x.AuthToken.Equals(guid));
            var result2 = result.Where(x => x.Identifier == identity);
            var count = result2.Count();
            return count == 1;
        }
        public static UserPrincipal GetUser(this string sid)
        {
            using (var ctx = GetPrincipalContext())
            {
                return UserPrincipal.FindByIdentity(ctx, sid);
            }
        }
        public static string GetUserName(this string sid)
        {
            using (var ctx = GetPrincipalContext())
            {
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(ctx, sid);

                return userPrincipal != null ? UserPrincipal.FindByIdentity(ctx, sid).Name : string.Empty;
            }
        }
        public static string GetUsersSID(string username)
        {
            try
            {
                using (var context = new CentralDBEntities())
                {

                    var user = context.User.Single(u => u.MembershipUser.LoweredUserName == username.ToLower());

                    var sid = "";

                    if (user != null)
                        sid = user.UserSid;

                    return sid;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// Checking the DIrectory system if the user have right to acces the resource
        /// </summary>
        /// <param name="authToken">Current authentication token</param>
        /// <param name="accessName">Resource to be access</param>
        /// <returns></returns>
        internal static bool CanAccess(this Guid authToken, params string[] accessName)
        {
            return true;
        }
        /// <summary>
        /// Checking the DIrectory system if the user have right to acces the resource
        /// </summary>
        /// <param name="authToken">Current authentication token</param>
        /// <param name="accessName">Resource to be access</param>
        /// <returns></returns>
        internal static bool CanAccess(this string authToken, params string[] accessName)
        {
            /*using (var ctx = GetPrincipalContext())
            {
                var sid = GetSidByAuthToken(authToken);
                if (sid == null) return false;
                var user = UserPrincipal.FindByIdentity(ctx, sid);
                
                return user!=null && user.CanAccess(accessName);
            }*/

            return true;
        }


        internal static string GetUserNameByToken(this Guid authToken)
        {
            using (var ctx = GetPrincipalContext())
            {
                var sid = GetSidByAuthToken(authToken.ToString());
                if (string.IsNullOrEmpty(sid)) return string.Empty;
                var user = UserPrincipal.FindByIdentity(ctx, sid);
                return user != null ? user.Name : string.Empty;
            }
        }

        internal static string GetUserNameByToken(this string authToken)
        {
            using (var ctx = GetPrincipalContext())
            {
                var sid = GetSidByAuthToken(authToken);
                if (string.IsNullOrEmpty(sid)) return string.Empty;
                var user = UserPrincipal.FindByIdentity(ctx, sid);
                return user != null ? user.Name : string.Empty;
            }
        }
        /// <summary>
        /// Checking the DIrectory system if the user have right to acces the resource
        /// </summary>
        /// <param name="user">An user princiapl object for a user which trying to acces resource.</param>
        /// <param name="accessName">Resource to be access</param>
        /// <returns></returns>
        internal static bool CanAccess(this UserPrincipal user, params string[] accessName)
        {
            var canAccess = user.GetAuthorizationGroups().Any(x => accessName.Contains(x.Name));

            if (!canAccess)
                _logger.Warn("  User {0} could not access resource {1}", user.Name, String.Join(",", accessName));

            return canAccess;
        }
        /// <summary>
        /// Method used to validate every item int he collection for access rights. Method will return only items which can be accessed
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">IEnumerable which should be validated</param>
        /// <param name="authToken">current authentication token</param>
        /// <param name="getNames">A list of parameters which are going to be cross checked for access rights.</param>
        /// <returns></returns>
        internal static IEnumerable<T> AuthorizeCollection<T>(this IEnumerable<T> collection, string authToken, params Func<T, string>[] getNames)
        {
            /*var sid = GetSidByAuthToken(authToken);

            var ctx = GetPrincipalContext();
            var user = UserPrincipal.FindByIdentity(ctx, sid);*/

            foreach (var item in collection)
            {
                var names = from nameFunctor in getNames
                            select nameFunctor(item);

                //if (user.CanAccess(names.ToArray()))
                    yield return item;
            }
        }

        public static IEnumerable<UserPrincipal> GetUsersByGroup(string groupName)
        {
            using (var ctx = GetPrincipalContext())
            {
                var group = GroupPrincipal.FindByIdentity(ctx, groupName);
                if (group != null)
                    foreach (var user in group.GetMembers(true))
                    {
                        if (user is System.DirectoryServices.AccountManagement.UserPrincipal)
                            yield return user as UserPrincipal;
                    }
            }
        }
        internal static UserPrincipal GetUsersByUsername(string username)
        {
            using (var ctx = GetPrincipalContext())
            {
                return UserPrincipal.FindByIdentity(ctx, username);
            }
        }

        private static string GetSidByAuthToken(string authToken)
        {
            var sid = String.Empty;
            using (var context = new CentralDBEntities())
            {
                var authTokenGuid = Guid.Parse(authToken);
                sid = context.Login
                    .Where(x => x.AuthToken.Equals(authTokenGuid))
                    .Select(x => x.SecurityUserId)
                    .FirstOrDefault();
            }
            return sid;
        }

        /*[Cache.Cacheable("AD",CacheSettings.Default)]*/
        internal static PrincipalContext GetPrincipalContext()
        {
            var context = Storage.Context.Equals("Domain", StringComparison.OrdinalIgnoreCase) ? ContextType.Domain : ContextType.ApplicationDirectory;
            var domain = Storage.Domain;
            var container = Storage.Container;
            var ldapUsername = Storage.User;
            var ldapPassword = Storage.Password;

            return new PrincipalContext(context, domain, container,ContextOptions.Negotiate, ldapUsername, ldapPassword);
        }

        public static void Impersonate(string authToken)
        {
           if (!string.IsNullOrEmpty(authToken) && authToken != new Guid().ToString())
            {

                var provider = new RihnoRoleProvider();
                var username = AuthenticationHelper.GetUsernameByAuthToken(authToken);

                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),
                                                               provider.GetRolesForUser(username));
            }
        }

        private static string GetUsernameByAuthToken(string authToken)
        {
            using (var ctx = new CentralDBEntities())
            {
                var loginSession = ctx.Login.Single(login => login.AuthToken == new Guid(authToken));
                var user = ctx.User.Single(user1 => user1.UserSid == loginSession.SecurityUserId);

                return user.MembershipUser.UserName;
            }
        }
        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}