using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    public enum BrokerSetOpStatus
    {
        Live
    };

    [ServiceContract]
    public interface ISetOperationService
    {
        [OperationContract]
        BrokerSetOpStatus Ping();

      
    }
}
