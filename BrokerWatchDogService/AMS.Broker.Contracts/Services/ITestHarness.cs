using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ITestHarness
    {
        [OperationContract]
        void PingStations();

        //[OperationContract]
        //void FireAlarm(string systemId, string alarmId);

        //[OperationContract]
        //void FireAlarm2(string systemId, string alarmId, string alarmType, string severity, string message, string longitude, string latitude);

        //event Action<string, string> AlarmFired;

        //event Action<string, string, int, int, string, double, double> AlarmFired2;
    }
}
