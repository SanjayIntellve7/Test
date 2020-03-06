using System.Security.Principal;

namespace AMS.Broker.Security
{
    internal sealed class Principal : IPrincipal
    {
        public Principal(IIdentity client)
        {
            Identity = client;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; private set; }
    }
}
