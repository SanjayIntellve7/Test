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
    public interface IAlertsCreationService
    {
        [OperationContract]
        Boolean SubmitNewAlert(string alert);

        [OperationContract]
        Boolean SubmitNewAlertDto(Alert alert);
        
        Boolean SubmitNewAlert(Alert alert);

        [OperationContract]
        long SubmitNewAlertMycs(Alert alert);

         [OperationContract]
        bool SubmitNewAlertEdgeAnalytics(Alert alert, byte[] managedArray);

        [OperationContract]
        bool CreatePAAlert(string strData,string authToken);

        [OperationContract]
        bool CreateMobileAlertNormal(string urgency, string severity, string certainty, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No);

        [OperationContract]
        bool CreateMobileAlertGeo(string urgency, string severity, string certainty, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No);


        [OperationContract]
        bool CreateDummySimulatorAlerts(string alertcode);

        [OperationContract]
        bool AnimateMapPin();
    
    }
}
