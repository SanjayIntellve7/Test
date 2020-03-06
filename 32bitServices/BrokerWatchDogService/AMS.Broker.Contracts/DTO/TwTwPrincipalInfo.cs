using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class TwTwPrincipalInfo
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string AuthenticationType;

        [DataMember]
        public string[] Roles;
    }
}
