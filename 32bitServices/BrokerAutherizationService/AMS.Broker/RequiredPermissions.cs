using System;

namespace AMS.Broker
{
    public sealed class RequiredPermissions : Attribute
    {
        public RequiredPermissions(string groupName)
        {
            GroupName = groupName;
        }

        public string GroupName { get; set; }
    }
}
