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
    public interface IMirasysVideoAnalyticsService
    {
        //  bool ConsumVideoAnalytics(string strDevName, string strEventCode, string strAlarmDateTime);
        [OperationContract]
        bool ConsumVideoAnalytics(MirasysAlertData _MirasysAlertData);
    }
}
