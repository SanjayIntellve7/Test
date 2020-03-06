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
        tblweatherchcurrentDTO GetCurrentClimateAlertData(string AlertID);

        [OperationContract]
        IList<tblWeatherhourlyforecastDTO> GetForecastClimateAlertData(string AlertID);

        [OperationContract]
        bool CreateClimateSimulatorAlert(string _threasholdDt);       

        [OperationContract]
        IEnumerable<tblweatherchcurrentDTO> GetAllCurrentWeather(string authToken);
        
    }
}
