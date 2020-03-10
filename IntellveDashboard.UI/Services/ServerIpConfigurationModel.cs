using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IntellveDashboard.UI
{
    public class ServerIpConfigurationModel
    {
        public string WatchDogServiceIp { get; set; }
        public string CommunicationServiceIp { get; set; }
        public string AutherizationServiceIp { get; set; }
        public string GetOperationServiceIp { get; set; }
        public string SetOperationServiceIp { get; set; }
        public string IntegrationServiceIp { get; set; }
        public string TransactionServiceIp { get; set; }
        public string SecondaryWatchDogServiceIp { get; set; }
        public string SecondaryCommunicationServiceIp { get; set; }
        public string SecondaryAutherizationServiceIp { get; set; }
        public string SecondaryGetOperationServiceIp { get; set; }
        public string SecondarySetOperationServiceIp { get; set; }
        public string SecondaryIntegrationServiceIp { get; set; }
        public string SecondaryTransactionServiceIp { get; set; }
        public Guid AuthToken { get; set; }
        public string RoleName { get; set; }
        public long UserSiteID { get; set; }
        public GenericIdentity AuthenticatedUser { get; set; }
        public string ServerName { get; set; }
    }
}
