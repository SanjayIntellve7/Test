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
    public interface IEscalationMatrixServiceConfig
    {
        [OperationContract]
        string Test(string Data);  

        [OperationContract]
        IEnumerable<tblEscalationLevelMasterDTO> GetEscalationLevelList(string authToken);

        [OperationContract]
        IEnumerable<tblEscalationMatrixContactDTO> GetSelectedLevelContacts(int LevelID);

        [OperationContract]
        tblEscalationLevelMasterDTO SetLevelAction(tblEscalationLevelMasterDTO ActionData);

        [OperationContract]
        tblEscalationMatrixContactDTO SetLevelContact(tblEscalationMatrixContactDTO ContactData);

        [OperationContract]
        bool IsDeleteLevel(int LevelId);

        [OperationContract]
        bool DeleteLevel(int LevelId);

        [OperationContract]
        bool DeleteAction(int ActionId);

        [OperationContract]
        bool DeleteContact(int ContactId);

        [OperationContract]
        List<SiteDto> GetEntitySiteList(int EntityType);

    }
}
