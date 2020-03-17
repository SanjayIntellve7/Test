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
    public interface IEscalationSetOperationService
    {
        [OperationContract]
        tblEscalationConfigMasterDTO SaveEscalationConfigMaster(tblEscalationConfigMasterDTO content, string AuthToken);

        // tblEscalationConfigMasterDTO SaveEscalationConfigMaster(tblEscalationConfigMasterDTO _Obj, string AuthToken);

        [OperationContract]
        bool DeleteEscalationConfigMaster(int id);
    }
}
