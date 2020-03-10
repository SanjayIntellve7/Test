using IntellveDashboard.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetIdentifier(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.Identifier);

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }
        public static string GetToken(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.Token);

            if (claim == null)
                return string.Empty;

            return claim.Value;
        }
    }
}
