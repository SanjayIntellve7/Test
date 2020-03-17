using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IMobileNotificationService
    {
        [OperationContract]
        void Test();

        [OperationContract]
        void SendMobileNotificationNative(string AlertID);

        [OperationContract]
        void SendMobNotificationToAddnContacts(string FCMToken, string PhNo, string AlertId);

        [OperationContract]
        string GetSLAWebIpPort();

        [OperationContract]
        void SendSLAMobileNotification(string PhoneNumber, string MessageBody, string MessageTitle);

        [OperationContract]
        void SendEscallationMobileNotification(string PhoneNumber, string MessageBody, string MessageTitle);

        

        [OperationContract]
        bool SendBulkMobileNotification(List<string> AllEmailList, string authToken, string strMessage);
        
    }
}
