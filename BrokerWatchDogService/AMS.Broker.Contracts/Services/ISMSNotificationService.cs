using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISMSNotificationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        void SendSmsNotification(string MobNo, string Msg);


        [OperationContract]
        void SendEventSMS(string _msg, int eventCode);

        [OperationContract]
        bool SendBulkSMSNotification(List<string> AllEmailList, string authToken, string strMessage);

    }
}
