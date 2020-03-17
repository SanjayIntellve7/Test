using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIDSPanelDVRAlertsIntegration
    {
        [OperationContract]
        int GenerateDVRAlert(string panelID, string EventCode, string ReceivedDateTime, string ChannelNo, int deviceId);
    }
}
