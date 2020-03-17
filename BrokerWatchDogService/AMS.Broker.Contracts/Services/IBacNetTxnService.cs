using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IBacNetTxnService
    {
        [OperationContract]
        string Test();

        [OperationContract]
        bool SendBacnetEventDetails(BacNetEventDetailsDto _bacNetEventDetailsDto);

        [OperationContract]
        bool SendBacNetAlertDeatils(string DeviceName, string PresentVal);
    }
}
