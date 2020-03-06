using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker
{
    [ServiceContract(Namespace = "", CallbackContract = typeof(IAlarmClient))]
    public interface IAlarmService
    {

        [OperationContract(IsOneWay = true)]
        void Ping(string systemId, string controllerId);

        [OperationContract(IsOneWay = false)]
        string Register(string systemId, string username, string password, string controllerId, string[] alarmIds);

        [OperationContract(IsOneWay = false)]
        bool Deregister(string systemId, string username, string password, string controllerId, string[] alarmIds);

        [OperationContract(IsOneWay = false)]
        bool ResetAlarm(string systemId, string token, string controllerId, string alarmId);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string systemId, string token, string controllerId);
        
    }

    [ServiceContract]
    public interface IAlarmClient
    {
        [OperationContract(IsOneWay = true)]
        void Pong();

        [OperationContract(IsOneWay = true)]
        void ReceiveInfo(string info);

        [OperationContract(IsOneWay = true)]
        void ReceiveError(string error);

        [OperationContract(IsOneWay = false)]
        bool ReceiveAlarm(string alarmId, int alarmType, int severity, string message, double longitude, double latitude);

        [OperationContract(IsOneWay = true)]
        void SessionExpired(DateTime expiryTime);
    }
}
