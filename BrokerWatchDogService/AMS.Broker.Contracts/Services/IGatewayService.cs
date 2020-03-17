using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    public enum BrokerStatus
    {
        Live
    };

    [ServiceContract]
    public interface IGatewayService
    {
        [OperationContract]
        BrokerStatus Ping();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ValidateCredentials(string username, string password);

        [OperationContract]
        bool ValidateUserName(string username);

        [OperationContract]
        bool PingWatchDog();

        [OperationContract]
        string TestCommunication();

     //  [OperationContract]
     //  bool PingClient();

        
    }
}
