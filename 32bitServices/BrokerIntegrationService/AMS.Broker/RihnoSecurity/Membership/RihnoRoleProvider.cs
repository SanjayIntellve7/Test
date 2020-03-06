using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Rhino.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.RihnoSecurity.Membership
{
    using AMS.Broker.IntegrationService.DataStore;
    using Microsoft.Practices.ServiceLocation;
    using NHibernate.Cache;
    using NHibernate.Cfg;
    using Rhino.Security;
    using Rhino.Security.Services;
    using System.Configuration;
    using System.Web.Security;
    using Membership = System.Web.Security.Membership;
    using Configuration = NHibernate.Cfg.Configuration;

    /// <summary>
    /// RoleProvider wrapper for Rhino Security.
    /// Note: this is still a raw & bugged implementation, needs polish.
    /// </summary>
    public class RihnoRoleProvider : RoleProvider
    {

        protected static ISessionFactory Factory;
        protected static ISession Session;
        protected static IAuthorizationRepository AuthRepository;
        protected static IPermissionsBuilderService PermissionsBuilderService;
        protected static IPermissionsService PermissionService;
        protected static IAuthorizationService AuthorizationService;
        
        public RihnoRoleProvider()
        {

            var cfg = new Configuration()
                .SetProperty(Environment.ConnectionDriver, typeof(Sql2008ClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.Dialect, typeof(MsSql2008Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, Storage.RhinoConnectionString)//ConfigurationManager.AppSettings["RhinoSecurity.ConnectionString"]) amit 23052017
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.UseSecondLevelCache, "true")
                .SetProperty(Environment.UseQueryCache, "true")
                .SetProperty(Environment.CacheProvider, typeof(HashtableCacheProvider).AssemblyQualifiedName)
                .AddAssembly(typeof(User).Assembly);

            Security.Configure<User>(cfg, SecurityTableStructure.Prefix);

            Factory = cfg.BuildSessionFactory();

            Session = Factory.OpenSession();
            Session.FlushMode = FlushMode.Always;            

            AuthRepository = new AuthorizationRepository(Session);
            PermissionsBuilderService = new PermissionsBuilderService(Session, AuthRepository);
            PermissionService = new PermissionsService(AuthRepository, Session);
            AuthorizationService = new AuthorizationService(PermissionService, AuthRepository);
        }

        public override string ApplicationName { get; set; }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var resultPermissions = new List<string>();

                using (var ctx = new CentralDBEntities())
                {
                    var usr =
                        ctx.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                    var permissions = PermissionService.GetPermissionsFor(usr);
                    foreach (var perm in permissions)
                    {
                        if (perm.Allow)
                        {
                            resultPermissions.Add(perm.Operation.Name);
                        }
                    }
                }
                return resultPermissions.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }

            
        }     

        public override bool IsUserInRole(string username, string operationName)
        {
            using (var ctx = new CentralDBEntities())
            {
                var usr =
                    ctx.User.Single(user => user.MembershipUser.LoweredUserName == username.ToLower());

                return AuthorizationService.IsAllowed(usr, operationName);
            }

            return false;
        }

        public override bool RoleExists(string roleName)
        {
            return AuthRepository.GetOperationByName(roleName) != null;
        }

        #region Not Needed But Implemented

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            using (var ctx = new CentralDBEntities())
            {
                var users = ctx.User.Where(user => usernames.Contains(user.MembershipUser.LoweredUserName));
                foreach (var user in users)
                {
                    var pbs = PermissionsBuilderService as PermissionsBuilderService;
                    foreach (var roleName in roleNames)
                    {
                        CreateNonExistentOperation(roleName);

                        pbs.Allow(roleName).For(user).OnEverything().DefaultLevel().Save();
                    }
                }
                Session.Flush();
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var resultUsers = new List<string>();

            using (var ctx = new CentralDBEntities())
            {
                var permissions = PermissionService.GetPermissionsFor(roleName);
                foreach (var perm in permissions)
                {
                    if (perm.Allow)
                    {
                        var usrId = (perm.User as User).UserId;
                        var usr = ctx.User.Single(user => user.UserId == usrId);

                        if (usr.MembershipUser.LoweredUserName.Contains(usernameToMatch.ToLower()))
                        {
                            resultUsers.Add(usr.MembershipUser.UserName);
                        }
                    }
                }
            }

            return resultUsers.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var resultUsers = new List<string>();

            using (var ctx = new CentralDBEntities())
            {
                var premissions = PermissionService.GetPermissionsFor(roleName);
                foreach (var prem in premissions)
                {
                    if (prem.Allow)
                    {
                        var usrId = (prem.User as User).UserId;
                        var usr = ctx.User.Single(user => user.UserId == usrId);

                        resultUsers.Add(usr.MembershipUser.UserName);
                    }
                }
            }

            return resultUsers.ToArray();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            using (var ctx = new CentralDBEntities())
            {
                var pbs = PermissionsBuilderService as PermissionsBuilderService;

                foreach (var userName in usernames)
                {
                    var usr = ctx.User.Single(user => user.MembershipUser.UserName == userName);
                    foreach (var roleName in roleNames)
                    {
                        pbs.Deny(roleName).For(usr).OnEverything().DefaultLevel().Save();
                    }
                }
                Session.Flush();
            }
        }

        #endregion

        #region Not Implemented

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Helper function
        /// </summary>        
        private void CreateNonExistentOperation(string operationName)
        {
            var operation = AuthRepository.GetOperationByName(operationName);
            if (operation == null)
            {
                AuthRepository.CreateOperation(operationName);
                Session.Flush();
            }
        }
    }
}
