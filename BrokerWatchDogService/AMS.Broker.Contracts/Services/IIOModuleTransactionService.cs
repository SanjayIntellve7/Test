using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIOModuleTransactionService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        bool HooterActivate(string deviceID);

        [OperationContract]
        bool HooterDeactivate(string deviceID);

        [OperationContract]
        bool HooterStatus(string deviceID);

        [OperationContract]
        bool GateOpen(string deviceID);

        [OperationContract]
        bool GateClose(string deviceID);
    }
}
