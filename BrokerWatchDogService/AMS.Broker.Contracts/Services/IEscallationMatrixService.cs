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
    public interface IEscallationMatrixService
    {
        [OperationContract]
        bool RemoveEscallation(long alertID);
        
        [OperationContract]
        void SetAlertEscallation(Alert alert);

        [OperationContract]
        List<tblEscalationConfigMasterDTO> GetEscalationConfigMasterDetails(string authtoken);//amit 15112019
    }
}
