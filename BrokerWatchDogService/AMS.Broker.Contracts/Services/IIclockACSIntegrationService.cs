using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIclockACSIntegrationService
    {
        [OperationContract]
        bool ACUnlock(string IPAddress, string Port);

        [OperationContract]
        bool GetDoorState(int machineID, int val, string IPAddress, string Port);

        [OperationContract]
        bool GeDeviceStatus(string IPAddress, string Port);

        [OperationContract]
        bool AnnunciatorCommand(string IPAddress, string Port);
    }
}
