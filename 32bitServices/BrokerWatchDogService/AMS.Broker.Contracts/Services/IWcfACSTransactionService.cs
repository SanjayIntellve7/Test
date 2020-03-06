using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IWcfACSTransactionService
    {
        [OperationContract(Name = "IntegrateACS")]
        string IntegrateACS(string Username, string Passward);

        [OperationContract(Name = "ConsumeAcsAlert")]
        int ConsumeAcsAlert(string deviceId, string errorCode, string dateTime);
    }
}
