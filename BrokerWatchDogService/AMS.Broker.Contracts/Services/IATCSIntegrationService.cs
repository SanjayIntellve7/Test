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
    public interface IATCSIntegrationService
    {
        [OperationContract]
        List<string> GetCorridoreName(string Key, string authToken);

        [OperationContract]
        List<string> GetJunctionForCorridore(string Key, string CorridoreName, string authToken);

        [OperationContract]
        ATCSJunctionDetailsDto GetJuctionDetails(string Key, string CorridoreName, string junctionName, string authToken);

        [OperationContract]
        LaneStageSeqDetailsDTO GetLaneStageSeqDetails(string junctionName, string authToken);

        [OperationContract]
        bool SetModeForTheJunction(string Key, string JunctionName, string Mode, string authToken);

        [OperationContract]
        string getAVGEstimatedTravelTimeForCorridor(string Key, string CorridorName, string StrDate, string StartTime, string EndTime);


        [OperationContract]
        void StartAtcsStatusThread();

        [OperationContract]
        void StartAtcsAlertThread();

    }
}
