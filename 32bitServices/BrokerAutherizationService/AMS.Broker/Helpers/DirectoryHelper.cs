using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace AMS.Broker.AutherizationService.Helpers
{
    public static class DirectoryHelper
    {
        public static void AddGroup(string groupName)
        {
            var rootDirectoryItem = GetRootDirectoryEntry();
            var groupsContainer = GetGroupsContainer(rootDirectoryItem);

            var group = groupsContainer.Children.Add("CN=" + groupName, "group");

            group.CommitChanges();
            groupsContainer.CommitChanges();
        }

        public static void AddUserToGroup(string userName, string groupName)
        {
            var rootDirectoryItem = GetRootDirectoryEntry();
            var groupsContainer = GetGroupsContainer(rootDirectoryItem);

            var group = groupsContainer.Children.Find("CN=" + groupName, "group");

            group.Properties["member"].Add("CN=" + userName + ",CN=Users," + Storage.Container);

            group.CommitChanges();
        }

        public static void RemoveGroup(string groupName)
        {
            var rootDirectoryItem = GetRootDirectoryEntry();
            var groupsContainer = GetGroupsContainer(rootDirectoryItem);

            var group = groupsContainer.Children.Cast<DirectoryEntry>().FirstOrDefault(x => String.Equals(x.Name, "CN=" +  groupName, StringComparison.OrdinalIgnoreCase));
            if (group != null)
            {
                groupsContainer.Children.Remove(group);
                group.CommitChanges();
                groupsContainer.CommitChanges();
            }
        }
        public static IEnumerable<string> GetUsers(string groupName)
        {
            using (var ctx = AuthenticationHelper.GetPrincipalContext())
            {
                var group = GroupPrincipal.FindByIdentity(ctx, groupName);

                if (group != null)
                    foreach (var user in group.GetMembers(true))
                        if (user is UserPrincipal)
                            yield return (user as UserPrincipal).Name;
            }
        }

        private static DirectoryEntry GetRootDirectoryEntry()
        {
            var context = Storage.Context.Equals("Domain", StringComparison.OrdinalIgnoreCase) ? ContextType.Domain : ContextType.ApplicationDirectory;
            var domain = Storage.Domain;
            var container = Storage.Container;
            var ldapUsername = Storage.User;
            var ldapPassword = Storage.Password;
            var fullPath = "LDAP://" + domain;

            if (!String.IsNullOrWhiteSpace(container))
                fullPath += "/" + container;

            var rootDirectoryItem = new DirectoryEntry(fullPath, ldapUsername, ldapPassword);
            return rootDirectoryItem;
        }
        private static DirectoryEntry GetGroupsContainer(DirectoryEntry rootDirectoryEntry)
        {
            var rolesContainerName = Storage.RolesContainerName;
            DirectoryEntry groupContainer = rootDirectoryEntry;

            foreach (var containerName in rolesContainerName.Split(';'))
            {
                groupContainer = groupContainer.Children.Cast<DirectoryEntry>().FirstOrDefault(x => String.Equals(x.Name, containerName, StringComparison.OrdinalIgnoreCase));
            }

            return groupContainer;
            //return rootDirectoryEntry.Children.Cast<DirectoryEntry>().FirstOrDefault(x => x.Name == rolesContainerName);
        }
    }
}
