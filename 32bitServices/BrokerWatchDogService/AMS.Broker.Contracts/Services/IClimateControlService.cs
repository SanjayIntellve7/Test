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
    public interface IClimateControlService
    {
        [OperationContract]
        string Test();

        [OperationContract]
        tblweatherchcurrentDTO GetCurrentClimateAlertData(string AlertID, string authToken);

        [OperationContract]
        IList<tblWeatherhourlyforecastDTO> GetForecastClimateAlertData(string AlertID, string authToken);

        [OperationContract]
        bool CreateClimateSimulatorAlert(string _threasholdDt);       

        [OperationContract]
        IEnumerable<tblweatherchcurrentDTO> GetAllCurrentWeather(string authToken);

        [OperationContract] //amit 23112016 need to merge in v1.5 
        tblweatherchcurrentDTO GetCurrentClimateAlertDataSimulator(string authToken);
        
    }
}
