using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IRadarTransactionService
    {
        [OperationContract]
        tblInterfaceSubRadarMasterDTO GetRadarInterfaceDetails(string InterfaceName);

        [OperationContract]
        void ConsumeRadarAlert(string Alertcode, string DeviceType, string EventType, string EventId, string RadarUID, double Lat, double _long);

        [OperationContract]
        void AddTransactionTrack(tblMagosTrackingDataDTO RadarTackingRada);
    }
}
