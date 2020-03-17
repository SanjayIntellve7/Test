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
    public interface IIclockACSTransactionService
    {
        [OperationContract(Name = "GetIclockACSControllerList")]
        List<AcsAlarmPanelDTO> GetIclockACSControllerList(); //amit 22052018

        [OperationContract(Name = "ConsumeIclockAcsAlert")]
        int ConsumeIclockAcsAlert(string ServerIP, string AlertType);       
    }   
}
