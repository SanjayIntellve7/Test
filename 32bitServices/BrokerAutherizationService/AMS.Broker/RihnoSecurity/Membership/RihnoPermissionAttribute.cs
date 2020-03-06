using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.RihnoSecurity.Membership
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]    
    public class RihnoPermissionAttribute : CodeAccessSecurityAttribute
    {
        public string Operation { get; set; }

        public RihnoPermissionAttribute(SecurityAction action = SecurityAction.Demand)
            : base(action)
        {
        }

        public override IPermission CreatePermission()
        {
            return new PrincipalPermission(null, Operation, true);
        }
    }
}
